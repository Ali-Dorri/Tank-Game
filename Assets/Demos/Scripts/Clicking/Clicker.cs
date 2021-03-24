using UnityEngine;
using UnityEngine.EventSystems;

namespace Adop.Demos.Clicking
{
    public abstract class Clicker : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current != null)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Click();
                    }
                }
                else
                {
                    Click();
                }
            }
        }

        protected abstract void Click();
    }
}
