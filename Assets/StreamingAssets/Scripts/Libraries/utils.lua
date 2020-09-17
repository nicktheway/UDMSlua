local UE = CS.UnityEngine

local M = {}

local trailShader = nil

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