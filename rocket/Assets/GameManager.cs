using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    Text timeT;
    Text bestT;
    public Text gameOverText;

    public Button btn;
    float t=0;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        i=this;
        Time.timeScale = 1;
        timeT = GameObject.Find("TimeText").GetComponent<Text>();
        bestT=GameObject.Find("BestText").GetComponent<Text>();
        gameOverText.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) 
        {   
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
        t+=Time.deltaTime;
        timeT.text = "TIME\n" + SetTime((int)t);     
    }

    string SetTime(int t)
    {
        string min = (t/60).ToString();
        if(int.Parse(min)<10)min = "0"+min;
        string sec = (t%60).ToString();
        if(int.Parse(sec)<10)sec="0"+sec;
        return min + ":" + sec;
    }
    
    
    public void GameOver()
    {   
        isGameOver = true;
        SetBestTime();
    }

    void SetBestTime()
    {
        if(PlayerPrefs.HasKey("BEST"))
        {
            int b =PlayerPrefs.GetInt("BEST");
            if((int)t>b)
                PlayerPrefs.SetInt("BEST",b=(int)t);

            bestT.text = "BEST\n" + SetTime(b);        
        }
        else
        {
            PlayerPrefs.SetInt("BEST",(int)t);
            bestT.text = "BEST\n"+SetTime((int)t);
        }

        bestT.enabled = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
        isGameOver =false;
    }
}
