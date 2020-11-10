-- aliases --
--local LM=require("math")
local UE = CS.UnityEngine
local UT = require('utils')
local Clips = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ')
local ROOM = require('functionsROOM');
local LOG = require('logic');
local debug = require('debug')

-- variables
local Nagn = Members.Count

local lights = {}

local Ground
local cube1
local sphere1
local empty1

local T0=100
local NormTransDur = 0.35
local TIME = 0

function start()
	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, -0.1, 0))
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(50,1,50))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)

	-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,1)
		LFG.setPos(i,UE.Vector3(0,0,0))
		LFG.setRot(i,UE.Vector3(0,180,0))
		LFG.aniCrossFade(i,Clips[185],NormTransDur,true)
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,0,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		--LFG.trailSetTime(i,5)
	end

	-- LIGHTS
	for i=0,1 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*(-1)^i,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],60)
		LFO.lgtSetIntensity(lights[i],2)
		LFO.lgtSetSpotAngle(lights[i],155)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
end
--------------------------------------------------------------------------------
local d1=2
local d2=5
function update()
    TIME = TIME + 1
    for i=0,Nagn-1 do
		onElementAnimatorMove(i)
		onElementAnimatorIK(0,i)
	end
end
--------------------------------------------------------------------------------
function onElementAnimatorMove(i)
    LFG.aniSetRootMotion(i,true)
	--Group.Members[i]:GetComponent(typeof(UE.Animator)):ApplyBuiltinRootMotion()
	--LFG.ikSetLookAtPnt(i,UE.Vector3(1,1+math.cos(0.1*TIME),1))
	--anims[i]:ApplyBuiltinRootMotion()
end
function onElementAnimatorIK(lrInd,i)
	local AC=Group.Members[i]:GetComponent(typeof(UE.Animator))
	
	LHPw=1.0
	RHPw=1.0
	R1=0.3
	ww=0.05
	AC.speed=0.7
	V1=LFG.getPos(i)
	V2L=UE.Vector3( 1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0,-0.50)
	V2R=UE.Vector3(-1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0, 0.50)
	V3=R1*UE.Vector3(math.cos(ww*TIME),math.cos(ww*TIME),math.sin(ww*TIME))
	AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,LHPw)
	AC:SetIKPositionWeight(UE.AvatarIKGoal.RightHand,RHPw)
	AC:SetIKPosition(UE.AvatarIKGoal.LeftHand,V1+V2L+V3)
	AC:SetIKPosition(UE.AvatarIKGoal.RightHand,V1+V2R+V3)


	LFG.ikSetLookAtPnt(i,UE.Vector3(1,2+math.cos(0.1*TIME),1))
	--AC:SetLookAtPosition(Vector3 lookAtPosition);
	--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,10);
	--AC:SetIKPosition(UE.AvatarIKGoal.LeftHand, UE.Vector3(1,1+math.cos(0.1*TIME),1));
	--LFG.ikSetLookAtPnt(i,UE.Vector3(1+math.cos(0.1*TIME),1,1))
end
