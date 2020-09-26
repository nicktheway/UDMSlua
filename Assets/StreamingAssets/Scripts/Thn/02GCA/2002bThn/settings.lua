-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')

-- vars --
local qualityLevel = 2
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600
local shadows = UE.ShadowQuality.All
local preferredRefreshRate = 0

-- global vars, used in other scripts
autoCamera = 0
scene = 'RoomA'


function applySettings()
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	UE.Application.targetFrameRate = 60
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = shadows
end

function setUp()
	setMusic('Commer/InTheLordsPresence.ogg')
	room:InstantiateCameraRig()
	local group = room:InstantiateGroup('NeoMan', 'models/main', 15*15, 'dancers', 'group.lua')
	--[[
	local group = room:AddGroupDomain('dancers', 'group.lua')
	
	for i=1,49 do 
		group:AddMember('NeoMan', 'models/main')
	end
	group:DoScript()
	--]]

	local lutEffect = VFX.globalEffect('lut')
	VFX.setLUTEffectTexture(lutEffect, require('luts')[146])
	lutEffect.enabled:Override(false)
end

-- Inside settings.lua
function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
