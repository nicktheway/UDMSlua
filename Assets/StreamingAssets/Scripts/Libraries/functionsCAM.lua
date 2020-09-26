local UE = CS.UnityEngine

function setUpDefaultCamera(luaCamera)
	local M = {}
	
	M.mainCamera = UE.Camera.main
	M.cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
	
	-- Private properties, use the provided setters/getters for modifying/accessing
	local targetGroup = nil
	local targetId = -1
	local previousTargetId = -1
	
	function M.stateInit(state)
		if state == nil then state = luaCamera.State end
		
		if state == 1 then							-- free camera with mouse
			M.cinemachineBrain.enabled = true
			luaCamera.ActiveCamera = "explorer"
		elseif state == 2 then						-- free camera with KB and side view
			M.cinemachineBrain.enabled = false
		elseif state == 3 then						-- free camera with KB and topdown view
			M.cinemachineBrain.enabled = false
		elseif state == 4 then						-- fixed camera with side view, follow agent
			M.cinemachineBrain.enabled = true
			luaCamera.ActiveCamera = "locked"
			luaCamera:SetFollowTarget(nil, UE.Vector3(10,4,-10))
		elseif state == 5 then
		elseif state == 6 then
		elseif state == 7 then
		elseif state == 8 then
		elseif state == 9 then
		elseif state == 10 then
		elseif state == 11 then
		elseif state == 12 then
		end
	end
	
	function M.stateUpdate(state)
		if state == nil then state = luaCamera.State end
	
		if state==1 then
			update1()
		elseif state == 2 then
			update2()
		elseif state == 3 then
			update3()
		elseif state == 4 then
			
		elseif state == 5 then
			--update2()
		elseif state == 6 then
			--update2()
		elseif state == 7 then
			--update2()
		elseif state == 8 then
			--update2()
		elseif state == 9 then
			--update2()
		elseif state == 10 then
			--update2()
		elseif state == 11 then
			--update2()
		elseif state == 12 then
			--update2()
		end
	end
	
	function update1()
		-- Mouse camera that uses cinemachine and moves around a target or (0, 0, 0)
		cinemachineTargetUpdate()
	end
	
	function update2()
		local a = M.mainCamera.transform.position
		local b = M.mainCamera.transform.eulerAngles
		if UE.Input.GetKey(UE.KeyCode.UpArrow) then
			b.x = b.x+1
		elseif UE.Input.GetKey(UE.KeyCode.DownArrow) then
			b.x = b.x-1
		elseif UE.Input.GetKey(UE.KeyCode.LeftArrow) then
			b.y = b.y-1
		elseif UE.Input.GetKey(UE.KeyCode.RightArrow) then
			b.y = b.y+1
		elseif UE.Input.GetKey(UE.KeyCode.Q) then
			a.y = a.y-0.1
		elseif UE.Input.GetKey(UE.KeyCode.E) then
			a.y = a.y+0.1
		elseif UE.Input.GetKey(UE.KeyCode.W) then
			a.z = a.z-0.1
		elseif UE.Input.GetKey(UE.KeyCode.S) then
			a.z = a.z+0.1
		elseif UE.Input.GetKey(UE.KeyCode.A) then
			a.x = a.x+0.1
		elseif UE.Input.GetKey(UE.KeyCode.D) then
			a.x = a.x-0.1
		end
		M.mainCamera.transform.position = a
		M.mainCamera.transform.eulerAngles = b
		if UE.Input.GetKey(UE.KeyCode.PageUp) then
			M.mainCamera.transform:Translate( 0.1*UE.Vector3.forward)
		elseif UE.Input.GetKey(UE.KeyCode.PageDown) then
			M.mainCamera.transform:Translate(-0.1*UE.Vector3.forward)
		end
		mainCameraTargetUpdate()
	end

	function update3()
		local group = targetGroup
		if group and targetId ~= -1 then
			M.mainCamera.transform.position=UE.Vector3(0,10,0)+group.Members[targetId].transform.position
		else
			local a=M.mainCamera.transform.position
			local b=M.mainCamera.transform.eulerAngles
			if UE.Input.GetKey(UE.KeyCode.Q) then
				a.y=a.y-0.1
			elseif UE.Input.GetKey(UE.KeyCode.E) then
				a.y=a.y+0.1
			elseif UE.Input.GetKey(UE.KeyCode.W) then
				a.z=a.z-0.1
			elseif UE.Input.GetKey(UE.KeyCode.S) then
				a.z=a.z+0.1
			elseif UE.Input.GetKey(UE.KeyCode.A) then
				a.x=a.x+0.1
			elseif UE.Input.GetKey(UE.KeyCode.D) then
				a.x=a.x-0.1
			end
			M.mainCamera.transform.position=a
			M.mainCamera.transform.eulerAngles=b
			if UE.Input.GetKey(UE.KeyCode.PageUp) then
				M.mainCamera.transform:Translate( 0.1*UE.Vector3.forward)
			elseif UE.Input.GetKey(UE.KeyCode.PageDown) then
				M.mainCamera.transform:Translate(-0.1*UE.Vector3.forward)
			end
		end
		M.mainCamera.transform.eulerAngles=UE.Vector3(90,0,0)
	end

	function update4()
		luaCamera:SetFollowTarget(nil, UE.Vector3(10, 2.5,6)) 
	end
	
	function M.targetUpdate()
		if M.cinemachineBrain.enabled then
			cinemachineTargetUpdate()
		else
			mainCameraTargetUpdate()
		end
	end
	
	function cinemachineTargetUpdate()
		if targetId ~= previousTargetId then
			if targetId ~= -1 then
				luaCamera:SetLookAtTarget(targetGroup.Members[targetId].transform, UE.Vector3(0, 1, 0))
			else
				luaCamera:SetLookAtTarget(nil, UE.Vector3(0, 0, 0))
			end
		end
	end
	
	function mainCameraTargetUpdate()
		if targetId ~= -1 then
			M.lookAt(targetGroup.Members[targetId].transform.position + UE.Vector3(0, 1, 0))
		end
	end
	
	function M.updateStateFromKeyboard()
		local state = luaCamera.State
		if UE.Input.GetKeyUp(UE.KeyCode.F1) then 		-- free camera with mouse
			state=1
		elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then 	-- free camera with KB and side view
			state=2
		elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then 	-- free camera with KB and topdown view
			state=3 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then 	-- fixed camera with side view, follow agent
			state=4 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F5) then 
			state=5 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then 
			state=6 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F7) then 
			state=7 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F8) then 
			state=8
		elseif UE.Input.GetKeyUp(UE.KeyCode.F9) then 
			state=9 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F10) then 
			state=10
		elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then 
			state=11 
		elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then 
			state=12 
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
	
	function M.getState()
		return luaCamera.State
	end
	
	function M.getTargetGroup()
		return targetGroup
	end
	
	function M.getTarget()
		return targetId
	end
	
	function M.setState(state)
		luaCamera.State = state
	end
	
	function M.setTargetGroup(newTargetGroup)
		targetGroup = newTargetGroup
	end
	
	function M.setTarget(newTargetId)
		previousTargetId = targetId
		targetId = newTargetId
	end
	
	function M.setFOV(fov)
		luaCamera.FOV = fov
	end
	
	function M.getFOV()
		return luaCamera.FOV
	end
	
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
	
	return M
end

return setUpDefaultCamera

--- When changing states SOMETIMES we want to inherit previous position and rotation