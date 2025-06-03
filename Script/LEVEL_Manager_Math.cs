using System;
using UnityEngine;
using UnityEngine.UI;

public class LEVEL_Manager_Math : MonoBehaviour
{
    [SerializeField]
    public Sprite[] allImages;// sprite means image -->create aaray [multiple image store]
    private string[] answer = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };  // static ans store
    private string[] hintAns = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };
    public static LEVEL_Manager_Math Instance;
    public int levelIndex = 0;
    public GameObject Playing, SelectionLevel, win;
    public Text LevelNo;
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        /*if (Input.GetKey(KeyCode.Escape))
        {
            print("Escape ---> ");
        }*/
    }
    private void Awake()
    {
        Instance = this;
        //LevelNo.text = levelIndex + 1.ToString();
    }

    public void startFromLast()   // play btn click --> last level is open 
    {
        moveToPlain(PlayerPrefs.GetInt("maxLevel", 0));
    }

    public void moveToPlain(int finalI)
    {
        this.levelIndex = finalI;
        LevelNo.text = (levelIndex + 1).ToString();
        Playing.SetActive(true);
        SelectionLevel.SetActive(false);
    }

    public string getRightAnswer()
    {
        return answer[levelIndex];
    }

  
    internal void setLevelState(String state)  //Home --> play btn click --> ex:- level 1 is completed and continue btn click next level 2 is open
    {
        //Lock.SetActive(false);                 // maxLevel means --> lastLevel
        //PlayerPrefs.SetInt("" + levelIndex, 1);

        string currentState = PlayerPrefs.GetString("" + levelIndex, "lock");
        if (currentState != "clear")
        {
            PlayerPrefs.SetString("" + levelIndex, state);
            PlayerPrefs.SetInt("maxLevel", PlayerPrefs.GetInt("maxLevel", 0) + 1);
        }
    }
    public void onContinueButtonClick() // Continue[Win] button click
    {
        int maxLevel = PlayerPrefs.GetInt("maxLevel", 0);

        if (levelIndex + 1 < allImages.Length)
        {
            levelIndex++;
            moveToPlain(levelIndex);
            Playing.SetActive(true);
            win.SetActive(false);
        }
        /*else
        {
            hint.gameObject.SetActive(true);
            hintTxt.text = "Wrong answer!";
            Playing.SetActive(false);
            SelectionLevel.SetActive(true);
        }*/
    }
    internal string getHintAnswer()
    {
        return hintAns[levelIndex];
    }

   
}
