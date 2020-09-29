-- aliases --
local UE = CS.UnityEngine
local effects = require('effects')
local UT = require('utils')
local LFO = require('functionsOBJ')
local LFR = require('functionsROOM')

-- vars --
local qualityLevel = 2
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600

--[[ Shadows
 - UE.ShadowQuality.All
 - UE.ShadowQuality.HardOnly
 - UE.ShadowQuality.Disable
]]
local shadows = UE.ShadowQuality.All

-- Set the <preferredRefreshRate> to 0 to use the highest supported refresh rate
local preferredRefreshRate = 0

function applySettings()
	-- Graphics
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	UE.Application.targetFrameRate = 60
	UE.QualitySettings.vSyncCount = 0
	
	UE.QualitySettings.shadows = shadows
end

function setUp()
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')

	LFR.useCameraScript(Room)
	-- LFR.addGroup(Room, 'models/main', 'NeoMan', 10, 'dancers', 'group.lua')
	LFR.addEmptyGroup(Room, 'dancers', 'group.lua')
	
	for i = 1, 5 do
		LFR.addGroupMember(Room, 'dancers', 'models/main', 'xbot')
		LFR.addGroupMember(Room, 'dancers', 'models/main', 'ybot')
	end
	
	LFR.runGroupScript(Room, 'dancers')
	
	local lutEffect = effects.globalEffect('lut')
	effects.setLUTEffectTexture(lutEffect, require('luts')[146])
	lutEffect.enabled:Override(false)
	--]]
end

-- Inside settings.lua

function update()
    effects.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
