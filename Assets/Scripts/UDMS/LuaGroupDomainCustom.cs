using System.Collections.Generic;
using UnityEngine;


namespace LuaScripting
{
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

        private void UpdateDistanceTable()
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
    }
}
