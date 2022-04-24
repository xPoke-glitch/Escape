using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitText : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BackToMenu(5.0f));
    }

    private IEnumerator BackToMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu");
    }
}
