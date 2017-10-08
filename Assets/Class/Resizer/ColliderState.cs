using UnityEngine;
using System.Collections;

public class ColliderState : MonoBehaviour{


    private bool _left;
    public bool Left
    {
        get
        {
            return _left;
        }
        set{
            _left = value;
            return; 
        }
    }
    private bool _up;
    public bool Up
    {
        get
        {
            return _up;
        }
        set
        {
            _up = value;
            return;
        }
    }
    private bool _right;
    public bool Right
    {
        get
        {
            return _right;
        }
        set
        {
            _right = value;
            return;
        }
    }
    private bool _down;
    public bool Down
    {
        get
        {
            return _down;
        }
        set
        {
            _down = value;
            return;
        }
    }





}
