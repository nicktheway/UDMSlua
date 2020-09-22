-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local max = UE.Mathf.Max
local min = UE.Mathf.Min
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

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
	--Group:SetState({99})
	--Group:ToGridFormation(10, UE.Vector3(-5, 0, -5), 2, 2)
	--Group:RegisterGridNeighbours(10)
	--Group:ToggleIndices(false)

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
    for i=0,Nagn-1 do
        agentState(i)
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
		Members[i].TurnToMoveDir = true
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		transforms[i] = Members[i].transform
		Members[i].ColorState = false
		meshes[i]=Members[i]:GetComponentInChildren(typeof(UE.Renderer))
		Members[i].State=1
		local myAnim = anims[i]
		myAnim:CrossFade(ClMv[1], NormTransDur);
		Members[i].transform.position=UE.Vector3(3*math.cos(i*3.14/Nagn),0,-15+3*math.sin(i*3.14/Nagn))
		State[i]=1
		trails[i]=Members[i].gameObject:AddComponent(typeof(UE.TrailRenderer))
		trails[i].time=20
		trails[i].widthMultiplier=0.1
		local mymat=UE.Material(UE.Shader.Find("Unlit/Color"))
		mymat.color=UE.Color.blue
		trails[i].material=mymat
end
--------------------------------------------------------------------------------
function agentState(i)
	j=math.fmod(i+1,Nagn)
	local d0=Members[i]:DistToAgent(j)
	local d1=2
	local d2=4
	if d0<d1 then
		Members[i].State=2
	end
	if d0>d2 then
		Members[i].State=1
	end
end
--------------------------------------------------------------------------------
function agentMove(i)
	j=math.fmod(i+1,Nagn)
	local v1=Members[i].transform.position-Members[j].transform.position
	if Members[i].State==1 then
		Members[i]:MoveInDir(-v1,0.05,true)
	end
	if Members[i].State==2 then
		Members[i]:MoveInDir(v1,0.05,true)
	end
end
--------------------------------------------------------------------------------
function agentAnim(i)
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
