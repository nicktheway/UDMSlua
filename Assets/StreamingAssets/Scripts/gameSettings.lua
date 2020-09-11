-- aliases --
local UE = CS.UnityEngine

-- vars --
local qualityLevel = 5
local volumeScale = 0.2
local fullScreen = true
local resolutionWidth = 1000
local resolutionHeight = 600

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
	Audio.volume = volumeScale
	
	-- Frame Rate
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	
	-- Graphics
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	
	UE.QualitySettings.shadows = shadows
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
