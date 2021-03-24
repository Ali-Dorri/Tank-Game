using UnityEngine;

namespace Adop.Demos.MaterialDemos
{
    public class ColorCube : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Renderer;

        public int m_ColorIndex;

        public MeshRenderer Renderer => m_Renderer;
    }
}
