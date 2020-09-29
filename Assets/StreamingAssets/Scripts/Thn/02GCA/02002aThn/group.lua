-- aliases --
local UE = CS.UnityEngine

--local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP')
local LFG= LF1(Group)
local LF2 = require('functionsOBJ')
local LFO= LF2(Group)


local Nagn = Members.Count
local transDur = 0.2
local TIME = 0
local gca

local form1 = LFG.frmMakeFormation("grid", Nagn, 7, UE.Vector3(-5,0,5), 1.5, 1.5)
local nbrs1 = LFG.gcaMakeNbhd('rel2', Nagn, 7, {{-2, 0}, {2, 0}, {0, -1}, {0, 1}}, false)

function start()
	LFG.grpSetFormation(form1)
	LFG.grpSetNeighbors(nbrs1)
	LFG.setState(24,3)
	local numStates = 6
	local threshold = 2
	gca=LFG.gcaDefine({0, 1, 3}, {0, 1, 3}, numStates, threshold)
    for i=0,Nagn - 1 do
		LFG.setRotY(i,180)
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	LFG.toggleIndices(true)
	onGcaStart()
end


function update()
    TIME = TIME + 1

	-- STATES
	if TIME % 70 == 0 then
		LFG.gcaUpdate(Group,gca,"type2")
		onGcaStep()
	end
	for i = 0, Nagn-1 do
		LFG.setColor(i, stateToColor(Members[i].State))
	end

	-- ANIMATION
	for i = 0, Nagn-1 do
		col=LFG.getColor(i)
		s=LFG.getState(i)
		LFG.setColor(i,UE.Color.Lerp(col,stateToColor(s),0.05))
		if LFG.getStateOld(i)~=LFG.getState(i) then
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[187],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[ 91],transDur,true) end
			if LFG.getState(i)==2 then LFG.aniCrossFade(i,CLP[ 92],transDur,true) end
			if LFG.getState(i)==3 then LFG.aniCrossFade(i,CLP[ 94],transDur,true) end
			if LFG.getState(i)==4 then LFG.aniCrossFade(i,CLP[ 95],transDur,true) end
			if LFG.getState(i)==5 then LFG.aniCrossFade(i,CLP[ 96],transDur,true) end
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
	
	if state==0 then return UE.Color(0.0,0.0,1.0) end
	if state==1 then return UE.Color(0.7,0.0,0.3) end
	if state==2 then return UE.Color(0.8,0.0,0.2) end
	if state==3 then return UE.Color(0.9,0.0,0.1) end
	if state==4 then return UE.Color(0.9,0.0,0.0) end
	if state==5 then return UE.Color(1.0,0.0,0.0) end
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

