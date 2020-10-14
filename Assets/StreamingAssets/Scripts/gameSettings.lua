-- aliases --
local UE = CS.UnityEngine

-- vars --
local qualityLevel = 4
local volumeScale = 0.2
local fullScreen = true
local resolutionWidth = 1440
local resolutionHeight = 900

--[[ Shadows
 - UE.ShadowQuality.All
 - UE.ShadowQuality.HardOnly
 - UE.ShadowQuality.Disable
]]
local shadows = UE.ShadowQuality.All
local preferredRefreshRate = 0
-- Set the <preferredRefreshRate> to 0 to use the highest supported refresh rate

function applySettings()
	Audio.volume = volumeScale
	UE.Application.targetFrameRate = 60
	UE.QualitySettings.vSyncCount = 0
	UE.Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen, preferredRefreshRate)
	UE.QualitySettings.SetQualityLevel(qualityLevel)
	UE.QualitySettings.shadows = shadows
end

-- Everytime the script is reloaded the settings are applied.
applySettings();
