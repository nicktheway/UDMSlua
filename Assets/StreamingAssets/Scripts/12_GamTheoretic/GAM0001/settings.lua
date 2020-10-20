-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local RM = require('functionsROOM');

-- global vars, used in other scripts
autoCamera = 0
scene = 'RoomA'

function applySettings()
	UE.Screen.SetResolution(1440,900, true, 0)
	UE.QualitySettings.SetQualityLevel(5)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = UE.ShadowQuality.All
end

local Nagn=10*10
local group
function setUp()
	group = RM.addGroup(Room,'models/main','NeoMan',Nagn,'dancers','group.lua')
	RM.runGroupScript(Room,'dancers')
	RM.addCamera(Room) --Room:InstantiateCameraRig()
	setMusic('Commer/InOurSleep.ogg')
	VFX.clearAllGlobalEffects()
end

-- Inside settings.lua
function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
