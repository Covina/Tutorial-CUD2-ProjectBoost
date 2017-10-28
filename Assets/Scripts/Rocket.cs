using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    // multiplier on thrust
    [SerializeField]
    private float thrustBoost = 1.2f;

    // how fast it should rotate
    [SerializeField]
    private float rotationBoost = 75.0f;

    // The Rocket Ship
    private Rigidbody rigidBody;

    // to play the thrust sound
    private AudioSource audioSource;

    // SFX: Thrust
    [SerializeField] AudioClip mainEngine;

    // Explosion
    [SerializeField] AudioClip explosion;

    // Success
    [SerializeField] AudioClip levelSuccess;

    // Particle effects for Rocket Ship
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;



    enum State
    {
        Alive,
        Dying,
        Transcending

    }

    State state = State.Alive;

	// Use this for initialization
	void Start () {

        // Get reference to the component
        rigidBody = GetComponent<Rigidbody>();

        // Get reference to the audio source component
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        if(state == State.Alive) {
            RespondToThrustInput();
            RespondToRotateInput();
        }


    }


    // 
    private void RespondToThrustInput()
    {
        // check for thrust
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();

        }
        else
        {
            // player is not thrusting, end sound
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    //
    private void ApplyThrust()
    {
        // Add force only in the direction of where its pointing (rotation)
        // Vector3.up = (0,1,0)  in the Y Axis
        rigidBody.AddRelativeForce(Vector3.up * thrustBoost);

        // check if its already playing, and if not, play it
        if (audioSource.isPlaying == false)
        {

            audioSource.PlayOneShot(mainEngine);

        }

        // fire the particles
        mainEngineParticles.Play();
    }

    /// <summary>
    /// Controlling the rotation of the ship
    /// </summary>
    private void RespondToRotateInput()
    {

        // disable physics on rotation
        rigidBody.freezeRotation = true;

        float rotationSpeed = Time.deltaTime * rotationBoost;

        // check for left tilt
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(Vector3.forward * rotationSpeed);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {


            transform.Rotate(-Vector3.forward * rotationSpeed);


        }

        // resume physics control
        rigidBody.freezeRotation = false;
    }


    /// <summary>
    /// Detect if rocket collides with something friendly or kill
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        // Prevent extra processing if we're dead
        if (state != State.Alive) { return; }

        Debug.Log("Player hit something");

        // What did we run into?
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                print("Rocket hit a friendly: " + collision.gameObject.name);
                break;

            case "Hazard":
                print("Rocket hit Hazard: " + collision.gameObject.name);
                PlayerDeath();
                break;

            case "Finish":
                PlayerSuccess();
                break;


            default:
                break;

        }


    }

    private void PlayerSuccess()
    {
        state = State.Transcending;

        audioSource.PlayOneShot(levelSuccess);

        successParticles.Play();

        // load next scene
        Invoke("LoadNextLevel", 2.0f);
    }

    private void PlayerDeath()
    {
        state = State.Dying;

        audioSource.PlayOneShot(explosion);

        deathParticles.Play();

        Invoke("LoadFirstLevel", 3.0f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }


    //
    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}


