scene = 'RoomA'

function setUp()
	setMusic('MusicArchiveOrg/D_SMILEZ_-_02_-_Blinded_in_Sweet_Realism.ogg')
    local group = room:InstantiateGroup('NeoMan', 'models/main', 16, 'group', 'group.lua')
	local camera = room:InstantiateCameraRig()
end

