local UE = CS.UnityEngine
local effects = require('effects')

local Nagn = Members.Count
local frameCounter = 0

function start()
    -- Group function call example
    -- full list of available functions at: https://udms-docs.netlify.app/src-pages-scripting-api-group/
    Group:ToGridFormation(4, UE.Vector3(-2, 0, -2), 1, 1)

    --[[ Disable Cinemachine
    local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
    if cinemachineBrain then
        cinemachineBrain.enabled = false
    end
	--]]
	Group:ToggleIndices(true)
	UE.GameObject.CreatePrimitive(UE.PrimitiveType.Cube)
end

function update()
    for i = 0, Nagn - 1 do
        individualUpdate(i)
    end
	
	if frameCounter % 300 == 0 then
		effects.vignetteEffect(1, 1, 1)
	end
	
	frameCounter = frameCounter + 1
end

function individualUpdate(id)
    -- Placeholder: make all agents face (0, 0, 0)
    -- Group Member function call example,
    -- full list at: https://udms-docs.netlify.app/src-pages-scripting-api-group-member
    local newDir =  Members[id]:DirAgentToPnt(UE.Vector3(0, 0, 0))
    Members[id]:SetDir(newDir)
end
