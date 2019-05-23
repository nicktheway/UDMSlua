-- aliases --
local UE = CS.UnityEngine
local frame = UE.Time.frameCount

-- vars --
local wPos = 0.4
local wRot = 0.2
local ww = 0.05
local anim = self:GetComponent(typeof(UE.Animator))

function onAnimatorIK()
	local ikwP = wPos * (1 + math.cos(ww * frame))
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,ikwP);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftHand, anim:GetIKPosition(UE.AvatarIKGoal.RightHand));
	
	ikwP = wPos * (1 + math.sin(ww * frame));
end