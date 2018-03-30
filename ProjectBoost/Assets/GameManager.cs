using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    LaunchPad launchPad;
    Vector3 launchPosition;

    // Use this for initialization
    void Start()
    {
        launchPad = GameObject.FindObjectOfType<LaunchPad>();
        launchPosition = launchPad.transform.position + new Vector3(launchPosition.x, 3, launchPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        var oldRocket = GameObject.FindObjectOfType<RocketController>();
        Destroy(oldRocket.gameObject);
        Instantiate(rocketPrefab, launchPosition, Quaternion.identity);

    }
}
