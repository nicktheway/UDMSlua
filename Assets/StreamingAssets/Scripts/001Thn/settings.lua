-- aliases --
local UE = CS.UnityEngine
local effects = require('effects')
local extras = require('extras')

-- global vars, used in other scripts
autoCamera = 0
scene = 'RoomA'

function setUp()
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')
	room:InstantiateCameraRig()
	local group = room:InstantiateGroup('NeoMan', 'models/main', 3, 'dancers', 'group.lua')
end

function update()
    effects.checkGlobalEffectInputs()
	extras.listenToGenericShortcuts()
end
