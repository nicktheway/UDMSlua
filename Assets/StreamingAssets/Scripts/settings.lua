-- aliases --
local UE = CS.UnityEngine

-- vars --
local qualityLevel = 5
local volumeScale = 0.4
local fullScreen = false
local resolutionWidth = 640
local resolutionHeight = 480

-- global vars, used in other scripts
autoCamera = 1

--[[ Shadows
 - UE.ShadowQuality.All
 - UE.ShadowQuality.HardOnly
 - UE.ShadowQuality.Disable
]]
local shadows = UE.ShadowQuality.All

-- Set the <preferredRefreshRate> to 0 to use the highest supported refresh rate
local preferredRefreshRate = 20

function applySettings()
	-- Sound
	self:GetComponent(typeof(UE.AudioSource)).volume = volumeScale
	
	-- Graphics
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	
	UE.QualitySettings.shadows = shadows
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
