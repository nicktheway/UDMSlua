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
	CAM.updateStateFromKeyboard()	-- or: updateStateFromKeyboard(), user defined
	CAM.updateTargetFromKeyboard()
	if CAM.getState() ~= CAM.getOldState() then CAM.stateInit() end
	CAM.targetUpdate()
	CAM.stateUpdate(TIME)
	--UT.printOnScreen(self.State)
end

function updateStateFromKeyboard()
	local state = CAM.getState()
	--- whatever YOU want, for example -->
	-- if UE.Input.GetKeyUp(UE.KeyCode.F1) then state=8 -- free camera with mouse
	-- elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then state=2 end
	CAM.setState(state)
end

