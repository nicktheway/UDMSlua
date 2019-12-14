-- aliases --
local UE = CS.UnityEngine

local anims = {}

function start()
    for i=0,Members.Count - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
    end

    anims[0]:Play('Esquiva 1', 0, 0)
end