using UnityEngine;
using System.Collections;

public class PortalBehavior : MonoBehaviour
{
    public CaracteristicPortal Portal;
    void OnTriggerEnter2D(Collider2D coll)
    {

        // MODIF AUJOURDHUI
        // MODIF AUJOURDHUI
        if (LevelManager.Instance.LevelIsCompleted[LevelManager.Instance.CurrentLevel]) {
        // MODIF AUJOURDHUI
        // MODIF AUJOURDHUI



            if (coll.gameObject.name == "MainCharacter")
            {
                LevelAnimator.CurrentlyChanging = true;
                LevelAnimator.ChangeLevel(Portal.originLevelNum, Portal.destinationLevelNum, Portal.animChgLvlDir);
            }
        }
    }
}
