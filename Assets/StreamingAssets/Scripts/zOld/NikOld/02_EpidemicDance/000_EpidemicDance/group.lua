-- aliases --
local UE = CS.UnityEngine
local sin = UE.Mathf.Sin
local cos = UE.Mathf.Cos
local floor = UE.Mathf.FloorToInt
local rand = UE.Random.Range

local anims = {}
local statuses = {}
local CRVTimes = {}

local clip1 = 'Idle02'
local clip2 = 'Jazz Dancing01'

local Nagn = Members.Count

local R0 = 3
local p1 = 0.3
local Dinf, Pheal = 2.5, 0.025
local Wx, Wz = 0.050, 0.050
local NormTransDur = 0.2
local TIME = 0

function start()
    for i=0,Nagn - 1 do
        anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
    end

    for i=0,Nagn-1 do
        individualPrepare(i)
    end
end

function update()
    for i=0,Nagn-1 do
        individualMove(i)
    end
    TIME = TIME + 1
end

function individualPrepare(agentId) 
    local agent = Members[agentId]
    local myAnim = anims[agentId]
    local transform = Members[agentId].transform
    
    anims[agentId]:Play(clip1, 0, 0)

    if rand(0.0, 1.0) < p1 then
        statuses[agentId] = 'Infected'
        CRVTimes[agentId] = rand(0, 300)
        myAnim:CrossFade(clip2, NormTransDur)
    else
        statuses[agentId] = 'Healthy'
        CRVTimes[agentId] = 0
    end

    transform.position = UE.Vector3(agentId, 0, 0)
    transform.eulerAngles.y = 0

end

function individualMove(agentId)
    local myAnim = anims[agentId]
    local transform = Members[agentId].transform

    -- State Transitions
    if statuses[agentId] == 'Healthy' then
        -- Infected by others
        for key, value in pairs(Group:GetMemberIdsInCircle(transform.position, Dinf)) do
            if statuses[value] == 'Infected' then
                statuses[agentId] = 'Infected'
                myAnim:CrossFade(clip2, NormTransDur)
            end
        end
    elseif statuses[agentId] == 'Infected' then
        if rand(0.0, 1.0) < Pheal then
            statuses[agentId] = 'Healthy'
            myAnim:CrossFade(clip1, NormTransDur)
        end
    end

    -- Movement
    if statuses[agentId] == 'Infected' then
        CRVTimes[agentId]=CRVTimes[agentId]+1
        local CRVTime = CRVTimes[agentId]

        transform.position = UE.Vector3(agentId * cos(Wx*CRVTime/(agentId+1)), 0, agentId * sin(Wz*CRVTime/(agentId+1)))
    end
end

--[[ Root motion is off :)
function onElementAnimatorMove(agentId)
    anims[agentId]:ApplyBuiltinRootMotion()
end
--]]

