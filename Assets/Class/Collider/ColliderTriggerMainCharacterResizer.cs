using UnityEngine;
using System.Collections;

public class ColliderTriggerMainCharacterResizer : MonoBehaviour {


    public GameObject CheckPointSample;

    public GameObject CheckingPoints_Dow1;
    public GameObject CheckingPoints_Dow2;
    public GameObject CheckingPoints_Cent;
    public GameObject CheckingPoints_Left;
    public GameObject CheckingPoints_Righ;
    public GameObject CheckingPoints_Uppe;
    void Start()
    {
        InstantiateCheckingPoints();

    }

    void InstantiateCheckingPoints()
    {

        // Création Checking Points
            CheckingPoints_Dow1 = GameObject.Instantiate(CheckPointSample);
            CheckingPoints_Dow2 = GameObject.Instantiate(CheckPointSample);
            CheckingPoints_Cent = GameObject.Instantiate(CheckPointSample);
            CheckingPoints_Left = GameObject.Instantiate(CheckPointSample);
            CheckingPoints_Righ = GameObject.Instantiate(CheckPointSample);
            CheckingPoints_Uppe = GameObject.Instantiate(CheckPointSample);

        // Nomination Des Checking Point
            CheckingPoints_Dow1.name = "MC_CheckingPoints_Dow1";
            CheckingPoints_Dow2.name = "MC_CheckingPoints_Dow2";
            CheckingPoints_Cent.name = "MC_CheckingPoints_Cent";
            CheckingPoints_Left.name = "MC_CheckingPoints_Left";
            CheckingPoints_Righ.name = "MC_CheckingPoints_Righ";
            CheckingPoints_Uppe.name = "MC_CheckingPoints_Uppe";

        // Setting Du Parent
            CheckingPoints_Dow1.transform.SetParent(this.transform, false);
            CheckingPoints_Dow2.transform.SetParent(this.transform, false);
            CheckingPoints_Cent.transform.SetParent(this.transform, false);
            CheckingPoints_Left.transform.SetParent(this.transform, false);
            CheckingPoints_Righ.transform.SetParent(this.transform, false);
            CheckingPoints_Uppe.transform.SetParent(this.transform, false);


        // Setting Des positions des Checkings Points
            CheckingPoints_Dow1.GetComponent<CheckingPoint>().MX = -0.35f;
            CheckingPoints_Dow1.GetComponent<CheckingPoint>().MY = -1.5f;

            CheckingPoints_Dow2.GetComponent<CheckingPoint>().MX = 0.35f;
            CheckingPoints_Dow2.GetComponent<CheckingPoint>().MY = -1.5f;

            CheckingPoints_Cent.GetComponent<CheckingPoint>().MX = 0;
            CheckingPoints_Cent.GetComponent<CheckingPoint>().MY = -0.65f;

            CheckingPoints_Left.GetComponent<CheckingPoint>().MX = -0.35f;
            CheckingPoints_Left.GetComponent<CheckingPoint>().MY = -0.65f;

            CheckingPoints_Righ.GetComponent<CheckingPoint>().MX = 0.35f;
            CheckingPoints_Righ.GetComponent<CheckingPoint>().MY = -0.65f;

            CheckingPoints_Uppe.GetComponent<CheckingPoint>().MX = 0;
            CheckingPoints_Uppe.GetComponent<CheckingPoint>().MY = -0.25f;

    }

    //public const int PX_UNIT = 100;

    //void Start()
    //{
    //    IMG_Resizer(0.3f, 0.3f);
    //    // WIDTH & HEIGHT Entre -1 et 1 !!!!
    //    COL_Position(0, -0.7f);
    //}


    //public void IMG_Resizer(float widthPercent, float heightPercent)
    //{
    //    if (this.gameObject.name == "MainCharacter" || this.gameObject.name.Contains("Monster"))
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)((this.gameObject.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT)) * widthPercent, (float)((this.gameObject.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent);

    //    }
    //    else if (this.gameObject.name == "MC_ColliderTOP")
    //    {
    //        //SIZE
    //        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT)) * widthPercent * 0.9f, (float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent); // * 1Xf => Ligne suivante * 0.5Xf
    //        //Position
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, (float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderDOWN")
    //    {
    //        //SIZE
    //        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT)) * widthPercent * 0.9f, (float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent * 0.03f);
    //        //Position
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -(float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent * 0.515f);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderRIGHT")
    //    {
    //        //SIZE
    //        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT)) * widthPercent * 0.1f, (float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent * 0.95f);
    //        //Position
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * widthPercent * 0.55f, 0f);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderLEFT")
    //    {
    //        //SIZE
    //        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT)) * widthPercent * 0.1f, (float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * heightPercent * 0.95f);
    //        //Position
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-(float)((this.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.height) / (float)(PX_UNIT)) * widthPercent * 0.55f, 0f);

    //    }
    //}

    //// WIDTH & HEIGHT Entre -1 et 1
    //public void COL_Position(float widthPercent, float heightPercent)
    //{
    //    float nbrSquare;
    //    if (this.gameObject.name == "MainCharacter")
    //    {
    //        nbrSquare = (float)((this.gameObject.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT));
    //    }
    //    else
    //    {
    //        nbrSquare = (float)((this.transform.parent.GetComponent<SpriteRenderer>().sprite.rect.width) / (float)(PX_UNIT));
    //    }
    //    widthPercent = (widthPercent * nbrSquare) / 2f;
    //    heightPercent = (heightPercent * nbrSquare)/ 2f;


    //    if (this.gameObject.name == "MainCharacter")
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(widthPercent, heightPercent);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderTOP")
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(widthPercent, this.gameObject.GetComponent<BoxCollider2D>().offset.y + heightPercent);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderDOWN")
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(widthPercent, this.gameObject.GetComponent<BoxCollider2D>().offset.y + heightPercent);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderRIGHT")
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(this.gameObject.GetComponent<BoxCollider2D>().offset.x + widthPercent,  heightPercent);
    //    }
    //    else if (this.gameObject.name == "MC_ColliderLEFT")
    //    {
    //        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(this.gameObject.GetComponent<BoxCollider2D>().offset.x + widthPercent,  heightPercent);
    //    }
    //}
}
