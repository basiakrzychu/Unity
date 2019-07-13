using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text tekst;
    public Text rekord;
    public int wynik;
    float highscore;
    public int x=1;
	void Start ()
    {
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        rekord.text = (highscore).ToString("0");
    }
    
    void FixedUpdate() {
       

        if (wynik > highscore)
        {
            highscore = wynik;

            
        }

        PlayerPrefs.SetFloat("highscore", highscore);
        rekord.text = (highscore).ToString("0");

        if (wynik != 0)
        {
          
            tekst.text = (wynik).ToString("0");
            rekord.enabled = false;
        } 
        wynik += x;
    }
}
