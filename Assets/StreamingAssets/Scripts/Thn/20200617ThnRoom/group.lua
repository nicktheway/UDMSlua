-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local anims = {}
local statuses = {}
local CRVTimes = {}

-- initialization 
local clip1 = 'Idle02'
local clip2 = 'Capoeira02'
local clip3 = 'Jazz Dancing01'
local clip4 = 'Ninja Idle2'

local cube1=UE.GameObject.CreatePrimitive(UE.PrimitiveType.Cube)
local cube2=UE.GameObject.CreatePrimitive(UE.PrimitiveType.Cube)

cube1.transform.position=UE.Vector3(3,1,-3)
cube2.transform.position=UE.Vector3(-3,1,3)

local Nagn = Members.Count

local d0=3.6
local v1 = 0.05
local w1 = 5
local w2 = 1.0
local R0 = 3
local p1 = 0.3
local Dinf, Pheal = 2.5, 0.025
local Wx, Wz = 0.050, 0.050
local NormTransDur = 0.2
local TIME = 0

-- scratch variables
local plane1
local obj1
local obj2
local MyMan
local MyCam

--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
function start()

	WriteGamObjNames()

    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
    end

    for i=0,Nagn-1 do
        individualPrepare(i)
    end
end
--------------------------------------------------------------------------------
function update()
    for i=0,Nagn-1 do
        individualMove(i)
    end
    TIME = TIME + 1
end
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------

function individualPrepare(agentId) 
    local agent = Members[agentId]
    local myAnim = anims[agentId]
    local transform = Members[agentId].transform
    
	if agentId==0 then 
		anims[agentId]:Play(clip3, 0, 0)
	else
		anims[agentId]:Play(clip3, 0, 0)
	end

	Members[agentId].TurnToMoveDir=true
    transform.position = UE.Vector3(agentId, 0, 0)
    transform.eulerAngles.y = 0

end


local state=1
local d01 = 0.5
local d02 = 2.5
local v1 = 0.02
local w1 = 1.25
local w2= 0.005

function individualMove(agentId)

    local myAnim = anims[agentId]
	local me=Members[agentId]
    local transform = me.transform
	local m=math.fmod(agentId+1,Nagn)
	local d1=me:DistToAgent(m)
	local V1
	if agentId==1 then
		V1=me:DirAttractRepel(0,1)
	end
	if agentId==0 then
		V1=me:DirAttractRepel(1,1)
	end
	me:TurnToDir(V1,1)
	transform:Translate(0.1*transform.forward)
end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

function WriteGamObjNames()
-- Find all game objects and write their names
	fn=io.open("qqq1.txt", "w")
	obj1=UE.GameObject.FindObjectsOfType(typeof(UE.MonoBehaviour))
	obj2=UE.GameObject.FindObjectsOfType(typeof(UE.MonoBehaviour))
	for i=0,obj1.Length-1 do
		fn:write(i," ",obj1[i].name,"\n")
		if obj1[i].name=="NeoMan(Clone)" then
			MyMan=obj1[i]
		end
		if obj1[i].name=="Main Camera" then
			MyCam=obj1[i]
		end
	end
	fn:close()
end