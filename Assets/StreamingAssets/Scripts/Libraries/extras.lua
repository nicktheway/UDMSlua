local UE = CS.UnityEngine

local M = {}

local trailShader = nil

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