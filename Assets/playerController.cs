using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [HideInInspector]
    public int comboCount = 0;
    [HideInInspector]
    public int blocksCollected = 0; //maxScore
    [HideInInspector]
    public int maxComboCount = 0; //maxCombo
    public Animator anim;
    public AnimationClip[] comboClips;
    public GameObject redBlockBlast;
    public GameObject greenBlockBlast;
    public GameObject blueBlockBlast;
    public AudioClip whooshEffectClip;
    public float whooshEffectVolume;

    [HideInInspector]
    public bool firstStar = false;
    [HideInInspector]
    public bool secondStar = false;
    [HideInInspector]
    public bool thirdStar = false;
    [HideInInspector]
    public int totalStars; //stars
    [HideInInspector]
    public int levelIndex; //levelindex
    // public GameObject ballMovementEffect;

    void Awake() {
        comboClips = anim.runtimeAnimatorController.animationClips;
        
        totalStars=0;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("level " + levelIndex);
    }

    void Update() {
        if (comboCount < 3) {
            GameObject.Find("ComboText").GetComponent<Text>().text = "";
        }
        else {
            GameObject.Find("ComboText").GetComponent<Text>().text = "COMBO X" + comboCount;
        }
        // GameObject.Find("ComboText").GetComponent<Text>().text = "COMBO X" + comboCount;
        GameObject.Find("TotalBlocksCollected").GetComponent<Text>().text = "score: " + blocksCollected;

        //individual stars code
        if (comboCount >= 50) {
            firstStar = true;
        }
        if (blocksCollected >= 350) {
            secondStar = true;
        }
        if (comboCount == blocksCollected) {
            thirdStar = true;
        }
        else {
            thirdStar = false;
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("RED")) {
            comboCount++;
            anim.Play(comboClips[Random.Range(0, comboClips.Length)].name);
            // PlayComboAnim(); //plays random animation
            blocksCollected++;
            GameObject red = Instantiate(redBlockBlast, gameObject.transform);
            red.transform.parent = null;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(whooshEffectClip, transform.position, whooshEffectVolume);
        }
        else if (other.gameObject.CompareTag("GREEN")) {
            comboCount++;
            anim.Play(comboClips[Random.Range(0, comboClips.Length)].name);
            // PlayComboAnim(); //plays random animation
            blocksCollected++;
            GameObject green = Instantiate(greenBlockBlast, gameObject.transform);
            green.transform.parent = null;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(whooshEffectClip, transform.position, whooshEffectVolume);
        }
        else if (other.gameObject.CompareTag("BLUE")) {
            comboCount++;
            anim.Play(comboClips[Random.Range(0, comboClips.Length)].name);
            // PlayComboAnim(); //plays random animation
            blocksCollected++;
            GameObject blue = Instantiate(blueBlockBlast, gameObject.transform);
            blue.transform.parent = null;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(whooshEffectClip, transform.position, whooshEffectVolume);
        }
    }
    public void GreenSide() {
        gameObject.transform.position = new Vector3(-1.25f, gameObject.transform.position.y, gameObject.transform.position.z);
        // Instantiate(ballMovementEffect, gameObject.transform.position, Quaternion.identity);
    }
    
    public void BlueSide() {
        gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, gameObject.transform.position.z);
        // Instantiate(ballMovementEffect, gameObject.transform.position, Quaternion.identity);
    }

    public void RedSide() {
        gameObject.transform.position = new Vector3(1.25f, gameObject.transform.position.y, gameObject.transform.position.z);
        // Instantiate(ballMovementEffect, gameObject.transform.position, Quaternion.identity);
    }
    public void SavePlayerDetails() {
        // playerController player = gameObject.AddComponent<playerController>();
        // player.levelIndex = GameObject.Find("Player").GetComponent<playerController>().levelIndex;
        // player.blocksCollected = GameObject.Find("Player").GetComponent<playerController>().blocksCollected;
        // player.maxComboCount = GameObject.Find("Player").GetComponent<playerController>().maxComboCount;
        // player.totalStars = GameObject.Find("Player").GetComponent<playerController>().totalStars;

        // playerData oldData = SaveSystem.LoadPlayer();
        // if (oldData.data[this.levelIndex, 1] > this.blocksCollected) {
        //     this.blocksCollected = oldData.data[this.levelIndex, 1];
        // }
        // if (oldData.data[this.levelIndex, 2] > this.maxComboCount) {
        //     this.maxComboCount = oldData.data[this.levelIndex, 2];
        // }
        // if (oldData.data[this.levelIndex, 3] > this.totalStars) {
        //     this.totalStars = oldData.data[this.levelIndex, 3];
        // }

        if (totalStars > PlayerPrefs.GetInt(levelIndex.ToString(), 0)) {
            PlayerPrefs.SetInt(levelIndex.ToString(), totalStars);
        }

        /*
        playerData oldData = SaveSystem.LoadPlayer();
        if (oldData.data[levelIndex, 1] > blocksCollected) {
            blocksCollected = oldData.data[levelIndex, 1];
        }
        if (oldData.data[levelIndex, 2] > maxComboCount) {
            maxComboCount = oldData.data[levelIndex, 2];
        }
        if (oldData.data[levelIndex, 3] > totalStars) {
            totalStars = oldData.data[levelIndex, 3];
        }

        SaveSystem.SavePlayer(this);
        */
    }
}
