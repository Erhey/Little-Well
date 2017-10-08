using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {


    public int NbrLife;



    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI
    public int Score;
    public int NbrShot;
    public GameObject GO_ShotLeft;
    public GameObject GO_ShotRight;
    public float Combo;
    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI




    private static GUIManager instance;
    public static GUIManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GUIManager>();
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
