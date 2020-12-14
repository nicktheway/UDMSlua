local M = {}

function M.getRoomName(room)
	-- Returns the name of the room which is
	-- the name of the scenario's main directory
	return room.RoomName
end

function M.getScriptPath(room)
	-- Returns the full path of the scenario's base directory.
	return room.RoomScriptPath
end

function M.getSceneName(room)
	-- Returns the name of the room's scene.
	return room.SceneName
end

function M.useCameraScript(room)
	--  Creates a LuaCameraDomain that uses by default the camera.lua script. 
	--  Access to the camera domain's properties is possible from that script using the 'self' variable
	return room:InstantiateCameraRig()
end

M.addCamera = M.useCameraScript

function M.getGroups(room)
	-- Returns a dictionary of the registered LuaGroupDomains in the room.
	-- key: groupName, value: LuaGroupDomain
	return room.Groups
end

function M.getGroupNames(room)
	-- Return a list of the names of the registered group domains in the room.
	return room:GetGroupDomainNames()
end

function M.getGroup(room, groupName)
	-- Retrieves one of the room's group domains from its name.
	-- A group in general can be accessed via the Group variable in its script or using this function from any script in the room.
	return room:GetGroupDomain(groupName)
end

function M.addEmptyGroup(room, groupName, scriptPath)
	-- Creates a new group and adds it to the group domain dictionary. Does not run the domain.
	-- groupName: The name of the group. Must be unique in the room.
	-- scriptPath: The path of the script that will control the group.
	return room:AddGroupDomain(groupName, scriptPath)
end

function M.addGroupMember(room, groupName, assetPath, prefab)
	-- Adds a new prefab as a member of the specified group.
	return room:GetGroupDomain(groupName):AddMember(prefab, assetPath)
end

function M.runGroupScript(room, groupName)
	return room:GetGroupDomain(groupName):DoScript()
end

function M.addGroup(room, assetBundle, prefabName, instanceCount, groupName, scriptPath)
	-- will create a group with the amount of the object specified, attach a script and run it
	room:InstantiateGroup(prefabName, assetBundle, instanceCount, groupName, scriptPath)
end

function M.getDomains(room)
	-- Returns a dictionary of the groups and individual domains in the room
	-- (basically all the script associated objects) key: domainName, value: domain
	return room.RegisteredDomains
end

function M.getIndividualObjectNames(room)
	return room:GetIndividualDomainNames()
end

function M.getIndividualObject(room, domainName)
	-- Retrieves one of the room's individual domains from its registered name.
	-- An individual object can be accessed via the 'self' property inside its script or with this function from any script in the room
	return room:GetIndividualDomain(domainName)
end

function M.addIndividualObject(room, assetBundle, prefabName, objectName, scriptPath)
	-- will create an instance of the object specified, attach a script and run it
	-- returns the created game object
	room:InstantiateIndividualGameObject(prefabName, assetBundle, groupName, scriptPath)
end

function M.getObjects(room)
	-- Returns a dictionary of the registered objects in the room
	-- key: objectKey, value: gameObject
	return room.Objects
end

function M.getObject(room, objectKey)
	return room:GetObject(objectKey)
end

function M.getObjectKeys(room)
	-- Returns a list of the keys of the available registered objects in the room.
	return room:GetObjectKeys()
end

function M.addRegisteredObject(room, objectKey, objectType, components, activateObject)
	-- Instantiates a new registered object in the room. Use for simple objects that do not need their own scripts.
	if components == nil then components = {} end
	if activateObject == nil then activateObject  = true end
	return room:InstantiateAndRegisterObject(objectKey,objectType,components,activateObject)
	--type: camera, cube, cylinder, light, plane, quad, sphere, vcamera:
end

function M.addObject(room, objectType,components,activateObject)
	-- Instantiates a new object in the room. Use for simple objects that do not need their own scripts.
	if components == nil then components = {} end
	if activateObject == nil then activateObject  = true end
	return room:InstantiateObject(objectType,components,activateObject)
	--type: camera, cube, cylinder, light, plane, quad, sphere, vcamera:
end

function M.registerObject(room, objectKey, object)
	-- Registers an object with a name.
	room:RegisterObject(objectKey, object)
end

return M