local UE = CS.UnityEngine
local UT = require('utils')
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')
local VFX = require('effects')

local groupDomain
local TIME=0

local lutEffect
local sobel
local motionBlur
local R=5
local blurTime=0

function start()
	CAM.useCinemachine(false)
	CAM.setTargetGroup(Room, 'dancers')
	CAM.setPos(UE.Vector3(4,3,-8))
	CAM.lookAt(UE.Vector3(0,1,0))
	CAM.setTargetOffset(UE.Vector3(0,1,0))

	--groupDomain = RM.getGroup(Room, 'dancers')
	--CAM.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	--CAM.stateInit()
	VFX.disableAllGlobalEffects()
	lutEffect = VFX.getEffect('lut')
	sobel = VFX.getEffect('sobel')
	motionBlur = VFX.getEffect('simplemotionblur')
	VFX.setProperty(motionBlur.BlurAmount,0.9)
end

function update()
	TIME=TIME+1
	print(TIME,blurTime)
	stateUpdate(TIME)
	
	if TIME==   1 then 
		VFX.setLUTEffectTexture(lutEffect, 'RobotVision3D16')
		VFX.enableEffect(lutEffect)
		CAM.setTarget(0) 
		CAM.setState(26)
	elseif TIME== 200 then 
		CAM.setTarget(0) 
		CAM.setState(27)
	elseif TIME== 251 then 
		CAM.setTarget(1)
		R=2
		CAM.setState(27)
	elseif  TIME== 301 then 
		--VFX.enableEffect(motionBlur)
	elseif  TIME== 331 then 
		VFX.enableEffect(sobel, true)
	elseif  TIME== 351 then 
		VFX.enableEffect(sobel, false)
	elseif  TIME== 371 then 
		VFX.enableEffect(sobel, true)
	elseif  TIME== 391 then 
		VFX.enableEffect(sobel, false)
	elseif  TIME== 411 then 
		CAM.setTarget(2) 
		VFX.enableEffect(sobel, true)
		CAM.setState(29)
	elseif  TIME== 431 then 
		CAM.setPos(UE.Vector3(-4,3,4))
		VFX.enableEffect(sobel, false)
	elseif  TIME== 451 then 
		VFX.enableEffect(sobel, true)
	elseif  TIME== 471 then 
		CAM.setPos(UE.Vector3(0,3,4))
		VFX.enableEffect(sobel, false)
	elseif  TIME== 411 then 
		VFX.enableEffect(sobel, true)
	elseif  TIME== 431 then 
		CAM.setTarget(3) 
		VFX.enableEffect(sobel, false)
	elseif  TIME== 441 then 
		CAM.setTarget(0) 
		VFX.enableEffect(sobel, true)
	elseif  TIME== 451 then 
		CAM.setTarget(1) 
		VFX.enableEffect(sobel, false)
	elseif  TIME== 461 then 
		CAM.setTarget(2) 
		VFX.enableEffect(sobel, false)
		TIME=200
	end
	if VFX.isEnabled(motionBlur) then blurTime=blurTime+1
	else blurTime=blurTime-1
	end
	if blurTime>0 then
		if math.random()<0.0001*blurTime then VFX.enableEffect(motionBlur,false) end
	else
		if math.random()<-0.0001*blurTime then VFX.enableEffect(motionBlur,true) end
	end
	CAM.targetUpdate()
	
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
	local Rx=10
	local Ry=3
	local Rz=10
	local wx=0.050
	local wy=0.025
	local wz=0.040
	CAM.setPos(UE.Vector3(Rx*math.cos(wx*TIME),Ry,Rz*math.cos(wz*TIME)))
end

function update27()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local Rx=3
	local Ry=1.5
	local Rz=3
	local wx=0.050
	local wy=0.025
	local wz=0.040
	CAM.setPos(UE.Vector3(Rx*math.cos(wx*TIME),Ry*(1.2+math.cos(wy*TIME)),Rz*math.cos(wz*TIME)))
end
