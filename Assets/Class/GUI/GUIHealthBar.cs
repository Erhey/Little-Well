using UnityEngine;
using System.Collections;
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI

public class GUIHealthBar : MonoBehaviour {

    public Texture2D Txt2D_HealthBarTexture;
    public Texture2D Txt2D_MurTexture;
    public Texture2D Txt2D_HatHeartLife;
    public GUIStyle GUI_StyleScore;
     


    // THIS GUI IS DONE TO FIT A FIRST PLAYABLE EXECUTABLE VERSION HAS TO CHANGED #achanger

    void OnGUI()
    {

        GUI_StyleScore.fontSize = (int)(Screen.height / 38.4f);
            //GUI.DrawTexture(new Rect(0, 1856, 1280, 64), Txt2D_HealthBarTexture);
            //GUI.DrawTexture(new Rect(1248, 0, 64, 1920), Txt2D_MurTexture);
            //GUI.DrawTexture(new Rect(-32, 0, 64, 1920), Txt2D_MurTexture);
        GUI.Label(new Rect((Screen.width/2.0f) - (Screen.height/3.0f)+ (Screen.height / 38.4f), (29*Screen.height)/30.0f, Screen.height/3.0f, Screen.height/30.0f), "Score :" + GUIManager.Instance.Score, GUI_StyleScore);
        //Fonction de nombre de vie
        for (int i = 0; i < GUIManager.Instance.NbrLife; i++)
        {
            GUI.DrawTexture(new Rect((Screen.width / 2.0f) + Screen.height / 30.0f * i , (29 * Screen.height) / 30.0f, (Screen.height / 38.4f), (Screen.height / 38.4f)), Txt2D_HatHeartLife);
        }
    }
}
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
// MODIF AUJOURDHUI
