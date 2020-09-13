local UE = CS.UnityEngine
local math = require('math')
local io = require('io')

local M = {}

function M.makeNbhd(nbhdType, N, ...)

	if nbhdType=="rel1" then
		local relArray=select(1,...)
		local wrap=select(2,...)
		return M.relativeNeighbours(N, relArray, wrap)
	elseif nbhdType=="rel2" then
		local n1=select(1,...)
		local relArray=select(2,...)
		local wrap=select(3,...)
		return M.relativeGridNeighbours(N, n1, relArray, wrap)
	elseif nbhdType=="fPath" then
		local fpath=select(1,...)
		return M.fpathNeighbours(N,fpath)
	elseif nbhdType=="distBased" then

	end

end

function M.fpathNeighbours(N, fpath)
	local file = io.open(fpath, 'r')
	--print(fpath, file)
	if file ~= nil then
		local nbrs = {}
		local counter = 1
		for line in file:lines() do
			nbrs[counter] = {}
			local nbrCounter = 1
			for nbr in line:gmatch("%d+") do
			   nbrs[counter][nbrCounter] = tonumber(nbr)
			   nbrCounter = nbrCounter + 1
			end
			
			if counter == N then break end
			counter = counter + 1
		end
		
		file:close()
		
		return nbrs
	else
		error('file not found')
	end
end

function M.relativeGridNeighbours(N, NC, relArray2, wrap)
	local nbrs = {}


	local NR = math.ceil(N/NC)
	local K = #relArray2
	
	for n = 0, N - 1 do
		local nc = n % NC
		local nr = math.floor(n / NC)
		nbrs[n+1] = {}
		local nbCounter = 1
		for k = 1, K do
			local ax = nc + relArray2[k][1]
			local ay = nr + relArray2[k][2]
			
			if wrap then
				ax = ax % NC
				ay = ay % NR
				local m = ay * NC + ax
				if m < N then
					nbrs[n+1][nbCounter] = m
					nbCounter = nbCounter + 1
				end
			else
				local m = ay * NC + ax
				if ax > -1 and ax < NC and ay > -1 and ay < NR and m < N then
					nbrs[n+1][nbCounter] = m
					nbCounter = nbCounter + 1
				end
			end
		end
	end

	
	return nbrs
end

function M.relativeNeighbours(n, relArray, wrap)
	if wrap == nil then
		wrap = true
	end

	local nbrs = {}
	
	if wrap then
		for i = 1, n do
			nbrs[i] = {}
			for j = 1, #relArray do
				nbrs[i][j] = (i - 1 + relArray[j] + n) % n
			end
		end
	else
		for i = 1, n do
			local nbsCounter = 1
			nbrs[i] = {}
			for j = 1, #relArray do
				local nbId = i - 1 + relArray[j]
				if nbId >= 0 and nbId < n then
					nbrs[i][nbsCounter] = nbId
					nbsCounter = nbsCounter + 1
				end
			end
		end
	end
	
	return nbrs
end

function M.makeFormation(formation, N, ...)

	if formation=="circle" then
		local center=select(1,...)
		local radius=select(2,...)
		local angleOffset=select(3,...)
		return M.circlePoints(N, center, radius, angleOffset)
	elseif formation=="ellipse" then
		local center=select(1,...)
		local a=select(2,...)
		local b=select(3,...)
		local angleOffset=select(4,...)
		return M.ellipsePoints(N, center, a, b, angleOffset)
	elseif formation=="line" then
		local start=select(1,...)
		local step=select(2,...)
		return M.linePoints(N,start,step)
	elseif formation=="grid" then
		local columns=select(1,...)
		local topLeftPoint=select(2,...)
		local rowDistance=select(3,...)
		local colDistance=select(4,...)
		return M.gridPoints(N, columns, topLeftPoint, rowDistance, colDistance)
	elseif formation=="lissajous" then
		local ax=select(1,...)
		local wx=select(2,...)
		local az=select(3,...)
		local wz=select(4,...)
		local angleOffset=select(5,...)
		return M.lissajousPoints(N,ax,wx,az,wz,angleOffset)
	elseif formation=="nrose" then
		local center=select(1,...)
		local a=select(2,...)
		local K=select(3,...)
		local angleOffset=select(4,...)
		return M.nrosePoints(N,center,a,K,angleOffset)
	else 
	end

end

function M.nrosePoints(N,center,a,K,angleOffset)

	if angleOffset == nil then
		angleOffset = 0
	end

	local da
	if math.fmod (K,2)==0 then
		da = 2.0  * math.pi / N
	else
		da = 1.0  * math.pi / N
	end
	local positions = {}
	local angle = math.rad(angleOffset)
	local rr
	for n = 1, N do
		rr=a*math.cos(K*angle)
		positions[n] = UE.Vector3(rr * math.cos(angle), 0, rr * math.sin(angle))+center
		angle = angle + da
	end
	return positions
end
function M.lissajousPoints(N,ax,wx,az,wz,angleOffset)

	if angleOffset == nil then
		angleOffset = 0
	end

	local dax = 2.0 * wx * math.pi / N
	local daz = 2.0 * wz * math.pi / N
	local positions = {}
	local anglex = math.rad(angleOffset)
	local anglez = math.rad(angleOffset)
	for n = 1, N do
		positions[n] = UE.Vector3(ax * math.cos(anglex), 0, az * math.sin(anglez))
		anglex = anglex + dax
		anglez = anglez + daz
	end
	return positions
end

function M.gridPoints(N, columns, topLeftPoint, rowDistance, colDistance)
	local currentRow = 0
	local currentCol = 0
	local positions = {}
	
	for i = 1, N do
		positions[i] = topLeftPoint - UE.Vector3(0, 0, currentRow * rowDistance) + UE.Vector3(currentCol * colDistance, 0, 0)
		currentCol = currentCol + 1
		if currentCol == columns then
			currentRow = currentRow + 1
			currentCol = 0
		end
	end
	
	return positions
end

function M.linePoints(N,start,step)
	local positions = {}
	positions[1]=start
	for n = 2, N do
		positions[n] =positions[n-1]+step
	end
	return positions
end

function M.ellipsePoints(N, center, a, b, angleOffset)

	if angleOffset == nil then
		angleOffset = 0
	end

	local da = 2.0 * math.pi / N
	local positions = {}
	angle = math.rad(angleOffset)
	for n = 1, N do
		positions[n] = UE.Vector3(a * math.cos(angle), 0, b * math.sin(angle)) + center
		angle = angle + da
	end
	return positions
end

function M.circlePoints(N, center, radius, angleOffset)

	if angleOffset == nil then
		angleOffset = 0
	end

	local da = 2.0 * math.pi / N
	local positions = {}
	angle = math.rad(angleOffset)
	for n = 1, N do
		positions[n] = UE.Vector3(radius * math.cos(angle), 0, radius * math.sin(angle)) + center
		angle = angle + da
	end
	return positions
end


return M