using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float pace = 30.0f;
    private float zBound = 0.2f;
    private Rigidbody playersRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    private SpawnManager spawnManager;

    public ParticleSystem expParticle;
    public ParticleSystem eParticle;
    public AudioClip gameOverSound;
    public AudioClip coronaSound;
    public AudioClip livesSound;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playersRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
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
        if (collision.gameObject.CompareTag("Trump") || spawnManager.activeGame)
            {
                Debug.Log("Game Over");
                gameOver = true;
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", 2);
                expParticle.Play();
                playerAudio.PlayOneShot(gameOverSound, 1.0f);
                spawnManager.GameOver();
            }
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Eliminate") || spawnManager.activeGame)
        {
            Destroy(other.gameObject);
           eParticle.Play();
                playerAudio.PlayOneShot(coronaSound, 1.0f);
                spawnManager.AddtoScore(1);
        }
        else if (other.gameObject.CompareTag("lives")){ 
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(livesSound, 1.0f);
            spawnManager.AddtoScore(5);
        }
        }
    }
