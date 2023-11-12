using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void LoadLevelString(string levelName)
    {
        //SceneManager.LoadScene(levelName);
        FadeCanvas.fader.FadeLoaderString(levelName);
    }
    public void LoadLevelIndex(int levelIndex)
    {
        //SceneManager.LoadScene(levelIndex);
        FadeCanvas.fader.FadeLoaderIndex(levelIndex);

    }

    public void RestartLevel() {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FadeCanvas.fader.FadeLoaderIndex(SceneManager.GetActiveScene().buildIndex);
    }


}
