local UE = CS.UnityEngine
local UT = require('utils')
local CF = require('functionsCAM')(self)

local cam00 = UE.Camera.main
local groupDomain
local TIME=0
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
local oldTarget = -1

function start()
	CF.setState(1)
	groupDomain = Room:GetGroupDomain('dancers')
	CF.setTargetGroup(groupDomain)
	cam00.transform.position=UE.Vector3(4,3,-8)
	cam00.transform:LookAt(groupDomain.Members[0].transform.position + UE.Vector3(0, 1, 0))
	
	CF.stateInit()
end

function update()
	TIME=TIME+1
	oldTarget = CF.getTarget()
	CF.updateStateFromKeyboard()
	if CF.getState() ~= self.OldState then
		CF.stateInit()
	end
	
	CF.stateUpdate()
	CF.updateTargetFromKeyboard()
	local newTarget = CF.getTarget()
	if newTarget ~= -1 then
		if not cinemachineBrain.enabled then
			cam00.transform:LookAt(groupDomain.Members[newTarget].transform.position + UE.Vector3(0, 1, 0))
		end
		if cinemachineBrain.enabled and newTarget ~= oldTarget then
			self:LookAtGroupAgent("dancers", newTarget, UE.Vector3(0,1,0))
		end
	end
	UT.printOnScreen(CF.getState())
end




