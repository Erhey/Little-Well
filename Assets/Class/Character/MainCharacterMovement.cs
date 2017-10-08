using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour
{


    private bool OnFloor;
    void ControlCharacter()
    {
        /// A VOIR C'EST TRES MOCHE EN TOUT CAS ///

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            Stop_RL();
            //Debug.Log("NOOOBBOBOBOBOBBOOBBOOB");
        }
        /// A VOIR C'EST TRES MOCHE EN TOUT CAS ///


        else
        {
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                if (OnFloor)
                    Wait();
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    goRight();

                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    goLeft();
                }

            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jump();
        }


        // MODIF AUJOURDHUI
        // MODIF AUJOURDHUI

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
        // MODIF AUJOURDHUI
        // MODIF AUJOURDHUI

    }
    void goLeft()
    {
        if (this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Left.GetComponent<CheckingPoint>().StateWall == 0 &&
            this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Uppe.GetComponent<CheckingPoint>().StateWall == 0 &&
            !LevelAnimator.CurrentlyChanging)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        //ANIMATION
        if (OnFloor) { MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.RunLeft); }
        else { MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.JumpLeft); }
    }

    void goRight()
    {
        if (this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Righ.GetComponent<CheckingPoint>().StateWall == 0 &&
            this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Uppe.GetComponent<CheckingPoint>().StateWall == 0 &&
            !LevelAnimator.CurrentlyChanging)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        //ANIMATION
        if (OnFloor) { MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.RunRight); }
        else { MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.JumpRight); }
    }
    void Wait()
    {
        // ANIMATION WAIT
        if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunLeft)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitLeft);
        }
        else if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunRight)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitRight);
        }

    }
    void Stop_RL()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void GravityLimitator()
    {
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y < -8f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -8f);
        }
    }





    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI
    public void Shot()
    {
        if (GUIManager.Instance.NbrShot < 5)
        {
            if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpLeft)
            {
                GameObject NewShot = GameObject.Instantiate(GUIManager.Instance.GO_ShotLeft);
                NewShot.SetActive(true);
            }
            else
            {
                GameObject NewShot = GameObject.Instantiate(GUIManager.Instance.GO_ShotRight);
                NewShot.SetActive(true);
            }
        }
        
    }
    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI






    void jump()
    {
        // ANIMATION Jump
        if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunLeft || MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitLeft)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.JumpLeft);
        }
        else if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunRight || MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitRight)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.JumpRight);
        }
        // ANIMATION JUMP 




        if (this.OnFloor)
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0.001f);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 875));
        }
    }
    void Start()
    {  
        Physics2D.IgnoreLayerCollision(8, 8, true);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateFloorState();
        ReactiveTrigger();
        ControlCharacter();
        GravityLimitator();
        CheckDeath();
    }
    void CheckDeath()
    {
        CheckingPoint[] ChecksDeath = this.gameObject.GetComponentsInChildren<CheckingPoint>();
        foreach(CheckingPoint ChDeath in ChecksDeath)
        {
            //DEATH ANIMATION
            if (ChDeath._stateDeath != 0)
            {
                if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpLeft)
                {
                    MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.DeathLeft);





                    //Lancer la Coroutine du reset du perso
                    // MODIF AUJOURDHUI
                    // MODIF AUJOURDHUI
                    StartCoroutine(this.Died());
                    // MODIF AUJOURDHUI
                    // MODIF AUJOURDHUI




                    break;
                }
                else if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunRight ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitRight ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpRight)
                {
                    MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.DeathRight);
                    


                    // MODIF AUJOURDHUI
                    // MODIF AUJOURDHUI
                    //Lancer la Coroutine du reset du perso
                    StartCoroutine(this.Died());
                    // MODIF AUJOURDHUI
                    // MODIF AUJOURDHUI


                    break;
                }
            }
        }
    }





    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI
    public IEnumerator Died()
    {

        //Reset Death State
        CheckingPoint[] ChecksDeath = GameManager.Instance.MainCharacter.GetComponentsInChildren<CheckingPoint>();
        foreach (CheckingPoint ChDeath in ChecksDeath)
        {
            ChDeath._stateDeath = 0;
        }

        GameManager.Instance.MainCharacter.GetComponent<MainCharacterMovement>().enabled = false;
        GameManager.Instance.MainCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        // Lengh of Death Animation => has to be more dynamic if we can find the time
        yield return new WaitForSeconds(0.75f);

        if (GUIManager.Instance.NbrLife == 1)
        {

            Time.timeScale = 0;
            GameManager.Instance.GO_GameOver.SetActive(true); 
            

            //GAME OVER
        }
        else
        {
            GUIManager.Instance.NbrLife--;
            GUIManager.Instance.Combo = 0;
        }
        //Animation
        if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.DeathLeft)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitLeft);
        }
        else if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.DeathRight)
        {
            MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitRight);
        }
        else { /*Nothing*/}
        GameManager.Instance.MainCharacter.transform.position = new Vector2(8, 10);

        GameManager.Instance.MainCharacter.GetComponent<MainCharacterMovement>().enabled = true;
    }
    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI




    void ReactiveTrigger()
    {
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0 &&
            this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Cent.GetComponent<CheckingPoint>().StateWall == 0 &&
            (this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Dow1.GetComponent<CheckingPoint>().StateWall != 0 || this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Dow2.GetComponent<CheckingPoint>().StateWall != 0))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    void UpdateFloorState()
    {
        if ((this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Dow1.GetComponent<CheckingPoint>().StateWall != 0 || this.GetComponent<ColliderTriggerMainCharacterResizer>().CheckingPoints_Dow2.GetComponent<CheckingPoint>().StateWall != 0) &&
            this.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            // ANIMATION Atterissage
            if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpLeft)
            {
                MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitLeft);
            }
            else if (MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpRight)
            {
                MainCharAnimator.Instance.Activation(MainCharAnimator.TypeAnimation.WaitRight);
            }
            // ANIMATION JUMP 
            this.OnFloor = true;
        }
        else
        {
            this.OnFloor = false;
        }
    }
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.name.Substring(0, 9) == "WallLine_")
    //    {
    //        //Côté Droit
    //        if (this.WallRight.hasCollided)
    //        {
    //            Debug.Log("RIGHT");
    //            this.WallRight.isInside = true;
    //        }

    //        //Côté Gauche
    //        if (this.WallLeft.hasCollided)
    //        {
    //            Debug.Log("LEFT");
    //            this.WallLeft.isInside = true;
    //        }
    //    }
    //}
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.name.Substring(0, 9) == "WallLine_")
    //    {
    //        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
    //            this.onFloor = true;
    //    }
    //}
    //void OnCollisionStay2D(Collision2D coll)
    //{
    //    if (coll.gameObject.name.Substring(0, 9) == "WallLine_")
    //    {
    //        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
    //            this.onFloor = true;
    //    }
    //}
}
