local UE = CS.UnityEngine
local UT = require('utils')

function groupff(group)
	local groupFuns = {}
	local anims = {}
	local renderers = {}
	local trailRenderers = {}
	local navs = {}
	local Nagn = group.Members.Count
	
	for i = 0, Nagn - 1 do
		anims[i] = group.Members[i]:GetComponent(typeof(UE.Animator))
		renderers[i] = group.Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
	end
	
	function groupFuns.attachTrail(i, color, aliveTime, width)
		if trailRenderers[i] == nil then
			trailRenderers[i] = UT.attachTrailRenderer(group.Members[i].gameObject)
		end
		trailRenderers[i].startColor = color
		trailRenderers[i].endColor = color
		trailRenderers[i].time = aliveTime
		trailRenderers[i].startWidth = width
		trailRenderers[i].endWidth = width
		return trailRenderers[i]
	end
	
	function groupFuns.navToAgent(i,j)
		navs[i].destination = group.Members[j].transform.position
	end

	function groupFuns.navToPoint(i,point)
		navs[i].destination = point
	end
	
	function groupFuns.navAttachAgent(i)
		if navs[i] == nil then
			navs[i] = group.Members[i].gameObject:AddComponent(typeof(UE.AI.NavMeshAgent))
		end
		return navs[i]
	end
	
	function groupFuns.navActive(i, status)
		navs[i].isStopped = not status
	end
	
	function groupFuns.navSetDestination(i, point)
		navs[i].destination = point
	end
	
	function groupFuns.navGetDestination(i)
		return navs[i].destination
	end
	
	function groupFuns.navSetSpeed(i, speed)
		navs[i].speed = speed
	end
	
	function groupFuns.dirToAgent(i,j)
		return group.Members[i]:DirToAgent(j)
	end

	function groupFuns.moveInDir(i,dir,speed,normalized)
		group.Members[i]:MoveInDir(dir,speed,normalized)
	end

	function groupFuns.setNeighbours(i,nbrs)
		group.Members[i]:SetNeighbours(nbrs)
	end

	function groupFuns.setPos(i, pos)
		group.Members[i].transform.position = pos
	end
	
	function groupFuns.setRot(i, eulerAngles)
		group.Members[i].transform.eulerAngles = eulerAngles
	end
	
	function groupFuns.setState(i, state)
		group.Members[i].State = state
	end
	
	function groupFuns.setAnim(i, anim, transitionDuration)
		anims[i]:CrossFade(anim, transitionDuration)
	end
	
	function groupFuns.setColor(i,color,j)
		if j==nil then j=0 end
		renderers[i][j].material.color=color 
	end
	
	function groupFuns.setTurnToMoveDir(i,turn)
		group.Members[i].TurnToMoveDir=turn
	end

	return groupFuns
end


return groupff