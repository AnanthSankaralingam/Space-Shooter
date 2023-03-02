using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;
    private Quaternion currentRotation;
    private Quaternion leftFinalRotation = Quaternion.Euler(0, 0, 25);
    private Quaternion rightFinalRotation = Quaternion.Euler(0, 0, -25);
    private Quaternion normalRotation = Quaternion.Euler(0, 0, 0);
    private float time;
    
    public GameObject explosionPrefab;
    private Quaternion startRotation, tilt;
    // Start is called before the first frame update
    public GameObject explosion;

    void Start()
    {
        Physics.IgnoreLayerCollision(0, 7);
        currentRotation = this.transform.rotation;
        time = 0;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -22.4)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime *20, relativeTo: Space.World);
            if (transform.localEulerAngles.z < 75 || transform.localEulerAngles.z > 280)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + (time * 40));
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            tilt = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y, startRotation.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 22.4)
        {
            //currentRotation = leftFinalRotation;
            this.transform.Translate(Vector3.right * Time.deltaTime *20, relativeTo: Space.World);
            if (transform.localEulerAngles.z > 285 || transform.localEulerAngles.z < 80)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - (time * 40));
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            tilt = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y, startRotation.eulerAngles.z);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * 30);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -25)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * 30);
        }//end user move  
        transform.rotation = Quaternion.Slerp(startRotation, tilt, Time.deltaTime * 1000);

        //if (transform.position.x > -5 && transform.position.x < 5)
        //  this.transform.rotation = normalRotation;
        /*
                if (Input.GetKey(KeyCode.RightArrow) && transform.position.x > 5)
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rightFinalRotation, 0.0005f);
                }
                if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 5)
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, leftFinalRotation, 0.0005f);
                }*/
        /* if (transform.position.x < -1 && Input.GetKey(KeyCode.RightArrow))
         {
             currentRotation = leftFinalRotation;
         }
         else if (transform.position.x < -1)
             currentRotation = normalRotation;*/

        /* if (transform.position.x > 1 && Input.GetKey(KeyCode.RightArrow))
             currentRotation = rightFinalRotation;
         else if (transform.position.x < -1)
             currentRotation = normalRotation;*/

        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentRotation, 0.0005f);
    }
    /*void OnCollisionStay(Collision col)
    {
        print("Collision Started");
        //Instantiate(explosion, transform.position, transform.rotation);
        GameObject e = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Destroy(user);
        Destroy(col.gameObject);

    }*/
}
