local UE = CS.UnityEngine
local math = require('math')
local io = require('io')

local M = {}

function M.circlePoints(center, radius, n, angleOffset)

	if angleOffset == nil then
		angleOffset = 0
	end

	local da = 2.0 * math.pi / n
	local positions = {}
	angle = math.rad(angleOffset)
	for i = 1, n do
		positions[i] = UE.Vector3(radius * math.cos(angle), 0, radius * math.sin(angle)) + center
		angle = angle + da
	end

	return positions
end

function M.relativeNeighbours(relArray, n)
	local nbrs = {}
	
	for i = 1, n do
		nbrs[i] = {}
		for j = 1, #relArray do
			nbrs[i][j] = (i - 1 + relArray[j] + n) % n
		end
	end
	
	return nbrs
end

function M.pointsFromFile(fileName)
	local file = io.open(fileName)
	if file then
		for line in file:lines() do
			print(line)
		end
		
		file:close()
	else
		error('file not found')
	end
	

end

return M