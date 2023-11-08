using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{

    public static EndGameManager endGameManager;
    public bool gameOver;
    private PanelController panelController;

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

    if(gameOver == false)
        {
            WinGame();
        } else
        {
            LoseGame();
        }
            }


    public void WinGame()
    {
        panelController.ActiveWin();

    }

    public void LoseGame()
    {
        panelController.ActiveLose();
    }

    public void RegisterPanelController(PanelController panel)
    {
        panelController = panel;
    }
}
