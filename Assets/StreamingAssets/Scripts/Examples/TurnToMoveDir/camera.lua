-- aliases --
local UE = CS.UnityEngine

function awake()
    self.ActiveCamera = "locked"
    self.FOV = 60

    self:SetFollowTarget(null, UE.Vector3(0, 3, -5))
    self:SetLookAtTarget(null, UE.Vector3(0, 0, 0))
end

