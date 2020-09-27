local M = {}

function M.getName(room)
	return room.RoomName
end

function M.getScriptPath(room)
	return room.RoomScriptPath
end

function M.getSceneName(room)
	return room.SceneName
end

function M.useCameraScript(room)
	return room:InstantiateCameraRig()
end

function M.getGroups(room)
	-- Returns a dictionary of the groups in the room.
	-- key: groupName, value: group
	return room.Groups
end

function M.getGroupNames(room)
	return room:GetGroupDomainNames()
end

function M.getGroup(room, groupName)
	return room:GetGroupDomain(groupName)
end

function M.addEmptyGroup(room, groupName, scriptPath)
	return room:AddGroupDomain(groupName, scriptPath)
end

function M.addGroupMember(room, groupName, assetPath, prefab)
	return room:GetGroupDomain(groupName):AddMember(prefab, assetPath)
end

function M.runGroupScript(room, groupName)
	return room:GetGroupDomain(groupName):DoScript()
end

function M.addGroup(room, assetBundle, prefabName, instanceCount, groupName, scriptPath)
	-- will create a group with the amount of the object specified, attach a script and run it
	room:InstantiateGroup(prefabName, assetBundle, instanceCount, groupName, scriptPath)
end

function M.getAllDomains(room)
	-- Returns a dictionary of the groups and individual domains in the room
	-- (basically all the script associated objects) key: domainName, value: domain
	return room.RegisteredDomains
end

function M.getIndividualObjectNames(room)
	return room:GetIndividualDomainNames()
end

function M.getIndividualObject(room, domainName)
	return room:GetIndividualDomain(domainName)
end

function M.addIndividualObject(room, assetBundle, prefabName, objectName, scriptPath)
	-- will create an instance of the object specified, attach a script and run it
	room:InstantiateIndividualGameObject(prefabName, assetBundle, groupName, scriptPath)
end

function M.getAllObjects(room)
	-- Returns a dictionary of the registered objects in the room
	-- key: objectKey, value: gameObject
	return room.Objects
end

function M.getObject(room, objectKey)
	return room:GetObject(objectKey)
end

function M.getObjectKeys(room)
	return room:GetObjectKeys()
end

function M.addRegisteredObject(room, objectKey, objectType)
	return room:InstantiateAndRegisterObject(objectKey, objectType)
end

function M.addObject(room, objectType)
	return room:InstantiateObject(objectType)
end

function M.registerObject(room, objectKey, object)
	room:RegisterObject(objectKey, object)
end

return M