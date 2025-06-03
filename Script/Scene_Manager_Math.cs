using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager_Math : MonoBehaviour
{
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
    public void loadScene(string sceneName)//   int sceneIndex
    {
        SceneManager.LoadScene("sceneName");//sceneIndex
    }

    /*public void unLoadScene(int sceneIndex)  //comments
    {
        SceneManager.UnloadScene(sceneIndex);
    }*/
}
