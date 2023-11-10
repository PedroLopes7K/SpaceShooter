using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas fader;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStart = false;

    private void Awake()
    {
        if(fader == null)
        {
            fader = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }
   public void FadeLoaderString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }

    public void FadeLoaderIndex(int index)
    {
        StartCoroutine(FadeOutIndex(index));
    }
    IEnumerator FadeIn()

    {
        loadingScreen.SetActive(false);
        fadeStart = false;
        while(canvasGroup.alpha > 0) {

            //if (fadeStart) yield break;
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }



    }


    IEnumerator FadeOutString(string levelName)

    {

        //if (canvasGroup.alpha != 0) yield break;
        if (fadeStart) yield break;

        fadeStart = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName);
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while (asyncOperation.isDone == false)
        {
            loadingBar.fillAmount = asyncOperation.progress / 0.9f;

            if (asyncOperation.progress == 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;


        }

        //SceneManager.LoadScene(levelName);
        //yield return new WaitForSeconds(0.01f);

        StartCoroutine(FadeIn());

    }

    IEnumerator FadeOutIndex(int index)

    {
        if (fadeStart) yield break;

        fadeStart = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        //SceneManager.LoadScene(index);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while(asyncOperation.isDone == false)
        {
            loadingBar.fillAmount = asyncOperation.progress / 0.9f;

            if (asyncOperation.progress == 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;

           
        }

        //yield return new WaitForSeconds(0.01f);

        StartCoroutine(FadeIn());

    }
}
