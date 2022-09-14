using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    public bool levelcomplete;

    #region Singlenton

    public static LevelComplete Instance;
        private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameController gameController;
    private void Start()
    {
        levelcomplete = false;
        gameController = GameController.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            levelcomplete = true;
            gameController.finishScreen.SetActive(true);
            gameController.gamingScreen.SetActive(false);
        }
        
    }

    void ShowMessage()
    {

    }

    
}
