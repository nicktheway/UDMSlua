local UE = CS.UnityEngine

function groupff(group)
	local groupFuns = {}
	local anims = {}
	local Nagn = group.Members.Count
	
	for i = 0, Nagn - 1 do
		anims[i] = group.Members[i]:GetComponent(typeof(UE.Animator))
	end
	
	function groupFuns.setPos(i, pos)
		group.Members[i].transform.position = pos
	end
	
	function groupFuns.setRot(i, eulerAngles)
		group.Members[i].transform.eulerAngles = eulerAngles
	end
	
	function groupFuns.setState(i, state)
		group.Members[i].State = state
	end
	
	function groupFuns.setAnim(i, anim, transitionDuration)
		anims[i]:CrossFade(anim, transitionDuration)
	end
	
	return groupFuns
end


return groupff