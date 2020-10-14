local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local ROOM = require('functionsROOM');
local LOG = require('logic');

local Nagn = Members.Count
local center = UE.Vector3.zero
local h = math.floor(math.log(Nagn)/math.log(2))
local leaves = (Nagn+1) // 2
local lights = {}

local ground 
local transDur = 0.2
local cm=UT.colMakeColorMap("cool")

local numStates = 3 --2
local gca
local threshold
local stateUpdateTime=50

local TIME = 0
function start()

	--GROUND
	ground = ROOM.getObject(Room, 'Ground')
	LFO.setScale(ground,UE.Vector3(40,1,40))
	LFO.textureObj(ground,'textures/Ground','grid_1',50,50)

	--[[
	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,13),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],30)
		LFO.lgtSetIntensity(lights[i],3)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
	--]]

	-- AGENTS
	local form1 = treePos(Nagn, h, leaves)
	local nbrs1  = treeNeighbours()
	LFG.grpSetFormation(form1)
	LFG.grpSetNeighbors(nbrs1)
    for i=0,Nagn - 1 do
		LFG.setRotY(i,180)
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	--LFG.toggleIndices(true)
	LFG.setState(0,1)
	threshold = 2 --1,2,3
	gca=LFG.gcaDefine({1, 2, 3}, {}, numStates, threshold)
	onGcaStart()
end

function update()
    TIME = TIME + 1

	-- STATES
	if TIME % stateUpdateTime == 0 then
		LFG.gcaUpdate(Group,gca,"type1")
		onGcaStep()
	end

	-- ANIMATION+COLORING
	for i = 0, Nagn-1 do
		if LFG.getStateOld(i)~=LFG.getState(i) then
			if LFG.getState(i)==0 then LFG.aniCrossFade(i,CLP[187],transDur,true) end
			if LFG.getState(i)==1 then LFG.aniCrossFade(i,CLP[ 91],transDur,true) end
			if LFG.getState(i)==2 then LFG.aniCrossFade(i,CLP[ 92],transDur,true) end
			if LFG.getState(i)==3 then LFG.aniCrossFade(i,CLP[ 94],transDur,true) end
			if LFG.getState(i)==4 then LFG.aniCrossFade(i,CLP[ 94],transDur,true) end
			if LFG.getState(i)==5 then LFG.aniCrossFade(i,CLP[ 94],transDur,true) end
		end
		local col1=LFG.getColor(i)
		local col2=UT.stateToColor(LFG.getState(i),numStates,cm)
		local col = UE.Color.Lerp(col1,col2,0.1)
		LFG.setColor(i,col)
	end
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
		s=LFG.getState(i)
		LFG.setColor(i,UT.stateToColor(s+1,numStates+1,cm))
	end
	textToWrite = textToWrite..'\n'
	UT.writeText(textToWrite, "test.log", 'w')	--UT.printOnScreen(textToWrite)
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
	end
	textToWrite = textToWrite..'\n'
	UT.writeText(textToWrite, "test.log", 'w') --UT.printOnScreen(textToWrite)
end

function onDestroy()
	UT.closeAllFiles()
end

function treePos(n, height, l)
	local pos = {}
	local offsetX=0
	local offsetZ=10
	for i = 1, n do
		local level = math.floor(math.log(i)/math.log(2))
		local maxX = 2^(height+1-level) * (2^level - 1) 
		local xpos = 2^(height+1-level) * (i % 2^level) - maxX / 2 +offsetX
		local zpos = -level * 3  +offsetZ
		
		pos[i] = UE.Vector3(xpos, 0, zpos)
	end
	
	return pos
end

function treeNeighbours()
	local nbrs = {}	
	for i = 1, Nagn do
		nbrs[i] = {}
		local id = i - 1
		local nCount = 1
		if i*2 <= Nagn then nbrs[i][nCount] = i * 2 - 1; nCount = nCount + 1 end
		if i*2 + 1 <= Nagn then nbrs[i][nCount] = i * 2; nCount = nCount + 1 end
		if i // 2 > 0 then nbrs[i][nCount] = i // 2 - 1; nCount = nCount + 1 end
	end
	return nbrs
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]




