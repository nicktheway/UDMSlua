-- aliases --
local UE = CS.UnityEngine

local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local ROOM = require('functionsROOM');
local LOG = require('logic');

local anims = {}
local renderers = {}
local agents = {}
local posOld = {}

local Nagn = Members.Count
local surface
local obstacles = {}
local targets = {}
local transDur = 0.2
local filepath = 'test.log'
local nc=31
local form1=LFG.frmMakeFormation("grid",Nagn, nc, UE.Vector3(-31,0,31), 2, 2)

local TIME = 0
function start()

	--ground
	local ground = ROOM.getObject(Room, 'Ground')
	LFO.setScale(ground,UE.Vector3(20,1,20))
	LFO.textureObj(ground,'textures/ground','grid_1',50,50)
	surface = LFG.navAddSurface(ground)
	
	-- obstacles
	for n=1,6 do
		obstacles[n]=LFO.makeObject(Room,'cube'..tostring(n),'cube','cube',UE.Vector3(0,0,0))
		LFO.setScale(obstacles[n],UE.Vector3(0.5, 4,20))
		LFO.textureObj(obstacles[n],'textures/ground','grid_2',40,40)
	end
	LFO.setPos(obstacles[1],UE.Vector3(-10,0, 0))
	LFO.setPos(obstacles[2],UE.Vector3( 10,0, 0))
	LFO.setPos(obstacles[3],UE.Vector3( 0,0, 10))
	LFO.setRot(obstacles[3],UE.Vector3(0,90, 0))
	LFO.setPos(obstacles[4],UE.Vector3( 0,0,-10))
	LFO.setRot(obstacles[4],UE.Vector3(0,90, 0))
	LFO.setRot(obstacles[5],UE.Vector3(0,90, 0))
	LFO.setScale(obstacles[5],UE.Vector3(0.5, 4,14))
	LFO.setScale(obstacles[6],UE.Vector3(0.5, 4,14))
	for n=1,6 do
		LFO.setParent(obstacles[n],ground)
	end
	LFG.navBakeSurface(surface)

	-- agents
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setPos(i,UE.Vector3(7, 0, 0+1*i))
		anims[i]=LFG.aniGetAnimator(i)
		renderers[i]=LFG.grpGetRenderers(i)
		LFG.navAttachAgent(i)
		LFG.navSetSpeed(i,8)
		LFG.navActive(i, true)
		LFG.setColor(i,UE.Color.red,1)
		--LFG.attachTrail(i, UE.Color.green, 10, 0.02)
		--LFG.trailAttach(i,UE.Vector3(0,0.4,0),UE.Color.green, 10, 0.02)
		LFG.aniCrossFade(i,CLP[180],transDur,true)
    end
	LFG.setColor(0,UE.Color.blue,1)
	LFG.setColor(1,UE.Color.red,1)
	LFG.setColor(2,UE.Color.magenta,1)
	LFG.setColor(3,UE.Color.cyan,1)
	LFG.setColor(4,UE.Color.yellow,1)
	LFG.navSetSpeed(4, 3)
	--LFG.trailSetTime(4,0)

	-- targets
    for i=0,3 do
		targets[i]=LFO.makeObject(Room,'target'..tostring(i),'target','sphere',UE.Vector3(0,0,0))
		LFO.setScale(targets[i],UE.Vector3(0.5, 0.5,0.5))
		LFG.navSetDestination(i,LFO.getPos(targets[i]))
	end
	LFO.setPos(targets[0],UE.Vector3( 2,0.25, 2))
	LFO.setPos(targets[1],UE.Vector3( 2,0.25,-2))
	LFO.setPos(targets[2],UE.Vector3(-2,0.25, 2))
	LFO.setPos(targets[3],UE.Vector3(-2,0.25,-2))
	LFO.setColor(targets[0],UE.Color.blue,1)
	LFO.setColor(targets[1],UE.Color.red,1)
	LFO.setColor(targets[2],UE.Color.magenta,1)
	LFO.setColor(targets[3],UE.Color.cyan,1)

end


--local d1
function update()
    TIME = TIME + 1
	print(TIME)
	
	-- REBAKE NAVMESH
	if TIME%20 == 0 then
		LFG.navBakeSurface(surface)
	end

	-- MOVEMENT
	for n=5,6 do
		LFO.turnUp(obstacles[n],0.15)
	end
	if TIME%200 == 0 then
		for i=0,Nagn-2 do
			LFO.setPosX(targets[i],-LFO.getPosX(targets[i]))
			LFO.setPosZ(targets[i],-LFO.getPosZ(targets[i]))
			LFG.navSetDestination(i,LFO.getPos(targets[i]))
		end
	end
	LFG.navToAgent(4,3)

	-- STATE
	for i=0,Nagn-1 do
		if 	LFG.navGetVelocity(i).magnitude<0.2 then 
			LFG.setState(i,0) 
		else
			LFG.setState(i,1) 
		end
		--print(LFG.getState(i))
	end
	if TIME % 50 == 0 then
		local textToWrite = ""
		for i=0,Nagn-1 do
			textToWrite = textToWrite..Members[i].State
		end
	end

	-- ANIMATION
	for i=0,Nagn-1 do
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[180],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[200],transDur,true) end
		end
	end
end

function onDestroy()
	UT.closeAllFiles()
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

