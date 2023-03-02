using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    float time;
    public GameObject firstship;
    public GameObject secondship;

    int count;
    private GameObject firstenemy;
    private GameObject secondenemy;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float randomx1 = Random.Range(-22, 0);
        float randomx2 = Random.Range(0, 23);

        
        if (time > 1.0f && count >= 5 && count < 12)
        {
            count+=2;
            time = 0;

        }
        if (time > 2.0f && count < 5)
        {

            firstenemy = Instantiate(firstship, new Vector3(randomx1, 0 , transform.position.z ), transform.rotation * Quaternion.Euler(0f, 180f, 0f)) as GameObject;
            count+=2;
            time = 0;
        }
        if (time > 3.0f && count >= 10 && count < 17)
        {

            secondenemy = Instantiate(secondship, new Vector3(randomx2, 0, transform.position.z), transform.rotation * Quaternion.Euler(0f, 180f, 0f)) as GameObject;
            count+=2;
            time = 0;
        }
        if (time > 1.0f && count >= 17 && count < 22)
        {
            count+=3;
            time = 0;
        }
        if (time > 1.0f && count >= 22 && count < 29)
        {
            count+=2;
            time = 0;
        }
        if (count >= 29)
            count = 0;
    }

    
}
