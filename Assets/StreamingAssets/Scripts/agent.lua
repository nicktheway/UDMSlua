-- aliases --
local UE = CS.UnityEngine

-- vars --
local wPos = 0.4
local wRot = 0.2
local ww = 0.05


function onElementAnimatorIK(layerIndex, id)
	local anim = Members[id]:GetComponent(typeof(UE.Animator))
	
	local ikwP = wPos * (1 + math.cos(ww * UE.Time.frameCount))
	
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,ikwP);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftHand, anim:GetIKPosition(UE.AvatarIKGoal.RightHand));
	
	ikwP = wPos * (1 + math.sin(ww * UE.Time.frameCount));
end
