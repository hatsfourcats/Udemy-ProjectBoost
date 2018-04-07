using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 75f;
    [SerializeField]
    float thrustAmount = 10f;

    [SerializeField]
    int maxFuel = 600;

    int currentFuel;
    [SerializeField] int fuelBurnPerFrame = 1;



    Rigidbody rigidBody;
    AudioSource engineSound;

    GameManager gameManager;

    public int CurrentFuel
    {
        get
        {
            return currentFuel;
        }

        set
        {

        }
    }


    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        currentFuel = maxFuel;
    }

    // Update is called once per frame



    void Update()
    {

        ProcessInput();

    }


    void ProcessInput()
    {
        Thrust();
        Rotate();

    }


    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag.Contains("Fatal"))
        {
            gameManager.ResetPlayer();


        }

        if (trigger.tag.Contains("Exit"))
        {

            Debug.LogFormat("Reached exit pad yay :");
        }


    }

    void Thrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentFuel > 0)
            {

                rigidBody.AddRelativeForce(Vector3.up * thrustAmount);

                if (!engineSound.isPlaying) { engineSound.Play(); } // TODO: figure out why this is popping every ~loop

                engineSound.DOFade(1, 1);
                currentFuel -= fuelBurnPerFrame;
            }
            else { Debug.LogFormat("Current fuel is less than 0 : {0}", currentFuel); }

        }

        else
        {
            engineSound.DOFade(0, 1f);
        }


    }

    void Rotate()
    {
        float rotationAmount = Time.deltaTime * rotationSpeed;
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationAmount);

        }

        rigidBody.freezeRotation = false;
    }
}

