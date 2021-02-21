
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMissileController : MonoBehaviour
{
    public float maxTimeRange = 1f;
    public float minTimeRange = 0.4f;

    public GameObject enemyMissile;



    public static Vector2 targetPos;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (!GameManager.instance.gameOver)
        {
         
           
            Instantiate(enemyMissile, transform.position, Quaternion.identity);
            float timeForNextSpawn = Random.Range(minTimeRange, maxTimeRange);
            yield return new WaitForSeconds(timeForNextSpawn);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
