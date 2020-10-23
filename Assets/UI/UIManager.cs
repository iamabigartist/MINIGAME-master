using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<string> levelList;
    public GameObject mainMenuCanvas,levelChooserCanvas; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(levelList[index],LoadSceneMode.Single);
        SceneManager.LoadScene("InGameManger", LoadSceneMode.Additive);
    }

    public void LevelChooser2MainMenu()
    {
        levelChooserCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void MainMenu2LevelChooser()
    {
        levelChooserCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
