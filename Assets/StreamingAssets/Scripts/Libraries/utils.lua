local UE = CS.UnityEngine

local M = {}

local trailShader = nil

--------------------------------------------------------------------------------

function M.makeTransFun(ss,N)
	local Sin={}
	local Sout={}
	local J=2^N
	for j=1,J do
		Sin[j]=M.byte2bin(j-1,N)
		Sout[j]=M.byte2bin(ss[j],N)
	end
	return Sin, Sout
end
function M.byte2bin(n,N)
	local t = {}
	for i=N-1,0,-1 do
		t[#t+1] = math.floor(n / 2^i)
		n = n % 2^i
	end
	return t
end

function M.byte2binString(n)
	local t = {}
	for i=7,0,-1 do
		t[#t+1] = math.floor(n / 2^i)
		n = n % 2^i
	end
	return table.concat(t)
end


function M.colMakeColorMap(colmap)
	local cm = {}
	if colmap == "cool" then
		cm[1]={0.0000,1.0000,1.0000};
		cm[2]={0.0526,0.9474,1.0000};
		cm[3]={0.1053,0.8947,1.0000};
		cm[4]={0.1579,0.8421,1.0000};
		cm[5]={0.2105,0.7895,1.0000};
		cm[6]={0.2632,0.7368,1.0000};
		cm[7]={0.3158,0.6842,1.0000};
		cm[8]={0.3684,0.6316,1.0000};
		cm[9]={0.4211,0.5789,1.0000};
		cm[10]={0.4737,0.5263,1.0000};
		cm[11]={0.5263,0.4737,1.0000};
		cm[12]={0.5789,0.4211,1.0000};
		cm[13]={0.6316,0.3684,1.0000};
		cm[14]={0.6842,0.3158,1.0000};
		cm[15]={0.7895,0.2105,1.0000};
		cm[16]={0.7368,0.2632,1.0000};
		cm[17]={0.8421,0.1579,1.0000};
		cm[18]={0.8947,0.1053,1.0000};
		cm[19]={0.9474,0.0526,1.0000};
		cm[20]={1.0000,0.0000,1.0000};
	elseif colmap == "parula" then
		cm[1 ]={0.2667,0.2028,0.8087}
		cm[2 ]={0.2422,0.1504,0.6603}
		cm[3 ]={0.2797,0.2699,0.9141}
		cm[4 ]={0.2796,0.3435,0.9710}
		cm[5 ]={0.2567,0.4185,0.9962}
		cm[6 ]={0.1867,0.4981,0.9841}
		cm[7 ]={0.1700,0.5681,0.9374}
		cm[8 ]={0.1356,0.6315,0.8954}
		cm[9 ]={0.0831,0.6879,0.8494}
		cm[10]={0.0040,0.7296,0.7701}
		cm[11]={0.1466,0.7597,0.6797}
		cm[12]={0.2291,0.7880,0.5757}
		cm[13]={0.3802,0.8026,0.4448}
		cm[14]={0.5675,0.7936,0.2998}
		cm[15]={0.7455,0.7657,0.1789}
		cm[16]={0.8934,0.7348,0.1712}
		cm[17]={0.9961,0.7445,0.2362}
		cm[18]={0.9857,0.8228,0.1841}
		cm[19]={0.9595,0.9058,0.1463}
		cm[20]={0.9769,0.9839,0.0805}
	else
		error("no colormap of name "..colmap)
	end
	return cm
end

function M.stateToColor(s,numStates,cm)
	local n=math.floor((s+1)*#cm/numStates)
	return UE.Color(cm[n][1],cm[n][2],cm[n][3])
end

--------------------------------------------------------------------------------
function M.navAddSurface(gameObject)
	local surface = gameObject:AddComponent(typeof(UE.AI.NavMeshSurface))
	surface.collectObjects = 2
	return surface
end

function M.navBuildSurface(surface)
	surface:BuildNavMesh()
end

--------------------------------------------------------------------------------
local writeFiles = {}
function M.writeText(text, filepath, mode)
	if mode == nil then
		mode = 'a'
	end

	if writeFiles[filepath] == nil then
		writeFiles[filepath] = io.open(filepath, mode)
	end
	
	io.output(writeFiles[filepath])
	io.write(text)
end

function M.closeFile(filepath)
	io.close(writeFiles[filepath])
	writeFiles[filepath] = nil
end

function M.closeAllFiles()
	for k, v in pairs(writeFiles) do
		io.close(v)
	end
	writeFiles = {}
end

function M.readText(filepath)
	error('NOT IMPLEMENTED FUNCTION')
end
--------------------------------------------------------------------------------
function M.DirPntToPnt(pnt1,pnt2)
-- Returns the normalized direction vector from point pnt1 to point pnt2.
	return UE.Vector3.Normalize(pnt2-pnt1)
end

function M.DistOfPnts(pnt1,pnt2)
--Returns the distance from pnt1 to pnt2.
	return UE.Vector3.Distance(pnt1,pnt2)
end

function M.RotateVector(V1,a)
--Rotates vector V1 around Y axis by angle a
	return UE.Quaternion.Euler(0,a,0)*V1
end


function M.unpackVector3(vector3)
	return vector3.x, vector3.y, vector3.z
end

function M.unpackVector2(vector2)
	return vector2.x, vector2.y
end

function M.arrayToVector3(array)
	return UE.Vector3(array[1] or 0, array[2] or 0, array[3] or 0)
end

function M.arrayToVector2(array)
	return UE.Vector2(array[1] or 0, array[2] or 0)
end

function M.vector3ToArray(vector3)
	return {vector3.x, vector3.y, vector3.z}
end

function M.vector2ToArray(vector2)
	return {vector2.x, vector2.y}
end

--------------------------------------------------------------------------------

--[[
	Adds a new trail renderer component to a game object and returns it.
	gameObject <UE.GameObject> 	:	The game object to add the trail renderer to.
--]]
function M.attachTrailRenderer(gameObject)
	local trail = gameObject:AddComponent(typeof(UE.TrailRenderer))
	
	if trailShader == nil then
		trailShader = UE.Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply")
	end
	
	trail.material.shader = trailShader
	
	return trail
end

--[[
	Prints text on the screen.
	text <string> 	:	The text to print.
	posX <int>		:	Horizontal distance in pixels from the upper left corner of the screen.
	posY <int>		:	Vertical distance in pixels from the upper left corner of the screen.
	color <UE.Color>:	The color of the text.
--]]
function M.printOnScreen(text, posX, posY, color)
	CS.UDMS.Globals.ScreenText.text = text
	if posX ~= nil and posY ~= nil then
		CS.UDMS.Globals.ScreenText.rectTransform.anchoredPosition = UE.Vector2(posX, -posY)
	end
	if color ~= nil then
		CS.UDMS.Globals.ScreenText.color = color
	end
end

function M.listenToGenericShortcuts()
	if UE.Input.GetKey(UE.KeyCode.Comma) then
		local vol = CS.UDMS.Globals.AudioSource.volume
		CS.UDMS.Globals.AudioSource.volume = math.max(vol - UE.Time.deltaTime, 0)
	elseif UE.Input.GetKey(UE.KeyCode.Period) then
		local vol = CS.UDMS.Globals.AudioSource.volume
		CS.UDMS.Globals.AudioSource.volume = math.min(vol + UE.Time.deltaTime, 1)
	end
end


return M