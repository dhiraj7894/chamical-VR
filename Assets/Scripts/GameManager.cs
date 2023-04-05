using GameEon;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject _canvas;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSecondsRealtime(0.7f);

        _canvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClick_RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            OnClick_RestartGame();
        }
    }

}
