-- aliases --
local UE = CS.UnityEngine

-- vars --
local speed = 100;
local speedBlue = 100;

function onSpaceButtonDown()
	local go = UE.GameObject.CreatePrimitive(UE.PrimitiveType.Sphere) 
	go.transform.position = Members[0].transform.position + UE.Vector3.up
	
	local rb = go:AddComponent(typeof(UE.Rigidbody))
	
	rb:AddForce(UE.Vector3.up * 20, UE.ForceMode.VelocityChange)
	UE.Object.Destroy(go, 3)
end

function start()
	print('Lua start')
end

function update()
	local r = UE.Vector3.zero
	r = UE.Vector3.right * UE.Time.deltaTime * speed
	local r1 = UE.Vector3.up * UE.Time.deltaTime * speedBlue

	
	Members[0].transform:Rotate(r)
	Members[1].transform:Rotate(r1)
	
	if UE.Input.GetKeyDown(UE.KeyCode.Space) then
		onSpaceButtonDown()
	end
end