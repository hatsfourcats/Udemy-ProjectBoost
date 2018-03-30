using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] float followDistanceX = 2f;
    [SerializeField] float followDistanceY = 20f;

    Transform playerTransform;
    Vector3 playerPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform)
        {
            playerPosition = playerTransform.position;
            transform.position = new Vector3(playerPosition.x + followDistanceX, playerPosition.y + followDistanceY, transform.position.z);

        }
        else
        {


            Debug.LogFormat("No player present for camera to follow.");
        }


    }


}
