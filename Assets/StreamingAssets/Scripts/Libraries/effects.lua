local UE = CS.UnityEngine
local DT = CS.DG.Tweening
local PP = UE.Rendering.PostProcessing

local M = {}

local pp_layer = UE.LayerMask.NameToLayer('PostProcessing')

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

return M