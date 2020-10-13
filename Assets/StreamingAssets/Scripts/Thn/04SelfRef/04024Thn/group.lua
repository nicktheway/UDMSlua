local debug = require('debug')
local UE = CS.UnityEngine
local UT = require('utils')
local CLP = require('animations')
local LF1 = require('functionsGRP'); local LFG = LF1(Group)
local LFO = require('functionsOBJ');
--------------------------------------------------------------
local lights = {}
local Nagn = Members.Count
local transDur = 0.10
local cm
local s = {}
local so = {}
local tt

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
	LFG.toggleIndices(false)
    for i=0,Nagn - 1 do
		LFG.setTurnToMoveDir(i,true)
		LFG.setColorState(i,false)
		s[i]=math.random()
		LFG.setPos(i,UE.Vector3(2*math.cos(i*6.28/Nagn),0,2*math.sin(i*6.28/Nagn)))
		LFG.trailAttach(i,UE.Vector3(0,1,0),UE.Color.red,30,0.01)
		LFG.trailSetEndColor(i,UE.Color.blue)
		LFG.trailSetEndWidth(i,0.05)
		LFG.trailSetTime(i,0)
	end
	--s={0.75,0.75,0.75,0.95}
	--s[0]=0.75; s[1]=0.75; s[2]=0.95; s[3]=0.95
	cm=UT.colMakeColorMap("cool")

end

--------------------------------------------------------------
local TIME = 0
local d1=2
local d2=5
function update()
    TIME = TIME + 1
	--tt=UT.byte2bin(TIME,10)
	--UT.printOnScreen(TIME..": "..tt[1]..tt[2]..tt[3]..tt[4]..tt[5]..tt[6]..tt[7]..tt[8],5,5,UE.Color.white)
	--UT.printOnScreen(TIME,5,5,UE.Color.green)


	-- AGENTS
	--print(TIME,s[0],s[1],s[2],s[3])
	--print(TIME,LFG.getState(0),LFG.getState(1),LFG.getState(2),LFG.getState(3))
	for j=0,Nagn-1 do
		so[j]=s[j]
	end
    
	if TIME%50==1 then
		updateState()
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

--------------------------------------------------------------
function updateState()
	s[0]= D1(N1(so[1]),N1(so[2]))
	s[1]= D1(N1(so[2]),N1(so[3]))
	s[2]= D1(N1(so[3]),N1(so[0]))
	s[3]= D1(N1(so[0]),N1(so[1]))
	for i=0,Nagn-1 do
		LFG.setState(i,math.floor(10*s[i]))
	end
end
function updateState2()
	s[0]= N1(so[1])
	s[1]= N1(so[2])
	s[2]= N1(so[3])
	s[3]= N1(so[0])
	for i=0,Nagn-1 do
		LFG.setState(i,math.floor(10*s[i]-0.05))
	end
end
function updateState1()
	s[0]= D2(so[2],C2(so[1],N1(so[2]),so[0]))
	s[1]= D2(so[3],C2(so[2],N1(so[3]),so[0]))
	s[2]= D2(so[0],C2(so[3],N1(so[0]),so[1]))
	s[3]= D2(so[1],C2(so[0],N1(so[1]),so[1]))
	for i=0,Nagn-1 do
		LFG.setState(i,math.floor(10*s[i]-0.05))
	end
end
function D1(...)
	local x=0
	for i, v in ipairs{...} do
		x=math.max(x,v)
	end
	return x
end
function D2(...)
	local x=0
	for i, v in ipairs{...} do
		x=x+v-x*v
	end
	return x
end
function C1(...)
	local x=1
	for i, v in ipairs{...} do
		x=math.min(x,v)
	end
	return x
end
function C2(...)
	local x=1
	for i, v in ipairs{...} do
		x=x*v
	end
	return x
end
function N1(x)
	return 1-x
end
--------------------------------------------------------------
--[[
-- variables
local Ground
local cube1
local sphere1
local empty1
--]]

