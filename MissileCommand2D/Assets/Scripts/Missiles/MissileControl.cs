using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public Transform[] MissileBases;
    public static Vector2 TargetPos;

    public GameObject missilePrefab;

    public Vector2 OriginPosition(Vector3 _targetPos)
    {
        float dist = 9999f;
        int id = 0;
        for(int i = 0; i<MissileBases.Length;i++)
        {
            if (MissileBases[i].gameObject.activeInHierarchy)
            {
                float missileXpos = MissileBases[i].position.x - _targetPos.x;
                if (Mathf.Abs(missileXpos) < dist)
                {
                    dist = missileXpos;
                    id = i;
                }
            }
        }

        return MissileBases[id].position;
       
    }


    public void ShootMissile(Vector2 targetPos)
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(missilePrefab, MissileBases[0].position, Quaternion.identity);
            //MissilePool.instance.RequestMissile(MissilePool.instance.ThisID, OriginPosition(Input.mousePosition), Input.mousePosition);
            
        }
    }
}
