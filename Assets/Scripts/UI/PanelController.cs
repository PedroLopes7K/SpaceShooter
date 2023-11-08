using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        EndGameManager.endGameManager.RegisterPanelController(this);
    }

  public void ActiveWin()
    {
        canvasGroup.alpha = 1;
        winScreen.SetActive(true);
    }
    public void ActiveLose()
    {
        canvasGroup.alpha = 1;
        loseScreen.SetActive(true);
    }
}
