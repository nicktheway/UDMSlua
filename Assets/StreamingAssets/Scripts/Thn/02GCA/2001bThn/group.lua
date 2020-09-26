-- aliases --
local UE = CS.UnityEngine

--local Form = require('formations')
local debug = require('debug')
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP')
local LFG = LF1(Group)
local LF2 = require('functionsOBJ')
local LFO = LF2(Group)

local Nagn = Members.Count
local transDur = 0.1
local TIME = 0
local numStates
local threshold
local stateUpdateTime = 50
local colmap="cool"
local gca

--local form1 = LFG.frmMakeFormation("circle", Nagn, UE.Vector3.zero, 4)
local nbrs1  = LFG.gcaMakeNbhd('rel1', Nagn, {-3, -2, -1, 0, 1}, true)
local R0=7
local center0 = {}
local R1=5
local center1 = {}
local col

function start()
	--LFG.grpSetFormation(form1)
	--LFG.grpSetStates({4})
	LFG.grpSetNeighbors(nbrs1)
	numStates = 5
	gca=LFG.gcaDefine({1, 2, 4}, {}, numStates)
    for i=0,Nagn - 1 do
		LFG.setColor(i,UE.Color.red)
		LFG.attachTrail(i, UE.Color.red, 10, 0.05)
		center0[i]=R0*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
		center1[i]=R1*UE.Vector3(math.cos(i*6.28/Nagn),0,math.sin(i*6.28/Nagn))
		LFG.setState(i,0)
		LFG.setPos(i,center0[i])
		LFG.aniCrossFade(i,CLP[121],transDur,true)
    end
	LFG.setState(0,1)
	LFG.setState(5,1)
	LFG.toggleIndices(true)
	onGcaStart()
end


function update()
    TIME = TIME + 1

	-- STATES
	if TIME % stateUpdateTime == 0 then
		LFG.gcaUpdate(Group,gca,"type1")
		onGcaStep()
	end
	
	-- MOVES
	for i = 0, Nagn-1 do
		if LFG.getState(i)<=1 then 
			--LFG.setDir(i,LFG.dirAgentToPnt(i,center0[i]))
			--LFG.turnToPnt(i,center0[i],2)
			if LFG.distAgentToPnt(i,center0[i])>0.1 then 
				LFG.turnToDir(i,LFG.dirAgentToPnt(i,center0[i]),10)
				LFG.moveFwd(i,0.05) 
			else 
				LFG.turnToDir(i,LFG.dirAgentToPnt(i,center1[i]),5) 
			end
		else 
			--LFG.setDir(i,LFG.dirAgentToPnt(i,center1[i]))
			--LFG.turnToPnt(i,center1[i],2)
			LFG.turnToDir(i,LFG.dirAgentToPnt(i,center1[i]),10)
			if LFG.distAgentToPnt(i,center1[i])>0.1 then LFG.moveFwd(i,0.05) end
		end
	end

	-- ANIMATION
	for i = 0, Nagn-1 do
		col=LFG.getColor(i)
		s=LFG.getState(i)
		LFG.setColor(i,UE.Color.Lerp(col,stateToColor(s,colmap),0.05))
		if LFG.getState(i)<=1 then 
			if LFG.distAgentToPnt(i,center0[i])>0.1 then
				--if LFG.aniGetClipName(i)~=CLP[177] then 
					LFG.aniCrossFadeDiff(i,CLP[177],0.01,true)
				--end
			else
				--if LFG.aniGetClipName(i)~=CLP[182] then 
					LFG.aniCrossFadeDiff(i,CLP[182],0.01,true) 
				--end
			end
		else
			if LFG.distAgentToPnt(i,center1[i])>0.1 then
				--if LFG.aniGetClipName(i)~=CLP[121] then 
					LFG.aniCrossFadeDiff(i,CLP[121],0.01,true)
				--end
			else
				--if LFG.aniGetClipName(i)~=CLP[109] then 
					LFG.aniCrossFadeDiff(i,CLP[109],0.01,true) 
				--end
			end
		end
	end
end

function onGcaStart()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..LFG.getState(i)
		LFG.setColor(i,stateToColor(LFG.getState(i),colmap))
	end
	textToWrite = textToWrite..'\n'
	UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onGcaStep()
	local textToWrite = ""
	for i=0,Nagn-1 do
		textToWrite = textToWrite..Members[i].State
	end
	textToWrite = textToWrite..'\n'
	UT.printOnScreen(textToWrite)
	UT.writeText(textToWrite, "test.log", 'w')
end

function onDestroy()
	UT.closeAllFiles()
end

    
function stateToColor(s,colmap)
	local cm = {}
	if colmap == "cool" then
		cm[0]={0.0000,1.0000,1.0000};
		cm[1]={0.0526,0.9474,1.0000};
		cm[2]={0.1053,0.8947,1.0000};
		cm[3]={0.1579,0.8421,1.0000};
		cm[4]={0.2105,0.7895,1.0000};
		cm[5]={0.2632,0.7368,1.0000};
		cm[6]={0.3158,0.6842,1.0000};
		cm[7]={0.3684,0.6316,1.0000};
		cm[8]={0.4211,0.5789,1.0000};
		cm[9]={0.4737,0.5263,1.0000};
		cm[10]={0.5263,0.4737,1.0000};
		cm[11]={0.5789,0.4211,1.0000};
		cm[12]={0.6316,0.3684,1.0000};
		cm[13]={0.6842,0.3158,1.0000};
		cm[14]={0.7368,0.2632,1.0000};
		cm[15]={0.7895,0.2105,1.0000};
		cm[16]={0.8421,0.1579,1.0000};
		cm[17]={0.8947,0.1053,1.0000};
		cm[18]={0.9474,0.0526,1.0000};
		cm[19]={1.0000,0.0000,1.0000};
	elseif colmap == "parula" then
		cm[0]={0.2422,0.1504,0.6603}
		cm[1]={0.2667,0.2028,0.8087}
		cm[2]={0.2797,0.2699,0.9141}
		cm[3]={0.2796,0.3435,0.9710}
		cm[4]={0.2567,0.4185,0.9962}
		cm[5]={0.1867,0.4981,0.9841}
		cm[6]={0.1700,0.5681,0.9374}
		cm[7]={0.1356,0.6315,0.8954}
		cm[8]={0.0831,0.6879,0.8494}
		cm[9]={0.0040,0.7296,0.7701}
		cm[10]={0.1466,0.7597,0.6797}
		cm[11]={0.2291,0.7880,0.5757}
		cm[12]={0.3802,0.8026,0.4448}
		cm[13]={0.5675,0.7936,0.2998}
		cm[14]={0.7455,0.7657,0.1789}
		cm[15]={0.8934,0.7348,0.1712}
		cm[16]={0.9961,0.7445,0.2362}
		cm[17]={0.9857,0.8228,0.1841}
		cm[18]={0.9595,0.9058,0.1463}
		cm[19]={0.9769,0.9839,0.0805}
	else
		cm[0]={0.2422,0.1504,0.6603}
		cm[1]={0.2667,0.2028,0.8087}
		cm[2]={0.2797,0.2699,0.9141}
		cm[3]={0.2796,0.3435,0.9710}
		cm[4]={0.2567,0.4185,0.9962}
		cm[5]={0.1867,0.4981,0.9841}
		cm[6]={0.1700,0.5681,0.9374}
		cm[7]={0.1356,0.6315,0.8954}
		cm[8]={0.0831,0.6879,0.8494}
		cm[9]={0.0040,0.7296,0.7701}
		cm[10]={0.1466,0.7597,0.6797}
		cm[11]={0.2291,0.7880,0.5757}
		cm[12]={0.3802,0.8026,0.4448}
		cm[13]={0.5675,0.7936,0.2998}
		cm[14]={0.7455,0.7657,0.1789}
		cm[15]={0.8934,0.7348,0.1712}
		cm[16]={0.9961,0.7445,0.2362}
		cm[17]={0.9857,0.8228,0.1841}
		cm[18]={0.9595,0.9058,0.1463}
		cm[19]={0.9769,0.9839,0.0805}
	end
	local n=math.floor(s*20/(numStates+1))
	return UE.Color(cm[n][1],cm[n][2],cm[n][3])
end

--[[
This turns on root motion
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

