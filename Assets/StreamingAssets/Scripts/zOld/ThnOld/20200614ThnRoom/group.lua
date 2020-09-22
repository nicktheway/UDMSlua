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

--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
function start()
	
	-- Find all game objects and write their names
	fn=io.open("qqq1.txt", "w")
	obj1=UE.GameObject.FindObjectsOfType(typeof(UE.MonoBehaviour))
	obj2=UE.GameObject.FindObjectsOfType(typeof(UE.MonoBehaviour))
	for i=0,obj1.Length-1 do
		fn:write(i," ",obj1[i].name,"\n")
		if obj1[i].name=="NeoMan(Clone)" then
			MyMan=obj1[i]
		end
	end
	fn:close()
	
	----------------

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
		anims[agentId]:Play(clip4, 0, 0)
	else
		anims[agentId]:Play(clip3, 0, 0)
	end


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
	if agentId==1 then
		local V1=DirDE1(agentId)
		transform:Translate(v1*V1)
		--print(state," ",d1)
	end
	if agentId==0 then
	end
end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

function DirDE1(m) ---(m,xstr,zstr)
	local x=Members[m].transform.position.x
	local z=Members[m].transform.position.z
	local dx=-z
	local dz=10*x
	print(dx," ",dz)
	local V1=UE.Vector3(1,0,1)
	local V1=UE.Vector3(dx,0,dz)
	--local dz=load("return "..zstr)
	--local dx=load("return "..xstr)
	--local dz=load("return "..zstr)
	--load("dx="..xstr)
	--load("dz="..zstr)
	return V1
end
---------------------------------------------------------------------------------------
--------------------------------- More   functions, do not delete ---------------------

---------------------------------------------------------------------------------------
--------------------------------- Sapies functions, do not delete ---------------------

	--print(Group:GetGroupCenter())
	--plane1.transform:Rotate(UE.Vector3.left * 10*UE.Time.deltaTime)


	--print(TIME,MyAng(agentId),MyDir(agentId).x,MyDir(agentId).z)
	--print(TIME,d1)
	--print(Members[agentId]:GetAgentNearest())

	--print(MyMan.name)
	--MyMan.transform:Rotate(UE.Vector3.up * 10*UE.Time.deltaTime)
	--transform:Translate(UE.Vector3.forward * agentId * v1)



	--plane1=UE.GameObject.CreatePrimitive(UE.PrimitiveType.Plane)
	--print(UE.GameObject.FindObjectOfType(typeof(UE.Camera)))
	--print(UE.GameObject.FindObjectOfType(typeof(UE.Camera)))
	--obj1=UE.GameObject.FindGameObjectsWithTag("aaaa")





function DirToAgn(m,n)
	local V1=123;
	local dV1=123;
	pos1=Members[m].transform.position
	pos2=Members[n].transform.position
	V1=pos2-pos1;
	dV1=math.sqrt(V1.x^2+V1.y^2+V1.z^2)
	if dV1>0 then V1=V1/dV1 end
	return V1
end
function MyDir(m)
	local V1=123;
	local dV1=123;
	ang1=Members[m].transform.eulerAngles.y
	V1=UE.Vector3(cos(ang1*3.14159/180),0,sin(ang1*3.14159/180));
	return V1
end
function MyAng(m)
	local ang1=0;
	ang1=Members[m].transform.eulerAngles.y
	return ang1
end

function individualMove1(agentId)
    local myAnim = anims[agentId]
    local transform = Members[agentId].transform
	if math.fmod(agentId,2)==0 then
		transform:Rotate(UE.Vector3(0, w1, 0))
	else
		transform:Rotate(UE.Vector3(0, -w1, 0))
	end
	transform:Translate(UE.Vector3.forward * v1)
	local agentId2=(agentId+1)%Nagn
	--print(TIME,agentId,DirToAgn(agentId,agentId2))
	--print(TIME,agentId,MyDir(agentId))
	if agentId==0 then
		print(TIME,MyAng(agentId),MyDir(agentId).x,MyDir(agentId).z)
	end
end


