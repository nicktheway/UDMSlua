-- aliases --
local UE = CS.UnityEngine

local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local Clips = require('animations')
local LFF = require('functions')
local LF = LFF(Group)


local Nagn = Members.Count

local NormTransDur = 0.2
local TIME = 0

local gca

local center = UE.Vector3.zero
local h = math.floor(math.log(Nagn)/math.log(2))
local leaves = (Nagn+1) // 2





function start()
	local form1 = treePos(Nagn, h, leaves)
	local nbs1  = treeNeighbours()

	Group:SetPositions(form1)
	Group:SetNeighbours(nbs1)
	Members[0].State = 1
	local numberOfStates = 2
	gca = CS.LuaScripting.GCA({1, 2, 3}, {}, numberOfStates)
	
    for i=0,Nagn - 1 do
		LF.setColor(i,UE.Color.red)
		LF.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	
	Group:ToggleIndices(true)

	onGcaStep()
end


function update()
    TIME = TIME + 1
	
	if TIME % 50 == 0 then
		Group:GCAUpdate(gca)
		onGcaStep()
	end
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
		LF.setColor(i, stateToColor(Members[i].State))
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

function treePos(n, height, l)
	local pos = {}
	
	for i = 1, n do
		local level = math.floor(math.log(i)/math.log(2))
		local maxX = 2^(height+1-level) * (2^level - 1)
		local xpos = 2^(height+1-level) * (i % 2^level) - maxX / 2
		local zpos = -level * 3
		
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


