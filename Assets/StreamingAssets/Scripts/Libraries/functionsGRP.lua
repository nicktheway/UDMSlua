local UE = CS.UnityEngine
local UT = require('utils')

function groupff(group)

--------------------------------------------------------------------------------
--- PREAMBLE

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
	
--------------------------------------------------------------------------------
--- GCA

--------------------------------------------------------------------------------
--- ANIMATIONS

	function groupFuns.setAnim(i,anim,transDur)
		anims[i]:CrossFade(anim,transDur)
	end

	function groupFuns.aniCrossFade(i,anim,transDur,rel)
		anims[i]:CrossFade(anim,transDur)
	end
	
	function groupFuns.aniGetClipLength(i)
		local currentClipInfo = anims[i]:GetCurrentAnimatorClipInfo(0)
		return currentClipInfo[0].clip.length
	end
	

	function groupFuns.aniGetClipName(i)
		local currentClipInfo = anims[i]:GetCurrentAnimatorClipInfo(0)
		return currentClipInfo[0].clip.name
	end
	

	function groupFuns.aniGetClipSpeed(i)
		return anims[i].speed
	end
	

	function groupFuns.aniGetClipSpeedMultiplier(i)
		return anims[i].speedMultiplier
	end
	
	function groupFuns.aniGetClipTime(i,typ)
		-- when typ="rel" returns the % (0-1) of progress in current loop
		local timnorm = anims[i]:GetCurrentAnimatorStateInfo(0).normalizedTime
		local timint,timfrac = math.modf(timnorm)
		local length=groupFuns.aniGetClipLength(i)
		if typ=="rel" then return timfrac 
		else return timfrac*length end
	end
	
	function groupFuns.aniGetSpeed(i)
		return anims[i]:GetCurrentAnimatorStateInfo(0).speed
	end

	function groupFuns.aniSetClipSpeed(i,v)
		anims[i].speed=v
	end
	
	function groupFuns.aniSetClipSpeedMultiplier(i,v)
		anims[i].speedMultiplier=v
	end
	
	function groupFuns.aniSetRootMotion(i,rootMotion)
		anims[i].applyRootMotion=rootMotion
	end
	
	function groupFuns.aniSetStabFeet(i,stabFeet)
		anims[i].stabilizeFeet=stabFeet
	end
	
--------------------------------------------------------------------------------
--- INVERSE KINEMATICS

	function groupFuns.ikSetLookAtObject(i,go)
		anims[i]:ikSetLookAtPosition(go.transform.position);
	end

	function groupFuns.ikSetLookAtAgent(i,j)
		anims[i]:SetLookAtPosition(group.Members[j].transform.position);
	end

	function groupFuns.ikSetLookAtPnt(i,pnt)
		anims[i]:SetLookAtPosition(pnt);
	end

	function groupFuns.ikSetLookAtWeight(i,ikWeight)
		anims[i]:SetLookAtWeight(ikWeight);
	end

	function groupFuns.ikSetPosObject(i,ikGoal,ikTarget)
		if ikGoal=="LH" then anims[i]:SetIKPosition(UE.AvatarIKGoal.LeftHand,ikTarget.transform.position)
		elseif ikGoal=="RH" then anims[i]:SetIKPosition(UE.AvatarIKGoal.RightHand,ikTarget.transform.position)
		elseif ikGoal=="LF" then anims[i]:SetIKPosition(UE.AvatarIKGoal.LeftFoot,ikTarget.transform.position)
		elseif ikGoal=="RF" then anims[i]:SetIKPosition(UE.AvatarIKGoal.RightFoot,ikTarget.transform.position)
		end
	end

	function groupFuns.ikSetPosVec(i,ikGoal,Pnt)
		if ikGoal=="BD" then anims[i].bodyPosition=ikTarget
		elseif ikGoal=="LH" then anims[i]:SetIKPosition(AvatarIKGoal.LeftHand,ikTarget)
		elseif ikGoal=="RH" then anims[i]:SetIKPosition(AvatarIKGoal.RightHand,ikTarget)
		elseif ikGoal=="LF" then anims[i]:SetIKPosition(AvatarIKGoal.LeftFoot,ikTarget)
		elseif ikGoal=="RF" then anims[i]:SetIKPosition(AvatarIKGoal.RightFoot,ikTarget)
		end
	end

	function groupFuns.ikSetPosWeight(i,ikGoal,ikWeight)
		if ikGoal=="LH" then anims[i]:SetIKPositionWeight(AvatarIKGoal.LeftHand,ikWeight)
		elseif ikGoal=="RH" then anims[i]:SetIKPositionWeight(AvatarIKGoal.RightHand,ikWeight)
		elseif ikGoal=="LF" then anims[i]:SetIKPositionWeight(AvatarIKGoal.LeftFoot,ikWeight)
		elseif ikGoal=="RF" then anims[i]:SetIKPositionWeight(AvatarIKGoal.RightFoot,ikWeight)
		end
	end

	function groupFuns.ikSetRot(i,ikGoal,ikTarget)
		if ikGoal=="LH" then anims[i]:SetIKRotation(AvatarIKGoal.LeftHand,ikTarget.transform.rotation)
		elseif ikGoal=="RH" then anims[i]:SetIKRotation(AvatarIKGoal.RightHand,ikTarget.transform.rotation)
		elseif ikGoal=="LF" then anims[i]:SetIKRotation(AvatarIKGoal.LeftFoot,ikTarget.transform.rotation)
		elseif ikGoal=="RF" then anims[i]:SetIKRotation(AvatarIKGoal.RightFoot,ikTarget.transform.rotation)
		end
	end

	function groupFuns.ikSetRotWeight(i,ikGoal,ikWeight)
	--Sets the ikGoal limb (options: "LH","RH","LF","RF") target rotation weight to be ikWeight.
		if ikGoal=="LH" then anims[i]:SetIKRotationWeight(AvatarIKGoal.LeftHand,ikWeight)
		elseif ikGoal=="RH" then anims[i]:SetIKRotationWeight(AvatarIKGoal.RightHand,ikWeight)
		elseif ikGoal=="LF" then anims[i]:SetIKRotationWeight(AvatarIKGoal.LeftFoot,ikWeight)
		elseif ikGoal=="RF" then anims[i]:SetIKRotationWeight(AvatarIKGoal.RightFoot,ikWeight)
		end
	end

--------------------------------------------------------------------------------
--- TRAILS
	
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

	function groupFuns.trailAttach(i,offset,color,tim,width)
		local go=UE.GameObject("Trail")
		go.transform.parent=group.Members[i].transform 
		go.transform.position=group.Members[i].transform.position+offset
		trail = UT.attachTrailRenderer(go)
		trail.startColor = color
		trail.endColor = color
		trail.time = tim
		trail.startWidth = width
		trail.endWidth = width
		return trailRenderers[i]
	end
	
	function groupFuns.trailGetEndColor(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail.endColor
	end

	function groupFuns.trailGetEndWidth(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail.endWidth
	end

	function groupFuns.trailGetStartColor(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail.startColor
	end

	function groupFuns.trailGetStartWidth(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail.startWidth
	end
	
	function groupFuns.trailGetTime(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail.time
	end

	function groupFuns.trailGetTrail(i)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		return trail
	end

	function groupFuns.trailSetEndColor(i,color)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		--if not trail==nil then trail.endColor=color end
		trail.endColor=color
	end
	
	function groupFuns.trailSetEndWidth(i,width)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		--if not trail==nil then trail.endWidth=width end
		trail.endWidth=width
	end

	function groupFuns.trailSetStartColor(i,color)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		--if not trail==nil then trail.startColor=color end
		trail.startColor=color
	end
	
	function groupFuns.trailSetStartWidth(i,width)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		--if not trail==nil then trail.startWidth=width end
		trail.startWidth=width
	end

	function groupFuns.trailSetTime(i,tim)
		local trail=group.Members[i]:GetComponentInChildren(typeof(UE.TrailRenderer))
		--if not trail==nil then trail.time=tim end
		trail.time=tim
	end
--------------------------------------------------------------------------------
--- GROUP AND GROUP MEMBERS

	function groupFuns.addMember(name,folder)
		return group:AddMember(name,folder)
	end

	function groupFuns.dirAgentToPnt(i,point)
		return group.Members[i]:DirAgentToPnt(point)
	end
	
	function groupFuns.dirAttractRepel(i,j,dist)
		return group.Members[i]:DirAttractRepel(j,dist)
	end

	function groupFuns.dirAvoidAgent(i,j)
		return group.Members[i]:DirAvoidAgent(j)
	end

	function groupFuns.dirAvoidNearestAgent(i)
		return group.Members[i]:DirAvoidDirAvoidNearestAgentAgent()
	end

	function groupFuns.dirMine(i)
		return group.Members[i]:DirMine()
	end
	
	function groupFuns.dirOfAgent(i)
		return group:DirOfAgent(i)
	end

	function groupFuns.dirOfNearest(i)
		return group.Members[i]:DirOfNearest()
	end

	function groupFuns.dirStayInDisc(i,radius)
		return group.Members[i]:DirStayInDisc(radius)
	end

	function groupFuns.dirToAgent(i,j)
		return group.Members[i]:DirToAgent(j)
	end

	function groupFuns.dirToHood(i,radius)
		return group.Members[i]:DirToHood(radius)
	end

	function groupFuns.dirToNearest(i)
		return group.Members[i]:DirToNearest()
	end

	function groupFuns.dirToNearestActive(i)
		return group.Members[i]:DirToNearestActive()
	end

	--?????????????????????????????????????????????
	function groupFuns.dirToNearestWithState(i,s)
		return group.Members[i]:DirToNearestActive()
	end

	function groupFuns.distAgentToPnt(i,point)
		return group.Members[i]:DistAgentToPnt(point)
	end

	function groupFuns.distOfAgents(i,j)
		return group:DistOfAgents(i,j)
	end

	function groupFuns.distToAgent(i,j)
		return group.Members[i]:DistToAgent(j)
	end

	function groupFuns.distToHood(i,radius)
		return group.Members[i]:DistToHood(radius)
	end

	function groupFuns.distToNearest(i)
		return group.Members[i]:DistToNearest()
	end

	function groupFuns.distToNearestActive(i)
		return group.Members[i]:DistToNearestActive()
	end

	function groupFuns.distTravelled(i)
		return group.Members[i]:DistTravelled()
	end

	function groupFuns.doScript()
		return group:DoScript()
	end

	--?????????????????????????????????????????
	function groupFuns.getAgentsInState(s)
	end

	function groupFuns.getAllComponents(i)
		return 	group.Members[i]:GetComponents(typeof(UE.Component))
	end

	function groupFuns.getAgentNearest(i)
		return group.Members[i]:GetAgentNearest()
	end

	function groupFuns.getDisplacement(i)
		return group.Members[i]:Displacement()
	end

	function groupFuns.getDist()
		return group.Dist
	end

	function groupFuns.getDomainName()
		return group.DomainName
	end

	function groupFuns.getEulerAngles(i)
		return group.Members[i].transform.eulerAngles
	end
	
	function groupFuns.getEulerAnglesOld(i)
		return group.Members[i].EulerAnglesOld
	end
	
	function groupFuns.getGroupCenter()
		return group:GetGroupCenter()
	end

	function groupFuns.getMemberIdsInCircle(center,radius)
		return group:GetMemberIdsInCircle(center, radius)
	end

	function groupFuns.getMembers()
		return group.Members
	end

	function groupFuns.getNearestAgentWithState(position,state)
		return group:GetNearestAgentWithState(position,state)
	end

	function groupFuns.getNearestActive(i)
		return group.Members[i]:GetNearestActive()
	end

	function groupFuns.getNeighbours(i)
		return group.Members[i].Neighbours
	end

	--?????????????????????????????????????????
	function groupFuns.getNumAgentsInState(s)
	end

	function groupFuns.getPos(i)
		return group.Members[i]:GetPos()
	end

	function groupFuns.getPosition(i)
		return group.Members[i].transform.position
	end
	
	function groupFuns.getPositionOld(i)
		return group.Members[i].PositionOld
	end
	
	function groupFuns.getRot(i)
		return group.Members[i]:GetAngles()
	end

	function groupFuns.getState(i)
		return group.Members[i].State
	end
	
	function groupFuns.getStateOld(i)
		return group.Members[i].StateOld
	end
	
	function groupFuns.getTurnToMoveDir(i)
		return group.Members[i].TurnToMoveDir
	end
	
	function groupFuns.goToAgent(i,j,dist)
		group.Members[i]:GoToAgent(i,j,dist)
	end

	function groupFuns.goToCenter(i,dist)
		group.Members[i]:GoToCentert(dist)
	end

	function groupFuns.goToPoint(i,point,dist)
		group.Members[i]:GoToPoint(point,dist)
	end

	function groupFuns.highlightNeigbours(i)
		return group:HighlightNeigbours(i)
	end

	function groupFuns.isActive(i)
		return group.Members[i].IsActive
	end

	function groupFuns.moveFwd(i,dist)
		group.Members[i]:MoveFwd(dist)
	end

	function groupFuns.moveInDir(i,dir,dist,normalized)
		group.Members[i]:MoveInDir(dir,dist,normalized)
	end

	function groupFuns.moveRight(i,dist)
		group.Members[i]:MoveRight(dist)
	end

	function groupFuns.moveUp(i,dist)
		group.Members[i]:MoveUp(dist)
	end

	function groupFuns.registerGridNeighbours(N1)
		return group:RegisterGridNeighbours(N1)
	end

	function groupFuns.setColor(i,color,j)
		if j==nil then j=0 end
		renderers[i][j].material.color=color 
	end

	function groupFuns.setColorState(i,bool)
		group.Members[i].ColorState = bool
	end
	
	function groupFuns.setDir(i,dir)
		group.Members[i]:SetDir(dir)
	end
	
	function groupFuns.setNeighbours(i,nbrs)
		group.Members[i]:SetNeighbours(nbrs)
	end

	function groupFuns.setPos(i,pos)
		group.Members[i].transform.position = pos
	end

	function groupFuns.setPosX(i,xpos)
		group.Members[i]:SetPosX(xpos)
	end
	
	function groupFuns.setPosY(i,ypos)
		group.Members[i]:SetPosY(ypos)
	end
	
	function groupFuns.setPosZ(i,zpos)
		group.Members[i]:SetPosZ(zpos)
	end
	
	function groupFuns.setRot(i,rot)
		group.Members[i].transform.eulerAngles =rot
	end
	
	function groupFuns.setRotX(i,xrot)
		group.Members[i]:SetRotX(xrot)
	end
	
	function groupFuns.setRotY(i,yrot)
		group.Members[i]:SetRotY(yrot)
	end
	
	function groupFuns.setRotZ(i,zrot)
		group.Members[i]:SetRotZ(zrot)
	end
	
	function groupFuns.setScale(i,scale)
		group.Members[i]:SetScale(scale)
	end
	
	function groupFuns.setState(i,s)
		group.Members[i].State=s
	end

	function groupFuns.setTurnToMoveDir(i,turn)
		group.Members[i].TurnToMoveDir=turn
	end

	function groupFuns.toGridFormation(N1,center,rowDist,colDist)
		local N2=math.ceil(Members.Count/N1)
		local topLeftPoint=center+UE.Vector3(N1*rowDist/2,0,N2*colDist/2)
		return group:ToGridFormation(N1,topLeftPoint,rowDist,colDist)
	end

	function groupFuns.toggleIndices(toggle)
		return group:ToggleIndices(toggle)
	end

	--?????????????????????????????????????????
	function groupFuns.turnByDir(i,dir,wr)
	-- Rotates with speed wr the calling Agent towards the direction vector Dir1.
		local ang0 = group.Members[i].transform.eulerAngles.y
		local dir0 = UE.Vector3(math.cos(ang0),0,math.sin(ang0))
		local dir1 = dir/math.sqrt(dir.x^2+dir.z^2)
		local dir2 = dir0+dir1
		group.Members[i]:TurnToDirSoft(dir2,wr)
	end

	function groupFuns.turnFwd(i,a)
	-- Rotates calling Agent a degrees around z axis.
		--group.Members[i].transform:Rotate(a*UE.Vector3.forward)
		group.Members[i].transform:Rotate(a*UE.Vector3(1,0,0))
	end

	--?????????????????????????????????????????
	function groupFuns.turnRght(i,a)
	-- Rotates calling Agent a degrees around x axis.
		--group.Members[i].transform:Rotate(a*UE.Vector3.right)
		group.Members[i].transform:Rotate(a*UE.Vector3(0,1,0))

	end

	--?????????????????????????????????????????
	function groupFuns.turnToAgent(i,j,wr)
	-- Rotates the calling Agent to the direction of Agents[n1] with angular speed wr (per update).
		local point=group.Members[j].transform.position
		local meRot=group.Members[i].transform.rotation
		local trgRot = UE.Quaternion.LookRotation(point);
		group.Members[i].transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
	end

	function groupFuns.turnToAngle(i,targetAngle,degrees)
		group.Members[i]:TurnToAngle(targetAngle,degrees)
	end

	--?????????????????????????????????????????
	function groupFuns.turnToAngle(i,targAng,dAng)
	-- Rotates calling Agent by dAng (in degrees) towards making his y Euler angle targAng.
		if(group.Members[i].transform.eulerAngles.y>targAng) then group.Members[i].transform:Rotate(-dAng*Vector3(0,1,0)) end
		if(group.Members[i].transform.eulerAngles.y<targAng) then group.Members[i].transform:Rotate( dAng*Vector3(0,1,0)) end
	end

	function groupFuns.turnToDir(i,dir,speed)
		group.Members[i]:TurnToDir(dir,speed)
	end

	function groupFuns.turnToDirSoft(i,dir,speed)
		group.Members[i]:TurnToDirSoft(dir,speed)
	end

	--?????????????????????????????????????????
	function groupFuns.turnToMoveDir(i,wr)
	-- Rotates calling Agent to the Agent’s move direction. Turn angular speed is wr (per update)
		local meRot=group.Members[i].transform.rotation
		local d=group.Members[i]:Displacement()
		local a=math.atan(d.x,d.z)*180/3.14159;
		local trgRot = UE.Quaternion.Euler(0,a,0);
		group.Members[i].transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
	end

	--?????????????????????????????????????????
	function groupFuns.turnToPnt(i,point,wr)
	-- Rotates calling Agent towards point Pnt. Turn angular speed is wr (per update).
		local meRot=group.Members[i].transform.rotation
		local trgRot = UE.Quaternion.LookRotation(point);
		group.Members[i].transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
	end

	--?????????????????????????????????????????
	function groupFuns.turnUp(i,a)
	-- Rotates calling Agent a degrees around y axis.
		--group.Members[i].transform:Rotate(a*UE.Vector3.up)
		group.Members[i].transform:Rotate(a*UE.Vector3(0,0,1))
	end

	function groupFuns.updateStates(rule,...)
	end

--------------------------------------------------------------------------------
--- NAVIGATION

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
	
	return groupFuns
end

return groupff
