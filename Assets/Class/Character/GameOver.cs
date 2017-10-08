using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public LevelGenerator LGRestarter;

    //PRESS Enter TO START AGAIN

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //Restart Les Données GUI
            GUIManager.Instance.Score = 0;
            GUIManager.Instance.NbrLife = 3;

            //Restart les Données des niveaux
            LevelManager.Instance.RestartLevelCompleted(LevelManager.Instance.levels.Length);
            // Suppress Level
            LevelAnimator.DeletePreviousLevel(LevelManager.Instance.CurrentLevel);

            //Reset List Monstre
            MonsterManager.Instance.Monsters.Clear();

            // Generate level 0 
            LGRestarter.generateLevel(LevelManager.Instance.levels[0]);
            LevelManager.Instance.CurrentLevel = 0;
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
