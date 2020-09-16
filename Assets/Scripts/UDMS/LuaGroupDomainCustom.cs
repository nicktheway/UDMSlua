using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using XLua;

namespace LuaScripting
{
	[LuaCallCSharp]
    [GCOptimize]
	public struct GCA
	{
		public int[] BirthConditions;
		public int[] SurviveConditions;
		public int NumberOfStates;
		
		public GCA(int[] birthConditions, int[] surviveConditions, int numberOfStates)
		{
			BirthConditions = birthConditions;
			SurviveConditions = surviveConditions;
			NumberOfStates = numberOfStates;
		}
	}

    [LuaCallCSharp]
    [GCOptimize]
    public struct InfectionInfo
    {
        public float InfectRate;
        public float HealRate;

        public InfectionInfo(float infectRate, float healRate)
        {
            InfectRate = infectRate;
            HealRate = healRate;
        }
    }

    [LuaCallCSharp]
    [GCOptimize]
    public struct DistUpdateInfo
    {
        public int NumberOfStates;
        public float Threshold;
        public float QuadraticCoefficient;
        public float LinearCoefficient;
        public float Constant;

        public DistUpdateInfo(int numberOfStates, float threshold, float quadraticCoefficient, float linearCoefficient, float constant)
        {
            NumberOfStates = numberOfStates;
            Threshold = threshold;
            QuadraticCoefficient = quadraticCoefficient;
            LinearCoefficient = linearCoefficient;
            Constant = constant;
        }
    }
	
    public partial class LuaGroupDomain : LuaDomain
    {
        private bool _distTableUpdated;
        private float[,] _dist;
        public float[,] Dist
        {
            get
            {
                if (!_distTableUpdated) UpdateDistanceTable();
                return _dist;
            }
        }

        public override void BeforeUpdateActions()
        {
            foreach (var member in Members)
            {
                member.BeforeUpdateActions();
            }
        }

        public override void AfterLateUpdateActions()
        {
            _distTableUpdated = false;

            foreach (var member in Members)
            {
                member.AfterLateUpdateActions();
            }
        }

        public void UpdateDistanceTable()
        {
            var len = Members.Count;
            _dist = new float[len, len];
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < len; j++)
                {
                    _dist[i, j] = Vector3.Distance(Members[i].transform.position, Members[j].transform.position);
                }
            }
            _distTableUpdated = true;
        }

        public Vector3 GetGroupCenter()
        {
            if (Members.Count == 0) return Vector3.zero;

            var center = Vector3.zero;
            foreach (var member in Members)
            {
                center += member.transform.position;
            }

            return center / Members.Count;
        }

        /// <summary>
        /// Finds the center of the agents inside a circle.
        /// </summary>
        /// <param name="center">The center of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <returns></returns>
        public Vector3 GetHoodCenter(Vector3 center, float radius)
        {
            var hoodMemberCount = 0;
            var hoodCenter = Vector3.zero;

            foreach (var member in Members)
            {
                if (Vector3.SqrMagnitude(member.transform.position - center) <= radius * radius)
                {
                    hoodMemberCount++;
                    hoodCenter += member.transform.position;
                }
            }

            return hoodMemberCount > 0 ? hoodCenter / hoodMemberCount : hoodCenter;
        }

        /// <summary>
        /// Finds the agents inside a circle.
        /// </summary>
        /// <param name="center">The circle's center.</param>
        /// <param name="radius">The circle's radius.</param>
        /// <returns>A list of agent ids.</returns>
        public List<int> GetMemberIdsInCircle(Vector3 center, float radius)
        {
            var idsList = new List<int>();

            for (var i = 0; i < Members.Count; i++)
            {
                if (Vector3.SqrMagnitude(Members[i].transform.position - center) <= radius * radius)
                {
                    idsList.Add(i);
                }
            }

            return idsList;
        }

        /// <summary>
        /// Positions the group members to a grid.
        /// </summary>
        /// <param name="columns">The grid's columns.</param>
        /// <param name="topLeftPoint">The position of the top left agent in the grid.</param>
        /// <param name="rowDistance">The distance between two rows.</param>
        /// <param name="colDistance">The distance between two columns.</param>
        public void ToGridFormation(int columns, Vector3 topLeftPoint, float rowDistance, float colDistance)
        {
            if (columns <= 0)
            {
                Debug.LogError("Invalid columns parameter. Must be a positive integer.");
                return;
            }

            var currentRow = 0;
            var currentCol = 0;
            foreach(var member in Members) 
            {
                member.transform.position = topLeftPoint - currentRow * rowDistance * Vector3.forward + currentCol * colDistance * Vector3.right;
                currentCol++;
                if (currentCol == columns) {
                    currentCol = 0;
                    currentRow++;
                }
            }
        }

        /// <summary>
        /// Sets the state of the specified members to one. Reset all the others' to zero.
        /// </summary>
        /// <param name="activeIds">A list of the members' ids to set their state to 1.</param> 
        public void SetState(List<int> activeIds)
        {
            foreach(var member in Members)
            {
                member.State = 0;
            }
            foreach(var id in activeIds)
            {
                Members[id].State = 1;
            }
        }

        /// <summary>
        /// Sets up all the member's neighbours for a grid formation.
        /// </summary>
        /// <param name="columns">The grid's columns.</param>
        public void RegisterGridNeighbours(int gridColumns)
        {
            if (gridColumns <= 0) 
            {
                Debug.LogError("The number of columns must be positive.");
                return;
            }
            var maxId = Members.Count;
            var maxRow = maxId / gridColumns;

            for (var i = 0; i < maxId; i++)
            {
                Members[i].Neighbours = new List<int>(8);
                var row = i / gridColumns;
                var column = i % gridColumns;
                for (var k = -1; k < 2; k++) 
                {
                    var currentRow = row + k;
                    if (currentRow < 0 || currentRow > maxRow) continue;
                    for (var l = -1; l < 2; l++) 
                    {
                        var currentCol = column + l;
                        if (currentCol < 0 || currentCol >= gridColumns) continue;

                        var id = currentRow * gridColumns + currentCol;
                        if (id != i && id < maxId) Members[i].Neighbours.Add(id);
                    }
                }
            }
        }

        public void SetPositions(Vector3[] positions)
        {
            var givenPositionsCount = positions.Length;
            if (givenPositionsCount <= 0)
            {
                Debug.LogError("There must be at least one position inside the array parameter.");
            }
            var currentIndex = 0;
            foreach (var member in Members)
            {
                member.transform.position = positions[currentIndex];
                currentIndex = (currentIndex + 1) % givenPositionsCount;
            }
        }

        public void SetNeighbours(int[][] neighbours)
        {
            if (neighbours.Length != Members.Count)
            {
                Debug.LogError("An array of neighbour ids must be given foreach of the group members.");
            }

            for (var i = 0; i < Members.Count; i++)
            {
                Members[i].SetNeighbours(neighbours[i]);
            }
        }
		
		public void GCAUpdate(GCA gca)
		{
			var states = new List<int>(Members.Count);

			foreach (var member in Members)
			{
				states.Add(member.State);
			}

			foreach(var member in Members)
			{
				var activeNeigbours = 0;

                foreach (var id in member.Neighbours)
                {
                    if (states[id] != 0) 
                    {
                        activeNeigbours++;
                    }
                }

				if (member.State == 0)
                {
                    foreach (var t in gca.BirthConditions)
                    {
                        if (activeNeigbours == t) 
                        {
                            member.State = 1;
                            break;
                        }
                    }
                }
				else
                {
                    var survive = false;
                    foreach (var t in gca.SurviveConditions)
                    {
                        if (activeNeigbours == t)
                        {
                            survive = true;
                            break;
                        }
                    }
                    
					member.State = survive ? member.State : (member.State + 1) % gca.NumberOfStates;
				}
			}						
		}

        public void InfectionUpdate(InfectionInfo infectionInfo)
        {
            var infected = 0;
            foreach (var member in Members)
            {
                infected += member.State;
            }

            foreach (var member in Members)
            {
                if (member.State == 0)
                {
                    member.State = Random.value < infectionInfo.InfectRate * (1 - 1.0 / (infected + 1)) ? 1 : 0;
                }
                else
                {
                    member.State = Random.value < infectionInfo.HealRate * (1 - 1.0 / (infected + 1)) ? 0 : 1;
                }
            }
        }

        public void DistStateUpdate(DistUpdateInfo distUpdateInfo)
        {
            var states = new List<int>(Members.Count);

            foreach (var member in Members)
            {
                states.Add(member.State);
            }

            for (var i = 0; i < Members.Count; i++)
            {
                var totalInf = 0;
                for (var j = 0; j < Members.Count; j++)
                {
                    if (i != j && states[j] > 0)
                    {
                        totalInf += (distUpdateInfo.QuadraticCoefficient * _dist[i, j] * _dist[i, j] + distUpdateInfo.LinearCoefficient * _dist[i, j] + distUpdateInfo.Constant < 0) ? 1 : 0;
                    }
                }

                if (Members[i].State == 0)
                {
                    Members[i].State = totalInf > distUpdateInfo.Threshold ? 1 : 0;
                }
                else
                {
                    Members[i].State = (Members[i].State + 1) % distUpdateInfo.NumberOfStates;
                }
            }
        }

        public void UpdateStates(string algorithm, string algorithmData)
        {
            if (algorithm == "gameoflife") 
            {
                var sMatch = Regex.Match(algorithmData, @"S([0-9])+", RegexOptions.Compiled);
                var bMatch = Regex.Match(algorithmData, @"B([0-9])+", RegexOptions.Compiled);
                var surviveList = new List<int>();
                var bornList = new List<int>();
                if (sMatch.Groups.Count == 2) 
                {
                    foreach (Capture capture in sMatch.Groups[1].Captures)
                    {
                        surviveList.Add(int.Parse(capture.ToString()));
                    }
                }
                
                if (bMatch.Groups.Count == 2) 
                {
                    foreach (Capture capture in bMatch.Groups[1].Captures)
                    {
                        bornList.Add(int.Parse(capture.ToString()));
                    }
                }
                var states = new List<int>(Members.Count);
                foreach (var member in Members)
                {
                    states.Add(member.State);
                }
                foreach (var member in Members)
                {
                    var activeNeigbours = 0;
                    foreach (var id in member.Neighbours)
                    {
                        if (states[id] != 0) 
                        {
                            activeNeigbours++;
                        }
                    }
                    if (member.State == 0 && bornList.Contains(activeNeigbours))
                    {
                        member.State = 1;
                    }
                    else if (member.State == 1 && !surviveList.Contains(activeNeigbours))
                    {
                        member.State = 0;
                    }
                }
            }
            else
            {
                Debug.LogError("Not supported algorithm. Only 'gameoflife' is currently supported.");
            }
        }

        /// <summary>
        /// Shows/Hides the index of each member. Useful for debugging.
        /// </summary>
        /// <param name="show">Show the members' ids.</param>
        public void ToggleIndices(bool show)
        {
            foreach(var member in Members)
            {
                member.ToggleTextMeshObject(show);
                if (show) member.SetText(member.GroupMemberId.ToString());
            }
        }

        /// <summary>
        /// Highlights the neighbours of a specific group member.
        /// </summary>
        /// <param name="memberId">The member's id.</param>
        public void HighlightNeigbours(int memberId)
        {
            foreach(var member in Members)
            {
                member.ToggleTextMeshObject(true);
                member.TextMeshComponent.color = new Color(1, 1, 1);
            }

            foreach (var id in Members[memberId].Neighbours)
            {
                Members[id].TextMeshComponent.color = new Color(0, 1, 0);
            }
        }

        public Vector3 DirOfAgent(int agentId)
        {
            Debug.Assert(Members.Count > agentId && agentId >= 0);

            return Members[agentId].DirMine();
        }

        public int GetNearestAgentWithState(Vector3 position, int state)
        {
            var minDist = float.MaxValue;
            var minId = -1;
            for (var i = 0; i < Members.Count; i++)
            {
                if (Members[i].State != state) continue;

                var dist = Vector3.SqrMagnitude(Members[i].transform.position - position);
                if (dist < minDist) 
                {
                    minDist = dist;
                    minId = i;
                }
            }
            return minId;
        }

        public float DistOfAgents(int agentId1, int agentId2)
        {
            Debug.Assert(Members.Count > agentId1 && agentId1 >= 0);
            Debug.Assert(Members.Count > agentId2 && agentId2 >= 0);
            
            return Vector3.Distance(Members[agentId1].transform.position, Members[agentId2].transform.position);
        }
    }
}
