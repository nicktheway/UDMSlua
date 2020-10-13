local UE = CS.UnityEngine
local UT = require('utils')



--------------------------------------------------------------------------------
--- PREAMBLE

local objfuns = {}
	
--------------------------------------------------------------------------------
--- TOARRANGE
function objfuns.setParent(go,parentgo)
	go.transform:SetParent(parentgo.transform)
end
--------------------------------------------------------------------------------
--- LIGHTS

function objfuns.lgtAttach(go,typ)
	local light=go:AddComponent(typeof(UE.Light))
	if typ=="spot" then light.type=UE.LightType.Spot 
	elseif typ=="directional" then light.type=UE.LightType.Directional 
	elseif typ=="point" then light.type=UE.LightType.Point
	end
	return light
end

function objfuns.lgtMake(room,key,name,typ,pos,rot)
	local go = room:InstantiateAndRegisterObject(key,"light",nil,true)
	local light=go:GetComponent(typeof(UE.Light))
	light.renderMode=UE.LightRenderMode.ForcePixel
	if typ=="spot" then light.type=UE.LightType.Spot 
	elseif typ=="directional" then light.type=UE.LightType.Directional 
	elseif typ=="point" then light.type=UE.LightType.Point
	end
	go.transform.position=pos
	go.transform.eulerAngles=rot
	return go
end

function objfuns.lgtGetColor(go)
	local light=go:GetComponent(typeof(UE.Light))
	return light.color
end

function objfuns.lgtGetIntensity(go)
	local light=go:GetComponent(typeof(UE.Light))
	return light.intensity
end

function objfuns.lgtGetRange(go)
	local light=go:GetComponent(typeof(UE.Light))
	return light.range
end

function objfuns.lgtGetSpotAngle(go)
	local light=go:GetComponent(typeof(UE.Light))
	local spotAngle=nil
	if light.type=="spot" then spotAngle=light.spotAngle end
	return spotAngle
end

function objfuns.lgtGetType(go)
	local light=go:GetComponent(typeof(UE.Light))
	return light.type
end

function objfuns.lgtSetColor(go,color)
	local light=go:GetComponent(typeof(UE.Light))
	light.color=color
end

function objfuns.lgtSetIntensity(go,a)
	local light=go:GetComponent(typeof(UE.Light))
	light.intensity=a
end

function objfuns.lgtSetRange(go,r)
	local light=go:GetComponent(typeof(UE.Light))
	light.range=r
end

function objfuns.lgtSetSpotAngle(go,a)
	local light=go:GetComponent(typeof(UE.Light))
	if light.type==UE.LightType.Spot then light.spotAngle=a end
end

function objfuns.lgtSetType(go,typ)
	local light=go:GetComponent(typeof(UE.Light))
	light.type=typ
end

--------------------------------------------------------------------------------
--- OBJECTS

function objfuns.getAllComponents(go)
	return 	go:GetComponents(typeof(UE.Component))
end

function objfuns.getDirMine(go)
	local dir = go.transform.forward
	return dir.normalized
end

function objfuns.getDirToPnt(go,point)
	local v = point-go.transform.position
	v = UE.Vector3(v.x,0,v.z)
	return v.normalized
end

function objfuns.getDistToPnt(go,point)
	local v = point-go.transform.position
	v = UE.Vector3(v.x,0,v.z)
	return v.magnitude
	--return math.sqrt(v.x^2+v.z^2)
end

function objfuns.getPos(go)
	return go.transform.position
end

function objfuns.getPosX(go)
	return go.transform.position.x
end

function objfuns.getPosY(go)
	return go.transform.position.y
end

function objfuns.getPosZ(go)
	return go.transform.position.z
end

function objfuns.getRot(go)
	return go.transform.eulerAngles
end

function objfuns.getRotX(go)
	return go.transform.eulerAngles.x
end

function objfuns.getRotY(go)
	return go.transform.eulerAngles.y
end

function objfuns.getRotZ(go)
	return go.transform.eulerAngles.z
end

function objfuns.makeObject(room,key,name,typ,pos)
	local go
	go = room:InstantiateAndRegisterObject(key,typ,nil,true)
	go.name=name
	go.transform.position=pos
	return go
end

function objfuns.moveFwd(go,d)
	go.transform.position=go.transform.position+d*go.transform.forward
end

function objfuns.moveInDir(go,dir,d)
	go.transform.position=go.transform.position+d*dir
end

function objfuns.moveRight(go,d)
	go.transform.position=go.transform.position+d*go.transform.right
end

function objfuns.moveUp(go,d)
	go.transform.position=go.transform.position+d*go.transform.up
end

function objfuns.setPos(go,pos)
	go.transform.position=pos
end

function objfuns.setPosX(go,xpos)
	local pos=go.transform.position
	pos.x=xpos
	go.transform.position=pos
end

function objfuns.setPosY(go,ypos)
	local pos=go.transform.position
	pos.y=ypos
	go.transform.position=pos
end

function objfuns.setPosZ(go,zpos)
	local pos=go.transform.position
	pos.z=zpos
	go.transform.position=pos
end

function objfuns.setRot(go,rot)
	go.transform.eulerAngles =rot
end

function objfuns.setRotX(go,xrot)
	local rot=go.transform.eulerAngles
	rot.x=xrot
	go.transform.eulerAngles=rot
end

function objfuns.setRotY(go,yrot)
	local rot=go.transform.eulerAngles
	rot.y=yrot
	go.transform.eulerAngles=rot
end

function objfuns.setRotZ(go,zrot)
	local rot=go.transform.eulerAngles
	rot.z=zrot
	go.transform.eulerAngles=rot
end

function objfuns.setScale(go,scale)
	go.transform.localScale=scale
end

function objfuns.setColor(go,color)
	local renderers = go:GetComponentsInChildren(typeof(UE.Renderer))
	for i=0,renderers.Length-1 do
		renderers[i].material.color=color 
	end
end

function objfuns.textureObj(go,assetpath,texturename,sx,sz)
	local texture = CS.LuaScripting.AssetManager.LoadAsset(typeof(UE.Texture),texturename,assetpath)
	go:GetComponent(typeof(UE.Renderer)).material.mainTexture = texture
	go:GetComponent(typeof(UE.Renderer)).material.mainTextureScale = UE.Vector2(sx, sz)
end

function objfuns.turnFwd(go,a)
	go.transform:Rotate(a*UE.Vector3.forward)
end

function objfuns.turnRght(go,a)
	go.transform:Rotate(a*UE.Vector3.right)
end

function objfuns.turnToAngle(go,targAng,dAng)
	if(go.transform.eulerAngles.y>targAng) then go.transform:Rotate(-dAng*UE.Vector3(0,1,0)) end
	if(go.transform.eulerAngles.y<targAng) then go.transform:Rotate( dAng*UE.Vector3(0,1,0)) end
end

function objfuns.turnToDir(go,dir,dAng)
	local targAng=math.atan(dir.x,dir.z)
	targAng=math.deg(targAng)
	if(go.transform.eulerAngles.y>targAng) then go.transform:Rotate(-dAng*UE.Vector3(0,1,0)) end
	if(go.transform.eulerAngles.y<targAng) then go.transform:Rotate( dAng*UE.Vector3(0,1,0)) end
end
function objfuns.turnToDir2(go,dir,wr)
	local point1=UE.Vector3(go.transform.position.x,0,go.transform.position.z)
	local point=point1+1000*dir.normalized
	local meRot=go.transform.rotation
	local trgRot = UE.Quaternion.LookRotation(point);
	go.transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
end

function objfuns.turnToPnt(go,point,wr)
	local meRot=go.transform.rotation
	local trgRot = UE.Quaternion.LookRotation(point);
	go.transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
end	

function objfuns.turnUp(go,a)
	go.transform:Rotate(a*UE.Vector3.up)
end

--[[
--?????????????????????????????????????????
function objfuns.turnToMoveDir(go,wr)
	local meRot=go.transform.rotation
	local d=group.Members[i]:Displacement()
	local a=math.atan(d.x,d.z)*180/3.14159;
	local trgRot = UE.Quaternion.Euler(0,a,0);
	go.transform.rotation = UE.Quaternion.Slerp(meRot,trgRot,wr*UE.Time.deltaTime);
end

--?????????????????????????????????????????
function objfuns.setTurnToMoveDir(go,turn)
	group.Members[i].TurnToMoveDir=turn
end

--?????????????????????????????????????????
function objfuns.turnByDir(go,dir,wr)
	local ang0 = go.transform.eulerAngles.y
	local dir0 = UE.Vector3(math.cos(ang0),0,math.sin(ang0))
	local dir1 = dir/math.sqrt(dir.x^2+dir.z^2)
	local dir2 = dir0+dir1
	group.Members[i]:TurnToDirSoft(dir2,wr)
end
--]]

--------------------------------------------------------------------------------
--- TRAILS

function objfuns.trailAttach(go,offset,color,tim,width)
	local go1=UE.GameObject("Trail")
	go1.transform.parent=go.transform 
	go1.transform.position=go.transform.position +offset
	trail = UT.attachTrailRenderer(go1)
	trail.startColor = color
	trail.endColor = color
	trail.time = tim
	trail.startWidth = width
	trail.endWidth = width
	return trail
end

function objfuns.trailGetEndColor(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail.endColor
end

function objfuns.trailGetEndWidth(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail.endWidth
end

function objfuns.trailGetStartColor(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail.startColor
end

function objfuns.trailGetStartWidth(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail.startWidth
end

function objfuns.trailGetTime(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail.time
end

function objfuns.trailGetTrail(go)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	return trail
end

function objfuns.trailSetEndColor(go,color)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	--if not trail==nil then trail.endColor=color end
	trail.endColor=color
end

function objfuns.trailSetEndWidth(go,width)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	--if not trail==nil then trail.endWidth=width end
	trail.endWidth=width
end

function objfuns.trailSetStartColor(go,color)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	--if not trail==nil then trail.startColor=color end
	trail.startColor=color
end

function objfuns.trailSetStartWidth(go,width)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	--if not trail==nil then trail.startWidth=width end
	trail.startWidth=width
end

function objfuns.trailSetTime(go,tim)
	local trail=go:GetComponentInChildren(typeof(UE.TrailRenderer))
	--if not trail==nil then trail.time=tim end
	trail.time=tim
end

return objfuns


