-- aliases --
local UE = CS.UnityEngine

--local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP')
local LFG = LF1(Group)
local LF2 = require('functionsOBJ')
local LFO = LF2(Group)

local Nagn = Members.Count
local transDur = 0.2
local TIME = 0
local gca

--local form1 = LFG.frmMakeFormation("circle", Nagn, UE.Vector3.zero, 4)
local nbrs1  = LFG.gcaMakeNbhd('rel1', Nagn, {-3, -2, -1, 0, 1}, true)
local center0 = {}
local center1 = {}
local col

function start()
	--LFG.grpSetFormation(form1)
	--LFG.grpSetStates({4})
	LFG.grpSetNeighbors(nbrs1)
	local numStates = 5
	gca=LFG.gcaDefine({1, 2, 4}, {}, numStates)
    for i=0,Nagn - 1 do
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
		center0[i]=7*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
		center1[i]=4*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
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
	if TIME % 60 == 0 then
		LFG.gcaUpdate(Group,gca,"type1")
		onGcaStep()
	end
	
	-- MOVES
	for i = 0, Nagn-1 do
		--print(i,LFG.dirOfAgent(i))
		if LFG.getState(i)==0 then 
			LFG.setDir(i,LFG.dirAgentToPnt(i,center0[i]))
			--LFG.turnToPnt(i,center0[i],2)
			--LFG.turnToDir(i,LFG.dirAgentToPnt(i,center0[i]),2)
			if LFG.distAgentToPnt(i,center0[i])>0.001 then LFG.moveFwd(i,0.05) end
		else 
			LFG.setDir(i,LFG.dirAgentToPnt(i,center1[i]))
			--LFG.turnToPnt(i,center1[i],2)
			--LFG.turnToDir(i,LFG.dirAgentToPnt(i,center1[i]),2)
			if LFG.distAgentToPnt(i,center1[i])>0.001 then LFG.moveFwd(i,0.05) end
		end
	end

	-- ANIMATION
	for i = 0, Nagn-1 do
		col=LFG.getColor(i)
		s=LFG.getState(i)
		LFG.setColor(i,UE.Color.Lerp(col,stateToColor(s),0.05))
		if LFG.getStateOld(i)~=LFG.getState(i) then
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[177],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[121],transDur,true) end
		end
	end
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
		LFG.setColor(i,stateToColor(state))
	end
	textToWrite = textToWrite..'\n'
	UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
	end
	textToWrite = textToWrite..'\n'
	UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onDestroy()
	UT.closeAllFiles()
end

function stateToColor(state)
	
	if state==0 then return UE.Color(0.0,0.0,1.0) end
	if state==1 then return UE.Color(0.7,0.0,0.3) end
	if state==2 then return UE.Color(0.8,0.0,0.2) end
	if state==3 then return UE.Color(0.9,0.0,0.1) end
	if state==4 then return UE.Color(1.0,0.0,0.0) end
	if state==5 then return UE.Color(0.75, 0.75, 0.5) end
	if state==6 then return UE.Color(0, 0, 1) end
	if state==7 then return UE.Color(0, 0, 1) end
	if state==8 then return UE.Color(0, 0, 1) end
	if state==9 then return UE.Color(1, 0, 0) end
	
	return UE.Color(0,0,1)
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

