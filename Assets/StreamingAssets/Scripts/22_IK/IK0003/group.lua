-- aliases --
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
local ikGameObjects = {}

local Ground
local cube1
local sphere1
local empty1

local T0=100
local NormTransDur = 0.35
local TIME = 0

local rend
local V0, V1, V2L, V2R, V3, V4L, V4R, V5L, V5R, V6
function start()
	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, 0.0, 0))
	LFO.setPos(Ground,UE.Vector3(0,-0.0,0))
	LFO.setScale(Ground,UE.Vector3(50,1,50))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)

	-- AGENTS
	LFG.toggleIndices(false)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		LFG.setState(i,1)
		ikGameObjects[i] = Members[i]:GetComponent(typeof(CS.UDMS.IKGameObjects))
		if i==0 then
			LFG.setPos(i,UE.Vector3(0,0.05,0))
			LFG.setRot(i,UE.Vector3(0,-180,0))
			LFG.aniCrossFade(i,Clips[181],NormTransDur,true)
			LFG.setColor(i,UE.Color.red,0)
			LFG.setColor(i,UE.Color.red,1)
			rend=Group.Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
			rend[0].material:SetFloat("_Metallic",0.85);
			rend[1].material:SetFloat("_Metallic",0.85);
		elseif i==1 then
			LFG.setPos(i,UE.Vector3(0,0.05,1))
			LFG.setRot(i,UE.Vector3(0, 0,0))
			LFG.aniCrossFade(i,Clips[183],NormTransDur,true)
			LFG.setColor(i,UE.Color.blue,0)
			LFG.setColor(i,UE.Color.blue,1)
			rend=Group.Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
			rend[0].material:SetFloat("_Metallic",0.85);
			rend[1].material:SetFloat("_Metallic",0.85);
		end
		--[[
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,0,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,5)
		--]]
	end

	-- LIGHTS
	for i=0,0 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(0,4,0),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],30)
		LFO.lgtSetIntensity(lights[i],1.6)
		LFO.lgtSetSpotAngle(lights[i],90)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end
end
--------------------------------------------------------------------------------
local d1=2
local d2=5
local lHnd, rHnd
function update()
    TIME = TIME + 1
	--lHnd=Group.Members[0].transform:Find("mixamorig:LeftHand");
	--rHnd=Group.Members[0].transform:Find("mixamorig:RightHand");
	--V5L=lHnd.transform.position
	--V5R=rHnd.transform.position
	V5L=ikGameObjects[0].LeftHand.transform.position
	V5R=ikGameObjects[0].RightHand.transform.position
	V6=ikGameObjects[1].LeftHand.transform.position
    for i=0,Nagn-1 do
		--print(Group.Members[i]:GetComponent(typeof(UE.Animator)).speed)
		--Group.Members[i]:GetComponent(typeof(UE.Animator)):ApplyBuiltinRootMotion()
		--onElementAnimatorMove(i)
		--onElementAnimatorIK(0,i)
	end
end
--------------------------------------------------------------------------------
--[ Root motion is off :	LFG.ikSetLookAtPnt(i,UE.Vector3(1,1,1))
--local anims = {}
function onElementAnimatorMove(i)
    LFG.aniSetRootMotion(i,true)
	--Group.Members[i]:GetComponent(typeof(UE.Animator)):ApplyBuiltinRootMotion()
	--LFG.ikSetLookAtPnt(i,UE.Vector3(1,1+math.cos(0.1*TIME),1))
	--anims[i]:ApplyBuiltinRootMotion()
end

local LHPw=3.0
local RHPw=3.0
local LKTw=5.0
local R1=0.3
local w1=0.015
local w2=0.035
local AC
local iks
local LFV1, RFV1
function onElementAnimatorIK(lrInd,i)
	
	if i==0 then
		AC=Group.Members[i]:GetComponent(typeof(UE.Animator))
		AC.speed=0.7
		AC.bodyPosition = UE.Vector3(0,0.90+0.1*math.sin(0.05*TIME),0);

		V0=UE.Vector3(0,1.5+0.25*math.cos(w2*TIME),1)
		LFG.ikSetLookAtWeight(i,LKTw)
		LFG.ikSetLookAtPnt(i,V6)
		--LFG.ikSetRotWeight(i,"LF",10.0)
		--LFG.ikSetRot(i,"LF",UE.Vector3(0,TIME,0))
		--LFG.ikSetLookAtPnt(i,V0)
		--AC:SetLookAtWeight(LKTw)
		--AC:SetLookAtPosition(V0)

		LFV1=UE.Vector3( 0.2,0.2,0.0)
		RFV1=UE.Vector3(-0.2,0.2,0.0)
		LFG.ikSetPosWeight(i,"LF",LHPw)
		LFG.ikSetPosWeight(i,"RF",RHPw)
		LFG.ikSetPosVec(i,"LF",LFV1)
		LFG.ikSetPosVec(i,"RF",RFV1)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftFoot,LHPw)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.RightFoot,RHPw)
		--AC:SetIKPosition(UE.AvatarIKGoal.LeftFoot,LFV1)
		--AC:SetIKPosition(UE.AvatarIKGoal.RightFoot,RFV1)

		V1=LFG.getPos(i)
		V2L=UE.Vector3( 0.5,1.0,-0.50) --UE.Vector3( 1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0,-0.50)
		V2R=UE.Vector3(-0.5,1.0,-0.50) --UE.Vector3(-1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0, 0.50)
		V3=R1*UE.Vector3(math.cos(w1*TIME),math.cos(w1*TIME),math.sin(w1*TIME))
		V4L=V1+V2L+V3
		V4R=V1+V2R+V3
		LFG.ikSetPosWeight(i,"LH",LHPw)
		LFG.ikSetPosWeight(i,"RH",RHPw)
		LFG.ikSetPosVec(i,"LH",V4L)
		LFG.ikSetPosVec(i,"RH",V4R)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,LHPw)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.RightHand,RHPw)
		--AC:SetIKPosition(UE.AvatarIKGoal.LeftHand,V4L)
		--AC:SetIKPosition(UE.AvatarIKGoal.RightHand,V4R)

	elseif i==1 then

		AC=Group.Members[i]:GetComponent(typeof(UE.Animator))
		AC.speed=0.7
		AC.bodyPosition = UE.Vector3(0,1.0+0.01*math.cos(0.05*TIME),-1);

		V0=UE.Vector3(0,1.5+0.25*math.cos(w2*TIME),1)

		LFG.ikSetLookAtWeight(i,LKTw)
		LFG.ikSetLookAtPnt(i,V0)
		--AC:SetLookAtWeight(LKTw)
		--AC:SetLookAtPosition(V0)

		LFV1=UE.Vector3(-0.2,0.2,-1)
		RFV1=UE.Vector3( 0.2,0.2,-1)
		LFG.ikSetPosWeight(i,"LF",LHPw)
		LFG.ikSetPosWeight(i,"RF",RHPw)
		LFG.ikSetPosVec(i,"LF",LFV1)
		LFG.ikSetPosVec(i,"RF",RFV1)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftFoot,LHPw)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.RightFoot,RHPw)
		--AC:SetIKPosition(UE.AvatarIKGoal.LeftFoot,LFV1)
		--AC:SetIKPosition(UE.AvatarIKGoal.RightFoot,RFV1)

		LFG.ikSetPosWeight(i,"LH",LHPw)
		LFG.ikSetPosWeight(i,"RH",RHPw)
		
		LFG.ikSetPosVec(i,"LH",V5R)
		LFG.ikSetPosVec(i,"RH",V5L)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,LHPw)
		--AC:SetIKPositionWeight(UE.AvatarIKGoal.RightHand,RHPw)
		--AC:SetIKPosition(UE.AvatarIKGoal.LeftHand,V5R)
		--AC:SetIKPosition(UE.AvatarIKGoal.RightHand,V5L)
		
	
		--[[
		V1=LFG.getPos(0)
		V2L=UE.Vector3(-0.5,1.0,-0.50) --UE.Vector3( 1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0,-0.50)
		V2R=UE.Vector3( 0.5,1.0,-0.50) --UE.Vector3(-1,1+math.cos(ww*TIME),0) --UE.Vector3(-0.5,1.0, 0.50)
		V3=R1*UE.Vector3(math.cos(w1*TIME),math.cos(w1*TIME),math.sin(w1*TIME))
		--print(V5L,V5R)
		--print(V4L,V4R)
		iks = Group.Members[0]:GetComponent(typeof(CS.UDMS.IKGameObjects))
		V2L=iks.LeftHand.gameObject.transform.position  --+UE.Vector3(0,0,math.cos(0.1*TIME))
		V2R=iks.RightHand.gameObject.transform.position
		print("iks",V2L,V2R)
		--Group.Members[0].transform.Find("LeftHand").gameObject;
		--V2L=iks.LeftHand.GameObject--.transform.position  --+UE.Vector3(0,0,math.cos(0.1*TIME))
		--V2R=iks.RightHand.GameObject--.transform.position
		--V2L=Group.Members[0].transform:Find("mixamorig:LeftHand").transform.position;
		--V2R=Group.Members[0].transform:Find("mixamorig:RightHand").transform.position;
		--print("iks",V2L,V2R)
		--print(iks.LeftHand.gameObject.transform.position.z,Group.Members[0].transform:Find("mixamorig:LeftHand").transform.position.z)
		--]]
	end
	
	--transform.position.y=0.0;

	--LFG.ikSetLookAtPnt(i,UE.Vector3(1,2+math.cos(w2*TIME),1))

	--AC:SetLookAtPosition(Vector3 lookAtPosition);
	--AC:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,10);
	--AC:SetIKPosition(UE.AvatarIKGoal.LeftHand, UE.Vector3(1,1+math.cos(0.1*TIME),1));
	--LFG.ikSetLookAtPnt(i,UE.Vector3(1+math.cos(0.1*TIME),1,1))
end
