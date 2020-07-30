local UE = CS.UnityEngine
local DT = CS.DG.Tweening
local PP = UE.Rendering.PostProcessing

local M = {}

local pp_layer = UE.LayerMask.NameToLayer('PostProcessing')
local globalEffects = {}

function M.checkGlobalEffectInputs()
	if UE.Input.GetKey(UE.KeyCode.RightShift) then
		if UE.Input.GetKeyDown(UE.KeyCode.Alpha1) then
			M.triggerGlobalEffect('sobel')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha2) then
			M.triggerGlobalEffect('simplemotionblur')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha3) then
			M.triggerGlobalEffect('negative')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha4) then
			M.triggerGlobalEffect('thermalvision')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha5) then
			M.triggerGlobalEffect('posterization')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha6) then
			M.triggerGlobalEffect('greyscale')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha7) then
			M.triggerGlobalEffect('duotone')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha8) then
			M.triggerGlobalEffect('colorization')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha9) then
			M.triggerGlobalEffect('emboss')
		elseif UE.Input.GetKeyDown(UE.KeyCode.Alpha0) then
			M.disableAllGlobalEffects()
		end
	end
end

function M.triggerGlobalEffect(effectName)
	if globalEffects[effectName] ~= nil then
		globalEffects[effectName].enabled.overrideState = not globalEffects[effectName].enabled.overrideState
	else
		globalEffects[effectName] = M.globalEffect(effectName)
		globalEffects[effectName].enabled:Override(true)
	end
end

function M.disableAllGlobalEffects()
	for k, v in pairs(globalEffects) do
		v.enabled.overrideState = false
	end
end

function M.globalEffect(effectName)
	local effectType = effectNameToType(effectName)
	if effectType == nil then
		return null
	end
	
	local glVolume = CS.UDMS.Globals.EffectsVolume
	
	if glVolume.profile:HasSettings(effectType) then
		for i = 0, glVolume.profile.settings.Count - 1 do
			if glVolume.profile.settings[i]:GetType() == effectType then
				return glVolume.profile.settings[i]
			end
		end
	else
		local effect = newEffect(effectName)
		glVolume.profile:AddSettings(effect)
		return effect
	end
	
	return null
end

function M.quickEffect(effectName)
	local effect = newEffect(effectName)

	if effect == null then 
		return null 
	end
	
	local volume = PP.PostProcessManager.instance:QuickVolume(pp_layer, 100.0, effect)
	volume.weight = 1
	return effect
end

function M.setLUTEffectTexture(lutEffect, textureName)
	if lutEffect:GetType() ~= typeof(CS.PPEffects.SimpleLUT) then
		print(lutEffect, ' is not a ', typeof(CS.PPEffects.SimpleLUT))
		return
	end
	
	lutEffect.LookupTexture:Override(true)
	lutEffect.LookupTexture.value = CS.LuaScripting.AssetManager.LoadAsset(typeof(UE.Texture), textureName, 'textures/luts')
end

function newEffect(effectName)
	local effect 
	local effectType = effectNameToType(effectName)
	
	if effectType ~= nil then
		effect = UE.ScriptableObject.CreateInstance(effectType)
		if effectType == typeof(CS.PPEffects.SimpleLUT) then
			M.setLUTEffectTexture(effect, 'Filter-Blue-Soft')
		end
		return effect
	else
		print('Could not find/create effect from name: ', effectName)
		return null
	end
end

function effectNameToType(effectName)
	if effectName == 'anaglyph3d' then
		return typeof(CS.PPEffects.Anaglyph3D)
	elseif effectName == 'circularblur' then
		return typeof(CS.PPEffects.CircularBlur)
	elseif effectName == 'colorization' then
		return typeof(CS.PPEffects.Colorization)
	elseif effectName == 'drunk' then
		return typeof(CS.PPEffects.Drunk)
	elseif effectName == 'duotone' then
		return typeof(CS.PPEffects.DuoTone)
	elseif effectName == 'emboss' then
		return typeof(CS.PPEffects.Emboss)
	elseif effectName == 'greyscale' then
		return typeof(CS.PPEffects.Greyscale)
	elseif effectName == 'laplacian' then
		return typeof(CS.PPEffects.Laplacian)
	elseif effectName == 'lens' then
		return typeof(CS.PPEffects.Lens)
	elseif effectName == 'lowresolution' then
		return typeof(CS.PPEffects.LowResolution)
	elseif effectName == 'negative' then
		return typeof(CS.PPEffects.Negative)
	elseif effectName == 'nightvision' then
		return typeof(CS.PPEffects.NightVision)
	elseif effectName == 'posterization' then
		return typeof(CS.PPEffects.Posterization)
	elseif effectName == 'radialblur' then
		return typeof(CS.PPEffects.RadialBlur)
	elseif effectName == 'scanner' then
		return typeof(CS.PPEffects.Scanner)
	elseif effectName == 'simplemotionblur' then
		return typeof(CS.PPEffects.SimpleMotionBlur)
	elseif effectName == 'sobel' then
		return typeof(CS.PPEffects.Sobel)
	elseif effectName == 'thermalvision' then
		return typeof(CS.PPEffects.ThermalVision)
	elseif effectName == 'wiggle' then
		return typeof(CS.PPEffects.Wiggle)
	elseif effectName == 'lut' then
		return typeof(CS.PPEffects.SimpleLUT)
	else
		print('No effect type registered for name: ', effectName)
		return nil
	end
end

--[[
	fadeIn <float> 	:	fade in duration
	fadeOut <float> :	fade out duration
	pause <float>	:	pause duration
--]]
function M.vignetteEffect(fadeIn, pause, fadeOut)
	local vignette = UE.ScriptableObject.CreateInstance(typeof(PP.Vignette))
	vignette.enabled:Override(true)
	vignette.intensity:Override(1.0)
	
	local volume = PP.PostProcessManager.instance:QuickVolume(pp_layer, 100.0, vignette)
	volume.weight = 0
	
	DT.DOTween.Sequence()
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 1, fadeIn)
	)
	:AppendInterval(pause)
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 0, fadeOut)
	)
	:OnComplete(
		function() PP.RuntimeUtilities.DestroyVolume(volume, true, true) end
	)
end

function M.bloomEffect(intensity, fadeIn, pause, fadeOut)
	local bloom = UE.ScriptableObject.CreateInstance(typeof(PP.Bloom))
	bloom.enabled:Override(true)
	bloom.intensity:Override(intensity)
	
	local volume = PP.PostProcessManager.instance:QuickVolume(pp_layer, 100.0, bloom)
	volume.weight = 0
	
	DT.DOTween.Sequence()
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 1, fadeIn)
	)
	:AppendInterval(pause)
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 0, fadeOut)
	)
	:OnComplete(
		function() PP.RuntimeUtilities.DestroyVolume(volume, true, true) end
	)
end

function M.colorGradingEffect(saturation, fadeIn, pause, fadeOut)
	local cg = UE.ScriptableObject.CreateInstance(typeof(PP.ColorGrading))
	cg.enabled:Override(true)
	cg.saturation:Override(saturation)
	
	local volume = PP.PostProcessManager.instance:QuickVolume(pp_layer, 100.0, cg)
	volume.weight = 0
	
	DT.DOTween.Sequence()
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 1, fadeIn)
	)
	:AppendInterval(pause)
	:Append(
		DT.DOTween.To(function() return volume.weight end, function(x) volume.weight = x end, 0, fadeOut)
	)
	:OnComplete(
		function() PP.RuntimeUtilities.DestroyVolume(volume, true, true) end
	)
end

return M