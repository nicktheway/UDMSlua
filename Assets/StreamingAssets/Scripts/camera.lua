-- aliases --
local UE = CS.UnityEngine

-- vars --
local speed = 10;

function update()
	local offset = UE.Input.GetAxis('Vertical') * speed * UE.Time.deltaTime * UE.Vector3.up;
	
	self.transform.position = self.transform.position + offset;
end