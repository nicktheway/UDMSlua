local UE = CS.UnityEngine
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
--- TOARRANGE

	function groupFuns.grpGetRenderers(i)
		return renderers[i]
	end

	function groupFuns.grpSetFormation(frm)
			group:SetPositions(frm)
	end
	function groupFuns.grpSetNeighbors(nbr)
			group:SetNeighbours(nbr)
	end
	function groupFuns.grpSetStates(agents)
			group:SetState(agents)
	end
	
--------------------------------------------------------------------------------
--- FORMATIONS

	function groupFuns.frmMakeFormation(formation, N, ...)
		if formation=="circle" then
			local center=select(1,...)
			local radius=select(2,...)
			local angleOffset=select(3,...)
			return groupFuns.frmCirclePoints(N, center, radius, angleOffset)
		elseif formation=="ellipse" then
			local center=select(1,...)
			local a=select(2,...)
			local b=select(3,...)
			local angleOffset=select(4,...)
			return groupFuns.frmEllipsePoints(N, center, a, b, angleOffset)
		elseif formation=="line" then
			local start=select(1,...)
			local step=select(2,...)
			return groupFuns.frmLinePoints(N,start,step)
		elseif formation=="grid" then
			local columns=select(1,...)
			local topLeftPoint=select(2,...)
			local rowDistance=select(3,...)
			local colDistance=select(4,...)
			return groupFuns.frmGridPoints(N, columns, topLeftPoint, rowDistance, colDistance)
		elseif formation=="lissajous" then
			local ax=select(1,...)
			local wx=select(2,...)
			local az=select(3,...)
			local wz=select(4,...)
			local angleOffset=select(5,...)
			return groupFuns.frmLissajousPoints(N,ax,wx,az,wz,angleOffset)
		elseif formation=="nrose" then
			local center=select(1,...)
			local a=select(2,...)
			local K=select(3,...)
			local angleOffset=select(4,...)
			return groupFuns.frmCKRosePoints(N,center,a,K,angleOffset)
		else 
		end
	end

	function groupFuns.frmKrosePoints(N,center,a,K,angleOffset)
		if angleOffset == nil then
			angleOffset = 0
		end
		local da
		if math.fmod (K,2)==0 then
			da = 2.0  * math.pi / N
		else
			da = 1.0  * math.pi / N
		end
		local positions = {}
		local angle = math.rad(angleOffset)
		local rr
		for n = 1, N do
			rr=a*math.cos(K*angle)
			positions[n] = UE.Vector3(rr * math.cos(angle), 0, rr * math.sin(angle))+center
			angle = angle + da
		end
		return positions
	end
	function groupFuns.frmLissajousPoints(N,ax,wx,az,wz,angleOffset)
		if angleOffset == nil then
			angleOffset = 0
		end
		local dax = 2.0 * wx * math.pi / N
		local daz = 2.0 * wz * math.pi / N
		local positions = {}
		local anglex = math.rad(angleOffset)
		local anglez = math.rad(angleOffset)
		for n = 1, N do
			positions[n] = UE.Vector3(ax * math.cos(anglex), 0, az * math.sin(anglez))
			anglex = anglex + dax
			anglez = anglez + daz
		end
		return positions
	end

	function groupFuns.frmGridPoints(N, columns, topLeftPoint, rowDistance, colDistance)
		local currentRow = 0
		local currentCol = 0
		local positions = {}
		for i = 1, N do
			positions[i] = topLeftPoint - UE.Vector3(0, 0, currentRow * rowDistance) + UE.Vector3(currentCol * colDistance, 0, 0)
			currentCol = currentCol + 1
			if currentCol == columns then
				currentRow = currentRow + 1
				currentCol = 0
			end
		end
		return positions
	end

	function groupFuns.frmLinePoints(N,start,step)
		local positions = {}
		positions[1]=start
		for n = 2, N do
			positions[n] =positions[n-1]+step
		end
		return positions
	end

	function groupFuns.frmEllipsePoints(N, center, a, b, angleOffset)
		if angleOffset == nil then
			angleOffset = 0
		end
		local da = 2.0 * math.pi / N
		local positions = {}
		angle = math.rad(angleOffset)
		for n = 1, N do
			positions[n] = UE.Vector3(a * math.cos(angle), 0, b * math.sin(angle)) + center
			angle = angle + da
		end
		return positions
	end

	function groupFuns.frmCirclePoints(N, center, radius, angleOffset)
		if angleOffset == nil then
			angleOffset = 0
		end
		local da = 2.0 * math.pi / N
		local positions = {}
		angle = math.rad(angleOffset)
		for n = 1, N do
			positions[n] = UE.Vector3(radius * math.cos(angle), 0, radius * math.sin(angle)) + center
			angle = angle + da
		end
		return positions
	end

--------------------------------------------------------------------------------
--- GCA
	function groupFuns.gcaDefine(BirthConds,SurvConds,NrStates)
		return CS.LuaScripting.GCA(BirthConds,SurvConds,NrStates)
	end
	
	function groupFuns.gcaUpdate(group,gca,typ)
		if typ=="type1" then
			group:GCAUpdate(gca)
		elseif typ=="type2" then
			group:AdaptiveStateUpdate(gca)
		else
		end
	end

	function groupFuns.gcaMakeNbhd(nbhdType, N, ...)
		if nbhdType=="rel1" then
			local relArray=select(1,...)
			local wrap=select(2,...)
			return groupFuns.gcaRelativeNeighbours(N, relArray, wrap)
		elseif nbhdType=="rel2" then
			local n1=select(1,...)
			local relArray=select(2,...)
			local wrap=select(3,...)
			return groupFuns.gcaRelativeGridNeighbours(N, n1, relArray, wrap)
		elseif nbhdType=="filePath" then
			local fpath=select(1,...)
			return groupFuns.gcaFilePathNeighbours(N,fpath)
		elseif nbhdType=="distBased" then
		end
	end

	function groupFuns.gcaFilePathNeighbours(N, fpath)
		local file = io.open(fpath, 'r')
		--print(fpath, file)
		if file ~= nil then
			local nbrs = {}
			local counter = 1
			for line in file:lines() do
				nbrs[counter] = {}
				local nbrCounter = 1
				for nbr in line:gmatch("%d+") do
				   nbrs[counter][nbrCounter] = tonumber(nbr)
				   nbrCounter = nbrCounter + 1
				end
				
				if counter == N then break end
				counter = counter + 1
			end
			file:close()
			return nbrs
		else
			error('file not found')
		end
	end

	function groupFuns.gcaRelativeGridNeighbours(N, NC, relArray2, wrap)
		local nbrs = {}
		local NR = math.ceil(N/NC)
		local K = #relArray2
		for n = 0, N - 1 do
			local nc = n % NC
			local nr = math.floor(n / NC)
			nbrs[n+1] = {}
			local nbCounter = 1
			for k = 1, K do
				local ax = nc + relArray2[k][1]
				local ay = nr + relArray2[k][2]
				
				if wrap then
					ax = ax % NC
					ay = ay % NR
					local m = ay * NC + ax
					if m < N then
						nbrs[n+1][nbCounter] = m
						nbCounter = nbCounter + 1
					end
				else
					local m = ay * NC + ax
					if ax > -1 and ax < NC and ay > -1 and ay < NR and m < N then
						nbrs[n+1][nbCounter] = m
						nbCounter = nbCounter + 1
					end
				end
			end
		end
		return nbrs
	end

	function groupFuns.gcaRelativeNeighbours(n, relArray, wrap)
		if wrap == nil then
			wrap = true
		end
		local nbrs = {}
		if wrap then
			for i = 1, n do
				nbrs[i] = {}
				for j = 1, #relArray do
					nbrs[i][j] = (i - 1 + relArray[j] + n) % n
				end
			end
		else
			for i = 1, n do
				local nbsCounter = 1
				nbrs[i] = {}
				for j = 1, #relArray do
					local nbId = i - 1 + relArray[j]
					if nbId >= 0 and nbId < n then
						nbrs[i][nbsCounter] = nbId
						nbsCounter = nbsCounter + 1
					end
				end
			end
		end
		return nbrs
	end

--------------------------------------------------------------------------------
--- ANIMATIONS

	function groupFuns.setAnim(i,anim,transDur)
		anims[i]:CrossFade(anim,transDur)
	end

	function groupFuns.aniCrossFade(i,anim,transDur,rel)
		if not rel then anims[i]:CrossFadeInFixedTime(anim,transDur)
		else anims[i]:CrossFade(anim,transDur) end
	end
	
	function groupFuns.aniCrossFadeDiff(i,anim,transDur,rel)
		local currentAnim = groupFuns.aniGetClipName(i)
		if currentAnim ~= "" and currentAnim ~= anim then
			groupFuns.aniCrossFade(i,anim,transDur,rel)
		end
	end

	function groupFuns.aniGetAnimator(i)
		return anims[i]
	end

	function groupFuns.aniGetClipLength(i)
		local currentClipInfo = anims[i]:GetCurrentAnimatorClipInfo(0)
		return currentClipInfo[0].clip.length
	end
	

	function groupFuns.aniGetClipName(i)
		local currentClipInfo = anims[i]:GetCurrentAnimatorClipInfo(0)
		--return currentClipInfo[0].clip.name
		--
		if currentClipInfo.Length>0 then 
			return currentClipInfo[0].clip.name
		else 
			return "" 
		end
		--]]
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
	
	-- obsolete, do not use ...
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

	function groupFuns.getColor(i,j)
		if j==nil then j=0 end
		return renderers[i][j].material.color
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

	function groupFuns.getPosition(i)
		return group.Members[i]:GetPos()
	end

	function groupFuns.getPos(i)
		return group.Members[i].transform.position
	end
	
	function groupFuns.getPosOld(i)
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
	function groupFuns.turnToAngle1(i,targAng,dAng)
	-- Rotates calling Agent by dAng (in degrees) towards making his y Euler angle targAng.
		if(group.Members[i].transform.eulerAngles.y>targAng) then group.Members[i].transform:Rotate(-dAng*UE.Vector3(0,1,0)) end
		if(group.Members[i].transform.eulerAngles.y<targAng) then group.Members[i].transform:Rotate( dAng*UE.Vector3(0,1,0)) end
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

	function groupFuns.navAddSurface(ground)
		return UT.navAddSurface(ground)
	end

	function groupFuns.navBakeSurface(surface)
		UT.navBuildSurface(surface)
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
	
	function groupFuns.navGetDestination(i)
		return navs[i].destination
	end
	
	function groupFuns.navGetVelocity(i)
		return navs[i].velocity
	end
	
	function groupFuns.navSetDestination(i, point)
		navs[i].destination = point
	end
	
	function groupFuns.navSetSpeed(i, speed)
		navs[i].speed = speed
	end
	
	return groupFuns
end

return groupff
