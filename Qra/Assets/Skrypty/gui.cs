using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gui : MonoBehaviour {

    public Text start;
    public Text wersja;
    public RawImage qra;
    public Text over;

    // Use this for initialization
    void Start () {
        over.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 1;
            start.enabled = false;
            wersja.enabled = false;
            Destroy(qra);
        }
        
        if (Screen.width < 1000)
        {
            qra.SetNativeSize();
            start.fontSize = 70;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("podstawa");
        }

    }

   



}
