using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else if(Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("LevelsMenu");
        }
    }
}
