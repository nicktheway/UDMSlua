local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local RM = require('functionsROOM')
local LOG = require('logic');

local Nagn = Members.Count
local nc=math.sqrt(Nagn)
local dx=1.5
local topLftCor=dx*UE.Vector3(-math.sqrt(Nagn/4),0,math.sqrt(Nagn/4))
local form1 = LFG.frmMakeFormation("grid",Nagn,nc,topLftCor,dx,dx)
local nbrs1 = LFG.gcaMakeNbhd('rel2',Nagn,nc, {{-1, 0}, {1, 0}, {0, -1}, {0, 1}}, false)
local ground 
local transDur = 0.2
local colmap=UT.colMakeColorMap("cool")


local numStates = 5
local gca
local threshold
local stateUpdateTime=70

local TIME = 0
function start()

	-- GROUND
	ground = RM.getObject(Room,'Ground')
	LFO.setPos(Room:GetObject('Ground'),UE.Vector3(0,-0.1,0))
	LFO.setScale(Room:GetObject('Ground'),UE.Vector3(40,0.1,40))
	LFO.textureObj(ground,'textures/ground','grid_1',50,50)

	-- AGENTS
	LFG.grpSetFormation(form1)
	LFG.grpSetNeighbors(nbrs1)
    for i=0,Nagn - 1 do
		LFG.setRotY(i,180)
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	--LFG.toggleIndices(true)

	--[[
	for i=nc/2-1,nc/2 do
		for j=math.floor(nc/2)-1,math.floor(nc/2) do
			LFG.setState(i*nc+j,3)
		end
	end
	--]]
	LFG.setState(math.floor(Nagn/2),3)

	threshold = 2 --1,2,3
	gca=LFG.gcaDefine({1,4}, {}, numStates, threshold)
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
		local col2=UT.stateToColor(LFG.getState(i),numStates,colmap)
		local col = UE.Color.Lerp(col1,col2,0.1)
		LFG.setColor(i,col)
	end
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
		s=LFG.getState(i)
		LFG.setColor(i,UT.stateToColor(s+1,numStates+1,colmap))
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
	UT.writeText(textToWrite, "test.log", 'w')	--UT.printOnScreen(textToWrite)
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
