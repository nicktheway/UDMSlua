-- aliases --
local UE = CS.UnityEngine

function awake()
    self.ActiveCamera = "dolly"
	self.DollyPath = 'circular'
    self.FOV = 30

	self:LookAtGroupAgent('group', 0, UE.Vector3(0,1,0))
	self:FollowGroupAgent('group', 0, UE.Vector3(6,10, 6))
	self.AutoDolly = false
	self:SetDollyPathPosition(0, 5, 0)
	self:SetDollyPathScale(5, 10, 5)
end

function update()
	self.PathPosition = self.PathPosition + 0.03
end
