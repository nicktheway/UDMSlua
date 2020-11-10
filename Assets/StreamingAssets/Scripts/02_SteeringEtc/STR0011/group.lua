-- aliases --
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
local sid=10

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
		--LFG.setPos(i,UE.Vector3(3*math.cos(i*5.28/Nagn),0,3*math.sin(i*5.28/Nagn)))
		LFG.setPos(i,UE.Vector3(sid*math.random(-10,10)/10,0,sid*math.random(-10,10)/10))
		LFG.setRotY(i,math.random(-180,180))
		LFG.aniCrossFade(i,Clips[121],NormTransDur,true)
	end

	-- LIGHTS
	for i=0,0 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(0,6,0),UE.Vector3(90,0,0))	LFO.lgtSetRange(lights[i],60)
		LFO.lgtSetIntensity(lights[i],2)
		LFO.lgtSetRange(lights[i],20)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
end
--------------------------------------------------------------------------------
local dir
local dir1
local dir2
local dist
local pos
local k=1.0
local wr=0.5
local d0=2
local d1=0.25
function update()
    TIME = TIME + 1

	-- AGENTS
    for i=0,Nagn-1 do

		dir=LFG.dirMine(i)
		if LFG.distToNearest(i)<d0 then
			if LFG.distToNearest(i)>d1 then
				dir=dir+LFG.dirOfNearest(i)
			else
				dir=dir-LFG.dirOfNearest(i)
			end
		end
		pos=LFG.getPos(i)
		if pos.x> sid then LFG.setPos(i,UE.Vector3(pos.x-2*sid,pos.y,pos.z)) end
		if pos.x<-sid then LFG.setPos(i,UE.Vector3(pos.x+2*sid,pos.y,pos.z)) end
		if pos.z> sid then LFG.setPos(i,UE.Vector3(pos.x,pos.y,pos.z-2*sid)) end
		if pos.z<-sid then LFG.setPos(i,UE.Vector3(pos.x,pos.y,pos.z+2*sid)) end
		--if i==0 then print(TIME,i,pos) end

		LFG.turnToDirSoft(i,dir,wr)
		--LFG.turnToDir(i,dir,wr)
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
function onElementAnimatorMove(i)
	LFG.aniSetRootMotion(i,true)
end
