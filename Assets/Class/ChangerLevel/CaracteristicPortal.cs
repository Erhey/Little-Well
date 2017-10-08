using UnityEngine;
using System.Collections;

public class CaracteristicPortal  {

    private int _posX;
    public int posX
    {
        get
        {
            return _posX;
        }
    }
    private int _posY;
    public int posY
    {
        get
        {
            return _posY;
        }
    }
    private int _originLevelNum;
    public int originLevelNum
    {
        get
        {
            return _originLevelNum;
        }
    }
    private int _destinationLevelNum;
    public int destinationLevelNum
    {
        get
        {
            return _destinationLevelNum;
        }
    }
    private GameManager.Direction   _animChgLvlDir;
    public GameManager.Direction animChgLvlDir
    {
        get
        {
            return _animChgLvlDir;
        }
    }

    public CaracteristicPortal(int x, int y, int OriLvlNum, int DestLvlNum, GameManager.Direction dir)
    {
        _posX = x;
        _posY = y;
        _originLevelNum = OriLvlNum;
        _destinationLevelNum = DestLvlNum;
        _animChgLvlDir = dir;
    }
}

