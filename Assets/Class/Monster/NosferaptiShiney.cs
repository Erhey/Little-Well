using UnityEngine;
using System.Collections;

public class NosferaptiShiney : Monster {

    void Awake()
    { 
        this.IDMonster = MonsterManager.Instance.Monsters.Count + 1;
        MonsterManager.Instance.Monsters.Add(this);
        this.Type = MonsterManager.TypeTriggerMonster.jumpBasic;
    }
    void Start()
    {
        MonsterMouvement(this.Type);
    }
}
