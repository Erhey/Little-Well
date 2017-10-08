using UnityEngine;
using System.Collections;

public class Collision_WALL_MAINCHARACTER : MonoBehaviour
{

    //private const string COLLIDER_TOP_MAINCHARACTER = "MC_ColliderTOP";
    //private const string COLLIDER_RIGHT_MAINCHARACTER = "MC_ColliderRIGHT";
    //private const string COLLIDER_DOWN_MAINCHARACTER = "MC_ColliderDOWN";
    //private const string COLLIDER_LEFT_MAINCHARACTER = "MC_ColliderLEFT";

    //private static int CptTriggerTop = 0;
    //private static int CptTriggerRight = 0;
    //private static int CptTriggerDown = 0;
    //private static int CptTriggerLeft = 0;

    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (!LevelAnimator.CurrentlyChanging)
    //    {
    //        if (coll.gameObject.name.Contains("WallLine_") || coll.gameObject.name.Contains("WallColonne_"))
    //        {
    //            if (this.gameObject.ToString().Contains(COLLIDER_TOP_MAINCHARACTER))
    //            {
    //                CptTriggerTop++;
    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_RIGHT_MAINCHARACTER))
    //            {
    //                CptTriggerRight++;
    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_DOWN_MAINCHARACTER))
    //            {
    //                CptTriggerDown++;
    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_LEFT_MAINCHARACTER))
    //            {
    //                CptTriggerLeft++;
    //            }
    //            UpdateColliderStates();
    //        }
    //    }

    //    //Debug.Log("TOP " + CptTriggerTop + "RIGHT " + CptTriggerRight + "DOWN " + CptTriggerDown + "LEFT " + CptTriggerLeft);
    //}
    //void OnTriggerExit2D(Collider2D coll)
    //{
    //    if (!LevelAnimator.CurrentlyChanging)
    //    {

    //        if (coll.gameObject.name.Contains("WallLine_") || coll.gameObject.name.Contains("WallColonne_"))
    //        {
    //            if (this.gameObject.ToString().Contains(COLLIDER_TOP_MAINCHARACTER))
    //            {
    //                CptTriggerTop--;
    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_RIGHT_MAINCHARACTER))
    //            {
    //                CptTriggerRight--;

    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_DOWN_MAINCHARACTER))
    //            {
    //                CptTriggerDown--;
    //            }
    //            if (this.gameObject.ToString().Contains(COLLIDER_LEFT_MAINCHARACTER))
    //            {
    //                CptTriggerLeft--;
    //            }
    //            UpdateColliderStates();

    //        }

    //    }

    //    //Debug.Log("TOP " + CptTriggerTop + "RIGHT " + CptTriggerRight + "DOWN " + CptTriggerDown + "LEFT " + CptTriggerLeft);
    //}
    //void UpdateColliderStates()
    //{
    //    this.transform.parent.GetComponent<ColliderState>().Up = (CptTriggerTop != 0);
    //    this.transform.parent.GetComponent<ColliderState>().Right = (CptTriggerRight != 0);
    //    this.transform.parent.GetComponent<ColliderState>().Down = (CptTriggerDown != 0);
    //    this.transform.parent.GetComponent<ColliderState>().Left = (CptTriggerLeft != 0);
    //}
}
