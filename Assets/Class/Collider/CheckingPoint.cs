using UnityEngine;
using System.Collections;
using System;

public class CheckingPoint : MonoBehaviour {


    public  int _stateWall;
    
    public int StateWall
    { 
        get
        {
            return _stateWall;
        }
    }
    public int _stateDeath;
    public float MX,MY;

    Collider2D[] ListColl;



    void FixedUpdate()
    {
        Refresh();
        CheckWallCollision();
        CheckDeathCollision();
    }
    void Refresh()
    {
        _stateWall = 0;
        _stateDeath = 0;
        ListColl = Physics2D.OverlapPointAll(new Vector2(this.transform.position.x + MX, this.transform.position.y + MY));

    }
    void CheckWallCollision()
    {
        
        foreach (Collider2D Coll in ListColl)
        {
            if (Coll.gameObject.name.Contains("WallLine_") || Coll.gameObject.name.Contains("WallColonne_"))
            {
                _stateWall++;
            }
        }
    }

    void CheckDeathCollision()
    {
        //Debug.Log(this.gameObject.name.Substring(1, 3));
        if (this.gameObject.name.Substring(0, 3).Equals("MC_")){

            foreach (Collider2D Coll in ListColl)
            {
                if (Coll.gameObject.name.Contains("Nosfera"))
                {
                    _stateDeath++;
                }
            }

        }
    }

}
