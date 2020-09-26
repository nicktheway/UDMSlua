local UE = CS.UnityEngine
local UT = require('utils')
local CF = require('functionsCAM')(self)

local groupDomain
local TIME=0

function start()
	CF.setState(1)
	groupDomain = Room:GetGroupDomain('dancers')
	CF.setTargetGroup(groupDomain)
	CF.setPos(UE.Vector3(4, 3, -8))
	CF.lookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	
	CF.stateInit()
end

function update()
	TIME=TIME+1
	CF.updateStateFromKeyboard()
	--updateStateFromKeyboard()
	if CF.getState() ~= self.OldState then
		CF.stateInit()
	end
	
	CF.stateUpdate()
	CF.updateTargetFromKeyboard()
	UT.printOnScreen(CF.getState())
end

function updateStateFromKeyboard()
	local state = self.State
	if UE.Input.GetKeyUp(UE.KeyCode.F1) then 		-- free camera with mouse
		state=1
	elseif UE.Input.GetKeyUp(UE.KeyCode.F2) then 	-- free camera with KB and side view
		state=2
	elseif UE.Input.GetKeyUp(UE.KeyCode.F3) then 	-- free camera with KB and topdown view
		state=3 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F4) then 	-- fixed camera with side view, follow agent
		state=4 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F5) then 
		state=5 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F6) then 
		state=6 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F7) then 
		state=7 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F8) then 
		state=8
	elseif UE.Input.GetKeyUp(UE.KeyCode.F9) then 
		state=9 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F10) then 
		state=10
	elseif UE.Input.GetKeyUp(UE.KeyCode.F11) then 
		state=11 
	elseif UE.Input.GetKeyUp(UE.KeyCode.F12) then 
		state=12 
	end
	
	self.State = state
end




