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

local form1=Form.makeFormation("circle",Nagn,UE.Vector3(0,0,3),4,45)
local form2=Form.makeFormation("ellipse",Nagn,UE.Vector3(0,0,0),5,2,60)
local form3=Form.makeFormation("line",Nagn,UE.Vector3(-4,0,-3),UE.Vector3(1,0,2))
local form4=Form.makeFormation("grid",Nagn, nc, UE.Vector3(-31,0,31), 2, 2)
local form5=Form.makeFormation("lissajous",Nagn,6,5,6,6,30)
local form6=Form.makeFormation("nrose",Nagn,UE.Vector3(0,0,0),10,5,0)

local nbs1 = Form.makeNbhd('rel1', Nagn, {-2, -1, 0, 1, 2},true)
--local nbs2 = Form.makeNbhd('rel2', Nagn, nc, {{-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}}, false)
local nbs2 = Form.makeNbhd('rel2', Nagn, nc, {{-1, 0}, {0, -1}, {0, 1}, {1, 0}, {0,0}}, false)
--local nbs3 = Form.makeNbhd('fPath', Nagn, "nbs.txt")

function start()
	--
	Group:SetPositions(form4)
	Group:SetNeighbours(nbs2)
	Group:SetState({1})
	gca = CS.LuaScripting.GCA({3}, {2, 3}, 2)
	--[[
	Group:SetPositions(form4)
	Group:SetNeighbours(nbs2)
	Group:SetState({480})
	gca = CS.LuaScripting.GCA({1}, {},4)
	--]]
	local c=100
	local ground = Room:GetObject('Ground')
	ground.transform.localScale = UE.Vector3(c, 1, c)
	surface = UT.navAddSurface(ground)
	for n=1,4 do
		obstacles[n] = Room:InstantiateObject('cube')
		obstacles[n].transform:SetParent(ground.transform)
		obstacles[n].transform.localScale = UE.Vector3(1, c,10)/c
		obstacles[n].transform.position = UE.Vector3(5*n-10, 0.5, 1)
		obstacles[n].transform:Rotate(UE.Vector3(0,90*n,0))
	end
	UT.navBuildSurface(surface)
	
    for i=0,Nagn - 1 do
		Members[i].transform.position=UE.Vector3(10, 0, -10*i)
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		renderers[i] = Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
		transforms[i] = Members[i].transform
		LF.navAttachAgent(i)
		LF.navSetSpeed(i,8)
		LF.navSetDestination(i, UE.Vector3(-10, 0, -10*i))
		targets[i]=Room:InstantiateObject('sphere')
		targets[i].transform.position=UE.Vector3(-10, 0.5, -10*i)
		targets[i].transform.localScale=UE.Vector3(0.3,0.3,0.3)
		LF.navActive(i, true)
		LF.setColor(i,UE.Color.red)
		LF.attachTrail(i, UE.Color.red, 10, 0.05)
    end
	LF.setColor(3,UE.Color.blue)
	LF.setColor(4,UE.Color.green)
	LF.navSetSpeed(4, 2)
	LF.navSetSpeed(3, 3)
	
	--Group:ToggleIndices(true)
	--[[
	LF.setPos(0, UE.Vector3(0, 2, 0))
	LF.setRot(0, UE.Vector3(0, 90, 0))
	LF.setAnim(0, clip1, 0.2)
	--]]
	onGcaStep()
end


function update()
	--UT.printOnScreen(UT.DirPntToPnt(UE.Vector3(1,0,0),UE.Vector3(0,1,0)))
	--local cc=UT.RotateVector(UE.Vector3(1,0,0),45)
	--print(cc.x,cc.y,cc.z)

		for i=Nagn-2, Nagn-1 do
			LF.navToAgent(i,i-1)
		end
	--]]
    TIME = TIME + 1
	
	if TIME % 50 == 0 then
		Group:GCAUpdate(gca)
		onGcaStep()
	end
	
	--[[
	if TIME%100 == 0 then
		for n=1,4 do
			obstacles[n].transform:Rotate(UE.Vector3(0,90,0))
		end
		surface:BuildNavMesh()
	end
	--]]
	for n=1,4 do
		obstacles[n].transform:Rotate(UE.Vector3(0,0.5,0))
	end
	if TIME%20 == 0 then
		UT.navBuildSurface(surface)
	end
	if TIME%500 == 0 then
		for i=0,Nagn-3 do
			LF.navSetDestination(i, -LF.navGetDestination(i))
		end
	end
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		--renderers[i][0].material.color = stateToColor(Members[i].State)
		textToWrite = textToWrite..Members[i].State
		individualAnimate(i)
	end
	--UT.printOnScreen(textToWrite)
	UT.writeText(TIME.." "..textToWrite.."\n", filepath)
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

