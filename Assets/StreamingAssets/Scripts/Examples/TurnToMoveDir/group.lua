local UE = CS.UnityEngine

local Nagn = Members.Count

local points = {UE.Vector2(-1, -1), UE.Vector2(-1, 1), UE.Vector2(1, 1), UE.Vector2(1, -1)}
local targets = {1, 2, 0, 3}

function start()
    Group:ToGridFormation(2, UE.Vector3(-1, 0, -1), 2, 2)
	Group:ToggleIndices(true)

    for i = 0, Nagn - 1 do
        Members[i].TurnToMoveDir = true
    end
end

function update()
    for i = 0, Nagn - 1 do
        individualUpdate(i)
    end
end

function individualUpdate(id)
    local point = points[targets[id+1]+1]
    Members[id]:GoToPointXZ(point, 0.02)
    if Members[id]:DistAgentToPntXZ(point) < 0.1 then
        targets[id+1] = (targets[id+1] + 1) % Nagn
    end
end

