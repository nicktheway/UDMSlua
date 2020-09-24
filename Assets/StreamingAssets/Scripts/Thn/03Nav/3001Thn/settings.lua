-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')

-- vars --
local qualityLevel = 2
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600

-- global vars, used in other scripts
autoCamera = 0
scene = 'RoomA'

local shadows = UE.ShadowQuality.All
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

	room:InstantiateCameraRig()
	local group = room:AddGroupDomain('dancers', 'group.lua')
	
	for i=1,5 do 
		group:AddMember('NeoMan', 'models/main')
	end
	
	group:DoScript()
	--[[
	local lutEffect = VFX.globalEffect('lut')
	VFX.setLUTEffectTexture(lutEffect, require('luts')[146])
	lutEffect.enabled:Override(true)
	--]]
end

-- Inside settings.lua
function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
