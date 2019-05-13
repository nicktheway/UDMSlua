-- aliases --
local UE = CS.UnityEngine

-- vars --
local speed = 100;
local speedBlue = 100;

function onSpaceButtonDown()
	local go = UE.GameObject.CreatePrimitive(UE.PrimitiveType.Sphere) 
	go.transform.position = self.transform.position + UE.Vector3.up
	
	local rb = go:AddComponent(typeof(UE.Rigidbody))
	
	rb:AddForce(UE.Vector3.up * 20, UE.ForceMode.VelocityChange)
	UE.Object.Destroy(go, 3)
end

function start()
	print('Lua start')
end

function update()
	local r1 = UE.Vector3.right * UE.Time.deltaTime * speed
	local r2 = UE.Vector3.up * UE.Time.deltaTime * speedBlue
	
	
	if self.ObjectId == 0 then
		self.transform:Rotate(r1)
	elseif self.ObjectId == 1 then
		self.transform:Rotate(r2)
	end
end