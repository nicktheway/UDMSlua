-- aliases --
local UE = CS.UnityEngine
local UT = require('utils')
local TIME=0

local cam00=UE.Camera.main
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))

function awake1()
	cam00.transform.position=UE.Vector3(4,3,-8)
	cam00.transform.eulerAngles=UE.Vector3(30,180,0)
end

function awake()
	self.State=1
    self.ActiveCamera = "locked"
    self.FOV = 60
    -- Follow and look at the object of the group 'group' and index 1 with some offsets.
    self:SetLookAtTarget(nil, UE.Vector3(0, 2, 0))
    self:SetFollowTarget(nil, UE.Vector3(5, 2.5,0))
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

