-- aliases --
local UE = CS.UnityEngine

-- vars --
local qualityLevel = 5
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600

-- global vars, used in other scripts
--autoCamera = 0
--scene = 'RoomA'

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
	room:InstantiateCameraRig()
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')

	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	local group = room:InstantiateGroup('NeoMan', 'models/main', 100, 'dancers', 'group.lua')
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
