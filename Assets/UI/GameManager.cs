using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuCanvas.activeSelf)
            {
                Time.timeScale = 0;
                pauseMenuCanvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenuCanvas.SetActive(false);
            }
        }
    }

    public void ToStartMenu()
    {
        Time.fixedDeltaTime = 0.02f;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
