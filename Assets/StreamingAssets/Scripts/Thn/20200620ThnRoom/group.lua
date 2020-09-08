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

local Nagn = Members.Count
local NormTransDur = 0.2
local TIME = 0

--------------------------------------------------------------------------------
-- Than variables
local cube1
local cube2
local MyMan
local MyCam
local CSCam


local plane1
local obj1
local obj2
local NuCam
local MyCube
local MyCubeComps
local comps

local d0=3.6
local v1 = 0.05
local w1 = 5
local w2 = 1.0
local R0 = 3
local p1 = 0.3
local Dinf, Pheal = 2.5, 0.025
local Wx, Wz = 0.050, 0.050


local state=1
local d01 = 0.5
local d02 = 2.5
local v1 = 0.02
local w1 = 1.25
local w2= 0.005

--------------------------------------------------------------------------------
--------------------- Than functions ----------------------
function ThanStuff01()

	--------------------- create new objects and control them
	cube1=UE.GameObject.CreatePrimitive(UE.PrimitiveType.Cube)
	cube2=UE.GameObject.CreatePrimitive(UE.PrimitiveType.Cube)
	cube1:GetComponent(typeof(UE.Renderer)).material.color = UE.Color.red
	cube2:GetComponent(typeof(UE.Renderer)).material.color = UE.Color.blue
	cube1.transform.position=UE.Vector3(3,1,-3)
	cube2.transform.position=UE.Vector3(-3,1,3)
	--	print(cube1.transform.position)

	--------------------- access objects and components ----------------------
	ThanWriteGamObjComp()

	--------------------- Than experiments with load / eval----------------------
	load("c=14; d=23; dx=c-d")()
	load("print(c+d)")()
	g=load("c=13423")	
	g()
	print(c)
	load("X=3; Z=4")()
	load("dX=2*X-3*Z")()
	load("print(dX)")()
end
function ThanWriteGamObjComp()
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
		if obj1[i].name=="CameraRig(Clone)" then
			CSCam=obj1[i]
		end
	end
	fn:write(MyCam.transform.position.x,"\n")
	fn:write(CSCam.transform.position.y,"\n")

	-- find all components of an object
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		comps = Members[i]:GetComponents(typeof(UE.Component))
		fn:write("There exist ",comps.Length, "components\n")
    end
	MyCubeComps = cube1:GetComponents(typeof(UE.Component))
	for i=0,MyCubeComps.Length-1 do
		fn:write(MyCubeComps[i].name,"\n")
	end
	MyCubeRends = cube1:GetComponents(typeof(UE.Renderer))
	fn:write(MyCubeRends.Length,"\n")
	MyCamComps = MyCam:GetComponents(typeof(UE.Component))
	fn:write(MyCamComps.Length,"\n")
	fn:close()

	-- turn CineMachine off
	local cinemachineBrain = MyCam:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
    if cinemachineBrain then
        cinemachineBrain.enabled = false
    end
	--???Members[0]:AddComponent(typeof(UE.Renderer))
end

function ThanUpdate()
	cube1.transform.localScale=UE.Vector3(1,4*(1+cos(0.1*TIME)),1)
	cube1.transform.eulerAngles=UE.Vector3(0,180*(1+cos(0.1*TIME)),0)
	UE.Camera.main.transform.position=UE.Vector3(4*(1+sin(0.05*TIME)),3,4*(1+cos(0.02*TIME)))
	UE.Camera.main.transform:LookAt(Members[0].transform.position+UE.Vector3(0,1,0))
	--???UE.Camera.main:SetActive(false)
	--???NuCam=UE.GameObject.Instantiate(MyCam)
end
function ThanMove(agentId)
	local m=math.fmod(agentId+1,Nagn)
	local x=transform.position.x
	local z=transform.position.z
	--local R1=5*PosPar01(0.1*TIME,agentId); transform.position=R1
	--local R1=PosPol01(0.1*TIME,agentId); transform.position=R1
	--local V1=DirDE01(agentId); transform.position=transform.position+0.02*V1
	local V1=DirDE02(x,z); transform.position=transform.position+0.02*V1
	--??? local V1=DirDE01(agentId);  transform:Translate(0.02*V1)
	--??? local V1=DirDE02(x,z);  transform:Translate(0.02*V1)
	--??? transform.position.x=R1.x
	--??? transform.position.z=R1.z
	--local phi=agentId*3.14/Nagn
	--transform.position.x= R1.x --math.cos(phi)*R1.x+math.sin(phi)*R1.z
	--transform.position.z=-R1.z --math.sin(phi)*R1.x+math.cos(phi)*R1.z
	--print(transform.position.x*transform.position.x+transform.position.z*transform.position.z)
	--print(R1.x," ",R1.z)
	--print(cos(phi)," ",sin(phi))
	--print(math.sin(phi)*R1.x," ",math.cos(phi)*R1.z)
	--print(math.cos(phi)*R1.x+math.sin(phi)*R1.z)
	--print(-math.sin(phi)*R1.x+math.cos(phi)*R1.z)
end
function DirDE01(agentId)
	local x=Members[agentId].transform.position.x
	local z=Members[agentId].transform.position.z
	local V1=UE.Vector3(-z,0,x)
	return V1
end
function DirDE02(x,z)
	local V1=UE.Vector3(-z,0,x)
	local d=math.sqrt(x^2+z^2) 
	if d>0 then
		V1=V1/d
	end
	return V1
end
function ThanRot1(x,z,phi)
	local xx= cos(phi)*x+sin(phi)*z
	local zz=-sin(phi)*x+cos(phi)*z
	return xx,zz
end
function PosPar01(t,m)
	local x=cos(0.03*t)
	local z=sin(0.02*t)
	local phi=m*3.14/Nagn
	xx,zz=ThanRot1(x,z,phi)
	R1=UE.Vector3(xx,0,zz)
	return R1
end
function PosPol01(t,m)
	t=0.03*t
	local r=3*cos(3*t)
	local x=r*cos(t)
	local z=r*sin(t)
	local phi=m*3.14/Nagn
	xx,zz=ThanRot1(x,z,phi)
	R1=UE.Vector3(xx,0,zz)
	return R1
end

--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
function start()
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
    end
    for i=0,Nagn-1 do
        individualPrepare(i)
    end
	ThanStuff01()
end
--------------------------------------------------------------------------------
function update()
	ThanUpdate()
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
    transform.position = UE.Vector3(agentId+1, 0, 1)
    transform.eulerAngles.y = 0

end

function individualMove(agentId)

    local myAnim = anims[agentId]
	local me=Members[agentId]
    transform = me.transform
	ThanMove(agentId)

end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

