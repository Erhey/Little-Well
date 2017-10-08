using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum Direction
    {
        Left,
        Up,
        Right,
        Down,
        other
    }

    public LevelGenerator LGSwitcher;
    public GameObject MainCharacter;
    public GameObject MainParentLevel;
    public GameObject GO_GameOver;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GameManager>();
            return instance;
        }
    }
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
