-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local max = UE.Mathf.Max
local min = UE.Mathf.Min
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local lt00 = UE.GameObject("Light00")
local lt000 = lt00:AddComponent(typeof(UE.Light))
local lt01 = UE.GameObject("Light01")
local lt010 = lt01:AddComponent(typeof(UE.Light))


local anims = {}
local transforms = {}
local meshes = {}
local State = {}
local StateOld = {}

local ClId={'Crouch Idle01','Offensive Idle','Standing Idle01','Standing Idle03','Idle02'}
local ClMv = {'Jazz Dancing01', 'Jazz Dancing02', 'Jazz Dancing03', 'Jazz Dancing04'}
local ClDn = {'salsa_dancing_0','salsa_dancing_1','bboy_hip_hop_move','bboy_hip_hop_move_1','hip_hop_dancing','flair_1','dancing'}

local Nagn = Members.Count

local R0 = 1
local Rads = {4, 6, 8, 10}
local T0=100
local T1=0
local T2=300
local v1, w1, a1 = 0.01, 3.14159/100, 1;
local NormTransDur = 0.35
local TIME = 0
local TCam=UE.GameObject.FindWithTag("ThanCam") 

function start()
	lt00.transform.position=UE.Vector3(5,5,-10)
	lt000.range=100
	lt000.intensity=2
	lt01.transform.position=UE.Vector3(5,5,-2)
	lt010.range=100
	lt010.intensity=2

    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		transforms[i] = Members[i].transform
		Members[i].ColorState = false
		meshes[i]=Members[i]:GetComponentInChildren(typeof(UE.Renderer))
    end
	--[[
    for i=0,Nagn-1 do
         individualPrepare(i)
    end
	--]]
	Group:SetState({44, 45, 54, 55})
	Group:ToGridFormation(10, UE.Vector3(-5, 0, -5), 2, 2)
	Group:RegisterGridNeighbours(10)
	Group:ToggleIndices(false)
    for i=0,Nagn-1 do
		State[i]=Members[i].State
        individualStart(i)
	end
	
end

function update()
    for i=0,Nagn-1 do
		StateOld[i]=Members[i].State
	end
    TIME = TIME + 1
	if TIME % T0 == 0 then
		Group:UpdateStates('gameoflife', 'B13S13')
	end
    for i=0,Nagn-1 do
		State[i]=Members[i].State
        individualMove(i)
		individualColor(i,0.05)
	end
end
function individualColor(i,dc)
	local r1=meshes[i].material.color.r
	local g1=meshes[i].material.color.g
	local b1=meshes[i].material.color.b
	if State[i]==0 then
		meshes[i].material.color=UE.Color(max(r1-dc,0),0,min(b1+dc,1),1)
	end
	if State[i]==1 then
		meshes[i].material.color=UE.Color(min(r1+dc,1),0,max(b1-dc,0),1)
	end
end
function individualPrepare(agentId)     
    anims[agentId]:Play(clip1, 0, 0)
end

function individualStart(agentId)
    local myAnim = anims[agentId]
	myAnim:CrossFade(ClId[4], NormTransDur);
end
function individualMove(agentId)
    local myAnim = anims[agentId]
    local transform = transforms[agentId]
    if StateOld[agentId]==1 and State[agentId]==0 then 
        myAnim:CrossFade(ClId[4], NormTransDur);     -- animation clips change at fixed times.
    end
    if StateOld[agentId]==0 and State[agentId]==1 then
        myAnim:CrossFade(ClDn[3], NormTransDur);
    end
    --transform:Rotate(UE.Vector3(0, 1 + cos(w1 * TIME), 0))
    --transform:Translate(UE.Vector3.forward * v1)
end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]
