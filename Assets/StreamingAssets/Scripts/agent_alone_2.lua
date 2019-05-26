-- aliases --
local UE = CS.UnityEngine

-- vars --
local wPos = 0.4
local wRot = 0.2
local ww = 0.05

local anim = {}
local leftHandTarget = {}
local rightHandTarget = {}
local leftFootTarget = {}

function start()
	anim = self:GetComponent(typeof(UE.Animator))
	leftHandTarget = anim:GetBoneTransform(UE.HumanBodyBones.RightShoulder)
	rightHandTarget = anim:GetBoneTransform(UE.HumanBodyBones.LeftShoulder)
	leftFootTarget = anim:GetBoneTransform(UE.HumanBodyBones.RightUpperLeg)
end

function onAnimatorIK(layerIndex)
	-- Weights
	local ikwP = wPos * (1 + math.cos(ww * UE.Time.frameCount))
	local ikwR = wRot
	
	-- Left hand
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.LeftHand,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftHand, leftHandTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.LeftHand, leftHandTarget.rotation);

	
	-- Right hand
	anim:SetIKPositionWeight(UE.AvatarIKGoal.RightHand,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.RightHand,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.RightHand, leftHandTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.RightHand, leftHandTarget.rotation);
	
	ikwP = wPos * (1 + math.sin(ww * UE.Time.frameCount));
	
	--[[
	-- Left foot
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftFoot,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.LeftFoot,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftFoot, leftFootTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
	--]]
end
