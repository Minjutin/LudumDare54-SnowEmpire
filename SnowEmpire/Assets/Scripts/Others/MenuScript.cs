using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(ClickAndStart());
    }

    IEnumerator ClickAndStart()
    {
        FindObjectOfType<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MainScene");
    }
}
