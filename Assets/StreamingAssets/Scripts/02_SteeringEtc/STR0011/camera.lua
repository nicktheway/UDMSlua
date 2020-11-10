local UE = CS.UnityEngine
local UT = require('utils')
local UE = CS.UnityEngine
local CAM = require('functionsCAM')(self)
local RM = require('functionsROOM')

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
	CAM.updateStateFromKeyboard()
	CAM.updateTargetFromKeyboard()
	CAM.targetUpdate()
	stateUpdate(TIME)
	--UT.printOnScreen(self.State)
end

function stateUpdate(TIME)
	local state = CAM.getState()
	if state<19		then CAM.stateUpdate(TIME) end
end
