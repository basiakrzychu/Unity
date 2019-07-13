using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kolizja : MonoBehaviour {

    Text game;
   

    private void Start()
    {
        game = GameObject.Find("Canvas/Text").GetComponent<gui>().over;
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            game.enabled = true;
            var rekord= GameObject.Find("Canvas/Score").GetComponent<Score>().x=0;
            game.text = ("kurka umarła :(");
         
            StartCoroutine(delay());
           
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("podstawa");
    }

}
