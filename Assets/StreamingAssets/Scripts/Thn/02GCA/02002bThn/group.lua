-- aliases --
local UE = CS.UnityEngine

--local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP')
local LFG= LF1(Group)
local LFO = require('functionsOBJ')
local RM = require('functionsROOM')

local Nagn = Members.Count
local transDur = 0.2
local TIME = 0
local gca
local numStates
local threshold
local stateUpdateTime
local colmap=UT.colMakeColorMap("parula")
local form1 = LFG.frmMakeFormation("grid", Nagn, 15, UE.Vector3(-10,0,10), 1.5, 1.5)
local nbrs1 = LFG.gcaMakeNbhd('rel2', Nagn, 15, {{-1, 0}, {1, 0}, {0, -1}, {0, 1}}, false)
local ground 
function start()
	LFO.setPos(Room:GetObject('Ground'),UE.Vector3(0,-0.6,0))
	LFO.setScale(Room:GetObject('Ground'),UE.Vector3(400,0.1,400))
	ground = RM.getObject(Room,'Ground')
	--LFO.setScale(ground,UE.Vector3(40,1,40))
	LFO.textureObj(ground,'textures/ground','checkerboard_2',50,50)



	LFG.grpSetFormation(form1)
	LFG.grpSetNeighbors(nbrs1)
	LFG.setState(112,1)
	numStates = 6
	threshold = 2
	--gca=LFG.gcaDefine({0, 1, 3}, {0, 1, 3}, numStates, threshold)
	gca=LFG.gcaDefine({1,4}, {}, numStates, threshold)
    for i=0,Nagn - 1 do
		LFG.setRotY(i,180)
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
		--LFG.setState(i,0)
    end
	--LFG.toggleIndices(true)
	onGcaStart()
end

stateUpdateTime=70
function update()
    TIME = TIME + 1

	-- STATES
	if TIME % stateUpdateTime == 0 then
		--LFG.gcaUpdate(Group,gca,"type2")
		LFG.gcaUpdate(Group,gca,"type1")
		onGcaStep()
	end

	-- COLORING
	for i = 0, Nagn-1 do
		local col1=LFG.getColor(i)
		local col2=UT.stateToColor(LFG.getState(i),numStates,colmap)
		local col = UE.Color.Lerp(col1,col2,0.1)
		LFG.setColor(i,col)
		--LFG.setColor(i,UE.Color.Lerp(LFG.getColor(i),UT.stateToColor(LFG.getState(i),numStates,colmap),0.1))
	end

	-- ANIMATION
	for i = 0, Nagn-1 do
		if LFG.getStateOld(i)~=LFG.getState(i) then
		--if TIME % stateUpdateTime == 0 then
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[181],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[194],transDur,true) end
			if LFG.getState(i)==2 then LFG.aniCrossFade(i,CLP[115],transDur,true) end
			if LFG.getState(i)==3 then LFG.aniCrossFade(i,CLP[109],transDur,true) end
			if LFG.getState(i)==4 then LFG.aniCrossFade(i,CLP[100],transDur,true) end
			if LFG.getState(i)==5 then LFG.aniCrossFade(i,CLP[118],transDur,true) end
		end
	end
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
		LFG.setColor(i,UT.stateToColor(LFG.getState(i),numStates,colmap))
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
    



--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]
