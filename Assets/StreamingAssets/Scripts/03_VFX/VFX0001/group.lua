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
local A ={}
A[1]={ 0,-1,0, 0}
A[2]={ 1, 0,0, 0}
--A[3]={-1, 1,0, 0}
--A[4]={-1, 1,0, 0}
A[3]={-1, 1,0,-1}
A[4]={-1, 1,1, 0}
local st = {}
local stOld = {}
function start()

	A = MakeA(Nagn)
	
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
		st[i]=math.random()
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
function update()
    TIME = TIME + 1
	--UT.printOnScreen(TIME,5,5,UE.Color.green)

	-- AGENTS
	--print(TIME,st[0],st[1],st[2],st[3])
	for j=0,Nagn-1 do
		stOld[j]=st[j]
	end
    for i=0,Nagn-1 do
	
        -- STATE
		if TIME%50==1 then
			local stNew=1
			for j=0,Nagn-1 do
				if A[i][j]==1 then
					stNew=math.min(stNew,stOld[j])
				elseif A[i][j]==0 then
					stNew=math.min(stNew,1-stOld[j])
				end
			end
			st[i]=stNew
			LFG.setState(i,math.floor(10*st[i]))
		end
		LFG.setColor(i,UT.stateToColor(math.floor(10*st[i]),10,cm),1)

		-- MOVE
		LFG.turnToDir(i,-LFG.getPos(i),1)

		-- ANIM
		if LFG.getStateOld(i)~=LFG.getState(i) then
			local s=LFG.getState(i)
			if LFG.getState(i)<5 then LFG.aniCrossFade(i,CLP[181],transDur,true) end
			if LFG.getState(i)>5 then LFG.aniCrossFade(i,CLP[103],transDur,true) end
		end

	end

end
--------------------------------------------------------------
function MakeA(Nagn)
	local A={}
	for i=0, Nagn-1 do
		local B={}
		for j=0, Nagn-1 do
			B[j]=0
			--if j==(i+2)%Nagn then B[j]=1 
			if j==(i+1)%Nagn then B[j]=-1 
			elseif j==(i-1)%Nagn then B[j]=-1 
			--elseif j==(i-2)%Nagn then B[j]=-1 
			end
		end
		A[i]=B
		--print(A[i][0],A[i][1],A[i][2],A[i][3])
	end
	return A
end

--------------------------------------------------------------
--[[
-- variables
local Ground
local cube1
local sphere1
local empty1
--]]

