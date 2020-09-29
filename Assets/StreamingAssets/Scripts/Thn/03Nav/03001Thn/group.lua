-- aliases --
local UE = CS.UnityEngine

local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP')
local LFG = LF1(Group)
local LF2 = require('functionsOBJ')
local LFO = LF2(Group)

local anims = {}
local renderers = {}
local agents = {}
local posOld = {}

local Nagn = Members.Count
local surface
local obstacles = {}
local targets = {}
local TIME = 0
local transDur = 0.2
local d1
local nc=31
local c=100

local filepath = 'test.log'
local form1=LFG.frmMakeFormation("grid",Nagn, nc, UE.Vector3(-31,0,31), 2, 2)

function start()
	LFG.grpSetFormation(form1)
	LFG.grpSetStates({1})
	local ground = Room:GetObject('Ground')
	LFO.setScale(ground,UE.Vector3(c,1,c))
	surface = LFG.navAddSurface(ground)
	for n=1,4 do
		obstacles[n]=LFO.makeObject(Room,'cube'..tostring(n),'cube','cube',UE.Vector3(5*n-10, 0.5, 1))
		LFO.setParent(obstacles[n],ground)
		LFO.setScale(obstacles[n],UE.Vector3(1, c,10)/c)
		LFO.setRot(obstacles[n],UE.Vector3(0,90*n,0))
	end
	LFG.navBakeSurface(surface)
	
    for i=0,Nagn - 1 do
		LFG.setPos(i,UE.Vector3(10, 0, -10*i))
		anims[i]=LFG.aniGetAnimator(i)
		renderers[i]=LFG.grpGetRenderers(i)
		LFG.navAttachAgent(i)
		LFG.navSetSpeed(i,8)
		LFG.navSetDestination(i, UE.Vector3(-10, 0, -10*i))
		targets[i]=LFO.makeObject(Room,'target'..tostring(i),'target','sphere',UE.Vector3(-10, 0.5, -10*i))
		LFO.setScale(targets[i],UE.Vector3(0.2, 0.2,0.2))
		LFG.navActive(i, true)
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
		LFG.aniCrossFade(i,CLP[180],transDur,true)
    end
	LFG.setColor(3,UE.Color.blue)
	LFG.navSetSpeed(3, 3)
	LFG.setColor(4,UE.Color.green)
	LFG.navSetSpeed(4, 2)
end


function update()
    TIME = TIME + 1
	
	-- REBAKE NAVMESH
	if TIME%20 == 0 then
		LFG.navBakeSurface(surface)
	end

	-- MOVEMENT
	for n=1,4 do
		LFO.turnUp(obstacles[n],0.5)
	end
	if TIME%500 == 0 then
		for i=0,Nagn-3 do
			LFG.navSetDestination(i, -LFG.navGetDestination(i))
		end
	end
	LFG.navToAgent(3,2)
	LFG.navToAgent(4,3)

	-- STATE
	for i=0,Nagn-1 do
		if 	LFG.navGetVelocity(i).magnitude<0.2 then 
			LFG.setState(i,0) 
		else
			LFG.setState(i,1) 
		end
		print(LFG.getState(i))
	end
	if TIME % 50 == 0 then
		local textToWrite = ""
		for i=0,Nagn-1 do
			textToWrite = textToWrite..Members[i].State
		end
	end

	-- ANIMATION
	for i=0,Nagn-1 do
		d1=LFG.aniGetClipTime(i)/LFG.aniGetClipLength(i)
		if 	LFG.getState(i)==0 and d1<0.9 then LFG.aniCrossFade(i,CLP[180],transDur,true) end
		if 	LFG.getState(i)==1 and d1>0.9 then LFG.aniCrossFade(i,CLP[200],transDur,true) end
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

