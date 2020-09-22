-- aliases --
local UE = CS.UnityEngine

-- vars --
local speed = 100;

function onSpaceButtonDown()
	local go = UE.GameObject.CreatePrimitive(UE.PrimitiveType.Sphere) 
	go.transform.position = self.transform.position + UE.Vector3.up
	
	local rb = go:AddComponent(typeof(UE.Rigidbody))
	
	rb:AddForce(UE.Vector3.up * 20, UE.ForceMode.VelocityChange)
	UE.Object.Destroy(go, 3)
end

function awake()
	print('test - awake')
end

function start()
	print('test - start')
end

function update()
	local r = UE.Vector3.zero
	
	r = UE.Vector3.up * UE.Time.deltaTime * speed
	
	self.transform:Rotate(r)
end