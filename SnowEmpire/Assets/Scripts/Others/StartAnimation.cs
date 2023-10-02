using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{

    [SerializeField] GameObject scene1, scene2, scene3, scene4;

    [Header("Scene 1")]
    [SerializeField] GameObject character1;
    [SerializeField] GameObject window, thoughtBubble, endPosition;

    [Header("Scene 2")]
    [SerializeField] GameObject character2;

    private void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {

        //FIRST PAGE

        Vector3 starPos = character1.transform.position;
        for(float i = 0; i<1; i += Time.deltaTime/2)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            character1.transform.position = Vector3.Lerp(starPos, endPosition.transform.position, i);
        }

        yield return new WaitForSeconds(1f);
        thoughtBubble.SetActive(true);
        yield return new WaitForSeconds(2f);
    }


}
