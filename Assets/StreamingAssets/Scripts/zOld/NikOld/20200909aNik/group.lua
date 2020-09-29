-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local Form = require('formations')
local debug = require('debug')
local extras = require('extras')
local Clips = require('animations')

local anims = {}
local transforms = {}
local renderers = {}

local clip1 = 'Sneak Walk1'
local clip2 = 'Jazz Dancing01'
local randomClips = {'Jazz Dancing01', 'Jazz Dancing02', 'Jazz Dancing03', 'Jazz Dancing04'}

local Nagn = Members.Count

local R0 = 1
local Rads = {4, 6, 8, 10}
local T0, T1, T2 = 400, 0, 300
local v1, w1, a1 = 0.01, 3.14159/100, 1;
local NormTransDur = 0.2
local TIME = 0

local gca = CS.LuaScripting.GCA({1,3}, {}, 4)


function start()
	Group:SetPositions(Form.circlePoints(UE.Vector3(0, 1, 0), 4, Nagn))
	Group:SetNeighbours(Form.relativeNeighbours({-2, -1, 0, 1, 2}, Nagn))
	Group:SetState({0})

    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		renderers[i] = Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
		transforms[i] = Members[i].transform
		Members[i].ColorState = false
		Members[i].transform:LookAt(UE.Vector3(0,1,0))
    end
	--[[
    for i=0,Nagn-1 do
         individualPrepare(i)
    end
	--]]
	-- Group:SetState({34, 44, 54})
	
	
	-- Group:ToGridFormation(10, UE.Vector3(-5, 0, 5), 1, 1)
	-- Group:RegisterGridNeighbours(10)
	Group:ToggleIndices(true)
end


function update()
    --local nclipId = floor(rand(1, 4.99))
    for i=0,Nagn-1 do
        --
	end
    TIME = TIME + 1

	
	if TIME % 50 == 0 then
		--Group:UpdateStates('gameoflife', 'B2S1')
		Group:GCAUpdate(gca)
		local file = io.open('test.log', 'a')
		io.output(file)
		local textToWrite = ""
		for i=0,Nagn-1 do
			renderers[i][1].material.color = stateToColor(Members[i].State)
			textToWrite = textToWrite..Members[i].State
			individualAnimate(i)
		end
		extras.printOnScreen(textToWrite)
		io.write(TIME.." "..textToWrite.."\n")
		io.close(file)
	end
	
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

function individualPrepare(agentId)     
    anims[agentId]:Play(clip1, 0, 0)
end

function individualAnimate(agentId)
    local myAnim = anims[agentId]
	local myState = Members[agentId].State

    if myState==0 then  myAnim:CrossFade(Clips[36], NormTransDur) end
    if myState==1 then  myAnim:CrossFade(Clips[39], NormTransDur) end
    if myState==2 then  myAnim:CrossFade(Clips[41], NormTransDur) end
    if myState==3 then  myAnim:CrossFade(Clips[33], NormTransDur) end
end
function individualMove(agentId, nclipId)
    transform:Rotate(UE.Vector3(0, 1 + cos(w1 * TIME), 0))
    transform:Translate(UE.Vector3.forward * v1)
end
--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]
