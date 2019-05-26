using UnityEngine;

namespace LuaScripting
{
    public abstract class LuaGameObject : MonoBehaviour
    {
        private bool _selected;

        public void Select(bool select)
        {
            _selected = select;

            if (select)
            {
                GetComponentInChildren<Renderer>().material.color = Color.red;
            }
            else
            {
                GetComponentInChildren<Renderer>().material.color = Color.white;
            }
        }

        public abstract LuaDomain LuaDomain { get; set; }

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
