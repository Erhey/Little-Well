using UnityEngine;
using System.Collections;

public class Level
{


    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI
    public bool isCompleted;
    // MODIF AUJOURDHUI
    // MODIF AUJOURDHUI



    public int[,] wallPosition;
    public CaracteristicPortal portal;
    public int[,] monsterMatrix;
    public int levelNum;


    public Level(int levelNum, int[,] wallPosition,int[,] monsterMatrix)
    {
        this.portal = new CaracteristicPortal(100, 0, 0, 0, GameManager.Direction.other);
        this.levelNum = levelNum;
        this.wallPosition = wallPosition;
        this.monsterMatrix = monsterMatrix;
    }
    public Level(CaracteristicPortal portal, int levelNum, int[,] wallPosition, int[,] monsterMatrix)
    {
        this.portal = portal;
        this.levelNum = levelNum;
        this.wallPosition = wallPosition;
        this.monsterMatrix = monsterMatrix;
    }
}