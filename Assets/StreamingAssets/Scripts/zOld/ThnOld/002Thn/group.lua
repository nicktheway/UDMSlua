-- aliases --
local UE = CS.UnityEngine
local KPF = CS.K_PathFinder
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local Clips = require('animations')
local LFF = require('functions')
local LF = LFF(Group)

local anims = {}
local transforms = {}
local renderers = {}
local agents = {}

local Nagn = Members.Count
local surface
local obstacles = {}
local targets = {}
local NormTransDur = 0.2
local TIME = 0
local nc=31
local gca

local filepath = 'test.log'


local lightGO1
local light1

function start()

    for i=0,Nagn - 1 do
		Members[i].transform.position=UE.Vector3(10, 0, -10*i)
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		renderers[i] = Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
		transforms[i] = Members[i].transform
		LF.setPos(i, 2*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn)))
		LF.setColor(i,UE.Color.blue)
		LF.trailAttach(i,UE.Color.yellow,15,0.03)
		--LF.setAnim(i,Clips[121], 0.2)
		LF.aniCrossFade(i,Clips[121], 0.2,rel)
    end
	Group:ToggleIndices(true)
end


function update()
	--UT.printOnScreen(UT.DirPntToPnt(UE.Vector3(1,0,0),UE.Vector3(0,1,0)))
	--local cc=UT.RotateVector(UE.Vector3(1,0,0),45)
	--print(cc.x,cc.y,cc.z)

    TIME = TIME + 1
	
	--[[
	lightGO1.transform.eulerAngles=UE.Vector3(90+90*math.cos(0.1*TIME),0,0)
	LF.lgtSetColor(light1,UE.Color((2+math.sin(0.1*TIME),0,(2+math.cos(0.1*TIME)))))
	LF.lgtSetIntensity(light1,2*(2+math.cos(0.1*TIME)))
	LF.lgtSetRange(light1,20*(2+math.cos(0.1*TIME)))
	LF.lgtSetType(light1,UE.LightType.Spot)
	LF.lgtSetSpotAngle(light1,45*(2+math.cos(0.1*TIME)))
	--]]

	for i=0,Nagn-1 do
		--LF.turnUp(i,-20) 
		--LF.turnToAgent(i,(i+1)%Nagn,1)
		--LF.turnByDir(i,UE.Vector3(1,0,4),1)
		--LF.turnToAngle(i,45,2)
		--LF.goToPoint(i,UE.Vector3(5*math.cos(i+0.1*TIME),0,5*math.sin(i+0.1*TIME)),0.1)
		LF.setRot(i,UE.Vector3(0,TIME,0),0.4)
		LF.moveFwd(i,0.1)
		LF.aniSetClipSpeed(i,(1+math.cos(0.03*TIME)))
		LF.ikSetLookAtAgent(i,(i+1)%Nagn)
		--math.cos(0.03*TIME)))
		--[[
		LF.setTurnToMoveDir(i,false)
		LF.trailSetStartColor(i,UE.Color(0.5+0.5*math.cos(0.1*TIME),0,0))
		LF.trailSetEndColor(i,UE.Color(0,0,0.5+0.5*math.sin(0.1*TIME)))
		LF.trailSetStartWidth(i,0.5+0.5*math.cos(0.1*TIME))
		LF.trailSetEndWidth(i,0.5+0.5*math.sin(0.1*TIME))
		LF.trailSetTime(i,TIME/2)
		--]]
	end

end


function onDestroy()
	UT.closeAllFiles()
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

    if myState==0 then  myAnim:CrossFade(Clips[91], NormTransDur) end
    if myState==1 then  myAnim:CrossFade(Clips[92], NormTransDur) end
    if myState==2 then  myAnim:CrossFade(Clips[93], NormTransDur) end
    if myState==3 then  myAnim:CrossFade(Clips[94], NormTransDur) end
end

function individualMove(agentId)

end
--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

