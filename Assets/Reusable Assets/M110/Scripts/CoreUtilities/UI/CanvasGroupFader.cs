
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{

    [SerializeField]
    bool fadeOnEnable = false;

    public float startingAlpha;
    public float endAlpha;

    [SerializeField]
    bool bringToFront = false;
    [SerializeField]
    bool sendToBack = false;

    public float fadeDuration;

    CanvasGroup canvasgroup;

    //[SerializeField]
    //bool isPauseIndependent;
    // Use this for initialization
    private void Awake()
    {
        canvasgroup = GetComponent<CanvasGroup>();

        if (bringToFront)
        {
            //sets this on top of everything else;
            transform.SetAsLastSibling();
        }
        else if (sendToBack)
        {
            transform.SetAsFirstSibling();
        }
    }

    void OnEnable()
    {
        if (fadeOnEnable)
        {
            PreSetFade();
        }
    }

    public void Black()
    {
        canvasgroup.alpha = 1;
    }


    [ContextMenu("RunFade")]
    public void PreSetFade()
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, startingAlpha, endAlpha, fadeDuration));
    }

    [ContextMenu("RunInversePreSetFade")]
    public void InversePreSetFade()
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, endAlpha, startingAlpha, fadeDuration));
    }

    public void FadeFrom10()
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, 1, 0, fadeDuration));
    }

    public void FadeFrom10(float duration)
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, 1, 0, duration));
    }

    public void FadeFrom01()
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, 0, 1, fadeDuration));
    }

    public void FadeFrom01(float duration)
    {
        StartCoroutine(FadeAlphaFromTo(canvasgroup, 0, 1, duration));

    }
    public void BlinkFader(float stayWithBlack)
    {
        IEnumerator FadeFromTo()
        {
            FadeFrom01();
            yield return new WaitForSeconds(fadeDuration + stayWithBlack);
            FadeFrom10();
        }

        StartCoroutine(FadeFromTo());
    }

    public static IEnumerator FadeAlphaFromTo(CanvasGroup canvasGroup, float startingAlpha, float endAlpha, float durationInSeconds)
    {
        //in case it wasn't, set alpha:
        canvasGroup.alpha = startingAlpha;

        for (float t = 0; t < durationInSeconds; t += Time.unscaledDeltaTime)
        {
            float currentalpha = Mathf.Lerp(startingAlpha, endAlpha, t / durationInSeconds);
            canvasGroup.alpha = currentalpha;
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }
}

