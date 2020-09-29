-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local RM = require('functionsROOM');

-- vars --
local Nagn=4
local group
function applySettings()
	UE.Screen.SetResolution(1000, 600, true, 0)
	UE.QualitySettings.SetQualityLevel(2)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = UE.ShadowQuality.All
end

function setUp()
	--group = RM.addGroup(Room,'models/main','ybot',Nagn,'dancers','group.lua')
	group = RM.addEmptyGroup(Room,'dancers','group.lua')
	for i=0,Nagn-1 do
		RM.addGroupMember(Room,'dancers', 'models/main','ybot')
		RM.addGroupMember(Room,'dancers', 'models/main','xbot')
	end
	RM.runGroupScript(Room,'dancers')
	RM.addCamera(Room) --Room:InstantiateCameraRig()
	setMusic('Commer/Rapanagatun.ogg')
end

function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
