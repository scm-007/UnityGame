using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void OnApplicationPause(bool pause)
    {
        OnPausePanel();
    }

    public void OnPausePanel()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void GoToMainMenu()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void LeaveGame()
    {
        pausePanel.SetActive(false);
        Application.Quit();
    }

}
