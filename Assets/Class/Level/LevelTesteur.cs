using UnityEngine;
using System.Collections;

public class LevelTesteur : MonoBehaviour {
    public LevelGenerator LGTest;
	// Use this for initialization
	void Start () {

        LevelManager.Instance.initiateLevels();
        LGTest.generateLevel( LevelManager.Instance.levels[0]);
        if(GameObject.Find("Portal_ActualLvl=" + 0)) {
            GameObject.Find("Portal_ActualLvl=" + 0).GetComponent<BoxCollider2D>().enabled = true;
        }
        //LGTest.MoveLevel(GameManager.Direction.Up, 0);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
