using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPadController : MonoBehaviour {


    private Animator animator;

    [SerializeField] private GameObject finishPad;

    // Use this for initialization
    void Start()
    {
        // 
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Display the landing pad
    /// </summary>
    public void DisplayLandingPad()
    {

        // Enable it
        EnableLandingPad();

        // Fade it in
        animator.Play("FadeIn");

    }


    public void HideLandingPad()
    {
        // Animate it out
        animator.Play("FadeOut");

    }


    public void EnableLandingPad()
    {

        // disable it
        finishPad.SetActive(true);

    }


    public void DisableLandingPad()
    {

        // disable it
        finishPad.SetActive(false);

    }

}
