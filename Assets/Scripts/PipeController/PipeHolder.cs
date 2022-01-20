using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PipeMovement();
    }

    void PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
