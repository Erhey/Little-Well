using UnityEngine;
using System.Collections;

public class ClassicChangeBehavior : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "MainCharacter")
        {
            // MODIF AUJOURDHUI
            // MODIF AUJOURDHUI
            if (LevelManager.Instance.LevelIsCompleted[LevelManager.Instance.CurrentLevel])
            {
            // MODIF AUJOURDHUI
            // MODIF AUJOURDHUI




                if (!LevelAnimator.CurrentlyChanging)
                {
                    LevelAnimator.CurrentlyChanging = true;
                    LevelAnimator.ChangeLevel(LevelManager.Instance.CurrentLevel, LevelManager.Instance.CurrentLevel + 1, GameManager.Direction.Down);
                }
            }





            // MODIF AUJOURDHUI
            // MODIF AUJOURDHUI
            else
            {
                StartCoroutine(GameManager.Instance.MainCharacter.GetComponent<MainCharacterMovement>().Died());
            }
            // MODIF AUJOURDHUI
            // MODIF AUJOURDHUI
        }
    }
}