using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPellet : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    Transform trans;
    

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
        Debug.Log("Character Gets a Speed Boost");
        
        rb2d.gravityScale = 0;
        GetComponent<AudioSource>().pitch = Random.Range(.7f, 1.3f);
        GetComponent<AudioSource>().Play();
        transform.position = new Vector3(1000000, 0, 0);
        Destroy(this.gameObject, 2);

    }
}
