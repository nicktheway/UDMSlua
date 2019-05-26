-- aliases --
local UE = CS.UnityEngine

-- vars --
local autoSpeed = 0.3
local manualSpeed = 0.9
local vcameras = {}
local initialCameraId = 0

local activeCameraId = initialCamera;

local dolly = {}

function awake()
	vcameras = self:GetComponentsInChildren(typeof(CS.Cinemachine.CinemachineVirtualCamera))
	
	setActiveCamera(initialCameraId)
	
	dolly = vcameras[0]:GetCinemachineTrackedDollyComponent()
end

function update()
	
	if UE.Input.GetKeyDown(UE.KeyCode.Alpha1) then
		setActiveCamera(0)
	elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha2) then
		setActiveCamera(1)
	end
	
	
	if activeCameraId == 0 then
		if Settings.autoCamera == 0 then
			dolly.m_PathPosition = dolly.m_PathPosition + UE.Input.GetAxis('Horizontal') * manualSpeed * UE.Time.deltaTime
		else
			dolly.m_PathPosition = dolly.m_PathPosition + autoSpeed * UE.Time.deltaTime
		end
	end
	
	
end

function setActiveCamera(index)
	for i=0, vcameras.Length - 1 do
		vcameras[i].Priority = 10
	end
	
	vcameras[index].Priority = 100
	activeCameraId = index
end