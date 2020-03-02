using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string PLAY_PREF_KEY_HS = "High Score"; //Player preferences key for high score. It is a "const" which means the value is only set once and can never be changed
    private const string FILE_HS = "/CodeLab1-S2020-highscore.txt"; //Const for name of the highscore file

    private float timer = 30;
    public Text TimerText;

    public int Timer
    {
        get
        {
            return (int)timer;
        }

        set
        {
            timer = value;
            if (timer > highscore)
            {
                Highscore = (int)timer;
            }
        }
    }

    private int highscore = 0;

    public int Highscore
    {
        get
        {
            return highscore;
        }

        set
        {
            highscore = value;

            File.WriteAllText(Application.dataPath + FILE_HS, highscore + "");
        }
    }

    private void Awake()
    {
        if (instance == null)
        { //instance hasn't been set yet
            instance = this; //set instance to this object
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
        }
        else
        { //if the instance is already set to an object
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    public void changescene(string stringname)
    {
        SceneManager.LoadScene(stringname);
    }

    public void TimerReset()
    {
        instance.TimerText.enabled = true;
        instance.timer = 30;
        instance.TimerText.text = "Time: " + (int)timer;
    }

    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponentInChildren<Text>();

        if (File.Exists(Application.dataPath + FILE_HS)) //check if the file exists
        {
            string hsString = File.ReadAllText(Application.dataPath + FILE_HS); //read the text from highscore file
            print(hsString); //print highscore
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; //increase the timer by deltaTime every frame
        TimerText.text = "Time: " + (int)timer + " High Score: " + highscore; //update the text component with the score and time

        if (timer <= 0)
        {
            //SceneManager.LoadScene("LoseScreen");
            TimerText.text = "Game Over";
        }
    }
}
