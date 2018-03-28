using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour {

  
    // multiplier on thrust
    //[SerializeField]
    private float thrustBoost = 200.0f;

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
    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem deathParticles;

    // Load delays
    [SerializeField] float deathLoadDelay = 3.0f;
    [SerializeField] float levelLoadDelay = 2.0f;

    private bool isCollisionsDisabled = false;

    // if player runs out of thrust, explode them after 5 seconds
    private float emptyThrustExplosionDelay = 8.0f;

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
    public enum State
    {
        Alive,
        Dying,
        Transcending

    }

    public State state = State.Alive;

    private void Awake()
    {
        ApplyWorldSettings();
    }


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

            // check fuel
			if (fuelCurrentValue > 0) {

				ApplyThrust ();

			} else
            {
                // player is out of fuel
                StopApplyingThrust();
            }

        }
        else
        {
            // player is not pressing the thrust button
            StopApplyingThrust();
        }
    }

    /// <summary>
    /// Apply Thrust to the rocket
    /// </summary>
    private void ApplyThrust()
    {
        // Add force only in the direction of where its pointing (rotation)
        // Vector3.up = (0,1,0)  in the Y Axis
        rigidBody.AddRelativeForce(Vector3.up * thrustBoost * Time.deltaTime);

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

    /// <summary>
    /// Stop applying thrust and everything related to it
    /// </summary>
    private void StopApplyingThrust()
    {
        // player is not thrusting, end sound and effects
        audioSource.Stop();
        mainEngineParticles.Stop();
        isThrusting = false;
    }



    // Reduce the fuel
    private void SpendFuel (float amount)
	{
		// Decrement by the consumption amount
		fuelCurrentValue -= amount;

        if(fuelCurrentValue <= 0)
        {
            // start countdown timer to destruction.
            StartCoroutine(OutOfThrustCountdown());

        }

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

        SceneNavigationController.Instance.LoadNextLevel();
    }


    /// <summary>
    /// Handles when the player dies
    /// </summary>
    /// <returns>The death.</returns>
    private IEnumerator PlayerDeath()
    {
        // Change State to Dying
        state = State.Dying;

		// stop all thrust actvity
        audioSource.Stop();
        mainEngineParticles.Stop();

        // Play explosion sound
        audioSource.PlayOneShot(explosion);

        // Play explosion Particles
        deathParticles.Play();

        // Delay before reloading the Level
		yield return new WaitForSeconds(deathLoadDelay);

        // Reload the level
		SceneNavigationController.Instance.ReloadLevel();


    }


    /// <summary>
    /// Start a player death countdown once they run out of fuel
    /// </summary>
    /// <returns></returns>
    private IEnumerator OutOfThrustCountdown()
    {

        // Countdown till explosion!
        yield return new WaitForSeconds(emptyThrustExplosionDelay);

        // Last ditch check; They were still unable to get more fuel
        if (fuelCurrentValue <= 0)
        {
            // Player blows up
            StartCoroutine(PlayerDeath());

        }


    }


    /// <summary>
    /// Apply the world's physics settings
    /// 
    /// </summary>
    private void ApplyWorldSettings()
    {
        // TODO - Get the current world meta data settings
        WorldData worldData = FindObjectOfType<WorldData>();

        float gravitySetting = worldData.GetGravityY();

        //Debug.Log("ApplyWorldSettings(): " + gravitySetting);

        // TODO - Update Gravity
        Physics.gravity = new Vector3(0, gravitySetting, 0);

    }

    /// <summary>
    /// Method for external thing to affect the rocket
    /// </summary>
    /// <param name="forceVector"></param>
    public void ApplyOutsideForceVector(Vector3 forceVector)
    {
        Debug.Log("ApplyOutsideForceVector() called.");
        rigidBody.AddForce(forceVector);

    }


    public void MoveTowardsPoint(Vector3 target, float speed)
    {
        Debug.Log("MoveTowardsPoint() called.");
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }

}


