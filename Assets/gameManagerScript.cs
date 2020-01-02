using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject pauseMenuUI;
    public GameObject finishMenuUI;
    public GameObject pauseButton;
    public AudioSource musicAudio;
    public GameObject[] disableObjectsOnPerformance;

    void Start() {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
        // musicAudio.Stop();
        pauseButton.SetActive(false);
        finishMenuUI.SetActive(false);
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        musicAudio.Pause();
        pauseButton.SetActive(false);
    }
    public void Resume() {
        startMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        musicAudio.Play();
        pauseButton.SetActive(true);
        finishMenuUI.SetActive(false);
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void FocusPerformance() {
        foreach (var item in disableObjectsOnPerformance)
        {
            item.SetActive(false);    
        }
        
    }
    public void FocusGraphics() {
        foreach (var item in disableObjectsOnPerformance)
        {
            item.SetActive(true);    
        }
    }
    
    public void FinishMenuDisplay() {
        finishMenuUI.SetActive(true);
        // musicAudio.Pause();
        pauseButton.SetActive(false);
    }
}
