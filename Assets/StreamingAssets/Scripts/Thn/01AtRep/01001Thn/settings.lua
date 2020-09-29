-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')

-- vars --
local Nagn=6
local group
function applySettings()
	UE.Screen.SetResolution(1000, 600, true, 0)
	UE.QualitySettings.SetQualityLevel(2)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = UE.ShadowQuality.All
end

function setUp()
	group = Room:AddGroupDomain('dancers', 'group.lua')
	for i=1,Nagn do 
		group:AddMember('ybot', 'models/main')
		--group:AddMember('NeoMan', 'models/main')
	end
	group:DoScript()
	Room:InstantiateCameraRig()
	setMusic('Commer/Rapanagatun.ogg')
end

function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();


-----------------------------------------------------------------------------------------
--local volumeScale = 0.2

	--[[
	local group = Room:InstantiateGroup('xbot', 'models/main', 3, 'dancers', 'group.lua')
   local lutEffect = VFX.globalEffect('lut')
   VFX.setLUTEffectTexture(lutEffect, 'Dark-Knight')
   lutEffect.enabled:Override(true)
   lutEffect.Contrast:Override(true)
   lutEffect.Contrast.value = 1.0
   local MBEffect = VFX.globalEffect("simplemotionblur")
   MBEffect.enabled:Override(true)
   MBEffect.BlurAmount:Override(true)
   MBEffect.BlurAmount.value=0.10
   --VFX.triggerGlobalEffect("simplemotionblur")
   --]]