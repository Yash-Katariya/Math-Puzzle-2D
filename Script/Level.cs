using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text displaytext, LevelNo, hintTxt;
    [SerializeField]
    Image previewImage;
    public GameObject playing, win ,hint;

    public void OnEnable()
    {
        int levelIndex = LEVEL_Manager_Math.Instance.levelIndex;
        LevelNo.text = "Puzzle " + (levelIndex + 1);  //level no is ++
        previewImage.sprite = LEVEL_Manager_Math.Instance.allImages[levelIndex];
        
        displaytext.text = string.Empty;   // clear displaytext
    }
    public void onButtonCLick(string data) // btn click[1234567890] show btn text in textbox [text]
    {
        displaytext.text += data;
    }
    public void onSubmitClick()  // submit click move to win page other show MSG [wrong Ans]
    {
        string answer = LEVEL_Manager_Math.Instance.getRightAnswer();
        if (displaytext.text == answer)
        {
            LEVEL_Manager_Math.Instance.setLevelState("clear");
            win.gameObject.SetActive(true);
            //LevelNo.text = (LEVEL_Manager_Math.Instance.levelIndex + 1).ToString();
            playing.gameObject.SetActive(false);
        }
        else
        {
            hint.gameObject.SetActive(true);
            hintTxt.text = "Wrong answer!";
            //print("Wrong answer!");
           
            displaytext.text = string.Empty;  // incorrect ans displaytext is blank 
        }
    }
    public void onBackCLick() //remove text one by one in textbox
    {
        if (displaytext.text.Length > 0)
        {
            displaytext.text = displaytext.text.Remove(displaytext.text.Length - 1, 1);
        }
    }
    public void onSkipButton() //level skip currentLevel + 1
    {
        int currentLevel = LEVEL_Manager_Math.Instance.levelIndex;
        LEVEL_Manager_Math.Instance.setLevelState("skip");// skip the level [EX: runing 1 and skip btn click 2 level is open]

        if (currentLevel + 1 < LEVEL_Manager_Math.Instance.allImages.Length) // Move to the next level
        {
            LEVEL_Manager_Math.Instance.levelIndex = currentLevel + 1;
            OnEnable();
        }
        else
        {
            hint.gameObject.SetActive(true);
            hintTxt.text = "No more levels to skip to!";
            //print("No more levels to skip to!");
        }
    }
    public void OnHintBtnClick() // hint btn click and show ans [hint type]
    {
        string hintAns = LEVEL_Manager_Math.Instance.getHintAnswer();
        /*if (displaytext.text == hintAns)
        {
            //LEVEL_Manager_Math.Instance.setLevelState("clear");
            //win.gameObject.SetActive(true);
            //playing.gameObject.SetActive(false);
        }*/
        //playing.gameObject.SetActive(false);
        hint.gameObject.SetActive(true);
        //print("" + hintAns);
        hintTxt.text = hintAns;   
    }
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
}
