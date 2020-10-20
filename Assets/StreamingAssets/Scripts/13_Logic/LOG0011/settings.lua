-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local RM = require('functionsROOM');

function applySettings()
	UE.Screen.SetResolution(1440,900, true, 0)
	UE.QualitySettings.SetQualityLevel(5)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = UE.ShadowQuality.All
end

local Nagn=16
local group
function setUp()
	--group = RM.addGroup(Room,'models/main','ybot',Nagn,'dancers','group.lua')
	group = RM.addEmptyGroup(Room,'dancers','group.lua')
	for i=0,Nagn-1 do
		RM.addGroupMember(Room,'dancers', 'models/main','ybot')
	end
	RM.runGroupScript(Room,'dancers')
	RM.addCamera(Room) --Room:InstantiateCameraRig()
	setMusic('Commer/Frankum.ogg')
	VFX.clearAllGlobalEffects()
end

function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
