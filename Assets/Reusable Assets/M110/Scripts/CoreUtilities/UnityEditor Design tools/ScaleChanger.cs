using NM.ValueDataRefWrapper;
using System.Collections;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [Header("Option 2")]
    [SerializeField]
    bool runOnEnable;
    [SerializeField]
    float initialScale;
    [SerializeField]
    float finalscale;

    [SerializeField]
    floatReference duration;


    [Header("Option 2")]
    [SerializeField]
    bool runInUpdate;
    [SerializeField]
    floatReference weight;
    [SerializeField]
    float multiplier;

    Vector3 initialScaleVector;
    private void Start()
    {
        //this is an assumption. It may not be helpful always. Please consider.
        initialScaleVector = Vector3.one;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (runInUpdate)
            this.transform.localScale = initialScaleVector * weight.Value * multiplier;
    }

    public void OnEnable()
    {
        if (runOnEnable)
            ScaleChange();
    }

    public void ScaleChange()
    {
        StartCoroutine(ScaleChangeEnum(initialScale, finalscale, duration.Value));
    }

    public void ScaleChangeInverse()
    {
        StartCoroutine(ScaleChangeEnum(finalscale, initialScale, duration.Value));
    }


    IEnumerator ScaleChangeEnum(float startingValue, float endValue, float durationInSeconds)
    {
        //in case it wasn't, set alpha:

        target.localScale = initialScaleVector * startingValue;
        for (float t = 0; t < durationInSeconds; t += Time.unscaledDeltaTime)
        {
            target.localScale = initialScaleVector * Mathf.Lerp(startingValue, endValue, t / durationInSeconds);
            yield return null;
        }
        target.localScale = initialScaleVector * endValue;
    }
}
