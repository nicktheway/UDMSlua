local UE = CS.UnityEngine
local UT = require('utils')
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')
local VFX = require('effects')

local groupDomain
local TIME=0
local camOffSet=UE.Vector3(4,4,4)
local camTargPos=UE.Vector3(0,2,0)
local camPos=UE.Vector3(0,3,0)
local camRot=UE.Vector3(89.8,0,0)
local Members ={}
local Nagn
local Hst=1.5
local Rst=1.5

function start()
	CAM.setState(1)
	CAM.setTargetGroup(Room, 'dancers')
	CAM.setPos(UE.Vector3(4,3,-8))
	groupDomain = RM.getGroup(Room, 'dancers')
	Members=groupDomain.Members
	Nagn=groupDomain.Members.Count
	CAM.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	CAM.stateInit()
	
	VFX.disableAllGlobalEffects()
	lutEffect = VFX.getEffect('lut')
	sobel = VFX.getEffect('sobel')
	motionBlur = VFX.getEffect('simplemotionblur')
	VFX.setProperty(motionBlur.BlurAmount,0.9)
end

function update()
	TIME=TIME+1
	print(TIME)
	
	CAM.updateStateFromKeyboard()	-- or: updateStateFromKeyboard(), user defined
	CAM.updateTargetFromKeyboard()
	CAM.targetUpdate()
	
	if TIME==   1 then 
		VFX.setLUTEffectTexture(lutEffect, 'RobotVision3D16')
		VFX.enableEffect(lutEffect,true)
		CAM.setTarget(0)
		CAM.setState(16)
	elseif TIME==  50 then 
		CAM.setTarget(1) 
		CAM.setState(16)
	elseif TIME==  75 then 
		CAM.setTarget(2) 
		CAM.setState(16)
	elseif TIME== 100 then 
		CAM.setTarget(3) 
		CAM.setState(16)
	elseif TIME== 125 then 
		CAM.setTarget(-1)
		CAM.setState(0)
		CAM.setPos(UE.Vector3(0,9,0))
		CAM.setRot(UE.Vector3(89.9,0,0))
	elseif TIME== 150 then 
		VFX.enableEffect(sobel, true)
	elseif TIME== 165 then 
		VFX.enableEffect(sobel, false)
	elseif TIME== 180 then 
		VFX.enableEffect(sobel, true)
	elseif TIME== 195 then 
		VFX.enableEffect(sobel, false)
	elseif TIME== 225 then 
		CAM.setTarget(0)
		CAM.setState(16)
	elseif TIME== 250 then 
		VFX.enableEffect(sobel, false)
		VFX.enableEffect(motionBlur,true)	
	elseif TIME== 275 then 
		CAM.setTarget(1)
	elseif TIME== 300 then 
		VFX.enableEffect(sobel, true)
	elseif TIME== 325 then 
		CAM.setTarget(2)
	elseif TIME== 350 then 
		VFX.enableEffect(sobel, false)
	elseif TIME== 325 then 
		CAM.setTarget(3)
	elseif TIME== 350 then 
		VFX.enableEffect(sobel, true)
	elseif TIME== 375 then 
		CAM.setTarget(3)
	elseif TIME==450 then
		CAM.setState(0)
	elseif TIME> 450 and TIME< 650 then
		VFX.enableEffect(motionBlur,false)
		CAM.setTarget(2)
		--CAM.setState(0)
		local w=0.015;
		local R=4
		CAM.setPos(UE.Vector3(R*math.cos(1*w*TIME),R*(1.1+math.cos(w*TIME)),R*math.sin(1*w*TIME)))
		if TIME> 500 then VFX.enableEffect(sobel, true) end
		if TIME> 600 then VFX.enableEffect(sobel, false) end
	elseif TIME> 750 and TIME <900 then
		VFX.enableEffect(motionBlur,false)
		CAM.setTarget(1)
		--CAM.setState(0)
		local w=0.05;
		local R=3
		CAM.setPos(UE.Vector3(R*math.cos(3*w*TIME),R*(1.1+math.cos(w*TIME)),R*math.sin(4*w*TIME)))
		if TIME> 700 then VFX.enableEffect(sobel, true) end
		if TIME> 800 then VFX.enableEffect(sobel, false) end
	elseif TIME> 900 then
		VFX.enableEffect(motionBlur,true)
		CAM.setTarget(2)
		--CAM.setState(0)
		local w=0.005;
		local R=3
		CAM.setPos(UE.Vector3(R*math.cos(3*w*TIME),R*(1.1+math.cos(0*TIME)),R*math.sin(4*w*TIME)))
	end
	
	stateUpdate(TIME)
end

function updateStateFromKeyboard()
	local state = CAM.getState()
	--- whatever YOU want, for example -->
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then state=1
	elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then state=12
	elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then state=13
	elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then state=14
	elseif UE.Input.GetKeyUp(UE.KeyCode.F5) then state=15
	elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then state=16 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then state=21
	elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then state=22
	end
	CAM.setState(state)
	--print(state)
end

function stateUpdate(TIME)
	local state = CAM.getState()
	if state==0 then update10()
	elseif state==1			then CAM.stateUpdate(TIME)
	elseif state==12	then update12()
	elseif state==13	then update13()
	elseif state==14	then update14()
	elseif state==15	then update15()
	elseif state==16	then update16()
	end
end

function update10()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
end
function update12()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local a = CAM.mainCamera.transform.position
	local b = CAM.mainCamera.transform.eulerAngles
	if UE.Input.GetKey(UE.KeyCode.PageUp) 			then b.x = b.x+1
	elseif UE.Input.GetKey(UE.KeyCode.PageDown) 	then b.x = b.x-1
	elseif UE.Input.GetKey(UE.KeyCode.LeftArrow) 	then b.y = b.y-1
	elseif UE.Input.GetKey(UE.KeyCode.RightArrow) 	then b.y = b.y+1
	elseif UE.Input.GetKey(UE.KeyCode.Q) 			then a.y = a.y-0.1
	elseif UE.Input.GetKey(UE.KeyCode.E) 			then a.y = a.y+0.1
	elseif UE.Input.GetKey(UE.KeyCode.W) 			then a.z = a.z-0.1
	elseif UE.Input.GetKey(UE.KeyCode.S) 			then a.z = a.z+0.1
	elseif UE.Input.GetKey(UE.KeyCode.A) 			then a.x = a.x+0.1
	elseif UE.Input.GetKey(UE.KeyCode.D) 			then a.x = a.x-0.1
	end
	CAM.mainCamera.transform.position = a
	CAM.mainCamera.transform.eulerAngles = b
	if UE.Input.GetKey(UE.KeyCode.UpArrow) then
		CAM.mainCamera.transform:Translate( 0.1*UE.Vector3.forward)
	elseif UE.Input.GetKey(UE.KeyCode.DownArrow) then
		CAM.mainCamera.transform:Translate(-0.1*UE.Vector3.forward)
	end
	local i=CAM.getTarget()
	if i ~= -1 then
		CAM.lookAt(Members[i].transform.position + UE.Vector3(0,1.3,0))
	end
end

function update13()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local i=CAM.getTarget()
	if i<0 or i>Nagn then camTargPos=UE.Vector3(0,2,0) 		
	else  camTargPos=Members[i].transform.position
	end
	camOffSet.x=0
	camOffSet.z=0
	camOffSet.y=math.max(0.10,camOffSet.y);		
	CAM.setPos(camTargPos+camOffSet)
	CAM.lookAt(camTargPos+UE.Vector3(0,1.3,0))
	if UE.Input.GetKey(UE.KeyCode.E) 		 	then camOffSet=camOffSet+UE.Vector3(0,0.05,0) end
	if UE.Input.GetKey(UE.KeyCode.Q)		  	then camOffSet=camOffSet-UE.Vector3(0,0.05,0) end 
	if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then camOffSet=camOffSet+UE.Vector3(0,0.05,0) end
	if UE.Input.GetKey(UE.KeyCode.PageDown)  	then camOffSet=camOffSet-UE.Vector3(0,0.05,0) end 
	if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then camOffSet=camOffSet+0.05*CAM.mainCamera.transform.forward end 
	if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then camOffSet=camOffSet-0.05*CAM.mainCamera.transform.forward end 
end

function update14()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local i=CAM.getTarget()
	if i<0 or i>Nagn then camTargPos=UE.Vector3(0,2,0) 		
	else  camTargPos=Members[i].transform.position
	end
	camOffSet.y=math.max(0.10,camOffSet.y);		
	CAM.setPos(camTargPos+camOffSet)
	--CAM.lookAt(camPos+UE.Vector3(0,1.3,0))
	CAM.setRot(UE.Vector3(89.8,0,0))
	if UE.Input.GetKey(UE.KeyCode.D) 		 	then camOffSet=camOffSet+UE.Vector3(0.05,0,0) end
	if UE.Input.GetKey(UE.KeyCode.A)		  	then camOffSet=camOffSet-UE.Vector3(0.05,0,0) end 
	if UE.Input.GetKey(UE.KeyCode.E) 		 	then camOffSet=camOffSet+UE.Vector3(0,0.05,0) end
	if UE.Input.GetKey(UE.KeyCode.Q)		  	then camOffSet=camOffSet-UE.Vector3(0,0.05,0) end 
	if UE.Input.GetKey(UE.KeyCode.W) 		 	then camOffSet=camOffSet+UE.Vector3(0,0,0.05) end
	if UE.Input.GetKey(UE.KeyCode.S)		  	then camOffSet=camOffSet-UE.Vector3(0,0,0.05) end 
	if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then camOffSet=camOffSet+UE.Vector3(0,0.05,0) end
	if UE.Input.GetKey(UE.KeyCode.PageDown)  	then camOffSet=camOffSet-UE.Vector3(0,0.05,0) end 
	if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then camOffSet=camOffSet+0.05*CAM.mainCamera.transform.forward end 
	if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then camOffSet=camOffSet-0.05*CAM.mainCamera.transform.forward end 
end

function update15()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local i=CAM.getTarget()
	if i>0 and i<Nagn then 
		camTargPos=Members[i].transform.position
		CAM.setPos(camTargPos+camOffSet)
		CAM.lookAt(camTargPos+UE.Vector3(0,1.3,0))
		local b = CAM.mainCamera.transform.eulerAngles
		if UE.Input.GetKey(UE.KeyCode.PageUp) 	 	then camOffSet=camOffSet+UE.Vector3(0,0.05,0) end
		if UE.Input.GetKey(UE.KeyCode.PageDown)  	then camOffSet=camOffSet-UE.Vector3(0,0.05,0) end 
		if UE.Input.GetKey(UE.KeyCode.LeftArrow) 	then b.y=b.y+1 end
		if UE.Input.GetKey(UE.KeyCode.RightArrow)	then b.y=b.y-1 end
		if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 	then camOffSet=camOffSet+0.05*CAM.mainCamera.transform.forward end 
		if UE.Input.GetKey(UE.KeyCode.DownArrow) 	then camOffSet=camOffSet-0.05*CAM.mainCamera.transform.forward end 
		camOffSet.x=math.max(0.40,camOffSet.x);		
		camOffSet.y=math.max(0.10,camOffSet.y);		
		camOffSet.z=math.max(0.40,camOffSet.z);
		CAM.mainCamera.transform.eulerAngles = b
	end
end

function update16()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	local i=CAM.getTarget()
--	if i<0 and i<Nagn then camTargPos=UE.Vector3(0,2,0) 		
	if i>0 and i<Nagn then 
		camTargPos=Members[i].transform.position
		if UE.Input.GetKey(UE.KeyCode.PageUp) 	 then Hst=Hst+0.05 end
		if UE.Input.GetKey(UE.KeyCode.PageDown)  then Hst=Hst-0.05 end
		if UE.Input.GetKey(UE.KeyCode.UpArrow) 	 then Rst=Rst-0.25 end
		if UE.Input.GetKey(UE.KeyCode.DownArrow) then Rst=Rst+0.25 end
		Hst=math.max(Hst,0.10);
		Rst=math.max(Rst,0.40);
		CAM.setPos(camTargPos+UE.Vector3(Rst*math.cos(0.3*UE.Time.time),Hst,Rst*math.sin(0.3*UE.Time.time)))
		CAM.lookAt(camTargPos+UE.Vector3(0,1.3,0))
	end
end

function update26()
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	CAM.setPos(UE.Vector3(3,4,1))
end

function update27()
	local R=7
	if CAM.isCinemachineEnabled() then CAM.useCinemachine(false) end
	CAM.setPos(UE.Vector3(R*math.cos(0.015*TIME),3,R*math.sin(0.015*TIME)))
end
