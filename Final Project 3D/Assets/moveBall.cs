using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(transform.position.y < 5)
        {
            Vector3 newVelocity = Vector3.up;
            newVelocity.y += 0.1f;
            rb.velocity = newVelocity;
        }
    }
}
