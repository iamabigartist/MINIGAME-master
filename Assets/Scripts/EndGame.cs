using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Animation blendPostEffect;
    public AudioManager am;
    public float exit_time;
    public string nextLevel;
    private AsyncOperation _asyncOperation;
    private bool isTriggered;
    private void Start()
    {
        _asyncOperation = SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Single);
        _asyncOperation.allowSceneActivation = false;
        isTriggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)return;
        
        if (blendPostEffect) blendPostEffect.Play();
        if (am) am.playEndGame();
        Invoke("LoadnextLevel", exit_time);
        isTriggered = true;
    }

    private void LoadnextLevel()
    {
        Time.fixedDeltaTime = 0.02f;
        _asyncOperation.allowSceneActivation = true;
        //SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        if (nextLevel != "StartMenu")
        {
            SceneManager.LoadScene("InGameManger", LoadSceneMode.Additive);
        }
        
    }

}
