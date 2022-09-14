using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float angleBar = 180;

    public static PlayerMovement Instance;
    public bool oncollisionPolice;
    public Camera camera;

    public Image barLife2;
    public float life = 100;
    public float reduceLife;
    private void Awake()
    {
        Instance = this;
        oncollisionPolice = false;
    }

    private void Update()
    {
 
        barLife2.transform.position= camera.WorldToScreenPoint(this.transform.position); 
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.collider.name);
        if (!collision.collider.name.Equals("Ground") && !collision.collider.name.Equals("Walls") && !collision.collider.name.Equals("default"))
        {
            DecreaseLife();
            oncollisionPolice = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.name.Equals("Ground") && !collision.collider.name.Equals("Walls") && !collision.collider.name.Equals("default"))
        {
            oncollisionPolice = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.name.Equals("Ground") && !collision.collider.name.Equals("Ground1") && !collision.collider.name.Equals("Walls") && !collision.collider.name.Equals("default"))
        {
            CameraShaker.Instance.ShakeOnce(1.2f, 1.2f, .1f, 1f);
            
           
        }
    }

    void DecreaseLife()
    {
        if ((life-reduceLife)>= 1)
        {

            life -= reduceLife;
            float amount = ((life) / 100.0f);

            barLife2.fillAmount = amount;

        }
        else
            life = 0;
        

    }

}
