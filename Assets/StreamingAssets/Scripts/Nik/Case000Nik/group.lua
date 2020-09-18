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


local form1 = Form.makeFormation("circle", Nagn, center, 4)
local nbs1  = Form.makeNbhd('rel1', Nagn, {-3, -2, -1, 0, 1}, true)


function start()
	Group:SetPositions(form1)
	Group:SetNeighbours(nbs1)
	Group:SetState({4})
	local numberOfStates = 5
	gca = CS.LuaScripting.GCA({1, 2, 4}, {}, numberOfStates)
	
    for i=0,Nagn - 1 do
		LF.setColor(i,UE.Color.red)
		LF.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	
	--Group:ToggleIndices(true)

	onGcaStep()
end


function update()
    TIME = TIME + 1
	
	if TIME % 50 == 0 then
		Group:GCAUpdate(gca)
		onGcaStep()
	end
	
	for i = 0, Nagn-1 do
		local dir = Members[i]:DirAgentToPnt(center)
		if Members[i].State <= 0 then
			dir = -dir
		end
		Members[i]:MoveInDir(dir, 0.02)
	end
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

