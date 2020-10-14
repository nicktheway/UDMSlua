-- aliases --
local UE = CS.UnityEngine
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local ROOM = require('functionsROOM');
local LOG = require('logic');


local Nagn = Members.Count
local transDur = 0.1
local gca
local nbrs1  = LFG.gcaMakeNbhd('rel1', Nagn, {-3, -2, -1, 0, 1}, true)
local center0 = {}
local center1 = {}
local lights = {}
local numStates = 5
local R0=7
local R1=5
local stateUpdateTime=50

local TIME = 0
function start()

	-- GROUND
	local Ground=ROOM.getObject(Room, "Ground")
	LFO.setPos(Ground,UE.Vector3(0,-0.5,0))
	LFO.setScale(Ground,UE.Vector3(40,1,40))
	LFO.textureObj(Ground,'textures/ground','grid_1',5,5)
	
	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],20)
		LFO.lgtSetIntensity(lights[i],3)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end

	-- AGENTS
	LFG.grpSetNeighbors(nbrs1)
	gca=LFG.gcaDefine({1, 2, 4}, {}, numStates)
    for i=0,Nagn - 1 do
		LFG.setColor(i,UE.Color.red)
		--LFG.attachTrail(i, UE.Color.red, 10, 0.05)
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red, 0, 0.05)
		LFG.trailSetStartWidth(i,0.01)
		LFG.trailSetEndWidth(i,0.04)
		LFG.trailSetStartColor(i,UE.Color.yellow)
		LFG.trailSetEndColor(i,UE.Color.red)
		center0[i]=R0*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
		center1[i]=R1*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
		LFG.setState(i,0)
		LFG.setPos(i,center0[i])
		LFG.aniCrossFade(i,CLP[121],transDur,true)
    end
	LFG.setState(0,1)
	LFG.setState(5,1)
	LFG.toggleIndices(true)
	onGcaStart()
end


function update()
    TIME = TIME + 1

	-- STATES
	if TIME % stateUpdateTime == 0 then
		LFG.gcaUpdate(Group,gca,"type1")
		onGcaStep()
	end
	
	-- MOVES
	for i = 0, Nagn-1 do
		if LFG.getState(i)<=1 then 
			--LFG.setDir(i,LFG.dirAgentToPnt(i,center0[i]))
			--LFG.turnToPnt(i,center0[i],2)
			if LFG.distAgentToPnt(i,center0[i])>0.1 then 
				LFG.turnToDir(i,LFG.dirAgentToPnt(i,center0[i]),10)
				LFG.moveFwd(i,0.05) 
			else 
				LFG.turnToDir(i,LFG.dirAgentToPnt(i,center1[i]),5) 
			end
		else 
			--LFG.setDir(i,LFG.dirAgentToPnt(i,center1[i]))
			--LFG.turnToPnt(i,center1[i],2)
			LFG.turnToDir(i,LFG.dirAgentToPnt(i,center1[i]),10)
			if LFG.distAgentToPnt(i,center1[i])>0.1 then LFG.moveFwd(i,0.05) end
		end
	end

	-- ANIMATION
	for i = 0, Nagn-1 do
		col=LFG.getColor(i)
		s=LFG.getState(i)
		LFG.setColor(i,UE.Color.Lerp(col,stateToColor(s,colmap),0.05))
		if LFG.getState(i)<=1 then 
			if LFG.distAgentToPnt(i,center0[i])>0.1 then
				--if LFG.aniGetClipName(i)~=CLP[177] then 
					LFG.aniCrossFadeDiff(i,CLP[177],0.01,true)
				--end
			else
				--if LFG.aniGetClipName(i)~=CLP[182] then 
					LFG.aniCrossFadeDiff(i,CLP[182],0.01,true) 
				--end
			end
		else
			if LFG.distAgentToPnt(i,center1[i])>0.1 then
				--if LFG.aniGetClipName(i)~=CLP[121] then 
					LFG.aniCrossFadeDiff(i,CLP[121],0.01,true)
				--end
			else
				--if LFG.aniGetClipName(i)~=CLP[109] then 
					LFG.aniCrossFadeDiff(i,CLP[109],0.01,true) 
				--end
			end
		end
	end
	--[[
	for i = 0, Nagn-1 do
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[177],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[121],transDur,true) end
		end
	end
	--]]
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..LFG.getState(i)
		LFG.setColor(i,stateToColor(LFG.getState(i),colmap))
	end
	textToWrite = textToWrite..'\n'
	--UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
	end
	textToWrite = textToWrite..'\n'
	--UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onDestroy()
	UT.closeAllFiles()
end

function stateToColor(state)
	
	if state==0 then return UE.Color.white end
	if state==1 then return UE.Color.yellow end
	if state==2 then return UE.Color.red end
	if state==3 then return UE.Color.blue end
	if state==4 then return UE.Color.cyan end
	if state==5 then return UE.Color.green end
	if state==6 then return UE.Color.gray end
	if state==7 then return UE.Color.magenta end
	if state==8 then return UE.Color.yellow end
	if state==9 then return UE.Color.white end
	
	return UE.Color.white
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

