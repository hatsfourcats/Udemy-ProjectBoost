using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    List<string> playableLevels = new List<string>();

    IEnumerator FadeToMainMenu()
    {

        yield return new WaitForSecondsRealtime(2f);

        LoadNextLevel();
    }

    // Use this for initialization
    void Start()
    {
        playableLevels.Add("Level1");
        playableLevels.Add("Level2");

        DontDestroyOnLoad(this);
        StartCoroutine(FadeToMainMenu());

    }


    public void LoadNextLevel()
    {
        var currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentLevelIndex + 1);

    }
}
