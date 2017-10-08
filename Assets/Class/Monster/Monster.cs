using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    



    protected MonsterManager.TypeTriggerMonster Type;
    protected int IDMonster;
    protected int[,] positionGeneration;
    public float speed; 
    private float upsetValue;
    private GameObject[,] MAT_CheckingPoints;
    public MonsterManager.TypeTriggerMonster getTypeMonster()
    {
        return Type;
    }
    
    protected void MonsterMouvement(MonsterManager.TypeTriggerMonster T)
    {
        switch (Type)
        {
            case MonsterManager.TypeTriggerMonster.basic:
                StartCoroutine(MoveBasic());
                break;
            case MonsterManager.TypeTriggerMonster.jumpBasic:
                StartCoroutine(MoveJumpBasic());
                break;
            default:
                break;
        }

              

    }
    protected IEnumerator MoveBasic()
    {

        yield return new WaitForSeconds(0.001f);
        upsetValue = 1;
        speed = (0.1f * ((float)((int)(2f * Random.value)) - 0.5f));

        this.MAT_CheckingPoints = this.GetComponent<MonsterTriggerCreator>().Matrix_CheckingPoints;
        while (true)
        {
            if (/*It Falls*/Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) >= 0.1f)
            {
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                if (this.MAT_CheckingPoints[1, 1].GetComponent<CheckingPoint>().StateWall != 0)
                {
                    speed = 0.05f;
                }
                if (this.MAT_CheckingPoints[3, 1].GetComponent<CheckingPoint>().StateWall != 0)
                {
                    speed = -0.05f;
                }


                if (this.MAT_CheckingPoints[2, 0].GetComponent<CheckingPoint>().StateWall == 0)
                {
                    speed = 0.05f;
                }
                if (this.MAT_CheckingPoints[2, 1].GetComponent<CheckingPoint>().StateWall == 0)
                {
                    speed = -0.05f;
                }


                //Debug.Log("Vitesse : " + vitesse);
                this.transform.position = new Vector2(this.transform.position.x + (speed * upsetValue), this.transform.position.y);
                //if (upsetValue < 4)
                //{
                //    upsetValue += 0.01f;
                //}
                yield return new WaitForSeconds(0.001f);
            }
        }


    }
    protected IEnumerator MoveJumpBasic()
    {
        yield return new WaitForSeconds(0.001f);
        upsetValue = 1;
        speed = (0.1f * ((float)((int)(2f * Random.value)) - 0.5f));

        this.MAT_CheckingPoints = this.GetComponent<MonsterTriggerCreator>().Matrix_CheckingPoints;
        while (true)
        {
            if (/*It Falls*/Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) >= 0.4f)
            {
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                if (this.MAT_CheckingPoints[1, 1].GetComponent<CheckingPoint>().StateWall != 0)
                {
                    speed = 0.05f;
                }
                if (this.MAT_CheckingPoints[3, 1].GetComponent<CheckingPoint>().StateWall != 0)
                {
                    speed = -0.05f;
                }


                if (this.MAT_CheckingPoints[2, 0].GetComponent<CheckingPoint>().StateWall == 0)
                {
                    if (speed == -0.05f && this.MAT_CheckingPoints[0, 0].GetComponent<CheckingPoint>().StateWall != 0 && this.MAT_CheckingPoints[0, 1].GetComponent<CheckingPoint>().StateWall == 0)
                    {
                        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 500));
                        yield return new WaitForSeconds(0.5f);
                    }
                    else
                    {
                        speed = 0.05f;
                    }
                    //ANIM JUMP
                }
                if (this.MAT_CheckingPoints[2, 1].GetComponent<CheckingPoint>().StateWall == 0)
                {
                    if (speed == 0.05f && this.MAT_CheckingPoints[4, 0].GetComponent<CheckingPoint>().StateWall != 0 && this.MAT_CheckingPoints[4, 1].GetComponent<CheckingPoint>().StateWall == 0)
                    {
                        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 500));
                        yield return new WaitForSeconds(0.5f);
                    }
                    else
                    {
                        speed = -0.05f;
                    }
                    //ANIM JUMP
                }
                this.transform.position = new Vector2(this.transform.position.x + (speed * upsetValue), this.transform.position.y);
                if (upsetValue < 4)
                {
                    //upsetValue += 0.01f;
                }
                yield return new WaitForSeconds(0.001f);
            }
        }
    }

    public void DestroyMonster()
    {
        foreach (Monster M in MonsterManager.Instance.Monsters)               // parcours de la list
        {
            if (this.IDMonster == M.IDMonster)
            {
                MonsterManager.Instance.Monsters.Remove(M);
                Destroy(this.gameObject);
                break;
            }
        }
    }
   


}
