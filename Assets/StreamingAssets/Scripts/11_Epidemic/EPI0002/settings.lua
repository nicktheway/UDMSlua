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

local Nagn=10
local group
function setUp()
	group = RM.addEmptyGroup(Room,'dancers','group.lua')
	for i=0,Nagn-1 do
		RM.addGroupMember(Room,'dancers', 'models/main','NeoMan')
	end
	RM.runGroupScript(Room,'dancers')
	RM.addCamera(Room) --Room:InstantiateCameraRig()
	setMusic('PercStudio/Silamalon.ogg')
	VFX.clearAllGlobalEffects()
	local sobel = VFX.globalEffect('sobel')
	sobel.enabled:Override(true)
	sobel.Threshold:Override(true)
	sobel.Threshold.value=15
	sobel.ShowBackground:Override(true)
	sobel.ShowBackground.value=true

end

-- Inside settings.lua
function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
