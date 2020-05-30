using UnityEngine;
using TMPro;
using XLua;

namespace LuaScripting
{
    [LuaCallCSharp]
    public abstract partial class LuaGameObject : MonoBehaviour
    {
        public TextMeshPro TextMeshComponent { get { if (!_textMeshComponent) createTextMesh(); return _textMeshComponent; } }

        private string _textMeshText;
        private TextMeshPro _textMeshComponent;
        private bool _showTextMeshObject = false;
        private bool _selected;
        private Color _initialColor;
        private Renderer _renderer;

        public void Select(bool select)
        {
            _selected = select;
            RefreshText();
            if (select)
            {
                ToggleTextMeshObject(true);
            }
        }

        public void ToggleTextMeshObject(bool show)
        {
            if (!_textMeshComponent && !show) return;
            TextMeshComponent.gameObject.SetActive(show);
            _showTextMeshObject = show;
        }

        private void createTextMesh()
        {
            var textObject = new GameObject();
            var text = textObject.AddComponent<TextMeshPro>();
            text.fontSize = 2;
            text.alignment = TextAlignmentOptions.Center;
            textObject.transform.SetParent(transform);
            textObject.transform.localPosition = Vector3.up * 2;

            _textMeshComponent = text;
        }

        public void SetColor(float r, float g, float b, float a = 1f)
        {
            SetColor(new Color(r, g, b, a));
        }

        public void SetText(string text)
        {
            _textMeshText = text;
            TextMeshComponent.text = (_selected ? "*\n" : "") + text;
        }

        private void RefreshText()
        {
            TextMeshComponent.text = (_selected ? "*\n" : "") + _textMeshText;
        }

        public void SetColor(Color color)
        {
            if (!_renderer) 
            {
                _renderer = GetComponentInChildren<Renderer>();
                _initialColor = _renderer.material.color;
            }
            _renderer.material.color = color;
        }
        
        public void ClearColor() 
        {
            SetColor(_initialColor);
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
