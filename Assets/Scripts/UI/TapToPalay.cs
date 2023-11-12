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
        // Start the coroutine to modify alpha in a loop
        StartCoroutine(ModifyAlpha());
    }

    IEnumerator ModifyAlpha()
    {
        float alphaValue = 1.0f; // Starting alpha value

        while (true) // Infinite loop
        {
            // Decrease alpha by changeRate until it reaches 0
            while (alphaValue > 0)
            {
                alphaValue -= changeRate;
                yield return new WaitForSeconds(0.04f);

                SetAlpha(alphaValue);
                yield return null;
            }

            // Increase alpha by changeRate until it reaches 1
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
