-- aliases --
local UE = CS.UnityEngine
local effects = require('effects')
local UT = require('utils')

-- vars --
local qualityLevel = 2
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600

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

	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	Room:InstantiateCameraRig()
	local group = Room:InstantiateGroup('NeoMan', 'models/main', 31*31, 'dancers', 'group.lua')
	--[[
	local group = Room:AddGroupDomain('dancers', 'group.lua')
	
	for i=1,25 do 
		group:AddMember('NeoMan', 'models/main')
		if i==25 then break end
		group:AddMember('NeoMan', 'models/main')
	end
	
	group:DoScript()
	--]]
	--
	local lutEffect = effects.globalEffect('lut')
	effects.setLUTEffectTexture(lutEffect, require('luts')[146])
	lutEffect.enabled:Override(true)
	--]]
end

-- Inside settings.lua

function update()
    effects.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
