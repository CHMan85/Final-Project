using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb2d;
    Animator anim;
    Transform trans;

    [Header("Movement")]
    public float speed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (trans.position.y <= -8f)
        {
            Destroy(this.gameObject);
        }
    }

    public void hitCharacter()
    {
        Debug.Log("Hitting Character");
        rb2d.gravityScale = 0;
        anim.Play("BottomHit");
        GetComponent<AudioSource>().Play();
    }
}
