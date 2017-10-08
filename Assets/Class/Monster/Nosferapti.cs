using UnityEngine;
using System.Collections;

public class Nosferapti : Monster {


    public GameObject AnimMoveLeft;
    public GameObject AnimMoveRight;
    private MainCharAnimator.TypeAnimation ActualAnimation;

    void Awake()
    {
        
        this.IDMonster = MonsterManager.Instance.Monsters.Count + 1;
        MonsterManager.Instance.Monsters.Add(this);
        this.Type = MonsterManager.TypeTriggerMonster.basic;
    }
    void Start()
    {
        MonsterMouvement(this.Type);
    }

    void FixedUpdate()
    {
        if (this.speed > 0 && this.ActualAnimation != MainCharAnimator.TypeAnimation.RunRight)
        {
            this.ActualAnimation = MainCharAnimator.TypeAnimation.RunRight;
            this.AnimMoveLeft.SetActive(false);
            this.AnimMoveRight.SetActive(true);

        }
        else if (this.speed < 0 && this.ActualAnimation != MainCharAnimator.TypeAnimation.RunLeft)
        {
            this.ActualAnimation = MainCharAnimator.TypeAnimation.RunLeft;
            this.AnimMoveRight.SetActive(false);
            this.AnimMoveLeft.SetActive(true);

        }
    }

}
