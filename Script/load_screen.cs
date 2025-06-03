using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_screen : MonoBehaviour
{
    public GameObject First,Second;
    public Image fillImage;

    void Start()
    {
        StartCoroutine(moveToPlayingWithDelay());
    }
    private IEnumerator moveToPlayingWithDelay()
    {
        print("start...");
        yield return new WaitForSeconds(3);
        print("End...");
        First.SetActive(false);
        Second.SetActive(true);
        loaderStart = true;
    }
    public bool loaderStart = false;

    public float waitTime = 10.0f;

    void Update()
    {
        if (loaderStart)
        {
            if (fillImage.fillAmount < 1)
            { 
                //Reduce fill amount over 30 seconds
                fillImage.fillAmount += 1.0f / waitTime * Time.deltaTime;
                //print("deltaTIme -> " + fillImage.fillAmount);
            }
            else
            {
                SceneManager.LoadScene("Home_Screen");   //MOVE scene 1 TO scene 2 ---not sceneManager use
                loaderStart = false;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}

