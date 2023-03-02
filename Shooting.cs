using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missile = Instantiate(myPrefab, new Vector3(transform.position.x, transform.position.y, -25f), transform.rotation * Quaternion.Euler(0f, -180f, 0f)) as GameObject;// creates missile
        }
    }
}
