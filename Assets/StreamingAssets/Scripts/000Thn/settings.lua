-- aliases --
local UE = CS.UnityEngine
local effects = require('effects')

-- vars --
local qualityLevel = 2
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
local preferredRefreshRate = 0 --20

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
	setMusic('Commer/Rapanagatun.ogg')
	local group = room:InstantiateGroup('xbot', 'models/main', 3, 'dancers', 'group.lua')
	 -- texture the plane
    local texture = CS.LuaScripting.AssetManager.LoadAsset(typeof(UE.Texture), 'checker', 'textures/ground')
    local myPlane = room:InstantiateAndRegisterObject('myGround', 'plane')
    myPlane:GetComponent(typeof(UE.Renderer)).material.mainTexture = texture
    myPlane.transform.localScale = UE.Vector3(10, 1, 10)
	myPlane.transform.position = UE.Vector3(0, -0.1, 0)
    myPlane:GetComponent(typeof(UE.Renderer)).material.mainTextureScale = UE.Vector2(10, 10)

	--[[
   local lutEffect = effects.globalEffect('lut')
   effects.setLUTEffectTexture(lutEffect, 'Dark-Knight')
   lutEffect.enabled:Override(true)
   lutEffect.Contrast:Override(true)
   lutEffect.Contrast.value = 1.0
   --]]
   
   local MBEffect = effects.globalEffect("simplemotionblur")
   MBEffect.enabled:Override(true)
   
   MBEffect.BlurAmount:Override(true)
   MBEffect.BlurAmount.value=0.10
   --effects.triggerGlobalEffect("simplemotionblur")
end

function update()
    effects.checkGlobalEffectInputs()
end
-- Everytime the script is reloaded the settings are applied.
applySettings();
