local UE = CS.UnityEngine

local cam = UE.Camera.main
local groupDomain
local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
local lookTarget = UE.Vector3(0, 1, 0)

function start()
	groupDomain = Room:GetGroupDomain('dancers')
	cinemachineBrain.enabled = false
end

function update()
	listenToCameraShortcuts(groupDomain)
	cam.transform:LookAt(lookTarget)
end

function listenToCameraShortcuts(group)
	local n = group.Members.Count
	if UE.Input.GetKey(UE.KeyCode.LeftShift) then
		if UE.Input.GetKeyUp(UE.KeyCode.Alpha1) and n > 0 then
			lookTarget = group.Members[0].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha2) and n > 1 then
			lookTarget = group.Members[1].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha3) and n > 2 then
			lookTarget = group.Members[2].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha4) and n > 3 then
			lookTarget = group.Members[3].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha5) and n > 4 then
			lookTarget = group.Members[4].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha6) and n > 5 then
			lookTarget = group.Members[5].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha7) and n > 6 then
			lookTarget = group.Members[6].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha8) and n > 7 then
			lookTarget = group.Members[7].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha9) and n > 8 then
			lookTarget = group.Members[8].transform.position + UE.Vector3(0, 1, 0)
		elseif UE.Input.GetKeyUp(UE.KeyCode.Alpha0) and n > 0 then
			lookTarget = group:GetGroupCenter() + UE.Vector3(0, 1, 0)
		end
	end
end