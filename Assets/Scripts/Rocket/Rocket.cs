using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

  
    // multiplier on thrust
    //[SerializeField]
    private float thrustBoost = 2.75f;

    // how much fuel should we burn
    private float fuelConsumptionIncrement = 0.75f;

    // how fast it should rotate
    //[SerializeField]
    private float rotationBoost = 110.0f;

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

    // Load delays
    [SerializeField] float deathLoadDelay = 3.0f;
    [SerializeField] float levelLoadDelay = 2.0f;

    private bool isCollisionsDisabled = false;


    // Fuel tank Min and Max Capacities
    public float FuelMaxCapacity = 8.0f;
    public float FuelMinCapacity = 0.0f;

    // Get/Set for current fuel value;
    private float fuelCurrentValue;
    public float FuelCurrentValue
    {
        get { return fuelCurrentValue; }
        set { fuelCurrentValue = value; }
    }


	private bool isThrusting = false;
    public bool IsThrusting { 
		get { 
			return isThrusting;  
		} 
		set {
			isThrusting = value;
		}
    }

    private bool isRotatingLeft = false;
	public bool IsRotatingLeft { 
		get { 
			return isRotatingLeft;  
		} 
		set {
			isRotatingLeft = value;
		}
    }


    private bool isRotatingRight = false;
	public bool IsRotatingRight { 
		get { 
			return isRotatingRight;  
		} 
		set {
			isRotatingRight = value;
		}
    }


    // Game States
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
	void Update ()
	{
		// if the player is alive
		if (state == State.Alive) {

			RespondToThrustInput();
            RespondToRotateInput();
        }

        // Check if in debug mode
        if(Debug.isDebugBuild)
        {
            RespondToDebugKeys();

        }
        

    }

    /// <summary>
    /// Respond to the debug key shortcuts
    /// </summary>
    private void RespondToDebugKeys()
    {

        if(Input.GetKeyDown(KeyCode.L))
        {

            // load next level
            
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {

            // toggle collisions
            isCollisionsDisabled = !isCollisionsDisabled;
        }

    }

    /// <summary>
    /// Apply thrust when player is pressing the SPACE bar
    /// </summary>
    public void RespondToThrustInput ()
	{
		// check for thrust
		if (Input.GetKey (KeyCode.Space) || isThrusting == true) {

			if (fuelCurrentValue > 0) {

				ApplyThrust ();
			}

        }
        else
        {
            StopApplyingThrust();
        }
    }

    /// <summary>
    /// Stop applying thrust and everything related to it
    /// </summary>
    private void StopApplyingThrust()
    {


        // player is not thrusting, end sound
        audioSource.Stop();
        mainEngineParticles.Stop();
		isThrusting = false;
    }

    /// <summary>
    /// Apply Thrust to the rocket
    /// </summary>
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


        // Spend Fuel
		SpendFuel(fuelConsumptionIncrement * Time.deltaTime);


    }

    // Reduce the fuel
    private void SpendFuel (float amount)
	{
		// Decrement by the consumption amount
		fuelCurrentValue -= amount;

	}

    /// <summary>
    /// Controlling the rotation of the ship
    /// </summary>
    public void RespondToRotateInput()
    {

        // Remove physics due to rotation
        rigidBody.angularVelocity = Vector3.zero;

        float rotationSpeed = Time.deltaTime * rotationBoost;

        // check for left tilt
        if (Input.GetKey(KeyCode.LeftArrow) || isRotatingLeft == true)
        {
            // Rotate to the left
            transform.Rotate(Vector3.forward * rotationSpeed);

        }
		else if (Input.GetKey(KeyCode.RightArrow) || isRotatingRight == true)
        {
            // Rotate to the right
            transform.Rotate(-Vector3.forward * rotationSpeed);

        }

    }


    /// <summary>
    /// Detect if rocket collides with something friendly or kill
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        // Prevent extra processing if we're dead
        if (state != State.Alive || isCollisionsDisabled == true) { return; }

        //Debug.Log("Player hit something");

        // What did we run into?
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                //print("Rocket hit a friendly: " + collision.gameObject.name);
                break;

            case "Hazard":
               // print("Rocket hit Hazard: " + collision.gameObject.name);
                StartCoroutine( PlayerDeath() );
                break;

            case "Finish":
                StartCoroutine( PlayerSuccess() );
                break;


            default:
                break;

        }


    }


    /// <summary>
    /// Handles when the player succeeds
    /// </summary>
    /// <returns>The success.</returns>
    private IEnumerator PlayerSuccess()
    {
        state = State.Transcending;

		// stop all thrust actvity
        audioSource.Stop();
        mainEngineParticles.Stop();

        // Play success sound
        audioSource.PlayOneShot(levelSuccess);

        successParticles.Play();


		yield return new WaitForSeconds(levelLoadDelay);

		SceneNavigationController.instance.LoadNextLevel();

    }


    /// <summary>
    /// Handles when the player dies
    /// </summary>
    /// <returns>The death.</returns>
    private IEnumerator PlayerDeath()
    {
        state = State.Dying;

		// stop all thrust actvity
        audioSource.Stop();
        mainEngineParticles.Stop();

        // Play explosion sound
        audioSource.PlayOneShot(explosion);

        deathParticles.Play();

		yield return new WaitForSeconds(deathLoadDelay);

		SceneNavigationController.instance.ReloadLevel();


    }


}


