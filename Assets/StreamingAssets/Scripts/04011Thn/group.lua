local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local ROOM = require('functionsROOM');
local LOG = require('logic');
--------------------------------------------------------------
local AND=LOG.C1
local OR=LOG.D1
--local AND=LOG.C2
--local OR=LOG.D2
local NOT=LOG.N1
--------------------------------------------------------------
local lights = {}
local Nagn = Members.Count
local transDur = 0.10
local cm
local s = {}
local so = {}
local tt
local filepath = ROOM.getScriptPath(Room).."/state.txt"
function start()


	-- LIGHTS
	for i=0,3 do
		lights[i]=LFO.lgtMake(Room,tostring(i),"Light1","spot",UE.Vector3(4*math.cos(i*6.28/4),4,4*math.sin(i*6.28/4)),UE.Vector3(90,0,0))
		LFO.lgtSetRange(lights[i],10)
		LFO.lgtSetIntensity(lights[i],2)
		LFO.lgtSetSpotAngle(lights[i],115)
		LFO.lgtSetColor(lights[i],UE.Color(1,1,1))
	end

	-- GROUND
	Ground=LFO.makeObject(Room,'Ground','Ground',"plane",UE.Vector3(0, -0.1, 0))
	--LFO.textureObj(Ground,'textures/SciFi','FloorTech02c',500,500)
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(40,1,40))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)
	--LFO.textureObj(Ground,'textures/ground','design_10',50,50)

		-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		s[i]=math.random(0,1)
		LFG.setPos(i,UE.Vector3(4*math.cos(i*6.28/Nagn),0,4*math.sin(i*6.28/Nagn)))
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,30,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,0)
	end
	cm=UT.colMakeColorMap("cool")

end

--------------------------------------------------------------
local TIME = 0
local d1=2
local d2=5
local txt1
function update()
    TIME = TIME + 1

	txt1=""
	for j=0,Nagn-1 do
		so[j]=s[j]
		txt1=txt1..so[j]
	end
    
	if TIME%50==0 then
		updateState01()
		print(txt1)
		--UT.printOnScreen(txt1, 5,5,UE.Color.white)
		UT.writeText(TIME.."  "..txt1.."\n", filepath, "a")
	end
    for i=0,Nagn-1 do
		LFG.setColor(i,UT.stateToColor(math.floor(9*s[i]),10,cm),1)

		-- MOVE
		LFG.turnToDir(i,-LFG.getPos(i),30)

		-- ANIM
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)<2 then LFG.aniCrossFade(i,CLP[181],transDur,true) end
			if LFG.getState(i)>2 then LFG.aniCrossFade(i,CLP[103],transDur,true) end
		end

	end

end

function onDestroy()
	UT.closeFile(filepath)
end

--------------------------------------------------------------
function updateState01()
	local q1
	local q2
	local m1
	local m2
	for n1=0,Nagn-1 do
		m1=(n1+1)%Nagn
		m2=(n1-1)%Nagn
		q1=AND(so[n1],NOT(so[m1]))
		q2=AND(NOT(so[n1]),so[m2])
		s[n1]=OR(q1,q2)
		LFG.setState(n1,math.floor(10*s[n1]))
	end
end


function updateState11()
	for n=0,Nagn-1 do
		local n1=(n+1)%Nagn
		local n2=(n+2)%Nagn
		s[n]= OR(so[n2],AND(so[n1],NOT(so[n2]),NOT(so[n])))
		LFG.setState(n,math.floor(10*s[n]-0.05))
	end
end

function updateState12()
	for n=0,Nagn-1 do
		local n1=(n+1)%Nagn
		s[n]= NOT(so[n1])
		LFG.setState(n,math.floor(10*s[n]-0.05))
	end
end

function updateState13()
	for n=0,Nagn-1 do
		local n1=(n+1)%Nagn
		local n2=(n+2)%Nagn
		s[n]= OR(NOT(so[n1]),NOT(so[n2]))
		LFG.setState(n,math.floor(10*s[n]))
	end
end

function updateState14()
	for n=0,Nagn-1 do
		local n1=(n-1)%Nagn
		local n2=(n+1)%Nagn
		s[n]= OR(NOT(so[n1]),NOT(so[n2]))
		LFG.setState(n,math.floor(10*s[n]))
	end
end
