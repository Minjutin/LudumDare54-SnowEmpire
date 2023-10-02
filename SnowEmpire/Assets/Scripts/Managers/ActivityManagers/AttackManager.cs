using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]GameObject bully;

    [SerializeField] float secondsToKill;

    // Start is called before the first frame update
    public void LaunchAttackMode()
    {
        GameManager.GM.UIM.LaunchAttackUI();
       
        GameManager.GM.currentMode = GameManager.Mode.ATTACK;

        FindObjectOfType<ChangeModeViaButtons>().modeText.text = "";


        //Shut down every tile. 
        foreach (KeyValuePair<(int, int), Tile> tile in GameManager.GM.GridM.tileGrid)
        {
            tile.Value.EnablePrice(false);
            tile.Value.EnableCanBeTunneled(false);
        }

        StartCoroutine(Launch());
    }

   IEnumerator Launch()
   {
        Vector3 bullyStartPos = bully.transform.position;

        for(float i = 0; i < 1; i=i+Time.deltaTime/secondsToKill)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            bully.transform.position = new Vector3(Mathf.Lerp(bullyStartPos.x, GameManager.GM.PlayerM.playerPos.x, i), bullyStartPos.y, 0);
        }

   }
}
