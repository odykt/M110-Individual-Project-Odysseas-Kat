using TMPro;
using UnityEngine;

namespace Assets.Resources.Scripts.Core.UI
{
    public class TxtMeshProSimpleColour : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI textMesh;
        [SerializeField]
        Color lightColorScheme;
        [SerializeField]
        Color darkColorScheme;
        // Use this for initialization
        public void SetToDark()
        {
            textMesh.color = darkColorScheme;
        }

        public void SetToLight()
        {
            textMesh.color = lightColorScheme;
        }


    }
}