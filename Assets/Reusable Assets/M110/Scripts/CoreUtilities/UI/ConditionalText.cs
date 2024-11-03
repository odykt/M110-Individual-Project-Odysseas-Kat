using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NM.ValueDataRefWrapper
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ConditionalText : MonoBehaviour
    {
        [SerializeField]
        DataTypeToUse dataToUse;
        [SerializeField]
        floatReference floatReference;
        [SerializeField]
        stringReference stringReference;
        [SerializeField]
        intReference intReference;
        [SerializeField]
        string prefix;

        [SerializeField]
        string suffix;
        [SerializeField]
        bool forceLowerCase;
        [SerializeField]
        bool removePeriods;


        [SerializeField]
        bool forceReCalculate;
        [SerializeField]
        bool runOnUpdate;
        public enum DataTypeToUse
        {
            useString,
            useInt,
            useFloat
        }

        TextMeshProUGUI textMesh;
        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            DisplayText();
        }

        private void Update()
        {
            if (runOnUpdate)
                DisplayText();
        }
        [ContextMenu("Display Text")]
        public void DisplayText()
        {
            if (textMesh == null) textMesh = GetComponent<TextMeshProUGUI>();


            if (dataToUse == DataTypeToUse.useString)
            {
                string textToShow = forceLowerCase ? (prefix + stringReference.Value + suffix).ToLower() : prefix + stringReference.Value + suffix;
                textToShow = removePeriods ? textToShow.Replace(",", "") : textToShow;
                textMesh.text = textToShow;

            }

            if (dataToUse == DataTypeToUse.useFloat)
            {
                textMesh.text = prefix + floatReference.Value + suffix;
            }

            if (dataToUse == DataTypeToUse.useInt)
                textMesh.text = prefix + intReference.Value + suffix;

            if (forceReCalculate)
            {
                LayoutRebuilder.MarkLayoutForRebuild(this.GetComponent<RectTransform>());
            }

        }

        public void DisplayText(stringReference stringReference)
        {
            textMesh.text = prefix + stringReference.Value + suffix;
        }


    }

}