using UnityEngine;
using System.Collections;

public class MonsterTriggerCreator : MonoBehaviour {
    
    public GameObject TriggerMonster;

    public GameObject[,] Matrix_CheckingPoints;
    //GameObject TRI_TOPR;
    //GameObject TRI_BOTL;
    //GameObject TRI_BOTR;
    //GameObject TRI_RIGH;
    //GameObject TRI_LEFT;

    void Start()
    {
        InstantiateCheckingPoints();

        Activation(this.GetComponent<Monster>().getTypeMonster());
    }

    void InstantiateCheckingPoints()
    {

        Matrix_CheckingPoints = new GameObject[5, 4];

        for (int i = 0; i < 5; i++)
        {
            for(int j = 0; j<4; j++)
            {
                // **************     Initiation MATRIX     **************
                    Matrix_CheckingPoints[i, j] = GameObject.Instantiate(TriggerMonster);

                // **************       SETTING NAMES       **************
                    Matrix_CheckingPoints[i, j].name = "MR_CheckingPoint["+ i +", " + j + "]";


                // **************       SETTING PARENTS       **************
                    Matrix_CheckingPoints[i,j].transform.SetParent(this.transform, false);
            }
        }
        // **************       SETTING POSITIONS VECTORS       **************
        SetPosMatVect();
    }




    public void SetPosMatVect()
    {
        //*************SETTING Positions*******************
            Matrix_CheckingPoints[0, 0].GetComponent<CheckingPoint>().MX = -1.5f;
            Matrix_CheckingPoints[0, 0].GetComponent<CheckingPoint>().MY = -1;

            Matrix_CheckingPoints[0, 1].GetComponent<CheckingPoint>().MX = -1.5f;
            Matrix_CheckingPoints[0, 1].GetComponent<CheckingPoint>().MY = 0;

            Matrix_CheckingPoints[0, 2].GetComponent<CheckingPoint>().MX = -1.5f;
            Matrix_CheckingPoints[0, 2].GetComponent<CheckingPoint>().MY = 1;

            Matrix_CheckingPoints[0, 3].GetComponent<CheckingPoint>().MX = -1.5f;
            Matrix_CheckingPoints[0, 3].GetComponent<CheckingPoint>().MY = 2;

            Matrix_CheckingPoints[1, 0].GetComponent<CheckingPoint>().MX = -0.5f;
            Matrix_CheckingPoints[1, 0].GetComponent<CheckingPoint>().MY = -1;

            Matrix_CheckingPoints[1, 1].GetComponent<CheckingPoint>().MX = -0.5f;
            Matrix_CheckingPoints[1, 1].GetComponent<CheckingPoint>().MY = 0;

            Matrix_CheckingPoints[1, 2].GetComponent<CheckingPoint>().MX = -0.5f;
            Matrix_CheckingPoints[1, 2].GetComponent<CheckingPoint>().MY = 1;

            Matrix_CheckingPoints[1, 3].GetComponent<CheckingPoint>().MX = -0.5f;
            Matrix_CheckingPoints[1, 3].GetComponent<CheckingPoint>().MY = 2;

            /*Special Behavior*/
                Matrix_CheckingPoints[2, 0].GetComponent<CheckingPoint>().MX = -0.25f;
                Matrix_CheckingPoints[2, 0].GetComponent<CheckingPoint>().MY = -1;

                Matrix_CheckingPoints[2, 1].GetComponent<CheckingPoint>().MX = 0.25f;
                Matrix_CheckingPoints[2, 1].GetComponent<CheckingPoint>().MY = -1;
            /*Special Behavior*/

            Matrix_CheckingPoints[2, 2].GetComponent<CheckingPoint>().MX = 0;
            Matrix_CheckingPoints[2, 2].GetComponent<CheckingPoint>().MY = 1;

            Matrix_CheckingPoints[2, 3].GetComponent<CheckingPoint>().MX = 0;
            Matrix_CheckingPoints[2, 3].GetComponent<CheckingPoint>().MY = 2;

            Matrix_CheckingPoints[3, 0].GetComponent<CheckingPoint>().MX = 0.5f;
            Matrix_CheckingPoints[3, 0].GetComponent<CheckingPoint>().MY = -1;

            Matrix_CheckingPoints[3, 1].GetComponent<CheckingPoint>().MX = 0.5f;
            Matrix_CheckingPoints[3, 1].GetComponent<CheckingPoint>().MY = 0;

            Matrix_CheckingPoints[3, 2].GetComponent<CheckingPoint>().MX = 0.5f;
            Matrix_CheckingPoints[3, 2].GetComponent<CheckingPoint>().MY = 1;

            Matrix_CheckingPoints[3, 3].GetComponent<CheckingPoint>().MX = 0.5f;
            Matrix_CheckingPoints[3, 3].GetComponent<CheckingPoint>().MY = 2;

            Matrix_CheckingPoints[4, 0].GetComponent<CheckingPoint>().MX = 1.5f;
            Matrix_CheckingPoints[4, 0].GetComponent<CheckingPoint>().MY = -1;

            Matrix_CheckingPoints[4, 1].GetComponent<CheckingPoint>().MX = 1.5f;
            Matrix_CheckingPoints[4, 1].GetComponent<CheckingPoint>().MY = 0;

            Matrix_CheckingPoints[4, 2].GetComponent<CheckingPoint>().MX = 1.5f;
            Matrix_CheckingPoints[4, 2].GetComponent<CheckingPoint>().MY = 1;

            Matrix_CheckingPoints[4, 3].GetComponent<CheckingPoint>().MX = 1.5f;
            Matrix_CheckingPoints[4, 3].GetComponent<CheckingPoint>().MY = 2;

    }
    public void Activation(MonsterManager.TypeTriggerMonster Type)
    {
        switch (Type)
        {
            case MonsterManager.TypeTriggerMonster.basic:

                //X = 0
                Matrix_CheckingPoints[0, 0].SetActive(false);
                Matrix_CheckingPoints[0, 1].SetActive(false);
                Matrix_CheckingPoints[0, 2].SetActive(false);
                Matrix_CheckingPoints[0, 3].SetActive(false);

                //X = 1
                Matrix_CheckingPoints[1, 0].SetActive(false);
                Matrix_CheckingPoints[1, 2].SetActive(false);
                Matrix_CheckingPoints[1, 3].SetActive(false);

                //X = 2
                Matrix_CheckingPoints[2, 2].SetActive(false);
                Matrix_CheckingPoints[2, 3].SetActive(false);

                //X = 3
                Matrix_CheckingPoints[3, 0].SetActive(false);
                Matrix_CheckingPoints[3, 2].SetActive(false);
                Matrix_CheckingPoints[3, 3].SetActive(false);

                //X = 4
                Matrix_CheckingPoints[4, 0].SetActive(false);
                Matrix_CheckingPoints[4, 1].SetActive(false);
                Matrix_CheckingPoints[4, 2].SetActive(false);
                Matrix_CheckingPoints[4, 3].SetActive(false);

                break;
            case MonsterManager.TypeTriggerMonster.jumpBasic:
                //X = 0
                Matrix_CheckingPoints[0, 2].SetActive(false);
                Matrix_CheckingPoints[0, 3].SetActive(false);

                //X = 1
                Matrix_CheckingPoints[1, 2].SetActive(false);
                Matrix_CheckingPoints[1, 3].SetActive(false);

                //X = 2
                Matrix_CheckingPoints[2, 2].SetActive(false);
                Matrix_CheckingPoints[2, 3].SetActive(false);

                //X = 3
                Matrix_CheckingPoints[3, 2].SetActive(false);
                Matrix_CheckingPoints[3, 3].SetActive(false);

                //X = 4
                Matrix_CheckingPoints[4, 2].SetActive(false);
                Matrix_CheckingPoints[4, 3].SetActive(false);
                break;
            default:
                break;
        }
    }
}
