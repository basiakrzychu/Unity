using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Net;

public class HSController : MonoBehaviour
{
    private string secretKey = "2137";
    string addScoreURL = "http://125928xd.epizy.com/addscore.php";
    string highscoreURL = "http://125928xd.epizy.com/display.php";
    public Text highscorelist;

  //  WebClient client = new WebClient();


    //We start by just getting the HighScores, this should be removed, when you are done setting up.
    void Start()
    {
            StartCoroutine(GetScores());
       // StartCoroutine(GetRequest(highscoreURL));
    }
     
   
    //This is where we post 
    public void PostScores(string name, int score)
    {
        string hash = Md5Sum(name + score + secretKey);
        WWWForm form = new WWWForm();
        form.AddField("namePost", name);
        form.AddField("scorePost", score);
        form.AddField("hashPost", hash);
        WWW www = new WWW(addScoreURL, form);
    }
    //This co-rutine gets the score, and print it to a text UI element.
    IEnumerator GetScores()
    {
        WWW wwwHighscores = new WWW(highscoreURL);
        yield return wwwHighscores;
  //      string htmlCode = client.DownloadString(highscoreURL);

     //   highscorelist.text = htmlCode;
       if (wwwHighscores.error != null)
        {
            highscorelist.text = wwwHighscores.error;
            print("There was an error getting the high score: " + wwwHighscores.error);
        }
        else
        {

            highscorelist.text = wwwHighscores.text;
        }
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
        
            highscorelist.text = webRequest.downloadHandler.text;
/*
            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
            */
        }
    }

    // This is used to create a md5sum - so that we are sure that only legit scores are submitted.
    // We use this when we post the scores.
    // This should probably be placed in a seperate class. But isplaced here to make it simple to understand.
    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }
}