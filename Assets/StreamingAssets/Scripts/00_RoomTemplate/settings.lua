scene = 'RoomA'

function setUp()
    local group = room:InstantiateGroup('NeoMan', 'models/main', 16, 'group', 'group.lua')
	local camera = room:InstantiateCameraRig()
end
