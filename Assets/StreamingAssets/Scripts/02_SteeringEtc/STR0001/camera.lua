local UE = CS.UnityEngine
local UT = require('utils')
local UE = CS.UnityEngine
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')
local VFX = require('effects')

local TIME=0
local spectrum = UT.newCSFloatArray(64)

local sobelEffect

function start()
	CAM.setState(1)
	CAM.setTargetGroup(Room, 'dancers')
	CAM.setPos(UE.Vector3(4,3,-8))
	groupDomain = RM.getGroup(Room, 'dancers')
	CAM.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	CAM.stateInit()
	
	sobelEffect = VFX.getEffect('sobel')
end

function update()
	TIME=TIME+1
	CAM.updateStateFromKeyboard()
	CAM.updateTargetFromKeyboard()
	CAM.targetUpdate()
	stateUpdate(TIME)
	--UT.printOnScreen(self.State)
	if TIME % 5 == 0 then
		CS.UDMS.Globals.AudioSource:GetSpectrumData(spectrum, 0, UE.FFTWindow.Rectangular)
		local mean = UT.arrayMean(spectrum, 1,2)
		print(mean)
		--[[
		if mean > 0.01 then
			VFX.enableEffect(sobelEffect)
		else
			VFX.enableEffect(sobelEffect, false)
		end
		--]]
	end
	for i=1,spectrum.Length-2 do
		UE.Debug.DrawLine(UE.Vector3(i - 1, spectrum[i] + 10, 0), UE.Vector3(i, spectrum[i + 1] + 10, 0), UE.Color.red);
		UE.Debug.DrawLine(UE.Vector3(i - 1, UE.Mathf.Log(spectrum[i - 1]) + 10, 2), UE.Vector3(i, UE.Mathf.Log(spectrum[i]) + 10, 2), UE.Color.cyan);
		UE.Debug.DrawLine(UE.Vector3(UE.Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), UE.Vector3(UE.Mathf.Log(i), spectrum[i] - 10, 1), UE.Color.green);
		UE.Debug.DrawLine(UE.Vector3(UE.Mathf.Log(i - 1), UE.Mathf.Log(spectrum[i - 1]), 3), UE.Vector3(UE.Mathf.Log(i), UE.Mathf.Log(spectrum[i]), 3), UE.Color.blue);
	end
end

function updateStateFromKeyboard()
	local state = CAM.getState()
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then state=1
	elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then state=2
	elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then state=3
	elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then state=4
	elseif UE.Input.GetKeyUp(UE.KeyCode.F8) then state=26
	elseif UE.Input.GetKeyUp(UE.KeyCode.F9) then state=27 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then state=11
	elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then state=12
	end
	CAM.setState(state)
end

function stateUpdate(TIME)
	local state = CAM.getState()
	if state<19		then CAM.stateUpdate(TIME)
	elseif state==26	then update26()
	elseif state==27	then update27()
	end
end

function update26()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	CAM.setPos(UE.Vector3(3,4,1))
end

function update27()
	local R=7
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	CAM.setPos(UE.Vector3(R*math.cos(0.015*TIME),3,R*math.sin(0.015*TIME)))
end
