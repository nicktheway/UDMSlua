local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
local LOG = require('logic');
--------------------------------------------------------------
local lights = {}
local Nagn = Members.Count
local transDur = 0.10
local cm
local s = {}
local so = {}
local tt
local Sin
local Sout
--local ss={1,2,3,4,5,6,7,0,9,10,11,12,13,14,15,8,1,2,3,4,5,6,7,0,9,10,11,12,13,14,15,8}
local ss={}
for n=1,2^(Nagn-1) do
	ss[n]           =(n)%(2^(Nagn-1))
	ss[n+2^(Nagn-1)]=(n)%(2^(Nagn-1)) + 2^(Nagn-1)
end
local textToWrite = ""

function start()

	-- STATE TRANSITION FUNCTION
	Sin, Sout=UT.makeTransFun(ss,Nagn)
	textToWrite = ""
	local M=2^Nagn
	for m=1,M do
		for n=1,Nagn do
			textToWrite = textToWrite..Sin[m][n]
		end
		textToWrite = textToWrite..' '
		for n=1,Nagn do
			textToWrite = textToWrite..Sout[m][n]
		end
		textToWrite = textToWrite..'\n'
	end
	--UT.printOnScreen(textToWrite)

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
	LFO.setPos(Ground,UE.Vector3(0,-0.2,0))
	LFO.setScale(Ground,UE.Vector3(40,1,40))
	LFO.textureObj(Ground,'textures/ground','checkerboard_2',50,50)
	--LFO.textureObj(Ground,'textures/SciFi','FloorTech02c',500,500)

	-- AGENTS
	LFG.toggleIndices(true)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		s[i]=math.random(0,1)
		--so[i]=s[i]
		LFG.setPos(i,UE.Vector3(2*math.cos(i*6.28/Nagn),0,2*math.sin(i*6.28/Nagn)))
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
	--UT.printOnScreen(txt1, 5,5,UE.Color.white)
    
	if TIME%50==1 then
		--s=LOG.updateStateByNumFast(so,Sout,Nagn)
		s=LOG.updateStateByNum(so,Sin,Sout,Nagn)
		for n=0,Nagn-1 do
			LFG.setState(n,math.floor(10*s[n]))
		end
	end
    for i=0,Nagn-1 do
		LFG.setColor(i,UT.stateToColor(math.floor(9*s[i]),10,cm),1)

		-- MOVE
		LFG.turnToDir(i,-LFG.getPos(i),1)

		-- ANIM
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)<2 then LFG.aniCrossFade(i,CLP[181],transDur,true) end
			if LFG.getState(i)>2 then LFG.aniCrossFade(i,CLP[103],transDur,true) end
		end

	end

end

function onElementAnimatorMove(i)
	LFG.aniSetRootMotion(i,true)
end
