using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour {


    public enum TypeTriggerMonster
    {
        basic,
        jumpBasic,
        jumpNormal,
        jumpEvolved,
        round
    }
    public List<Monster> Monsters;
    private static MonsterManager instance;
    public static MonsterManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<MonsterManager>();
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