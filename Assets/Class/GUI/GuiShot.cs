using UnityEngine; 
using System.Collections;
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI

public class GuiShot : MonoBehaviour {
    
    public Sprite Sp_Shoot1;
    public Sprite Sp_Shoot2;
    public Sprite Sp_Shoot3;
    public Sprite Sp_Shoot4;
    public Sprite Sp_Shoot5;

    private bool B_IsDirectionLeft;
    private SpriteRenderer SpR_TextureToDraw;


    void Start()
    {
        B_IsDirectionLeft = MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.RunLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.WaitLeft ||
                    MainCharAnimator.Instance.ActualAnimation == MainCharAnimator.TypeAnimation.JumpLeft;

        this.transform.position = new Vector2(GameManager.Instance.MainCharacter.transform.position.x, GameManager.Instance.MainCharacter.transform.position.y);
        SpR_TextureToDraw = this.gameObject.GetComponent<SpriteRenderer>();
        GUIManager.Instance.NbrShot++;
        StartCoroutine(Shooting());
    }
    void Update()
    {
        if (this.B_IsDirectionLeft)
        {
            this.transform.position = new Vector2(this.transform.position.x - 0.1f, this.transform.position.y);
        }else
        {
            this.transform.position = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
        }
        ShotOutOfMap();
    }
    void ShotOutOfMap()
    {
        if(this.transform.position.x > 10 || this.transform.position.x < -10 ){
            Destroy(this.gameObject);
            GUIManager.Instance.NbrShot = Mathf.Max(GUIManager.Instance.NbrShot - 1, 0);
            GUIManager.Instance.Combo = 0;
        }

    }
    IEnumerator Shooting()
    {
        SpR_TextureToDraw.sprite = Sp_Shoot1;
        yield return new WaitForSeconds(0.1f);
        SpR_TextureToDraw.sprite = Sp_Shoot2;
        yield return new WaitForSeconds(0.1f);

        while (true) {
        SpR_TextureToDraw.sprite = Sp_Shoot1;
        yield return new WaitForSeconds(0.1f);
        SpR_TextureToDraw.sprite = Sp_Shoot3;
        yield return new WaitForSeconds(0.1f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Nosfera"))
        {

            Destroy(this.gameObject);
            other.GetComponent<Monster>().DestroyMonster();
            GUIManager.Instance.NbrShot = Mathf.Max(GUIManager.Instance.NbrShot-1,0);
            UpdateScore();
            if(MonsterManager.Instance.Monsters.Count == 0)
            {
                LevelManager.Instance.LevelIsCompleted[LevelManager.Instance.CurrentLevel] = true;
                //Debug.Log(LevelManager.Instance.levels[LevelManager.Instance.CurrentLevel].isCompleted);
            }
        }
            
    }

    void UpdateScore()
    {
        GUIManager.Instance.Combo ++;
        GUIManager.Instance.Score += (int)((300f + (75f * GUIManager.Instance.Combo)) * (1f + (GUIManager.Instance.Combo) / 10f));

    }
}
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
