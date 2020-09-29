local UE = CS.UnityEngine
local UT = require('utils')

function groupff()

--------------------------------------------------------------------------------
--- TO ARRANGE

	local roomfuns = {}

--addGameObject
--DistTravelled
--gcaUpdate(type3, type4, ...

	function roomfuns.roomAddMember(group,name,folder)
		return group:AddMember(name,folder)
	end
	function roomfuns.roomMakeGroup(room,prefabName, assetBundle, amount, domainName, scriptRelativePath)
		local grp = room:InstantiateGroup(prefabName, assetBundle, amount, domainName, scriptRelativePath)
		return grp
	end

	
	function roomfuns.roomGetGroups(room)
		return room.Groups
	end

	function roomfuns.roomGetGroups(room)
		return room.Groups
	end
	function roomfuns.roomGetObjects(room)
		return room.Objects
	end
	function roomfuns.roomGetRegDomains(room)
		return room.RegisteredDomains
	end
	function roomfuns.roomGetRoomName(room)
		return room.RoomName
	end
	function roomfuns.roomGetSceneName(room)
		return room.SceneName
	end
	function roomfuns.roomGetScriptPath(room)
		return room.RoomScriptPath
	end



	function roomfuns.roomAddGroupDomain(room,name,script)
		room:AddGroupDomain(name,script)
	end
	function roomfuns.roomGetGroupDomain(room,groupName)
		return room:GetGroupDomain(groupName)
	end
	function roomfuns.roomGetGroupDomainNames(room)
		return room:GetGroupDomainNames()
	end
	function roomfuns.roomGetIndividualDomain(room,domainName)
		return room:GetIndividualDomain(domainName)
	end
	function roomfuns.roomGetIndividualDomainNames(room)
		return room:GetIndividualDomainNames()
	end
	function roomfuns.roomGetObject(room,objectKey)
		return room:GetObject(objectKey)
	end
	function roomfuns.roomGetObjectKeys(room)
		return room:GetObjectKeys()
	end
	function roomfuns.roomMakeAndRegisterObject(room,objectKey, objectType, components, activateObject)
		local go = room:InstantiateAndRegisterObject(objectKey, objectType, components, activateObject)
		return go
	end
	function roomfuns.roomMakeCamera(room)
		local cam = room:InstantiateCameraRig()
		return cam
	end
	function roomfuns.roomMakeIndivObject(room,prefabName, assetBundle, domainName, scriptRelativePath)
		local go = room:InstantiateIndividualGameObject(prefabName, assetBundle, domainName, scriptRelativePath)
		return go
	end
	function roomfuns.roomMakeObject(room,objectType, components, activateObject)
		local go = room:InstantiateObject(objectType, components, activateObject)
		return go
		--camera:
		--cube:
		--cylinder:
		--light:
		--plane:
		--quad:
		--sphere:
		--vcamera:
	end
	function roomfuns.roomRegiObject(room,objectKey, myLight)
		room:RegisterObject(objectKey, myLight)
	end


	--[[
	function roomfuns.setParent(go,parentgo)
		go.transform:SetParent(parentgo.transform)
	end
	--]]
	
	return roomfuns
end

return groupff

