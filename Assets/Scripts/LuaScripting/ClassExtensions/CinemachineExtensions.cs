using Cinemachine;
using XLua;

namespace LuaScripting.ClassExtensions
{
    [LuaCallCSharp]
    public static class CinemachineExtensions
    {
        public static CinemachineTrackedDolly GetCinemachineTrackedDollyComponent(
            this CinemachineVirtualCamera virtualCamera)
        {
            return virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        }
    }
}
