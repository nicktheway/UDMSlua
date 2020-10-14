-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local RM = require('functionsROOM')

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

local Nagn=9*9
local group
function setUp()
	group = RM.addGroup(Room,'models/main','NeoMan',Nagn,'dancers','group.lua')
	RM.runGroupScript(Room,'dancers')
	RM.addCamera(Room) --Room:InstantiateCameraRig()
	setMusic('Commer/Rapanagatun.ogg')
	VFX.clearAllGlobalEffects()
	
	local sobel = VFX.globalEffect('sobel')
	sobel.enabled:Override(true)
	sobel.Threshold:Override(true)
	sobel.Threshold.value=10
	sobel.ShowBackground:Override(true)
	sobel.ShowBackground.value=true
	
	local lutEffect = VFX.globalEffect('lut')
    VFX.setLUTEffectTexture(lutEffect, 'Sepia3D16')
    --VFX.setLUTEffectTexture(lutEffect, 'Sin-City')
	lutEffect.Contrast:Override(true)
    lutEffect.Contrast.value = 5.0
	lutEffect.enabled:Override(true)

end

-- Inside settings.lua
function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
