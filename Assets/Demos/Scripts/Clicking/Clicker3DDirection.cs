using System;
using UnityEngine;

namespace Adop.Demos.Clicking
{
    public class Clicker3DDirection : Clicker
    {
        public event Action<Vector3> OnClick;

        protected override void Click()
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            OnClick?.Invoke(clickRay.direction);
        }
    }
}
