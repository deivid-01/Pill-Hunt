using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    
    public GameObject tutorial;
    public GameObject godLight;
    public Quaternion rotationGodLight;
    public int timeLightsOn;
    public string timeLimite;
    bool lucesEncendidas;
    int previusTime = 0;
    public float reduceSpeed;
    int activeTutorial;
    #region Player propierties
    public GameObject player;
    public float speedPlayer;
    #endregion

    #region CameraControls
 
    public Camera camera;
   
    #endregion

    #region Screen Propierties

    public GameObject preGamingScreen;
    public GameObject startScreen;
    public GameObject gamingScreen;
    public GameObject finishScreen;
    public GameObject gameOverScreen;
    public Text reverseTimer;
    public Text timerLights;
    public Text timerLights2;
    public bool gameOver;

    PlayerMovement playerMovement;

    #endregion

    #region
    LevelComplete levelComplete;
    #endregion
    #region Singlenton

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        activeTutorial = PlayerPrefs.GetInt("Tutorial", 0);
        tutorial.SetActive(false);
        levelComplete = LevelComplete.Instance;
        playerMovement = PlayerMovement.Instance;
        lucesEncendidas = true;

        reverseTimer.text = timeLimite;
        timerLights.text = timeLightsOn.ToString();
        timerLights2.text = timeLightsOn.ToString();
        godLight.SetActive(false);
        preGamingScreen.SetActive(false);
        startScreen.SetActive(true);
        gamingScreen.SetActive(false);
        finishScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameOver = false;
    }
    private void FixedUpdate()
    {
        /*if (lucesEncendidas == false && gameOver == false && levelComplete.levelcomplete==false)
        {
          
            PlayerControls();
        }*/
    }
    private void Update()
    {

        
        TurnOffLights();
        if (lucesEncendidas == false && gameOver == false && levelComplete.levelcomplete == false)
        {

            PlayerControls();
        }

        if (levelComplete.levelcomplete == false && gameOver == false)
        {
            if (lucesEncendidas == false)
            {
                StopWatch(reverseTimer, null);
               
            }
        
            ShowLife();

            UpdateSpeed();
        }
        if (gameOver == true )
        {

            GameOver();
        }
        //


    }
    void TurnOffLights()
    {
        if (Time.timeSinceLevelLoad > 4 && lucesEncendidas == true)
        {

            startScreen.SetActive(false);
            godLight.SetActive(true);
            PreGamingScreen();

            if (Time.timeSinceLevelLoad >= (timeLightsOn + 3))
            {

                preGamingScreen.SetActive(false);

                gamingScreen.SetActive(true);
                //godLight.transform.rotation = rotationGodLight;
                lucesEncendidas = false;
            }

        }
        else if (lucesEncendidas == false)
        {
            if (Time.timeSinceLevelLoad <= (timeLightsOn + 6))
            {

                ShowTutorial();

            }
            else
                tutorial.SetActive(false);
        }
       
    }

    void PlayerControls()

    {
        player.transform.position = player.transform.position + (-1 * Vector3.forward * Input.GetAxis("Vertical") + (-1) * Vector3.right * Input.GetAxis("Horizontal")) * speedPlayer * Time.deltaTime;//Delta time es 1/FPS
    
        //player.transform.Translate(-Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime, 0, -Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime);
          
    }

   

    void StopWatch(Text  textTimer,Text textTimer2)
    {
        if (previusTime != (int)Time.time)
        {
            previusTime = (int)Time.time;


            if (int.Parse(textTimer.text) > 1)
            {
                {
                    textTimer.text = (int.Parse(textTimer.text) - 1).ToString();
                    if (textTimer2 != null)
                    {
                        textTimer2.text = (int.Parse(textTimer2.text) - 1).ToString();
                    }
                }


            }
            else if(lucesEncendidas==false)
                gameOver = true;

        }
        else
            return;
    }
    void GameOver()
    {
        gameOverScreen.SetActive(true);
        gamingScreen.SetActive(false);
    }
    void UpdateSpeed()
    {
        if (playerMovement.oncollisionPolice == true)
        {
            if (speedPlayer>0.05)
                speedPlayer -= reduceSpeed;

        }
        else
        {
            if (speedPlayer < 9f)
                speedPlayer += reduceSpeed/5;
        }
    }
    void ShowLife()
    {
    
        if (playerMovement.life == 0)
        {
            gameOver = true;
        }
        
    }

    void PreGamingScreen()
        {
        preGamingScreen.SetActive(true);
        StopWatch(timerLights2,timerLights);

        
    }

    void ShowTutorial()
    {
        tutorial.GetComponent<Transform>().position = camera.WorldToScreenPoint(player.transform.position);
        if (activeTutorial == 0)
        {          
            tutorial.SetActive(true);
            PlayerPrefs.SetInt("Tutorial", 1);
            //
        }
    }
   
}
