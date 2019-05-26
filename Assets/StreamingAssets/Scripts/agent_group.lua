-- aliases --
local UE = CS.UnityEngine

-- vars --
local wPos = 0.4
local wRot = 0.2
local ww = 0.05

local anims = {}
local rightShoulders = {}
local leftShoulders = {}
local rightUpperLegs = {}
local leftUpperLegs = {}

function start()
	for i=0,Members.Count - 1 do
		anims[i] = Members[i]:GetComponent(typeof(UE.Animator))
		rightShoulders[i] = anims[i]:GetBoneTransform(UE.HumanBodyBones.RightShoulder)
		leftShoulders[i] = anims[i]:GetBoneTransform(UE.HumanBodyBones.LeftShoulder)
		rightUpperLegs[i] = anims[i]:GetBoneTransform(UE.HumanBodyBones.RightUpperLeg)
		leftUpperLegs[i] = anims[i]:GetBoneTransform(UE.HumanBodyBones.LeftUpperLeg)
	end
end

function onElementAnimatorIK(layerIndex, id)
	local anim = anims[id]
	local otherId = 0
	
	if id % 2 == 1 then 
		otherId = (id - 1) 
	else 
		otherId = (id + 1) 
	end

	-- Weights
	local ikwP = wPos * (1 + math.cos(ww * UE.Time.frameCount))
	local ikwR = wRot
	
	-- Left hand
	local leftHandTarget = rightShoulders[otherId]
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftHand,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.LeftHand,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftHand, leftHandTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.LeftHand, leftHandTarget.rotation);

	
	-- Right hand
	local rightHandTarget = leftShoulders[otherId]
	anim:SetIKPositionWeight(UE.AvatarIKGoal.RightHand,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.RightHand,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.RightHand, leftHandTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.RightHand, leftHandTarget.rotation);
	
	ikwP = wPos * (1 + math.sin(ww * UE.Time.frameCount));
	--[
	-- Left foot
	local leftFootTarget = rightUpperLegs[otherId]
	anim:SetIKPositionWeight(UE.AvatarIKGoal.LeftFoot,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.LeftFoot,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.LeftFoot, leftFootTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
	--]]
	--[[
	-- Right foot
	local rightFootTarget = leftUpperLegs[otherId]
	anim:SetIKPositionWeight(UE.AvatarIKGoal.RightFoot,ikwP);
	anim:SetIKRotationWeight(UE.AvatarIKGoal.RightFoot,ikwR);
	anim:SetIKPosition(UE.AvatarIKGoal.RightFoot, rightFootTarget.position);
	anim:SetIKRotation(UE.AvatarIKGoal.RightFoot, rightFootTarget.rotation);
	--]]

end