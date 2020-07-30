local UE = CS.UnityEngine
local effects = require('effects')

local Nagn = Members.Count
local frameCounter = 0
local clip = 'Jazz Dancing01'
local anims = {}

function start()
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		anims[i]:CrossFade(clip, 0.4);
    end
    -- Group function call example
    -- full list of available functions at: https://udms-docs.netlify.app/src-pages-scripting-api-group/
    Group:ToGridFormation(4, UE.Vector3(-2, 0, -2), 1, 1)

    --[[ Disable Cinemachine
    local cinemachineBrain = UE.Camera.main:GetComponent(typeof(CS.Cinemachine.CinemachineBrain))
    if cinemachineBrain then
        cinemachineBrain.enabled = false
    end
	--]]
	Group:ToggleIndices(false)
end

function update()
	effects.checkGlobalEffectInputs()
    for i = 0, Nagn - 1 do
        individualUpdate(i)
    end
	
	if frameCounter % 200 == 0 then
		effects.vignetteEffect(1, 1, 1)
		effects.bloomEffect(50, 1, 2, 1)
		effects.colorGradingEffect(-100, 1, 2, 1)
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

