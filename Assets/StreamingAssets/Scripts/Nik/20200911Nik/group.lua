-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local Form = require('formations')
local debug = require('debug')
local extras = require('extras')
local Clips = require('animations')
local LFF = require('functions')
local LF = LFF(Group)

local anims = {}
local transforms = {}
local renderers = {}

local Nagn = Members.Count

local NormTransDur = 0.2
local TIME = 0
local nc=31
local gca

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
	--[[
	Group:SetPositions(form4)
	Group:SetNeighbours(nbs2)
	Group:SetState({10, 16, 23, 24, 25})
	gca = CS.LuaScripting.GCA({3}, {2, 3}, 2)
	--]]
	Group:SetPositions(form4)
	Group:SetNeighbours(nbs2)
	Group:SetState({480})
	gca = CS.LuaScripting.GCA({1}, {},4)

	local ground = Room:GetObject('Ground')
	ground.transform.localScale = UE.Vector3(100, 1, 100)
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		renderers[i] = Members[i]:GetComponentsInChildren(typeof(UE.Renderer))
		transforms[i] = Members[i].transform
		Members[i].ColorState = false
		--Members[i].transform:LookAt(UE.Vector3(0,1,0))
    end
	
	--Group:ToggleIndices(true)
	--[[
	LF.setPos(0, UE.Vector3(0, 2, 0))
	LF.setRot(0, UE.Vector3(0, 90, 0))
	LF.setAnim(0, clip1, 0.2)
	--]]
	onGcaStep()
end


function update()
	extras.printOnScreen(math.floor(1/UE.Time.deltaTime))
	--[[
    for i=0,Nagn-1 do
        --
	end
	--]]
    TIME = TIME + 1
	
	if TIME % 50 == 0 then
		Group:GCAUpdate(gca)
		onGcaStep()
	end
	
end

function onGcaStep()
	--[[
	local file = io.open('test.log', 'a')
	io.output(file)
	--]]
	local textToWrite = ""
	for i=0,Nagn-1 do
		renderers[i][0].material.color = stateToColor(Members[i].State)
		textToWrite = textToWrite..Members[i].State
		individualAnimate(i)
	end
	--extras.printOnScreen(textToWrite)
	--[[
	io.write(TIME.." "..textToWrite.."\n")
	io.close(file)
	-]]
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
function individualMove(agentId, nclipId)
    transform:Rotate(UE.Vector3(0, 1 + cos(w1 * TIME), 0))
    transform:Translate(UE.Vector3.forward * v1)
end
--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

