using UnityEngine;
using System.Collections;

public class WallResizer : MonoBehaviour {


    public const int PX_UNIT = 100;

    void Start()
    {
        if(this.gameObject.name != "Wall") { 
        float px_SizeWall = Mathf.Round(PX_UNIT * this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x);
        this.gameObject.transform.localScale = new Vector3(LevelManager.Instance.pxResizedWall / px_SizeWall, LevelManager.Instance.pxResizedWall / px_SizeWall,1);
        }
    }
}
