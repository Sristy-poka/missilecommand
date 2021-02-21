using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePool : MonoBehaviour
{
    public static MissilePool instance;
    public List<GameObject> missiles;

    int thisID;
    public int ThisID
    {
        get
        {
            return thisID;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void RequestMissile(int _thisID, Vector2 pos, Vector2 targetPos)
    {
        
        if (missiles != null) {

            if (_thisID == missiles.Count)
            {
                _thisID = 0;
            }
            
        }
        else
        {
            Debug.Log("Missle list empty");
        }

        GameObject newMissile = missiles[_thisID].gameObject;
        newMissile.transform.position = pos;
//        newMissile.GetComponent<Missile>().targetPos = targetPos;
        newMissile.gameObject.SetActive(true);

        thisID = _thisID;
        thisID++;

       
    }

    public void GetBackMissile(GameObject ReturnedMissile)
    {
      
        ReturnedMissile.transform.position = transform.position;
        ReturnedMissile.gameObject.SetActive(false);
    }
}
