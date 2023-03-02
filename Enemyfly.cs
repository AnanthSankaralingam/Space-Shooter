using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfly : MonoBehaviour
{
    float time;
    public GameObject explosion;
    public GameObject user;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0,7);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
        if (time < 1.0f)
        {
            
            transform.Translate(Vector3.right * Time.deltaTime*10);

            
            transform.Translate(Vector3.forward * Time.deltaTime*10);

        }
    }
    void OnCollisionStay(Collision col)
    {
        print("Collision Started");
        //Instantiate(explosion, transform.position, transform.rotation);
        GameObject e = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Destroy(user);
        Destroy(col.gameObject);

    }
}
