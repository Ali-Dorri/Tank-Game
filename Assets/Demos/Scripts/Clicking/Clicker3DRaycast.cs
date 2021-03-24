using System;
using UnityEngine;

namespace Adop.Demos.Clicking
{
    public class Clicker3DRaycast : Clicker
    {
        [SerializeField] private float m_ClickDistance = 100;
        [SerializeField] private LayerMask m_ClickablesLayer;

        public event Action<RaycastHit> OnClick;

        protected override void Click()
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHitted = Physics.Raycast(clickRay, out RaycastHit hit, m_ClickDistance, m_ClickablesLayer.value);
            if (isHitted)
            {
                OnClick?.Invoke(hit);
            }
        }
    }
}
