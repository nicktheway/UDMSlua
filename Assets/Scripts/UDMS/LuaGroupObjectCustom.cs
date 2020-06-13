using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using XLua;

namespace LuaScripting
{
    /// <summary>
    /// The part of LuaGroupObject for holding custom UDMS functions.
    /// </summary>
    public partial class LuaGroupObject : LuaGameObject
    {
        // TODO: to be removed. no need for this function.
        public void SetState(int value)
        {
            State = value;
        }

        public int GetAgentNearest()
        {
            var length = _luaGroupScript.Members.Count;
            var minDistance = double.MaxValue;
            var nearestId = -1;
            for (var i = 0; i < length; i++)
            {
                if (i != GroupMemberId && _luaGroupScript.Dist[GroupMemberId, i] < minDistance)
                {
                    minDistance = _luaGroupScript.Dist[GroupMemberId, i];
                    nearestId = i;
                }
            }

            return nearestId;
        }

        public Vector3 DirAttractRepel(int agentId, float distance)
        {
            Debug.Assert(agentId >= 0 && agentId < _luaGroupScript.Members.Count);
            var diff = transform.position - _luaGroupScript.Members[agentId].transform.position;

            if (Vector3.Magnitude(diff) > distance)
            {
                diff = -diff;
            }
            return Vector3.Normalize(diff);
        }
        
        public Vector3 DirAvoidAgent(int agentId)
        {
            Debug.Assert(agentId >= 0 && agentId < _luaGroupScript.Members.Count);
            var diff = transform.position - _luaGroupScript.Members[agentId].transform.position;
            return Vector3.Normalize(diff);
        }

        public Vector3 DirAvoidNearestAgent()
        {
            var id = GetAgentNearest();

            return DirAvoidAgent(id);
        }

        public Vector3 DirOfNearest()
        {
            var id = GetAgentNearest();

            return _luaGroupScript.DirOfAgent(id);
        }

        public Vector3 DirToAgent(int agentId)
        {
            Debug.Assert(agentId >= 0 && agentId < _luaGroupScript.Members.Count);

            var dir = _luaGroupScript.Members[agentId].transform.position - transform.position;

            return Vector3.Normalize(dir);
        }

        public Vector3 DirToHood(float radius)
        {
            var hoodCenter = _luaGroupScript.GetHoodCenter(transform.position, radius);
            return Vector3.Normalize(hoodCenter - transform.position);
        }

        public Vector3 DirToNearest()
        {
            var id = GetAgentNearest();

            return DirToAgent(id);
        }

        public int GetNearestActive()
        {
            var minDist = float.MaxValue;
            var minId = -1;
            for (var i = 0; i < _luaGroupScript.Members.Count; i++)
            {
                var dist = Vector3.SqrMagnitude(_luaGroupScript.Members[i].transform.position - transform.position);
                if (i != GroupMemberId && _luaGroupScript.Members[i].State == 1 && dist < minDist) 
                {
                    minDist = dist;
                    minId = i;
                }
            }
            return minId;
        }

        public Vector3 DirToNearestActive()
        {
            var id = GetNearestActive();
            if (id >= 0)
            {
                return DirToAgent(id);
            }
            return Vector3.zero;
        }

        public float DistAgentToPnt(Vector3 point)
        {
            return Vector3.Distance(transform.position, point);
        }

        public float DistToAgent(int agentId)
        {
            Debug.Assert(agentId >= 0 && agentId < _luaGroupScript.Members.Count);

            return Vector3.Distance(_luaGroupScript.Members[agentId].transform.position, transform.position);
        }

        public float DistToHood(float radius)
        {
            var hoodCenter = _luaGroupScript.GetHoodCenter(transform.position, radius);
            return Vector3.Distance(transform.position, hoodCenter);
        }

        public float DistToNearest()
        {
            var id = GetAgentNearest();
            return DistToAgent(id);
        }

        public float DistToNearestActive()
        {
            var id = GetNearestActive();
            if (id >= 0)
            {
                return DistToAgent(id);
            }
            return float.MaxValue;
        }

        public Vector3 GetHoodCenter(float radius)
        {
            return _luaGroupScript.GetHoodCenter(transform.position, radius);
        }
    }
}