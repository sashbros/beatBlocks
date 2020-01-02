using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start() {
        speed = GameObject.Find("BlockSpawner").GetComponent<spawnManager>().blockSpeed;
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
    }
}
