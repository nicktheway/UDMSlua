local UE = CS.UnityEngine

local M = {}

function M.D1(...)
	local x=0
	for i, v in ipairs{...} do
		x=math.max(x,v)
	end
	return x
end
function M.D2(...)
	local x=0
	for i, v in ipairs{...} do
		x=x+v-x*v
	end
	return x
end
function M.C1(...)
	local x=1
	for i, v in ipairs{...} do
		x=math.min(x,v)
	end
	return x
end
function M.C2(...)
	local x=1
	for i, v in ipairs{...} do
		x=x*v
	end
	return x
end
function M.N1(x)
	return 1-x
end

function M.updateStateByNum(so,Sin,Sout,Nagn)
	local s={}
	local K=2^Nagn
	local i=0
	local q
	for n1=1,Nagn do
		s[n1-1]=0
		for k=1,K do
			q=1
			for n2=1,Nagn do
				if Sin[k][n2]==1 then q=math.min(q,so[n2-1]) end
				if Sin[k][n2]==0 then q=math.min(q,1-so[n2-1]) end
			end
			q=math.min(q,Sout[k][n1])
			s[n1-1]=math.max(s[n1-1],q)
		end
		--LFG.setState(n1-1,math.floor(10*s[n1-1]))
	end
	return s
end

function M.updateStateByNumFast(so,Sout,Nagn)
	local s={}
	local K=2^Nagn
	local i=0
	for n=0,Nagn-1 do
		i=i+so[Nagn-n-1]*2^n
	end
	for n=0,Nagn-1 do
		s[n]=Sout[i+1][n+1]
		--LFG.setState(n,math.floor(10*s[n]))
	end
	return s
end

return M


