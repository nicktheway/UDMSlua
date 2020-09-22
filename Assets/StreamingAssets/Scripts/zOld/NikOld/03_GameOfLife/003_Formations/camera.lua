local UE = CS.UnityEngine

local cam00 = UE.Camera.main
local groupDomain
local TIME=0
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
local lookTarget = UE.Vector3(0, 1, 0)

function awake()
	self.State = 1
end

function start()
	groupDomain = Room:GetGroupDomain('dancers')
	cinemachineBrain.enabled = false
	
	cam00.transform.position=UE.Vector3(4,3,-8)
	cam00.transform.eulerAngles=UE.Vector3(30,180,0)
end

function update()
	TIME=TIME+1
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then self.State=1 end
	if UE.Input.GetKeyUp(UE.KeyCode.F2) then self.State=2 end
	if UE.Input.GetKeyUp(UE.KeyCode.F10) then self.State=0 end
	if self.State==1 then 
		cinemachineBrain.enabled = false
		update1()
	end
	if self.State==2 then 
		cinemachineBrain.enabled = false
		update2()
	end
	if self.State==0 then 
		cinemachineBrain.enabled = true
	end

	listenToCameraShortcuts(groupDomain)
	cam00.transform:LookAt(lookTarget)
end

function listenToCameraShortcuts(group)
	local n = group.Members.Count
	if UE.Input.GetKey(UE.KeyCode.LeftShift) then
		if UE.Input.GetKeyUp(UE.KeyCode.Alpha1) and n > 0 then
			lookTarget = group.Members[0].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha2) and n > 1 then
			lookTarget = group.Members[1].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha3) and n > 2 then
			lookTarget = group.Members[2].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha4) and n > 3 then
			lookTarget = group.Members[3].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha5) and n > 4 then
			lookTarget = group.Members[4].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha6) and n > 5 then
			lookTarget = group.Members[5].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha7) and n > 6 then
			lookTarget = group.Members[6].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha8) and n > 7 then
			lookTarget = group.Members[7].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha9) and n > 8 then
			lookTarget = group.Members[8].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha0) and n > 0 then
			lookTarget = group:GetGroupCenter() + UE.Vector3(0, 1, 0)
		end
	end
end

function update()
	TIME=TIME+1
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then self.State=1 end
	if UE.Input.GetKeyUp(UE.KeyCode.F2) then self.State=2 end
	if UE.Input.GetKeyUp(UE.KeyCode.F10) then self.State=0 end
	if self.State==1 then 
		cinemachineBrain.enabled = false
		update1()
	end
	if self.State==2 then 
		cinemachineBrain.enabled = false
		update2()
	end
	if self.State==0 then 
		cinemachineBrain.enabled = true
	end
	print(TIME," ",self.StateOld," ",self.State)
end
function update1()
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
	elseif UE.Input.GetKey(UE.KeyCode.F1) then
		a=UE.Vector3(4,3,-8)
		b=UE.Vector3(30,180,0)
	end
	cam00.transform.position=a
	cam00.transform.eulerAngles=b
	if UE.Input.GetKey(UE.KeyCode.PageUp) then
		cam00.transform:Translate( 0.1*UE.Vector3.forward)
	elseif UE.Input.GetKey(UE.KeyCode.PageDown) then
		cam00.transform:Translate(-0.1*UE.Vector3.forward)
	end
end
function update2()
	local group = Room:GetGroupDomain("dancers")
	cam00.transform.position=UE.Vector3(0,10,0)+group.Members[0].transform.position
	cam00.transform.eulerAngles=UE.Vector3(90,0,0)
end
function update0()
	self:SetFollowTarget(nil, UE.Vector3(5, 2.5,0)) 
	self:LookAtGroupAgent("dancers", 1, UE.Vector3(0,1,0))
end