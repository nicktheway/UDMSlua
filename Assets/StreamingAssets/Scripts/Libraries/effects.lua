local UE = CS.UnityEngine
local DT = CS.DG.Tweening
local PP = UE.Rendering.PostProcessing

local M = {}

local pp_layer = UE.LayerMask.NameToLayer('PostProcessing')


function M.newEffect(effectName)
	local effect
	
	if effectName == 'anaglyph3d' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Anaglyph3D))
	elseif effectName == 'circularblur' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.CircularBlur))
	elseif effectName == 'colorization' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Colorization))
	elseif effectName == 'drunk' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Drunk))
	elseif effectName == 'duotone' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.DuoTone))
	elseif effectName == 'emboss' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Emboss))
	elseif effectName == 'greyscale' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Greyscale))
	elseif effectName == 'laplacian' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Laplacian))
	elseif effectName == 'lens' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Lens))
	elseif effectName == 'lowresolution' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.LowResolution))
	elseif effectName == 'negative' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Negative))
	elseif effectName == 'nightvision' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.NightVision))
	elseif effectName == 'posterization' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Posterization))
	elseif effectName == 'radialblur' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.RadialBlur))
	elseif effectName == 'scanner' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Scanner))
	elseif effectName == 'sobel' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Sobel))
	elseif effectName == 'thermalvision' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.ThermalVision))
	elseif effectName == 'wiggle' then
		effect = UE.ScriptableObject.CreateInstance(typeof(CS.PPEffects.Wiggle))
	else
		return null
	end
	
	local volume = PP.PostProcessManager.instance:QuickVolume(pp_layer, 100.0, effect)
	volume.weight = 1
	
	return effect
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