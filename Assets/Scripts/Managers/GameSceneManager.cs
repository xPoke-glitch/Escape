using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameSceneManager : Singleton<GameSceneManager>
{
    [SerializeField]
    private GameObject transition;

    public void ChangeScene(string sceneName)
    {
        transition.GetComponent<Animator>().SetTrigger("OpenTransition");
        StartCoroutine(WaitForAction(1.5f, () =>
        {
            SceneManager.LoadScene(sceneName);
        }));
    }

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        transition.GetComponent<Animator>().SetTrigger("OpenTransition");
        StartCoroutine(WaitForAction(1.5f, () =>
        {
            // TO-DO: change game scene name later
            SceneManager.LoadScene("Level_1");
        }));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        Player.OnDamage += ResetLevel;
        Player.OnGameOver += OpenGameOver;
    }

    private void OnDisable()
    {
        Player.OnDamage -= ResetLevel;
        Player.OnGameOver -= OpenGameOver;
    }

    private void ResetLevel()
    {
        transition.GetComponent<Animator>().SetTrigger("OpenTransition");
        StartCoroutine(WaitForAction(1.5f, () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }));
    }

    private void OpenGameOver()
    {
        transition.GetComponent<Animator>().SetTrigger("OpenGameOver");
    }

    private IEnumerator WaitForAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

}
