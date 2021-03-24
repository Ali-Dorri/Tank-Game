using System;
using UnityEngine;

namespace Adop.Demos.Clicking
{
    public class Clicker2D : Clicker
    {
        [SerializeField] private float m_ClickDistance = 10;

        public event Action<Vector3> OnClick;

        protected override void Click()
        {
            Vector3 clickScreenPosition = Input.mousePosition;
            clickScreenPosition.z = m_ClickDistance;
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(clickScreenPosition);

            OnClick?.Invoke(clickPosition);
        }
    }
}
