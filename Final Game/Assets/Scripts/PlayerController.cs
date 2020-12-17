using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float pace = 30.0f;
    private float zBound = 0.2f;
    private Rigidbody playersRb;

    // Start is called before the first frame update
    void Start()
    {
        playersRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainsPlayersPosition();
    }

    //Player is moved by arrow keys back, forward, left to right visa versa
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
       
        playersRb.AddForce(Vector3.right * pace * horizontalInput);
    }

    //Keeps player in certain space with invisable walls
    void ConstrainsPlayersPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trump"))
        {
            Debug.Log("Player has hit Trump"); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Eliminate"))
        {
            Destroy(other.gameObject);
        }
    }
}
