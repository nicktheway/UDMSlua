local UE = CS.UnityEngine
local UT = require('utils')

local cam00 = UE.Camera.main
local groupDomain
local TIME=0
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
local lookTarget = -1
local oldTarget = -1

function start()
	self.State = 1
	groupDomain = Room:GetGroupDomain('dancers')
	cam00.transform.position=UE.Vector3(4,3,8)
	cam00.transform:LookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	
	stateInit(self.State)
	for i = 0, self.Cameras.Length - 1 do
		print(self.Cameras[i])
		self.Cameras[i].transform.position = UE.Vector3(4,3,8)
	end
end

function update()
	TIME=TIME+1
	oldTarget = lookTarget
	selectState()
	
	if self.State ~= self.OldState then
		stateInit(self.State)
	end
	
	selectUpdateFnc()
	selectTarget(groupDomain)
	
	if lookTarget ~= -1 then
		if not cinemachineBrain.enabled then
			cam00.transform:LookAt(groupDomain.Members[lookTarget].transform.position + UE.Vector3(0, 1, 0))
		end
		if cinemachineBrain.enabled and lookTarget ~= oldTarget then
			self:LookAtGroupAgent("dancers", lookTarget, UE.Vector3(0,1,0))
		end
	end
	--UT.printOnScreen(self.State)
end

function selectState()
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then 		-- free camera with mouse
		self.State=1
	elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then 	-- free camera with KB and side view
		self.State=2
	elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then 	-- free camera with KB and topdown view
		self.State=3 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then 	-- fixed camera with side view, follow agent
		self.State=4 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F5) then 
		self.State=5 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then 
		self.State=6 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F7) then 
		self.State=7 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F8) then 
		self.State=8
	elseif UE.Input.GetKeyUp(UE.KeyCode.F9) then 
		self.State=9 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F10) then 
		self.State=10
	elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then 
		self.State=11 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then 
		self.State=12 
	end
end

function stateInit(state)
	if state == 1 then							-- free camera with mouse
		cinemachineBrain.enabled = true
		self.ActiveCamera = "explorer"
	elseif state == 2 then						-- free camera with KB and side view
		cinemachineBrain.enabled = false
	elseif state == 3 then						-- free camera with KB and topdown view
		cinemachineBrain.enabled = false
	elseif state == 4 then						-- fixed camera with side view, follow agent
		cinemachineBrain.enabled = true
		self.ActiveCamera = "locked"
		self:SetFollowTarget(nil, UE.Vector3(10,4,-10))
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

function selectUpdateFnc()
	if self.State==1 then 
		
	elseif self.State == 2 then
		update2()
	elseif self.State == 3 then
		update3()
	elseif self.State == 4 then
		
	elseif self.State == 5 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 6 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 7 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 8 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 9 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 10 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 11 then
		cinemachineBrain.enabled = false
		--update2()
	elseif self.State == 12 then
		cinemachineBrain.enabled = false
		--update2()
	end
end

function selectTarget(group)
	local n = group.Members.Count
	if UE.Input.GetKey(UE.KeyCode.LeftShift) then
		if UE.Input.GetKeyUp(UE.KeyCode.Alpha1) and n > 0 then
			lookTarget = 0
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha2) and n > 1 then
			lookTarget = 1
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha3) and n > 2 then
			lookTarget = 2
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha4) and n > 3 then
			lookTarget = 3
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha5) and n > 4 then
			lookTarget = 4
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha6) and n > 5 then
			lookTarget = 5
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha7) and n > 6 then
			lookTarget = 6
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha8) and n > 7 then
			lookTarget = 7
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha9) and n > 8 then
			lookTarget = 8
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha0) and n > 0 then
			lookTarget = -1
		end
	end
end

function update2()
	local a=cam00.transform.position
	local b=cam00.transform.eulerAngles
	if UE.Input.GetKey(UE.KeyCode.UpArrow) then
		b.x=b.x+1
	elseif UE.Input.GetKey(UE.KeyCode.DownArrow) then
		b.x=b.x-1
	elseif UE.Input.GetKey(UE.KeyCode.LeftArrow) then
		b.y=b.y-1
	elseif UE.Input.GetKey(UE.KeyCode.RightArrow) then
		b.y=b.y+1
	elseif UE.Input.GetKey(UE.KeyCode.Q) then
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
	cam00.transform.position=a
	cam00.transform.eulerAngles=b
	if UE.Input.GetKey(UE.KeyCode.PageUp) then
		cam00.transform:Translate( 0.1*UE.Vector3.forward)
	elseif UE.Input.GetKey(UE.KeyCode.PageDown) then
		cam00.transform:Translate(-0.1*UE.Vector3.forward)
	end
	
end

function update3()
	local group = Room:GetGroupDomain("dancers")
	if lookTarget ~= -1 then
		cam00.transform.position=UE.Vector3(0,10,0)+group.Members[lookTarget].transform.position
	else
		local a=cam00.transform.position
		local b=cam00.transform.eulerAngles
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
		cam00.transform.position=a
		cam00.transform.eulerAngles=b
		if UE.Input.GetKey(UE.KeyCode.PageUp) then
			cam00.transform:Translate( 0.1*UE.Vector3.forward)
		elseif UE.Input.GetKey(UE.KeyCode.PageDown) then
			cam00.transform:Translate(-0.1*UE.Vector3.forward)
		end
	end
	cam00.transform.eulerAngles=UE.Vector3(90,0,0)
end

function update4()
	self:SetFollowTarget(nil, UE.Vector3(10, 2.5,6)) 
end