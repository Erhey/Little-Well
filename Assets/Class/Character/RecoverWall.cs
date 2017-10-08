using UnityEngine;
using System.Collections;

public class RecoverWall : MonoBehaviour {

	//void Update () {
 //       Recovering();
 //   }
 //   void Recovering() {
 //            if (!GameManager.Instance.MainCharacter.gameObject.GetComponent<ColliderState>().Down || GameManager.Instance.MainCharacter.gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
 //       {
 //           object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
 //           foreach (object o in obj)
 //           {
 //               GameObject g = (GameObject)o;
 //               if (g.name.Contains("WallLine_") || g.name.Contains("WallColonne_"))
 //               {
 //                   float myPosY = this.gameObject.transform.parent.position.y + this.gameObject.GetComponent<BoxCollider2D>().offset.y * this.gameObject.transform.parent.localScale.y;
 //                   float wallPosYTOP = g.transform.position.y + g.GetComponent<BoxCollider2D>().size.y / 2;
                    
 //                   if (myPosY > wallPosYTOP && (!GameManager.Instance.MainCharacter.gameObject.GetComponent<ColliderState>().Left || !GameManager.Instance.MainCharacter.gameObject.GetComponent<ColliderState>().Right))
 //                   {
 //                       //if (g.name == ("WallLine_11_3to9"))
 //                       //Debug.Log(!GameManager.Instance.MainCharacter.gameObject.GetComponent<MainCharacterMovement>().WallLeft.hasCollided + "  " + !GameManager.Instance.MainCharacter.gameObject.GetComponent<MainCharacterMovement>().WallRight.hasCollided);
 //                       g.GetComponent<BoxCollider2D>().isTrigger = false;
 //                   }
 //               }
 //           }
 //       }
   
 //   }
}
