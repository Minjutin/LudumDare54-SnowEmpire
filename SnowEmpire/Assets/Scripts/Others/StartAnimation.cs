using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimation : MonoBehaviour
{

    [SerializeField] GameObject scene1, scene2, scene3, scene4;

    [Header("Scene 1")]
    [SerializeField] GameObject character1;
    [SerializeField] GameObject window, thoughtBubble, endPosition;

    [Header("Scene 3")]
    [SerializeField] GameObject bubbleAsk;
    [SerializeField] GameObject bubbleDotdotdot;

    [Header("Scene 4")]
    [SerializeField] GameObject bubble41;
    [SerializeField] GameObject bubble42;
    [SerializeField] GameObject bubble43;

    private void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {

        //1. PAGE
        scene1.SetActive(true);

        Vector3 starPos = character1.transform.position;
        for(float i = 0; i<1; i += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            character1.transform.position = Vector3.Lerp(starPos, endPosition.transform.position, i);
        }

        yield return new WaitForSeconds(0.5f);
        thoughtBubble.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        //SCENE 2
        scene1.SetActive(false);
        scene2.SetActive(true);

        yield return new WaitForSeconds(3f);


        //SCENE 3
        scene2.SetActive(false);
        scene3.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        bubbleAsk.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        bubbleDotdotdot.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        //SCENE 4
        scene3.SetActive(false);
        scene4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        bubble41.SetActive(true);
        yield return new WaitForSeconds(1f);
        bubble42.SetActive(true);
        yield return new WaitForSeconds(1f);
        bubble43.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Skip();
    
    }

    public void Skip()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
