local UE = CS.UnityEngine
local UT = require('utils')


function setUpDefaultCamera(luaCamera)
	local M = {}
	M.camOffSet=UE.Vector3(4,4,4)
	M.camTargPos=UE.Vector3(0,2,0)
	M.camPos=UE.Vector3(0,3,0)
	M.camRot=UE.Vector3(89.8,0,0)
	M.Hst=1.5
	M.Rst=1.5	
	local Nagn
	M.mainCamera = UE.Camera.main
	M.cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
	
	-- Private properties, use the provided setters/getters for modifying/accessing
	local targetGroup = nil
	local targetId = -1
	local previousTargetId = -1
	local targetOffset = UE.Vector3(0, 2, 0)
	
	function M.stateInit(state)
		if state == nil then state = luaCamera.State end
		
		if state == 1 then init01()	
		elseif state == 2 then init02()
		elseif state == 3 then init03()
		elseif state == 4 then init04()
		elseif state == 5 then init05()
		elseif state == 6 then init06()
		elseif state == 7 then
		elseif state == 8 then
		elseif state == 9 then
		elseif state == 10 then
		elseif state == 11 then	init11()		-- Camera moving on a custom track with the keyboard
		elseif state == 12 then init12()		-- Camera moving on a triangle above its target
		end
	end
	
	function M.stateUpdate(TIME, state)
		if state == nil then 
			state = luaCamera.State
			if luaCamera.State ~= luaCamera.StateOld then M.stateInit() end 
		end
	
		if state==1 then update01(TIME)
		elseif state == 2 then update02(TIME)
		elseif state == 3 then update03(TIME)
		elseif state == 4 then update04(TIME)
		elseif state == 5 then update05(TIME)
		elseif state == 6 then update06(TIME)
		elseif state == 7 then
		elseif state == 8 then
		elseif state == 9 then
		elseif state == 10 then
		elseif state == 11 then update11(TIME)
		elseif state == 12 then update12(TIME)
		end
	end
	
	-------------------------------------------------------------------------------
	----------------------------- State Functions ---------------------------------
	-------------------------------------------------------------------------------
	function init01()
		M.useCinemachine(true)
		luaCamera.ActiveCamera = "explorer"
	end
	
	function update01(TIME)
		-- Mouse camera that uses cinemachine and moves around a target or (0, 0, 0)
		cinemachineTargetUpdate()
	end
	
	function init02()
		M.useCinemachine(false)
	end
	
	function update02(TIME)
		if M.isCinemachineEnabled() then M.useCinemachine(false) end
		local a = M.mainCamera.transform.position
		local b = M.mainCamera.transform.eulerAngles
		if UE.Input.GetKey(UE.KeyCode.PageUp) 			then b.x = b.x+1
		elseif UE.Input.GetKey(UE.KeyCode.PageDown) 	then b.x = b.x-1
		elseif UE.Input.GetKey(UE.KeyCode.LeftArrow) 	then b.y = b.y-1
		elseif UE.Input.GetKey(UE.KeyCode.RightArrow) 	then b.y = b.y+1
		elseif UE.Input.GetKey(UE.KeyCode.Q) 			then a.y = a.y-0.1
		elseif UE.Input.GetKey(UE.KeyCode.E) 			then a.y = a.y+0.1
		elseif UE.Input.GetKey(UE.KeyCode.W) 			then a.z = a.z-0.1
		elseif UE.Input.GetKey(UE.KeyCode.S) 			then a.z = a.z+0.1
		elseif UE.Input.GetKey(UE.KeyCode.A) 			then a.x = a.x+0.1
		elseif UE.Input.GetKey(UE.KeyCode.D) 			then a.x = a.x-0.1
		end
		M.mainCamera.transform.position = a
		M.mainCamera.transform.eulerAngles = b
		if UE.Input.GetKey(UE.KeyCode.UpArrow) then
			M.mainCamera.transform:Translate( 0.1*UE.Vector3.forward)
		elseif UE.Input.GetKey(UE.KeyCode.DownArrow) then
			M.mainCamera.transform:Translate(-0.1*UE.Vector3.forward)
		end
	end

	function init03()
		M.useCinemachine(false)
	end

	function update03(TIME)
		if M.isCinemachineEnabled() then M.useCinemachine(false) end
		local i=M.getTarget()
		if i<0 or i>Nagn then M.camTargPos=UE.Vector3(0,2,0) 		
		else  M.camTargPos=targetGroup.Members[i].transform.position
		end
		M.camOffSet.x=0
		M.camOffSet.z=0
		M.camOffSet.y=math.max(0.10,M.camOffSet.y);		
		M.setPos(M.camTargPos+M.camOffSet)
		M.lookAt(M.camTargPos+UE.Vector3(0,1.3,0))
		if UE.Input.GetKey(UE.KeyCode.E) 		 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0.05,0) end
		if UE.Input.GetKey(UE.KeyCode.Q)		  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0.05,0) end 
		if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0.05,0) end
		if UE.Input.GetKey(UE.KeyCode.PageDown)  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0.05,0) end 
		if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then M.camOffSet=M.camOffSet+0.05*M.mainCamera.transform.forward end 
		if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then M.camOffSet=M.camOffSet-0.05*M.mainCamera.transform.forward end 
	end

	function init04()
		M.useCinemachine(false)
	end

	function update04(TIME)
		if M.isCinemachineEnabled() then M.useCinemachine(false) end
		local i=M.getTarget()
		if i<0 or i>Nagn then M.camTargPos=UE.Vector3(0,2,0) 		
		else  M.camTargPos=targetGroup.Members[i].transform.position
		end
		M.camOffSet.y=math.max(0.10,M.camOffSet.y);		
		M.setPos(M.camTargPos+M.camOffSet)
		--M.lookAt(M.camPos+UE.Vector3(0,1.3,0))
		M.setRot(UE.Vector3(89.8,0,0))
		if UE.Input.GetKey(UE.KeyCode.D) 		 	then M.camOffSet=M.camOffSet+UE.Vector3(0.05,0,0) end
		if UE.Input.GetKey(UE.KeyCode.A)		  	then M.camOffSet=M.camOffSet-UE.Vector3(0.05,0,0) end 
		if UE.Input.GetKey(UE.KeyCode.E) 		 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0.05,0) end
		if UE.Input.GetKey(UE.KeyCode.Q)		  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0.05,0) end 
		if UE.Input.GetKey(UE.KeyCode.W) 		 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0,0.05) end
		if UE.Input.GetKey(UE.KeyCode.S)		  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0,0.05) end 
		if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0.05,0) end
		if UE.Input.GetKey(UE.KeyCode.PageDown)  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0.05,0) end 
		if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then M.camOffSet=M.camOffSet+0.05*M.mainCamera.transform.forward end 
		if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then M.camOffSet=M.camOffSet-0.05*M.mainCamera.transform.forward end 
	end

	function init05()
		M.useCinemachine(false)
	end

	function update05(TIME)
		if M.isCinemachineEnabled() then M.useCinemachine(false) end
		local i=M.getTarget()
		if i>0 and i<Nagn then 
			M.camTargPos=targetGroup.Members[i].transform.position
			M.setPos(M.camTargPos+M.camOffSet)
			M.lookAt(M.camTargPos+UE.Vector3(0,1.3,0))
			local b = M.mainCamera.transform.eulerAngles
			if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then M.camOffSet=M.camOffSet+UE.Vector3(0,0.05,0) end
			if UE.Input.GetKey(UE.KeyCode.PageDown)  	then M.camOffSet=M.camOffSet-UE.Vector3(0,0.05,0) end 
			if UE.Input.GetKey(UE.KeyCode.LeftArrow) 	then b.y=b.y+1 end
			if UE.Input.GetKey(UE.KeyCode.RightArrow)	then b.y=b.y-1 end
			if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then M.camOffSet=M.camOffSet+0.05*M.mainCamera.transform.forward end 
			if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then M.camOffSet=M.camOffSet-0.05*M.mainCamera.transform.forward end 
			M.camOffSet.x=math.max(0.40,M.camOffSet.x);		
			M.camOffSet.y=math.max(0.10,M.camOffSet.y);		
			M.camOffSet.z=math.max(0.40,M.camOffSet.z);
			M.mainCamera.transform.eulerAngles = b
		end
	end

	function init06()
		M.useCinemachine(false)
	end
	function update06(TIME)
		if M.isCinemachineEnabled() then M.useCinemachine(false) end
		local i=M.getTarget()
	--	if i<0 and i<Nagn then M.camTargPos=UE.Vector3(0,2,0) 		
		if i>0 and i<Nagn then 
			M.camTargPos=targetGroup.Members[i].transform.position
			if UE.Input.GetKey(UE.KeyCode.PageUp) 	 then M.Hst=M.Hst+0.05 end
			if UE.Input.GetKey(UE.KeyCode.PageDown)  then M.Hst=M.Hst-0.05 end
			if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 then M.Rst=M.Rst-0.25 end
			if UE.Input.GetKey(UE.KeyCode.DownArrow) then M.Rst=M.Rst+0.25 end
			M.Hst=math.max(M.Hst,0.10);
			M.Rst=math.max(M.Rst,0.40);
			M.setPos(M.camTargPos+UE.Vector3(M.Rst*math.cos(0.3*UE.Time.time),M.Hst,M.Rst*math.sin(0.3*UE.Time.time)))
			M.lookAt(M.camTargPos+UE.Vector3(0,1.3,0))
		end
	end
	
	function init11()
		M.useCinemachine(true)
		M.setActiveCamera('dolly')
		-- Create a circle track if not already created.
		if not M.dollyPathExists('state11') then
			local yPos = 4
			local points = {UE.Vector3(1, yPos, 1), UE.Vector3(-1, yPos, 1), UE.Vector3(-1, yPos, -1), UE.Vector3(1, yPos, -1)}
			M.newSmoothDollyPath('state11', points)
		end
		
		-- Get closest position on the new dolly path.
		--[[
		local path = M.getDollyPath('state11')
		local closestPointPathUnits = path:FindClosestPoint(M.getPos())
		local closestPoint = path:FromPathNativeUnits(closestPointPathUnits, CS.Cinemachine.CinemachinePathBase.PositionUnits.Distance)
		print(closestPointPathUnits, ':', closestPoint)
		--]]
		
		-- Set the dolly path to the new circular one.
		M.setDollyPath('state11')
		
		-- Initialize position.
		--[[
		M.setPosOnPath(closestPoint)
		--]]
		
		-- Don't auto position the camera on the path based on the target.
		-- We will move the camera on the path manually.
		M.setAutoDolly(false)
		-- Initial path position (the points are offsetted by this)
		M.setPathPos(0, 0, 0)
		-- Will scale the points making the radius of the circle 8.
		M.setPathScale(8, 1, 8)
	end
	
	function update11()
		local speed = 0
		if UE.Input.GetKey(UE.KeyCode.LeftArrow) then
			speed = -10
		elseif UE.Input.GetKey(UE.KeyCode.RightArrow) then
			speed = 10
		end
		M.setPosOnPath(M.getPosOnPath() + speed*UE.Time.deltaTime)
	end
	
	function init12()
		M.useCinemachine(true)
		M.setActiveCamera('dolly')
		-- Create a triangle track if not already created.
		if not M.dollyPathExists('triangle1') then
			local points = {UE.Vector3(3, 2, 3), UE.Vector3(-3, 2, 3), UE.Vector3(-3, 2, -3)}
			M.newDollyPath('triangle1', points)
		end
		-- Set the current dolly path to the triangle one.
		M.setDollyPath('triangle1')
		-- Don't auto position the camera on the path based on the target.
		-- We will move the camera on the path manually.
		M.setAutoDolly(false)
		-- Initial path position (the points are offsetted by this)
		M.setPathPos(0, 0, -5)
		-- Initial path scale (the points' coordinates are scaled per axis by this)
		M.setPathScale(1, 1, 1)
	end
	
	function update12(TIME)
		if targetId ~= -1 then
			M.setPathScale(1, 1, 1)
			-- The path will move along with the target
			local x, y, z = UT.unpackVector3(targetGroup.Members[targetId].transform.position)
			M.setPathPos(x, y, z-1.5)
		else
			M.setPathScale(3, 1.5, 3) -- Scale the triangle on x-z plane.
			M.setPathPos(0, 0, -5)
		end
		-- Update the position of the camera on the path. (distance based, 0 is the first point on the path)
		local speed = 2 -- units/second
		M.setPosOnPath(luaCamera.PathPosition + UE.Time.deltaTime * speed)
	end

	-------------------------------------------------------------------------------
	-------------------------   Updates to LookAt target --------------------------
	-------------------------------------------------------------------------------
	function M.targetUpdate()
		if M.isCinemachineEnabled() then
			cinemachineTargetUpdate()
		else
			mainCameraTargetUpdate()
		end
	end
	
	function cinemachineTargetUpdate()
		if targetId ~= previousTargetId then
			if targetId ~= -1 then
				luaCamera:SetLookAtTarget(targetGroup.Members[targetId].transform, targetOffset)
			else
				luaCamera:SetLookAtTarget(nil, targetOffset)
			end
		end
	end
	
	function mainCameraTargetUpdate()
		if targetId ~= -1 then
			M.lookAt(targetGroup.Members[targetId].transform.position + targetOffset)
		end
	end
	
	-------------------------------------------------------------------------------
	---------------------------  KEYBOARD LISTENERS -------------------------------
	-------------------------------------------------------------------------------
	function M.updateStateFromKeyboard()
		local state = luaCamera.State
		if UE.Input.GetKeyUp(UE.KeyCode.F1) then state=1 -- free camera with mouse
		elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then state=2 -- free camera with KB and side view
		elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then state=3 -- free camera with KB and topdown view
		elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then state=4 -- fixed camera with side view, follow agent
		elseif UE.Input.GetKeyUp(UE.KeyCode.F5) then state=5
		elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then state=6
		elseif UE.Input.GetKeyUp(UE.KeyCode.F7) then state=7
		elseif UE.Input.GetKeyUp(UE.KeyCode.F8) then state=8
		elseif UE.Input.GetKeyUp(UE.KeyCode.F9) then state=9
		elseif UE.Input.GetKeyUp(UE.KeyCode.F10) then state=10   
		elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then state=11  
		elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then state=12  
		end
		
		luaCamera.State = state
	end

	function M.updateTargetFromKeyboard(targetsCount)
		if targetsCount == nil then
			if targetGroup == nil then
				targetsCount = 0
			else
				targetsCount = targetGroup.Members.Count
			end
		end
		local target = targetId
		if UE.Input.GetKey(UE.KeyCode.LeftShift) then
			if UE.Input.GetKeyUp(UE.KeyCode.Alpha1) then target = 0
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha2) then target = 1
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha3) then target = 2
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha4) then target = 3
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha5) then target = 4
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha6) then target = 5
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha7) then target = 6
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha8) then target = 7
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha9) then target = 8
			elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha0) then target = -1
			end
		end
		
		if target < targetsCount then 
			M.setTarget(target) 
		elseif targetId ~= -1 then
			M.setTarget(-1) 
		end
	end

	-------------------------------------------------------------------------------
	------------------- SETTERS/GETTERS: State, Target, FOV, CM -------------------
	-------------------------------------------------------------------------------
	function M.setState(state)
		luaCamera.State = state
	end
	
	function M.getState()
		return luaCamera.State
	end
	
	function M.getOldState()
		return luaCamera.StateOld
	end
	
	function M.setTargetGroup(room, groupName)
		targetGroup = room:GetGroupDomain(groupName)
		Nagn = targetGroup.Members.Count
	end
	
	function M.getTargetGroup()
		return targetGroup
	end
	
	function M.setTarget(newTargetId)
		previousTargetId = targetId
		targetId = newTargetId
	end
	
	function M.getTarget()
		return targetId
	end
	
	function M.setTargetOffset(offset)
		targetOffset = offset
		M.targetUpdate()
	end
	
	function M.getTargetOffset()
		return targetOffset
	end
	
	function M.setFOV(fov)
		luaCamera.FOV = fov
	end
	
	function M.getFOV()
		return luaCamera.FOV
	end
	
	function M.useCinemachine(use)
		M.cinemachineBrain.enabled = use
	end
	
	function M.isCinemachineEnabled()
		return M.cinemachineBrain.enabled
	end
	
	-------------------------------------------------------------------------------
	-------------------    NON CINEMACHINE FUNCTIONS     --------------------------
	-------------------------------------------------------------------------------
	function M.setPos(pos)
		M.mainCamera.transform.position = pos
	end
	
	function M.getPos()
		return M.mainCamera.transform.position
	end
	
	function M.setPosX(posX)
		M.mainCamera.transform.position.x = posX
	end
	
	function M.getPosX()
		return M.mainCamera.transform.position.x
	end
	
	function M.setRot(eulerAng)
		M.mainCamera.transform.eulerAngles = eulerAng
	end
	
	function M.getRot()
		return M.mainCamera.transform.eulerAngles
	end
	
	function M.setRotX(rotX)
		M.mainCamera.transform.eulerAngles.x = rotX
	end
	
	function M.getRotX()
		return M.mainCamera.transform.eulerAngles.x
	end
	
	function M.moveFwd(dist)
		M.mainCamera.transform:Translate(dist*UE.Vector3.forward)
	end
	
	function M.moveUp(dist)
		M.mainCamera.transform:Translate(dist*UE.Vector3.up)
	end
	
	function M.moveRight(dist)
		M.mainCamera.transform:Translate(dist*UE.Vector3.right)
	end
	
	function M.moveInDir(dir, dist)
		M.mainCamera.transform:Translate(dist*dir)
	end
	
	function M.turnToDir(dir, speed)
		local targetRot = UE.Quaternion.LookRotation(dir)
		M.mainCamera.transform.rotation = UE.Quaternion.Slerp(M.mainCamera.transform.rotation, targetRot, speed * UE.Time.deltaTime);
	end
	
	function M.lookAt(target)
		M.mainCamera.transform:LookAt(target)
	end
	
	-------------------------------------------------------------------------------
	----------------  CINEMACHINE: Set/Get currently active camera  ---------------
	-------------------------------------------------------------------------------
	function M.setActiveCamera(cameraName)
		luaCamera.ActiveCamera = cameraName
	end
	
	function M.getActiveCamera()
		return luaCamera.ActiveCamera
	end
	
	-------------------------------------------------------------------------------
	----------------  CINEMACHINE: Dolly camera related functions  ----------------
	-------------------------------------------------------------------------------
	function M.dollyPathExists(pathKey)
		return luaCamera:DollyPathKeyExists(pathKey)
	end
	
	function M.getDollyPath(pathKey)
		return luaCamera:GetDollyPath(pathKey)
	end
	
	function M.newDollyPath(pathName, waypoints, looped)
		if looped == nil then looped = true end
		luaCamera:NewDollyPath(pathName, waypoints, looped)
	end
	
	function M.newSmoothDollyPath(pathName, waypoints, looped)
		if looped == nil then looped = true end
		luaCamera:NewSmoothDollyPath(pathName, waypoints, looped)
	end

	function M.setAutoDolly(auto)
		luaCamera.AutoDolly = auto
	end
	
	function M.setDollyPath(pathName)
		luaCamera.DollyPath = pathName
	end
	
	function M.setPosOnPath(pos)
		luaCamera.PathPosition = pos
	end
	
	function M.getPosOnPath()
		return luaCamera.PathPosition
	end
	
	function M.setPathPos(x, y, z)
		luaCamera:SetDollyPathPosition(x, y, z)
	end
	
	function M.setPathScale(x, y, z)
		luaCamera:SetDollyPathScale(x, y, z)
	end
	----------------------------------- END -----------------------------------------
	
	return M
end

return setUpDefaultCamera
