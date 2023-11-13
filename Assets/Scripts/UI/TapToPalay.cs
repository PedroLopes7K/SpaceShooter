using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapToPalay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTapToPlay;

    public float changeRate = 0.7f;

    void Start()
    {
        
        StartCoroutine(ModifyAlpha());
    }

    IEnumerator ModifyAlpha()
    {
        float alphaValue = 1.0f; 

        while (true) 
        {
            while (alphaValue > 0)
            {
                alphaValue -= changeRate;
                yield return new WaitForSeconds(0.04f);

                SetAlpha(alphaValue);
                yield return null;
            }

            while (alphaValue < 1)
            {
                alphaValue += changeRate;
                yield return new WaitForSeconds(0.04f);

                SetAlpha(alphaValue);
                yield return null;
            }
        }
    }

    void SetAlpha(float alphaValue)
    {
        Color currentColor = textTapToPlay.color;
        currentColor.a = alphaValue;
        textTapToPlay.color = currentColor;
    }
}
