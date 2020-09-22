-- aliases --
local UE = CS.UnityEngine

--local Form = require('formations')
--local debug = require('debug')
--local UT = require('utils')
local Clips = require('animations')
local LFF = require('functions')
local LF = LFF(Group)

local Nagn = Members.Count
local NormTransDur = 0.2
local TIME = 0

function start()
	Group:ToggleIndices(true)
	for i=0,Nagn-1 do
		LF.setNeighbours(i,{(i+1)%Nagn})
		LF.setPos(i,UE.Vector3(3*math.cos(i*6.28/Nagn),0,5*math.sin(i*6.28/Nagn)))
		LF.setState(i,i%2)
		LF.setTurnToMoveDir(i,true)
	end

	local ground = Room:GetObject('Ground')
	ground.transform.localScale = UE.Vector3(100, 1, 100)
	
    for i=0,Nagn - 1 do
		updateColor(i)
    end
	
	--[[
	LF.setRot(0, UE.Vector3(0, 90, 0))
	
	--]]
end


function update()
	--UT.printOnScreen(math.floor(1/UE.Time.deltaTime))
    for i=0,Nagn-1 do
		if TIME%150==1 then
			updateState(i)
			updateColor(i)
			updateAnim(i)
		end
		updateTransform(i)
	end
    TIME = TIME + 1
end

function updateState(i)
	Members[i].State=(Members[i].State+1)%2
end
function updateColor(i)
	if Members[i].State==1 then 
		LF.setColor(i,UE.Color.red,0)
	else
		LF.setColor(i,UE.Color.blue)
	end
end
function updateTransform(i)
	local dir=LF.dirToAgent(i,(i+1)%Nagn)
	if Members[i].State==0 then 
		dir=-dir
	end
	LF.moveInDir(i,dir, 0.03,true)
end
function updateAnim(i)
	if Members[i].State==0 then 
		LF.setAnim(i, Clips[120], NormTransDur)
	else
		LF.setAnim(i, Clips[178], NormTransDur)
	end
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

