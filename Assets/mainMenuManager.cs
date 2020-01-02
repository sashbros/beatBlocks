using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuManager : MonoBehaviour
{
    // public GameObject startPanelUI;
    public Animator startPanel;
    public Animator creditsPanel;
    public Animator levelsPanel;
    public void Start() {
        //here firstly start menu anim
        startPanel.Play("comeStartP");
    }
    public void PlayGame() {
        //and load all the data
        GameObject parent = GameObject.Find("Canvas/LevelsPanel/ScrollRect/Content");
        /*
        playerData data = SaveSystem.LoadPlayer();
        // Debug.Log(data.data[1, 3]);
        // Debug.Log(parent.name + ":PARENT");
        foreach (Transform child in parent.transform) {
            child.gameObject.transform.Find("Stars").gameObject.GetComponent<Text>().text = 
                    "stars: " + data.data[int.Parse(child.gameObject.name), 3] + "/3";
            
        }
        */
        foreach (Transform child in parent.transform) {
            child.gameObject.transform.Find("Stars").gameObject.GetComponent<Text>().text = 
                    "stars: " + PlayerPrefs.GetInt(child.gameObject.name, 0) + "/3";
            
        }

        startPanel.Play("goStartP");
        levelsPanel.Play("comeLevelsP");

        // startPanelUI.SetActive(false);
    }
    public void Credits() {
        startPanel.Play("goStartP");
        creditsPanel.Play("comeCreditsP");
    }
    public void QuitGame() {
        startPanel.Play("goStartP");
        Application.Quit();
        Debug.Log("Quitting...");
    }
    public void BackButtonOnCredits() {
        creditsPanel.Play("goCredits");
        startPanel.Play("comeStartP");
    }
    public void BackButtonOnLevels() {
        levelsPanel.Play("goLevelsP");
        startPanel.Play("comeStartP");
    }

    public void PlayThatLevel(int levelNo) {
        // SceneManager.LoadScene(levelNo);
        StartCoroutine(WaitForLoad(levelNo));
    }
    IEnumerator WaitForLoad(int levelNo) {
        levelsPanel.Play("goLevelsP");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelNo);
    }
}
