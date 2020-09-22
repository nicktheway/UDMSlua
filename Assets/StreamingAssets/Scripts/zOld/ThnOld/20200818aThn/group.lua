-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local max = UE.Mathf.Max
local min = UE.Mathf.Min
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range
local AnClips=require("animations")

local Nagn = Members.Count
local anims = {}
local transforms = {}
local trails = {}
local meshes = {}
local State = {}
local StateOld = {}

local lt00 = UE.GameObject("Light00")
local lt000 = lt00:AddComponent(typeof(UE.Light))
local lt01 = UE.GameObject("Light01")
local lt010 = lt01:AddComponent(typeof(UE.Light))

local ClId={'Crouch Idle01','Offensive Idle','Standing Idle01','Standing Idle03','Idle02'}
local ClMv = {'Jazz Dancing01', 'Jazz Dancing02', 'Jazz Dancing03', 'Jazz Dancing04'}
local ClDn = {'salsa_dancing_0','salsa_dancing_1','bboy_hip_hop_move','bboy_hip_hop_move_1','hip_hop_dancing','flair_1','dancing'}


local T0=100
local NormTransDur = 0.35
local TIME = 0

function start()
	Group:SetState({99})
	Group:ToGridFormation(10, UE.Vector3(-5, 0, -5), 2, 2)
	Group:RegisterGridNeighbours(10)
	Group:ToggleIndices(false)

    for i=0,Nagn - 1 do
		agentStart(i)
	end
	
	lightStart()
end
--------------------------------------------------------------------------------
function update()
    TIME = TIME + 1

    for i=0,Nagn-1 do
		StateOld[i]=Members[i].State
	end
	if TIME % T0 == 1 then
		Group:UpdateStates('gameoflife', 'B13S13')
	end
    for i=0,Nagn-1 do
		State[i]=Members[i].State
        agentMove(i)
        agentAnim(i)
		agentColor(i,0.05)
	end
	
	lightUpdate()
end
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
--[[ Root motion is off :
function onElementAnimatorMove(i)
    anims[i]:ApplyBuiltinRootMotion()
end
--]]
--------------------------------------------------------------------------------
function agentStart(i)
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		transforms[i] = Members[i].transform
		Members[i].ColorState = false
		meshes[i]=Members[i]:GetComponentInChildren(typeof(UE.Renderer))
		State[i]=Members[i].State
		local myAnim = anims[i]
		myAnim:CrossFade(ClId[4], NormTransDur)
		trails[i]=Members[i].gameObject:AddComponent(typeof(UE.TrailRenderer))
		
end
--------------------------------------------------------------------------------
function agentMove(i)
end
--------------------------------------------------------------------------------
function agentAnim(i)
    local myAnim = anims[i]
    local transform = transforms[i]
    if StateOld[i]==1 and State[i]==0 then 
        myAnim:CrossFade(ClId[4], NormTransDur);     -- animation clips change at fixed times.
    end
    if StateOld[i]==0 and State[i]==1 then
        myAnim:CrossFade(ClDn[3], NormTransDur);
    end
end
--------------------------------------------------------------------------------
function agentColor(i,dc)
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
--------------------------------------------------------------------------------
function lightStart()
	lt00.transform.position=UE.Vector3(5,5,-10)
	lt000.range=100
	lt000.intensity=2
	lt01.transform.position=UE.Vector3(5,5,-2)
	lt010.range=100
	lt010.intensity=2
end
--------------------------------------------------------------------------------
function lightUpdate()
end
--------------------------------------------------------------------------------
