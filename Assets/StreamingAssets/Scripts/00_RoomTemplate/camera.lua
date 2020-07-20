-- aliases --
local UE = CS.UnityEngine

function awake()
    self.ActiveCamera = "dolly"
	self.DollyPath = 'custom1'
    self.FOV = 30

	self:LookAtGroupAgent('group', 14, UE.Vector3(0, 2, 0))
	self:FollowGroupAgent('group', 14, UE.Vector3(0, 2.5, -0.8))
	self.AutoDolly = false
end

function update()
	self.PathPosition = self.PathPosition + 0.1
end