-- aliases --
local UE = CS.UnityEngine

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
	
	UE.QualitySettings.shadows = shadows
end

function setUp()
	print('Room set up')
	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	local grandma = room:InstantiateIndividualGameObject('grandma Variant', 'models/lpfamily', 'agent_alone.lua')
	grandma.transform.position = UE.Vector3.zero
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
