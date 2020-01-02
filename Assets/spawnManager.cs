using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class spawnManager : MonoBehaviour
{
    public GameObject[] blocks;
    public float blockSpeed;
    public float beat;
    private float timer;
    private float length;
    private int oneTimeIteration = 0;
    void Start() {
        length = GameObject.Find("AudioManager").GetComponent<AudioSource>().clip.length;
    }

    void Update() {
        if (length > 1.5f) {

            if (timer>beat) {
                GameObject cube = Instantiate(blocks[Random.Range(0,3)]);
                if (cube.CompareTag("BLUE")) {
                    cube.transform.position = new Vector3(0f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if (cube.CompareTag("GREEN")) {
                    cube.transform.position = new Vector3(-1.5f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if (cube.CompareTag("RED")) {
                    cube.transform.position = new Vector3(1.5f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                cube.transform.Rotate(transform.forward, 45 * Random.Range(0, 8));
                timer -= beat;
            }

            timer += Time.deltaTime;

            length -= Time.deltaTime;
        }
        else {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        GameObject.Find("GameManager").GetComponent<gameManagerScript>().FinishMenuDisplay();

        bool fs = GameObject.Find("Player").GetComponent<playerController>().firstStar;
        bool ss = GameObject.Find("Player").GetComponent<playerController>().secondStar;
        bool ts = GameObject.Find("Player").GetComponent<playerController>().thirdStar;
        int tts = GameObject.Find("Player").GetComponent<playerController>().totalStars;

        
        
        //total stars calculation count
        if (fs==true && oneTimeIteration==0) {
            tts++;
            oneTimeIteration++;
        }
        else {
            oneTimeIteration++;
        }
        if (ss==true && oneTimeIteration==1) {
            tts++;
            oneTimeIteration++;
        }
        else {
            oneTimeIteration++;
        }
        if(ts==true && oneTimeIteration==2) {
            tts++;
            oneTimeIteration++;
            GameObject.Find("Player").GetComponent<playerController>().totalStars = tts;
            //call the function here
            // GameObject.Find("Player").GetComponent<playerController>().SavePlayerDetails();
        }
        else {
            oneTimeIteration++;
            GameObject.Find("Player").GetComponent<playerController>().totalStars = tts;
            //call the same above function here
            // GameObject.Find("Player").GetComponent<playerController>().SavePlayerDetails();
        }
        

        //slider display slide

        if (GameObject.Find("StarProgress").GetComponent<Slider>().value < (tts/3f)) {
            GameObject.Find("StarProgress").GetComponent<Slider>().value += 0.0043f;// speed of slider
        }

        if (oneTimeIteration == 3) {
            GameObject.Find("Player").GetComponent<playerController>().SavePlayerDetails();
            oneTimeIteration++;
        }
        // Debug.Log(tts);
        // Debug.Log(fs);
        // Debug.Log(ss);
        // Debug.Log(ts);
    }
    //code of function for saving playerdata to device
    // public void SaveTheDetails() {
        

    // }
}
