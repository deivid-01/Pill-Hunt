using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : MonoBehaviour
{
    // Start is called before the first frame update
 
 
    public Transform player;
    public GameController gameController;
   
    public bool follow = false;









    void Start()
    {


        gameController = GameController.Instance;

  
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            if (follow == true)
            {
                gameController.gameOver = true;
            }
        }
    }
}
