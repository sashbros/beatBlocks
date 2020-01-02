using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behindPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("RED") || other.gameObject.CompareTag("GREEN") || other.gameObject.CompareTag("BLUE")) {
            Destroy(other.gameObject);
            // code to find max Combo Count
            if (GameObject.Find("Player").GetComponent<playerController>().comboCount > 
                    GameObject.Find("Player").GetComponent<playerController>().maxComboCount) {
                        GameObject.Find("Player").GetComponent<playerController>().maxComboCount = 
                            GameObject.Find("Player").GetComponent<playerController>().comboCount;
                    }
            GameObject.Find("Player").GetComponent<playerController>().comboCount = 0;
            // Debug.Log(GameObject.Find("Player").GetComponent<playerController>().maxComboCount);
        }
    }
}
