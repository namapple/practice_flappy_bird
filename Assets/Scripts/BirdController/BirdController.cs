using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float bounceForce;
    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;
    private bool isAlive; //default value is false
    private bool didFlap;
    private void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        BirdMovement();
    }
    void BirdMovement()
    {
        //if bird is alive
        if (isAlive)
        {
            //if the user tap
            if (didFlap)
            {
                // user can only tap once, if not, bird will jump in the sky
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        if (myBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (myBody.velocity.y == 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }
}
