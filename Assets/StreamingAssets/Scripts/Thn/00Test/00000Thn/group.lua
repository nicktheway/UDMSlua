local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LF2 = require('functionsOBJ'); local LFO = LF2()
local LF3 = require('functionsTHN'); local THN = LF3()

--------------------------------------------------------------
local lights = {}
local Nagn = Members.Count
local transDur = 0.35
local cm
function start()

	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],10)
		LFO.lgtSetIntensity(lights[i],3)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end

	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, -0.1, 0))
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(50,1,50))
	--LFO.textureObj(Ground,'textures/ground','checker',50,50)
	LFO.textureObj(Ground,'textures/SciFi','FloorTiles',200,200)

		-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,0)
		LFG.setPos(i,UE.Vector3(3*math.cos(i*5.28/Nagn),0,3*math.sin(i*5.28/Nagn)))
		LFG.aniCrossFade(i,CLP[121],transDur,true)
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,30,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,0)
	end
	cm=UT.colMakeColorMap("cool")

end

--------------------------------------------------------------
local TIME = 0
local d1=2
local d2=5
function update()
    TIME = TIME + 1
	UT.printOnScreen(TIME,5,5,UE.Color.green)

	-- AGENTS
    for i=0,Nagn-1 do
	
        -- STATE
		local d0=LFG.distToAgent(i,math.fmod(i+1,Nagn))
		if d0<d1 then LFG.setState(i,1) end
		if d0>d2 then LFG.setState(i,0) end	
		LFG.setColor(i,UT.stateToColor(LFG.getState(i),2,cm),1)

		-- MOVE
		local dir=LFG.dirToAgent(i,math.fmod(i+1,Nagn))
		if LFG.getState(i)==0 then LFG.moveInDir(i,dir,0.05,true) 
		elseif LFG.getState(i)==1 then LFG.moveInDir(i,-dir,0.05,true)  
		end

		-- ANIM
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[177],transDur,true) end
			if LFG.getState(i)==2 then LFG.aniCrossFade(i,CLP[121],transDur,true) end
		end

	end

end
--------------------------------------------------------------
--[[
-- variables
local Ground
local cube1
local sphere1
local empty1
--]]

