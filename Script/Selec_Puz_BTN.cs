using UnityEngine;
using UnityEngine.UI;
public class Selec_Puz_BTN : MonoBehaviour
{
    public GameObject btn, Playing, SelectionLevel;
    public Transform gridTransform;

    private void Update()
    {
        /*if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                //print("Escape ---> ");
            }
        }*/
        if (Input.GetKey(KeyCode.Escape))   // back press in mobile device
        {
            Application.Quit();
        }
    }
    private void OnEnable()
    {
        Sprite[] allImages = LEVEL_Manager_Math.Instance.allImages;  //all image 
        int allChild = gridTransform.childCount; //get total childs
        for (int i = 0; i < allChild; i++)
        {
            Destroy(gridTransform.GetChild(i).gameObject);   // destroty btn on grid
        }
        int maxLevel = PlayerPrefs.GetInt("maxLevel",0);
        for (int i = 0; i < 75; i++)  // allimage 
        {

            GameObject Clone = Instantiate(btn, gridTransform);
            Button b = Clone.GetComponent<Button>();
            Text t = Clone.GetComponentInChildren<Text>();
            Image tickImage = Clone.transform.GetChild(1).GetComponent<Image>();
            Image lockImage = Clone.transform.GetChild(2).GetComponent<Image>();

            string state = PlayerPrefs.GetString("" + i, "lock");   // GetString("LevelStatus_" + i, "locked"),,using string [ tick,lock,skip  ]

            if (state == "clear")   // level is compeleted then show tick image is show
            {
                tickImage.gameObject.SetActive(true);
                lockImage.gameObject.SetActive(false);
                t.text = (i + 1).ToString();        //  Display level number
            }
            else if (state == "skip" || maxLevel == i)   // skip level & lastlevel 
            {
                tickImage.gameObject.SetActive(false);
                lockImage.gameObject.SetActive(false);
                t.text = (i + 1).ToString();        //  Display level number
            }
            else    // bydefault is lock image show
            {
                tickImage.gameObject.SetActive(false);
                lockImage.gameObject.SetActive(true);
                t.text = "";
                b.interactable = false;   // lock show is level is not open
            }

            int finalI = i;
            b.onClick.AddListener(() =>   // click image and move to playing page show
            {
                //print("level   ----");
                LEVEL_Manager_Math.Instance.moveToPlain(finalI);

            });
        }

    }
}
