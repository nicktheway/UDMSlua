-- aliases --
local UE = CS.UnityEngine

-- vars --
local autoSpeed = 0.3
local manualSpeed = 0.9
local vcameras = {}
local initialCameraId = 0

local activeCameraId = initialCamera;

local dolly = {}
self.AutoDolly=false

function awake()
	vcameras = self:GetComponentsInChildren(typeof(CS.Cinemachine.CinemachineVirtualCamera))
	setActiveCamera(initialCameraId)
	dolly = vcameras[0]:GetCinemachineTrackedDollyComponent()
end

function update()
	if UE.Input.GetKeyDown(UE.KeyCode.Alpha1) then
		--setActiveCamera(0)
		--print("0")
	elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha2) then
		--setActiveCamera(1)
		--print("1")
	end
	--print(self.PathPosition)
end

function setActiveCamera(index)
	for i=0, vcameras.Length - 1 do
		vcameras[i].Priority = 10
	end
	
	vcameras[index].Priority = 100
	activeCameraId = index
end