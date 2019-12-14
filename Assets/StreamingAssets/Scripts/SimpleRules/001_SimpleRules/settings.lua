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
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')

	--UE.SceneManager:LoadScene(scene, UE.LoadSceneMode.Additive)
	--UE.SceneManagement.MoveGameObjectToScene	
	local group = room:InstantiateGroup('grandpa Variant', 'models/lpfamily', 3, 'grandpas', 'group.lua')
	for i = 0, group.Members.Count - 1 do
		group.Members[i].transform.position = UE.Vector3(i * 10, 0, 0)
	end
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
