using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    LaunchPad launchPad;
    Vector3 launchPosition;
    public Text fuelValueText;
    RocketController rocketController;
    LevelManager levelManager;


    // Use this for initialization
    void Start()
    {
        launchPad = GameObject.FindObjectOfType<LaunchPad>();
        launchPosition = launchPad.transform.position + new Vector3(launchPosition.x, 3, launchPosition.z);
        rocketController = GameObject.FindObjectOfType<RocketController>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResetPlayer();
        }
        fuelValueText.text = rocketController.CurrentFuel.ToString();
    }

    public void ResetPlayer()
    {
        var oldRocket = GameObject.FindObjectOfType<RocketController>();
        Destroy(oldRocket.gameObject);
        var newPlayer = Instantiate(rocketPrefab, launchPosition, Quaternion.identity);
        rocketController = newPlayer.GetComponent<RocketController>();
    }

    public void GoNextLevel()
    {
        levelManager.LoadNextLevel();

    }

}
