-- aliases --
local UE = CS.UnityEngine
local effects = require('effects')
local extras = require('extras')

-- vars --
local qualityLevel = 5
local fullScreen = false
local resolutionWidth = 640
local resolutionHeight = 480

-- global vars, used in other scripts
autoCamera = 0
scene = 'RoomA'

--[[ Shadows
 - UE.ShadowQuality.All
 - UE.ShadowQuality.HardOnly
 - UE.ShadowQuality.Disable
]]
local shadows = UE.ShadowQuality.All

-- Set the <preferredRefreshRate> to 0 to use the highest supported refresh rate
local preferredRefreshRate = 20

function applySettings()
	-- Graphics
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	
	UE.QualitySettings.shadows = shadows
end

function setUp()
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')

	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	room:InstantiateCameraRig()
	local group = room:InstantiateGroup('NeoMan', 'models/main', 16, 'dancers', 'group.lua')
	local group2 = room:AddGroupDomain('hehes', 'group.lua')
	
	group2:AddMember('xbot', 'models/main')
	group2:AddMember('ybot', 'models/main')
	group2:AddMember('MvnPuppet', 'models/main')
	
	group2:DoScript()
	
	local lutEffect = effects.globalEffect('lut')
	effects.setLUTEffectTexture(lutEffect, 'Action3D16')
	lutEffect.enabled:Override(true)
end

-- Inside settings.lua

function update()
    effects.checkGlobalEffectInputs()
	extras.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
