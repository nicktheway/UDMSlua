-- aliases --
--local LM=require("math")
local UE = CS.UnityEngine
local UT = require('utils')
local Clips = require('animations')
local LF1 = require('functionsGRP')
local LFG = LF1(Group)
local LF2 = require('functionsOBJ')
local LFO = LF2()
local LF3 = require('functionsTHN')
local THN = LF3()
local Form = require('formations')
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
	LFO.textureObj(Ground,'textures/ground','checker',50,50)

	-- OBJECTS
	cube1=LFO.makeObject(Room,"Cube1","Cube1","cube",UE.Vector3(0, -0.1, 0))
	LFO.setPos(cube1,UE.Vector3(5,-0.2,5))
	LFO.setScale(cube1,UE.Vector3(1,1,1))
	LFO.setColor(cube1,UE.Color.red)

	sphere1=LFO.makeObject(Room,"Sphere1","Sphere1","sphere",UE.Vector3(0, -0.1, 0))
	LFO.setPos(sphere1,UE.Vector3(-5,-0.2,-5))
	LFO.setScale(sphere1,UE.Vector3(0.5,2,0.5))
	LFO.textureObj(sphere1,'textures/ground','lgreen_grid',0.5,0.5)

	empty1=LFO.makeObject(Room,"Empty1","Empty1",nil,UE.Vector3(0, -0.1, 0))
	LFO.setPos(sphere1,UE.Vector3(5,-0.2,-5))

	LFO.setPosX(cube1,3)
	LFO.setPosY(cube1,1.5)
	LFO.setPosZ(cube1,3)

	LFO.trailAttach(cube1,UE.Vector3(0,0.1,0),UE.Color.red,10,0.07)

	--[[
	LFO.turnFwd(cube1,45)
	LFO.turnRght(cube1,0)
	LFO.turnUp(cube1,225)
	light0=LFO.lgtAttach(cube1,"point")
	LFO.lgtSetIntensity(light0,3)
	LFO.lgtSetRange(light0,6)
	--]]
	
	--print(LFO.getDirMine(cube1))
	--print(LFO.getDirToPnt(cube1,UE.Vector3(0,0,0)))
	--print(LFO.getDistToPnt(cube1,UE.Vector3(0,0,0)))

	-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,1)
		LFG.setPos(i,UE.Vector3(3*math.cos(i*5.28/Nagn),0,3*math.sin(i*5.28/Nagn)))
		LFG.aniCrossFade(i,Clips[121],NormTransDur,true)
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,30,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,5)
	end

	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],10)
		LFO.lgtSetIntensity(lights[i],3)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
end
--------------------------------------------------------------------------------
function update()
    TIME = TIME + 1

	-- OBJECTS
	LFO.turnToDir2(cube1,UE.Vector3(math.cos(0.031*TIME),0,math.sin(0.021*TIME)),1)
	LFO.moveFwd(cube1,0.1)
	--LFO.turnToPnt(cube1,UE.Vector3(2,0,3),1)
	--LFO.moveInDir(cube1,UE.Vector3(-1,0,-1),0.03)  --,1)

	-- AGENTS
    for i=0,Nagn-1 do
        agentState(i)
        agentMove(i)
		agentAnim(i)
	end
	--UT.printOnScreen(LFG.getState(0)..LFG.getState(1)..LFG.getState(2)..LFG.getState(3))
	--print(LFG.getState(0)..LFG.getState(1)..LFG.getState(2)..LFG.getState(3))

	-- LIGHTS
	--LFO.lgtSetSpotAngle(lights[0],45*(2+math.cos(0.05*TIME)))
	--LFO.lgtSetSpotAngle(lights[1],45*(2+math.sin(0.05*TIME)))

end
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
local d1=2
local d2=3
function agentState(i)
	local d0=LFG.distToAgent(i,math.fmod(i+1,Nagn))
	if d0<d1 then LFG.setState(i,2) end
	if d0>d2 then LFG.setState(i,1) end	
	if LFG.getState(i)==1 then LFG.setColor(i,UE.Color.blue,1) end
	if LFG.getState(i)==2 then LFG.setColor(i,UE.Color.red,1) end
end
--------------------------------------------------------------------------------
function agentMove(i)
	local dir=LFG.dirToAgent(i,math.fmod(i+1,Nagn))
	if LFG.getState(i)==1 then LFG.moveInDir(i,dir,0.05,true) 
	elseif LFG.getState(i)==2 then LFG.moveInDir(i,-dir,0.05,true)  
	end
end
--------------------------------------------------------------------------------
function agentAnim(i)
	if LFG.getStateOld(i)~=LFG.getState(i) then
	local s=LFG.getState(i)
		if LFG.getState(i)==1 then LFG.aniCrossFade(i,Clips[177],NormTransDur,true) end
		if LFG.getState(i)==2 then LFG.aniCrossFade(i,Clips[121],NormTransDur,true) end
	end
	-- 200, 240, 261
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
