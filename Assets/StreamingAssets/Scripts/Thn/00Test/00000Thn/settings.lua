-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local LF3 = require('functionsTHN'); local THN = LF3()

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
	group = THN.roomMakeGroup(Room,'ybot', 'models/main', Nagn, 'dancers', 'group.lua')
	--THN.roomAddMember(group,'ybot', 'models/main')
	THN.roomMakeCamera(Room) --Room:InstantiateCameraRig()
	setMusic('Commer/Rapanagatun.ogg')
end

function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
