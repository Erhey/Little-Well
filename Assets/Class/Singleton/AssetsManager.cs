using UnityEngine;
using System.Collections;

public class AssetsManager : MonoBehaviour {


    public PhysicsMaterial2D GB_MATERIAL_WALL;

    private static AssetsManager instance;
    public static AssetsManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<AssetsManager>();
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
