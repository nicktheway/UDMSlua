-- aliases --
local UE = CS.UnityEngine

-- vars --
local qualityLevel = 5
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
local preferredRefreshRate = 20

function applySettings()
	-- Graphics
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	
	UE.QualitySettings.shadows = shadows
end

function setUp()
--	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')
	setMusic('PercStudio/Diansa.ogg')

	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	--local group = room:InstantiateGroup('MvnPuppet', 'models/main', 10, 'MvnPuppets', 'group.lua')
	local group = room:InstantiateGroup('NeoMan', 'models/main', 10, 'group', 'group.lua')
	local camera = room:InstantiateCameraRig()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
