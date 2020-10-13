local UE = CS.UnityEngine
local UT = require('utils')
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')

local groupDomain
local TIME=0

function start()
	CAM.setState(1)
	CAM.setTargetGroup(Room, 'dancers')
	CAM.setPos(UE.Vector3(4,3,-8))
	groupDomain = RM.getGroup(Room, 'dancers')
	CAM.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	CAM.stateInit()
end

function update()
	TIME=TIME+1
	updateStateFromKeyboard()	-- or: updateStateFromKeyboard(), user defined
	CAM.updateTargetFromKeyboard()
	--if CAM.getState() ~= CAM.getOldState() then CAM.stateInit() end
	CAM.targetUpdate()
	--CAM.stateUpdate(TIME)
	stateUpdate(TIME)
	UT.printOnScreen(self.State)
end

function updateStateFromKeyboard()
	local state = CAM.getState()
	--- whatever YOU want, for example -->
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then state=1
	elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then state=2
	elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then state=3
	elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then state=4
	elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then state=26
	elseif UE.Input.GetKeyUp(UE.KeyCode.F7) then state=27 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then state=11
	elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then state=12
	end
	CAM.setState(state)
end

function stateUpdate(TIME)
	local state = CAM.getState()
	if state<19		then CAM.stateUpdate(TIME)
	elseif state==26	then update26()
	elseif state==27	then update27()
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
