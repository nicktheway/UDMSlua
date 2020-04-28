using UnityEngine;

namespace LuaScripting
{
    public abstract partial class LuaGameObject : MonoBehaviour
    {
        private bool _selected;
        private Color _initialColor;

        public void Select(bool select)
        {
            _selected = select;

            if (select)
            {
                var renderer = GetComponentInChildren<Renderer>();
                _initialColor = renderer.material.color;
                renderer.material.color = Color.red;
            }
            else
            {
                GetComponentInChildren<Renderer>().material.color = _initialColor;
            }
        }

        public abstract LuaDomain LuaDomain { get; set; }

        public void RerunDomain()
        {
            LuaDomain.RedoLuaScript(true, true);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected abstract void OnCollisionEnter(Collision collision);

        protected abstract void OnCollisionExit(Collision collision);

        protected abstract void OnCollisionStay(Collision collision);

        protected abstract void OnTriggerEnter(Collider other);

        protected abstract void OnTriggerExit(Collider other);

        protected abstract void OnTriggerStay(Collider other);

        protected abstract void OnAnimatorIK(int layerIndex);

        protected abstract void OnAnimatorMove();
    }
}
