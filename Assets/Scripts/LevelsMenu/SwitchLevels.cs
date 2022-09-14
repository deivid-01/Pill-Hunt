using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwitchLevels : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] pivotes;
    public int pivoteActual;
    public GameObject[] titlesLevel;
    public GameObject[] pointLight;
    public float speed;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region MoveCamera

        titlesLevel[pivoteActual].SetActive(true);
        pointLight[pivoteActual].SetActive(true);
        transform.position = Vector3.Lerp(transform.position, pivotes[pivoteActual].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pivotes[pivoteActual].rotation, speed * Time.deltaTime * 0.9f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            titlesLevel[pivoteActual].SetActive(false);
            pointLight[pivoteActual].SetActive(false);
            pivoteActual = (pivoteActual + 1) % pivotes.Length;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            titlesLevel[pivoteActual].SetActive(false);
            pointLight[pivoteActual].SetActive(false);
            pivoteActual -= 1;
            if (pivoteActual < 0)
            {
                pivoteActual = pivotes.Length - 1;
            }

        }

        #endregion

        ChangeLevel();
        Exit();
    }

    void ChangeLevel()

    {
        if (Input.GetKey(KeyCode.C))
        {
            if (pivoteActual==0)
            {
                SceneManager.LoadScene("L1");
            }
            else if (pivoteActual == 1)
            {
                SceneManager.LoadScene("L2");
            }
            else if (pivoteActual == 2)
            {
                SceneManager.LoadScene("L3");
            }
            else if (pivoteActual == 3)
            {
                SceneManager.LoadScene("L4");
            }
        }



    }

    void Exit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
