using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    public IEnumerator Shoot()
    {
        GameObject snowBall = Instantiate(GameManager.GM.AttackM.snowballPrefab, new Vector3(-17, 0, 0), Quaternion.identity);

        float startTime = Random.Range(0.1f, 1.2f);
        yield return new WaitForSeconds(startTime);

        while (GameManager.GM.currentMode == GameManager.Mode.ATTACK)
        {

            snowBall.transform.position = this.gameObject.transform.position;


            for (float i = 0; i < 1; i += Time.deltaTime / 1)
            {
                yield return new WaitForSeconds(Time.deltaTime);

                snowBall.transform.position = Bezier(i, this.transform.position,
                                                this.transform.position + (GameManager.GM.AttackM.bully.transform.position - this.transform.position) / 2
                                                + new Vector3(0,4,0),
                                                GameManager.GM.AttackM.bully.transform.position);
            }

            snowBall.transform.position = new Vector3(-17, 0, 0);
            yield return new WaitForSeconds(0.2f);

        }

        
    }

    public Vector2 Bezier(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }
}
