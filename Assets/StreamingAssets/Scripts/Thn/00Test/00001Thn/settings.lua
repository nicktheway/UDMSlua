-- aliases --
local UE = CS.UnityEngine
local VFX = require('effects')
local UT = require('utils')
local LF3 = require('functionsTHN')
local THN = LF3()


-- vars --
local Nagn=6
local group
function applySettings()
	UE.Screen.SetResolution(1000, 600, true, 0)
	UE.QualitySettings.SetQualityLevel(2)
	UE.Application.targetFrameRate = 30
	UE.QualitySettings.vSyncCount = 0
	UE.QualitySettings.shadows = UE.ShadowQuality.All
end

function setUp()
	group = Room:AddGroupDomain('dancers', 'group.lua')
	for i=1,Nagn do 
		group:AddMember('ybot', 'models/main')
		--group:AddMember('NeoMan', 'models/main')
	end
	group:DoScript()
	Room:InstantiateCameraRig()
	setMusic('Commer/Rapanagatun.ogg')
	
	
	--
	print(THN.roomGetGroups(Room))
	print(THN.roomGetGroups(Room))
	print(THN.roomGetObjects(Room))
	print(THN.roomGetRegDomains(Room))
	print(THN.roomGetRoomName(Room))
	print(THN.roomGetSceneName(Room))
	print(THN.roomGetScriptPath(Room))
	print(THN.roomGetGroupDomain(Room,'colorfoul'))
	print(THN.roomGetGroupDomainNames(Room)[0])
	print(THN.roomGetGroupDomain(Room,'dancers'))
	local sphere11=THN.roomMakeAndRegisterObject(Room,"ground", 'capsule', {typeof(UE.Light)}, true)
	sphere11.name="mysphereso"
	print(THN.roomGetObject(Room,"ground"))
	local objectKeys = Room:GetObjectKeys()
	print(objectKeys.Count)
	print(THN.roomGetObjectKeys(Room).Count)
	local objy1 = THN.roomMakeObject(Room,'cylinder',{},true)
	THN.roomRegiObject(Room,"genie", objy1)
	print(THN.roomGetObject(Room,"genie"))

	THN.roomAddGroupDomain(Room,'colorfoul', 'group.lua')
	newgrp=THN.roomMakeGroup(Room,'NeoMan', 'models/main', 5, 'groupnew', './group2.lua')
	local objy2 = THN.roomMakeIndivObject(Room,'NeoMan', 'models/main', 'mannew', './group2.lua')
end

function update()
    VFX.checkGlobalEffectInputs()
	UT.listenToGenericShortcuts()
end

-- Everytime the script is reloaded the settings are applied.
applySettings();


-----------------------------------------------------------------------------------------
--local volumeScale = 0.2

	--[[
	local group = Room:InstantiateGroup('xbot', 'models/main', 3, 'dancers', 'group.lua')
   local lutEffect = VFX.globalEffect('lut')
   VFX.setLUTEffectTexture(lutEffect, 'Dark-Knight')
   lutEffect.enabled:Override(true)
   lutEffect.Contrast:Override(true)
   lutEffect.Contrast.value = 1.0
   local MBEffect = VFX.globalEffect("simplemotionblur")
   MBEffect.enabled:Override(true)
   MBEffect.BlurAmount:Override(true)
   MBEffect.BlurAmount.value=0.10
   --VFX.triggerGlobalEffect("simplemotionblur")
   --]]