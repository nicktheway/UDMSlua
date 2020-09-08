-- aliases --
local UE = CS.UnityEngine
local activeCameraId = initialCamera;
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
if cinemachineBrain then
	cinemachineBrain.enabled = false
end
local cam00=UE.Camera.main

function awake()
	cam00.transform.position=UE.Vector3(4,3,-8)
	cam00.transform.eulerAngles=UE.Vector3(30,180,0)
end

function update()
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
		a.x=a.x-0.1
	elseif UE.Input.GetKey(UE.KeyCode.D) then
		a.x=a.x+0.1
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

function setActiveCamera(index)
end

-----------------------------------------------------------------------------------------------
--[[
-- vars --
local autoSpeed = 0.3
local manualSpeed = 0.9
local vcameras = {}
local initialCameraId = 0
local dolly = {}
self.AutoDolly=false

	vcameras = self:GetComponentsInChildren(typeof(CS.Cinemachine.CinemachineVirtualCamera))
	setActiveCamera(initialCameraId)
	dolly = vcameras[0]:GetCinemachineTrackedDollyComponent()


	for i=0, vcameras.Length - 1 do
		vcameras[i].Priority = 10
	end
	
	vcameras[index].Priority = 100
	activeCameraId = index

--]]