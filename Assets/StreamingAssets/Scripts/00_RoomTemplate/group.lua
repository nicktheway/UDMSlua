local UE = CS.UnityEngine
local effects = require('effects')

local Nagn = Members.Count
local frameCounter = 0
local clip = 'Jazz Dancing01'
local anims = {}

local effectStatuses = {}

function start()
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		anims[i]:CrossFade(clip, 0.4);
    end
    -- Group function call example
    -- full list of available functions at: https://udms-docs.netlify.app/src-pages-scripting-api-group/
    Group:ToGridFormation(4, UE.Vector3(-2, 0, -2), 1, 1)

    --[[ Disable Cinemachine
    local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
    if cinemachineBrain then
        cinemachineBrain.enabled = false
    end
	--]]
	Group:ToggleIndices(false)
end

function update()
	checkForEffectInput()
    for i = 0, Nagn - 1 do
        individualUpdate(i)
    end
	
	if frameCounter % 200 == 0 then
		effects.vignetteEffect(1, 1, 1)
		effects.bloomEffect(50, 1, 2, 1)
		effects.colorGradingEffect(-100, 1, 2, 1)
	end
	
	frameCounter = frameCounter + 1
end

function individualUpdate(id)
    -- Placeholder: make all agents face (0, 0, 0)
    -- Group Member function call example,
    -- full list at: https://udms-docs.netlify.app/src-pages-scripting-api-group-member
    local newDir =  Members[id]:DirAgentToPnt(UE.Vector3(0, 0, 0))
    Members[id]:SetDir(newDir)
end

function checkForEffectInput()
	if UE.Input.GetKey(UE.KeyCode.RightShift) then
		if UE.Input.GetKeyDown(UE.KeyCode.Alpha1) then
			triggerEffect('sobel')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha2) then
			triggerEffect('circularblur')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha3) then
			triggerEffect('negative')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha4) then
			triggerEffect('thermalvision')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha5) then
			triggerEffect('posterization')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha6) then
			triggerEffect('greyscale')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha7) then
			triggerEffect('duotone')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha8) then
			triggerEffect('colorization')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha9) then
			triggerEffect('emboss')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha0) then
			disableAllEffects()
		end
	end
end

function triggerEffect(effectName)
	if effectStatuses[effectName] ~= nil then
		effectStatuses[effectName].enabled.overrideState = not effectStatuses[effectName].enabled.overrideState
	else
		effectStatuses[effectName] = effects.newEffect(effectName)
		effectStatuses[effectName].enabled:Override(true)
	end
end

function disableAllEffects()
	for k, v in pairs(effectStatuses) do
		v.enabled.overrideState = false
	end
end
