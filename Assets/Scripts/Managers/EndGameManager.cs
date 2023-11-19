using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndGameManager : MonoBehaviour
{

    public static EndGameManager endGameManager;
    public bool gameOver;
    private PanelController panelController;
    private TextMeshProUGUI scoreTextComponent;
    private int score;
    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";

    private void Awake()
    {
      if(endGameManager == null)
        {
            endGameManager = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text = "Score: " + score.ToString();
    }
    public void StartResolveSequence() {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }
    public void ResolveGame() {
        Debug.Log("RESOLVE GAME CALLED");
        if (gameOver == false)
        {
            Invoke("WinGame", 0.8f);
            //WinGame();
        } else
        {
            Invoke("LoseGame", 0.8f);

            //LoseGame();
        }
     }


    public void WinGame()
    {
        SetScore();
        panelController.ActiveWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if(nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }

    }

    public void LoseGame()
    {
        SetScore();
        panelController.ActiveLose();
    }

    private void SetScore()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name,  score);
        float roundedDownValue = Mathf.Floor((score / 10));
        Debug.Log("MY MONEY " + roundedDownValue);
        float money = PlayerPrefs.GetInt("money", 0);
        PlayerPrefs.SetFloat("money", roundedDownValue + money);

        int HighScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if(score > HighScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        }
        //reset score
        score = 0;

    }


    public void RegisterPanelController(PanelController panel)
    {
        panelController = panel;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        scoreTextComponent = scoreText;
    }
}
