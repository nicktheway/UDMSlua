-- aliases --
local UE = CS.UnityEngine

function awake()
    self.ActiveCamera = "dolly"
	self.DollyPath = 'circular'
    self.FOV = 40

	self:LookAtGroupAgent('group', 0, UE.Vector3(0,1,0))
	--self:FollowGroupAgent('group', 0, UE.Vector3(6,10, 6))
	self.AutoDolly = false
	self:SetDollyPathPosition(3, 2, 5)
	--self:SetDollyPathScale(5, 10, 5)
end

function update()
	self.PathPosition = 0
end
