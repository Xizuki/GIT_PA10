using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, 250, 0));
        }
        
        if(transform.position.y >= 6.3)
        {
            transform.position = new Vector3(transform.position.x, 6.3f, transform.position.z);
        }
        else if (transform.position.y <= -4.3)
        {
            GameManager.thisManager.GameOver();
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            GameManager.thisManager.GameOver();
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Clear")
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
