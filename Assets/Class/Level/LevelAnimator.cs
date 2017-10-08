using UnityEngine;
using System.Collections;

public class LevelAnimator : MonoBehaviour {
    public static bool CurrentlyChanging = false;
    public static void ChangeLevel(int Origine, int Destination, GameManager.Direction Direction)
    {
        if (Direction != GameManager.Direction.other)
        {

            // Suppression des Ennemis Restants sur le niveau actuel
            MonsterManager.Instance.Monsters.Clear();

            // Creation du level
            CreateLevel(Destination, Direction);

            // Animation du changement de Level
            GameManager.Instance.gameObject.GetComponent<GameManager>().StartCoroutine(LevelAnimator.AnimationSlideLevel(Origine, Destination, Direction, 0.25f));

            // Creation des monstres et objets du nouveau Level
            // MonsterAndObjectCreation(Portal.destinationLevelNum)
        }

    }

    static void CreateLevel(int numLevel, GameManager.Direction dir)
    {

        GameManager.Instance.LGSwitcher.generateLevel(LevelManager.Instance.levels[numLevel]);
        GameManager.Instance.LGSwitcher.MoveLevel(dir, numLevel);

    }

    static IEnumerator AnimationSlideLevel(int origine, int destination, GameManager.Direction dir, float Time)
    {
        yield return new WaitForSeconds(0.001f);


        GameManager.Instance.MainCharacter.SetActive(false);
        //AnimatorManager.Instance.Desactivation();
        //GameManager.Instance.MainCharacter.GetComponent<Rigidbody2D>().isKinematic = true;

        switch (dir)
        {
            case GameManager.Direction.Up:
                //v1
                for (int i = 0; i < 40; i++)
                {
                    GameManager.Instance.MainParentLevel.transform.position = new Vector3(GameManager.Instance.MainParentLevel.transform.position.x, GameManager.Instance.MainParentLevel.transform.position.y - 0.75f, GameManager.Instance.MainParentLevel.transform.position.z);
                    yield return new WaitForSeconds(Time / 40);
                }
                GameManager.Instance.MainCharacter.transform.position = new Vector3(GameManager.Instance.MainCharacter.transform.position.x, -15, GameManager.Instance.MainCharacter.transform.position.z);

                break;
            case GameManager.Direction.Right:
                //v1
                for (int i = 0; i < 40; i++)
                {
                    GameManager.Instance.MainParentLevel.transform.position = new Vector3(GameManager.Instance.MainParentLevel.transform.position.x - 0.5f, GameManager.Instance.MainParentLevel.transform.position.y, GameManager.Instance.MainParentLevel.transform.position.z);
                    yield return new WaitForSeconds(Time / 40);
                }
                GameManager.Instance.MainCharacter.transform.position = new Vector3(-8.5f, GameManager.Instance.MainCharacter.transform.position.y, GameManager.Instance.MainCharacter.transform.position.z);
                break;
            case GameManager.Direction.Down:
                //v1

                for (int i = 0; i < 40; i++)
                {
                    GameManager.Instance.MainParentLevel.transform.position = new Vector3(GameManager.Instance.MainParentLevel.transform.position.x, GameManager.Instance.MainParentLevel.transform.position.y + 0.75f, GameManager.Instance.MainParentLevel.transform.position.z);
                    yield return new WaitForSeconds(Time / 40);
                }
                GameManager.Instance.MainCharacter.transform.position = new Vector3(GameManager.Instance.MainCharacter.transform.position.x, 15, GameManager.Instance.MainCharacter.transform.position.z);
                break;
            case GameManager.Direction.Left:
                //v1
                for (int i = 0; i < 40; i++)
                {
                    GameManager.Instance.MainParentLevel.transform.position = new Vector3(GameManager.Instance.MainParentLevel.transform.position.x + 0.5f, GameManager.Instance.MainParentLevel.transform.position.y, GameManager.Instance.MainParentLevel.transform.position.z);
                    yield return new WaitForSeconds(Time / 40);
                }

                GameManager.Instance.MainCharacter.transform.position = new Vector3(8.5f, GameManager.Instance.MainCharacter.transform.position.y, GameManager.Instance.MainCharacter.transform.position.z);
                break;
        }

        LevelManager.Instance.CurrentLevel = destination;
        CurrentlyChanging = false;
        // Suppression du Niveau Précédent
        if(GameObject.Find("Portal_ActualLvl=" + destination)) { 
        GameObject.Find("Portal_ActualLvl=" + destination).GetComponent<BoxCollider2D>().enabled = true;
        }
        DeletePreviousLevel(origine);
        GameManager.Instance.MainCharacter.SetActive(true);
        //AnimatorManager.Instance.Activation(AnimatorManager.Instance.ActualAnimation);

        //GameManager.Instance.MainCharacter.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public static void  DeletePreviousLevel(int numLevel)
    {
        Destroy(GameObject.Find("LevelMainParent/Level " + numLevel));
    }
}
