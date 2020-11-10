-- aliases --
--local LM=require("math")
local UE = CS.UnityEngine
local DT = CS.DG.Tweening
local UT = require('utils')
local Clips = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ')
local ROOM = require('functionsROOM');
local LOG = require('logic');
local debug = require('debug')
local math = require('math')

-- variables
local Nagn = Members.Count

local lights = {}

local Ground
local cube1
local sphere1
local empty1

local T0=100
local NormTransDur = 0.35
local TIME = 0

local audioData = UT.newCSFloatArray(512)

function start()
	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, -0.1, 0))
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(50,1,50))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)

	-- AGENTS
	LFG.toggleIndices(false)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,1)
		LFG.setTurnToMoveDir(i,true)
		LFG.aniCrossFade(i,Clips[121],NormTransDur,true)
		LFG.trailAttach(i,UE.Vector3(0,0.1,0),UE.Color.red,0,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,15)
	end

	-- LIGHTS
	for i=0,0 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(0,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],60)
		LFO.lgtSetIntensity(lights[i],2)
		LFO.lgtSetSpotAngle(lights[i],5)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
	local ll = lights[0]:GetComponent(typeof(UE.Light))
	--DT.DOTween.To(function() return LFO.lgtGetColor(lights[0]) end, function(x) LFO.lgtSetColor(lights[0],x) end, UE.Color.red, 3);
	--DT.DOTween.To(function() return LFO.lgtGetColor(lights[0]) end, function(x) LFO.lgtSetColor(lights[0],x) end, UE.Color.red, 3);
	
end
--------------------------------------------------------------------------------
local Rx=3
local wx=0.005
local xti
local Rz=3
local wz=0.015
local zti
local phi
local REALTIME = 0.0
local PERIOD = 0.3
local MINVAL = 10
local MAXVAL = 100
local tweenSeq = DT.DOTween.Sequence()

function update()
    TIME = TIME + 1
	REALTIME = REALTIME + UE.Time.deltaTime

	-- AGENTS
    for i=0,Nagn-1 do
		phi=(i/Nagn)*6.28
		xti= math.cos(phi)*Rx*math.sin(wx*TIME)+math.sin(phi)*Rz*math.cos(wz*TIME)
		zti=-math.sin(phi)*Rx*math.sin(wx*TIME)+math.cos(phi)*Rz*math.cos(wz*TIME)
		LFG.setPos(i,UE.Vector3(xti,0,zti))
	end
	
	if REALTIME > PERIOD then
		REALTIME = 0.0
		CS.UDMS.Globals.AudioSource:GetOutputData(audioData, 0)
		local qq=UT.arrayAbsMean(audioData, 0,511)
		qq = math.min(1500*qq, MAXVAL - MINVAL) 
		--onBeat(100*qq)
		onBeat(qq)
	end
end

function onBeat(value)
	tweenSeq:Append(
--		DT.DOTween.To(function() return LFO.lgtGetIntensity(lights[0]) end, function(x) LFO.lgtSetIntensity(lights[0],x) end, value, PERIOD)
		DT.DOTween.To(function() return LFO.lgtGetSpotAngle(lights[0]) end, function(x) LFO.lgtSetSpotAngle(lights[0],x) end, MINVAL + value, PERIOD)
	)
	tweenSeq:Play()
end
--------------------------------------------------------------------------------
function onElementAnimatorMove(i)
	LFG.aniSetRootMotion(i,true)
end