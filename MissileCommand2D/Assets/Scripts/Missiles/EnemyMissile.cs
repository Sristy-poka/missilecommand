using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    float timeKeeper = 0f;
    float fracDistance = .01f;
    public float timeToIncreaseSpeed = 1f;
    //  public Vector2 targetPos;


    public int id;
    Vector2 targetPos;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        TargetVectors tVectors = GameObject.FindObjectOfType<TargetVectors>();
        int id = Random.Range(0, tVectors.targetVectors.Length);
        targetPos = tVectors.targetVectors[id].position;
    

    }

    // Update is called once per frame
    void Update()
    {



        timeKeeper += Time.deltaTime;
        if (timeKeeper > timeToIncreaseSpeed)
        {
            fracDistance += .01f;
            timeKeeper = 0f;
        }

    //   transform.position = Vector2.Lerp(transform.position, targetPos, fracDistance);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, fracDistance);
   //     transform.Translate(targetPos);


        if (Vector2.Distance(transform.position, targetPos) < 1)
        {
            //Debug.Log("2222......." + Vector2.Distance(transform.position, targetPos) + " current distance, dead status" + isDead);

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "base" || collision.gameObject.tag == "boundary")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }


    private void OnDestroy()
    {
        Debug.Log("Death position: " + transform.position);
    }

}
