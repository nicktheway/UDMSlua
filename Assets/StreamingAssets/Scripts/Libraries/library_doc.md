---
  title: UDMS Library Documentation
  author: Nik and Thn
  date: 05-10-2020
---

# Room (functionsRoom.lua)

All the examples assume that the 'Room' variable contains a LuaRoom.
This is true by default inside all the individual, group and settings scripts.

### getRoomName(room)
Returns the name of the room.

```lua
local roomName = require('functionsRoom').getRoomName(Room)
```

### getScriptPath(room)
Returns the containing folder of the room's settings.lua.

```lua
local scriptPath = require('functionsRoom').getScriptPath(Room)
```

### getSceneName(room)
Returns the name of the unity scene the room is using.

```lua
local sceneName = require('functionsRoom').getSceneName(Room)
```

### useCameraScript(room)
Use the camera.lua script in the room/scenario.
The camera.lua script must exist in the room's path.

```lua
require('functionsRoom').useCameraScript(Room)
```
### addCamera(room)
Alias for useCameraScript(room)

```lua
require('functionsRoom').addCamera(Room)
```

### getGroups(room)
Returns a dictionary of the groups in the room.
Format: key: groupName, value: group

```lua
local groups = require('functionsRoom').getGroups(Room)
```

### getGroupNames(room)
Returns a list with the names of all the groups in the room.

```lua
local groupNames = require('functionsRoom').getGroupNames(Room)
```

### getGroup(room, groupName)
Returns a room's group from its name.

```lua
local groupName = 'dancers'
local group = require('functionsRoom').getGroup(Room, 'dancers')
```

### TODO: etc

-------------------------------------------------------------------------

# Group (functionsGRP.lua)

The 'LFG' variable in all the examples below is assumed to be defined like,
where the 'Group' variable contains a LuaGroup.

The 'Group' variable exists by default inside each group script. It can also be
set on any script using the room's getGroup function.

Also, all the group member ids that appear are assumed to be in range.

```lua
local LFG = require('functionsGRP')(Group)
```

### getMembers()
Returns a list of the group's members.

```lua
local members = LFG.getMembers()
```

### dirToAgent(i, j)
Returns the direction (Vector3) of the agent with id i to the agent with id j.

```lua
local dir_0_to_2 = LFG.dirToAgent(0, 2)
```

### TODO: etc

-------------------------------------------------------------------------

# Objects (functionsOBJ.lua)

### setParent(go, parentGo)
Sets the go as a child of parentGo.

```lua
-- Assuming go and parentGo are gameObjects or MonoBehaviours
require(functionsOBJ').setParent(go, parentGo)
```

### TODO: etc

## Lights

### lgtGetColor(go)
Sets the color of the light component of the go.

```lua
-- Assuming go is a gameObject/MonoBehaviour on a gameObject with a light component
require(functionsOBJ').lgtGetColor(go)
```

### TODO: etc

## Trails

### trailGetTime(go)
Returns the alive time of the trail particles.

```lua
-- Assuming go is a gameObject/MonoBehaviour on a gameObject with a trail component IN CHILDREN
local time = require(functionsOBJ').trailGetTime(go)
```

### TODO: etc

---------------------------------------------------------------------------

# Camera (functionsCAM.lua)

### stateUpdate(TIME, state)
Updates the camera based on the TIME and state parameters.
If the state isn't given, it uses the camera's current state.

```lua
-- Updates the camera using the update3 function.
require('functionsCAM')(self).stateUpdate(TIME, 3)	
```

### TODO: etc

---------------------------------------------------------------------------

# Effects (effects.lua)

### setProperty(effectProperty, value)
Sets the effectProperty to the value specified.

```lua
require('effects').setProperty(lutEffect.Saturation, 0.5)
```

### TODO: etc

---------------------------------------------------------------------------

# Utilities (utils.lua)

### TODO: etc

---------------------------------------------------------------------------

# Logic (logic.lua)

---------------------------------------------------------------------------

# Animations List (animations.lua)

---------------------------------------------------------------------------

# Look Up Textures List (luts.lua)

![Action3D16](../../../Data/Textures/LUTs/Action3D16.png)

