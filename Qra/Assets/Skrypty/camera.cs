using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class camera : MonoBehaviour {

    public float speed;
    public float acceleration;
     public Camera kamera;

    float xd;
    
	void Start ()
    {
        
        kamera.orthographicSize = kamera.orthographicSize * 1080 / 1920 / kamera.aspect;
        xd = kamera.aspect;
        Time.timeScale = 0;

    }
    
    void FixedUpdate()
    {
        transform.Translate(0, speed, 0);
        speed += acceleration;

        if (xd != kamera.aspect)
        {
            SceneManager.LoadScene("podstawa");
         
        }

        if (1.2f*kamera.pixelHeight < kamera.pixelWidth)
        {
            SceneManager.LoadScene("podstawa");
        }
        

    }
    
}
