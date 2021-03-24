using UnityEngine;

namespace Adop.Demos.Clicking
{
    public class ClickSpawner2D : MonoBehaviour
    {
        [SerializeField] private Clicker2D m_Clicker;
        [SerializeField] private GameObject m_Prefab;

        private void OnEnable()
        {
            m_Clicker.OnClick += Spawn;
        }

        private void OnDisable()
        {
            m_Clicker.OnClick -= Spawn;
        }

        private void Spawn(Vector3 position)
        {
            Instantiate(m_Prefab, position, Quaternion.identity);
        }
    }
}
