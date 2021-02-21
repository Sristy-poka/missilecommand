using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float timeKeeper = 0f;
    float fracDistance = .01f;
    public float timeToIncreaseSpeed = .04f;
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
        targetPos = MissileControl.TargetPos;

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

        transform.position = Vector2.Lerp(transform.position, targetPos, fracDistance);



        if (Vector2.Distance(transform.position, targetPos) < 1 && !isDead)
        {
            //Debug.Log("2222......." + Vector2.Distance(transform.position, targetPos) + " current distance, dead status" + isDead);
            isDead = true;
            StartCoroutine(OnDeath());
        }

    }

    IEnumerator OnDeath()
    {
        //Debug.Log(Vector2.Distance(transform.position, targetPos) + " current distancedead status" + isDead);
        GetComponent<Animator>().SetTrigger("dead");
        yield return new WaitForSeconds(0.29f);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyMissile")
        {
            Destroy(collision.gameObject);
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore();
                Destroy(gameObject);
            }
        }
    }
}
