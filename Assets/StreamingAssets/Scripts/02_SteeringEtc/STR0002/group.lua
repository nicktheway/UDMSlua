-- aliases --
--local LM=require("math")
local UE = CS.UnityEngine
local UT = require('utils')
local Clips = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ')
local ROOM = require('functionsROOM');
local LOG = require('logic');
local debug = require('debug')

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

function start()
	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, -0.1, 0))
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(50,1,50))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)

	-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,1)
		--LFG.setPos(i,UE.Vector3(3*math.cos(i*5.28/Nagn),0,3*math.sin(i*5.28/Nagn)))
		LFG.setPos(i,UE.Vector3(3*math.random(-1,1),0,3*math.random(-1,1)))
		LFG.aniCrossFade(i,Clips[121],NormTransDur,true)
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,0,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		--LFG.trailSetTime(i,5)
	end

	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],60)
		LFO.lgtSetIntensity(lights[i],2)
		LFO.lgtSetSpotAngle(lights[i],155)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
end
--------------------------------------------------------------------------------
local d1=0.5
local d2=3
local dir
local dir2
local k=1.0
local wr=2
function update()
    TIME = TIME + 1

	-- AGENTS
    for i=0,Nagn-1 do

        -- STATE
		local d0=LFG.distToAgent(i,math.fmod(i+1,Nagn))
		if d0<d1 then LFG.setState(i,2) end
		if d0>d2 then LFG.setState(i,1) end	
		if LFG.getState(i)==1 then LFG.setColor(i,UE.Color.blue,0) end
		if LFG.getState(i)==2 then LFG.setColor(i,UE.Color.red,0) end

        -- MOVE
		dir=LFG.dirToAgent(i,math.fmod(i+1,Nagn))
		dir2=-dir
		--dir2.x=dir.z
		--dir2.z=dir.x
		if LFG.getState(i)==1 then LFG.turnToDirSoft(i,dir,wr)
		elseif LFG.getState(i)==2 then LFG.turnToDirSoft(i,(1-k)*dir+k*dir2,wr)  
		end
		LFG.moveFwd(i,0.05)

		-- ANIM
		if LFG.getStateOld(i)~=LFG.getState(i) then
		local s=LFG.getState(i)
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,Clips[177],NormTransDur,true) end
			if LFG.getState(i)==2 then LFG.aniCrossFade(i,Clips[121],NormTransDur,true) end
		end
		-- 200, 240, 261
	end
end
--------------------------------------------------------------------------------
--[[ Root motion is off :
local anims = {}
function onElementAnimatorMove(i)
    anims[i]:ApplyBuiltinRootMotion()
end
--]]
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
