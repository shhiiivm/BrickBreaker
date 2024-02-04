using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {


        if (gm.gameOver)
        {
            return;
        }
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {

            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Debug.Log("ball entered in bottom zone");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.Updatelives(-1);
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bricks"))
        {
            Transform newExplosion =  Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);

            gm.Updatescore(other.gameObject.GetComponent<Bricks>().points);
            Destroy(other.gameObject);
        }
    }
}
