using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adop.Demos.Clicking;

namespace Adop.Demos.MaterialDemos
{
    public class MaterialChanger : MonoBehaviour
    {
        [SerializeField] private Clicker3DRaycast m_Clicker;
        [SerializeField] private Color[] m_Colors;
        [SerializeField] private float m_ChangeDuration = 1f;
        private List<Material> m_ChangingMaterials = new List<Material>();
        private List<int> m_ValidColors = new List<int>();

        private void OnEnable()
        {
            m_Clicker.OnClick += ChangeMaterial;
        }

        private void OnDisable()
        {
            m_Clicker.OnClick -= ChangeMaterial;
        }

        private void Start()
        {
            for(int i = 0; i < m_Colors.Length; i++)
            {
                m_ValidColors.Add(i);
            }
        }

        private void ChangeMaterial(RaycastHit hit)
        {
            ColorCube cube = hit.collider.GetComponent<ColorCube>();
            if(cube != null)
            {
                if (!m_ChangingMaterials.Contains(cube.Renderer.material))
                {
                    m_ChangingMaterials.Add(cube.Renderer.material);
                    int newColorIndex = GetRandomColorIndex(cube);
                    StartCoroutine(ChangeOverTime(cube, newColorIndex));
                }
            }
        }

        private int GetRandomColorIndex(ColorCube cube)
        {
            int removedIndex = -1;
            for(int i = 0; i < m_ValidColors.Count; i++)
            {
                if(m_ValidColors[i] == cube.m_ColorIndex)
                {
                    removedIndex = i;
                    m_ValidColors.RemoveAt(i);
                    break;
                }
            }

            int randomIndex = Random.Range(0, m_ValidColors.Count);
            int randomColorIndex = m_ValidColors[randomIndex];

            if(removedIndex != -1)
            {
                m_ValidColors.Add(removedIndex);
            }

            return randomColorIndex;
        }

        private IEnumerator ChangeOverTime(ColorCube cube, int newColorIndex)
        {
            Color initialColor = cube.Renderer.material.color;
            float startTime = Time.time;
            while(Time.time - startTime < m_ChangeDuration)
            {
                float progress = (Time.time - startTime) / m_ChangeDuration;
                cube.Renderer.material.color = Color.Lerp(initialColor, m_Colors[newColorIndex], progress);
                yield return null;
            }

            cube.m_ColorIndex = newColorIndex;
            cube.Renderer.material.color = m_Colors[newColorIndex];
            m_ChangingMaterials.Remove(cube.Renderer.material);
        }
    }
}
