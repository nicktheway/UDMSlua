scene = 'RoomA'

function setUp()
    local group = room:InstantiateGroup('NeoMan', 'models/main', 4, 'group', 'group.lua')
	local camera = room:InstantiateCameraRig()
end

