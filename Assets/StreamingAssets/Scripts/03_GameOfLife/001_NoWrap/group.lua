-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local anims = {}
local transforms = {}

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

function start()
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		transforms[i] = Members[i].transform
		Members[i].ColorState = true
    end
	--[[
    for i=0,Nagn-1 do
         individualPrepare(i)
    end
	--]]
	Group:SetState({34, 44, 54})
	Group:ToGridFormation(10, UE.Vector3(-5, 0, -5), 1, 1)
	Group:RegisterGridNeighbours(10)
	Group:ToggleIndices(false)
end

function update()
    local nclipId = floor(rand(1, 4.99))
    for i=0,Nagn-1 do
        individualMove(i, nclipId)
	end
    TIME = TIME + 1
	
	if TIME % 80 == 0 then
		Group:UpdateStates('gameoflife', 'B2S1')
	end
end

function individualPrepare(agentId)     
    anims[agentId]:Play(clip1, 0, 0)
end

function individualMove(agentId, nclipId)
    local myAnim = anims[agentId]
    local transform = transforms[agentId]

    if TIME%T0==T1 then 
        myAnim:CrossFade(clip1, NormTransDur);     -- animation clips change at fixed times.
    end
    if TIME%T0==T2 then
        myAnim:CrossFade(randomClips[nclipId], NormTransDur);
    end

    transform:Rotate(UE.Vector3(0, 1 + cos(w1 * TIME), 0))
    transform:Translate(UE.Vector3.forward * v1)
end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]
