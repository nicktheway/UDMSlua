local UE = CS.UnityEngine
local UT = require('utils')
local UE = CS.UnityEngine
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')
local VFX = require('effects')

local TIME=0
function start()
	CAM.setState(1)
	CAM.setTargetGroup(Room, 'dancers')
	CAM.setPos(UE.Vector3(4,3,-8))
	groupDomain = RM.getGroup(Room, 'dancers')
	CAM.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	CAM.stateInit()
	VFX.disableAllGlobalEffects()
	lutEffect = VFX.getEffect('lut')
	sobel = VFX.getEffect('sobel')
	duotone= VFX.getEffect('duotone')
	motionBlur = VFX.getEffect('simplemotionblur')
	VFX.setProperty(motionBlur.BlurAmount,0.9)
	VFX.setProperty(duotone.MinLimit,0.15)
	VFX.setProperty(duotone.MaxLimit,0.85)
	VFX.enableEffect(sobel, true)
	VFX.enableEffect(duotone, true)
	VFX.enableEffect(motionBlur, true)
end

function update()
	TIME=TIME+1
	CAM.updateStateFromKeyboard()
	CAM.updateTargetFromKeyboard()
	CAM.targetUpdate()
	stateUpdate(TIME)
	--UT.printOnScreen(self.State)
end

function stateUpdate(TIME)
	local state = CAM.getState()
	if state<19		then CAM.stateUpdate(TIME) end
end
