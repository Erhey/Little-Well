using UnityEngine;
using System.Collections;

public class MainCharAnimator : MonoBehaviour
{
 
        public GameObject Anim_MainChar_RunLeft;
        public GameObject Anim_MainChar_RunRight;
        public GameObject Anim_MainChar_WaitLeft;
        public GameObject Anim_MainChar_WaitRight;
        public GameObject Anim_MainChar_JumpLeft;
        public GameObject Anim_MainChar_JumpRight;
        public GameObject Anim_MainChar_DeathLeft;
        public GameObject Anim_MainChar_DeathRight;


    TypeAnimation _actualAnimation;
    public TypeAnimation ActualAnimation
    {
        get
        {
            return _actualAnimation;
        }
    }
    public enum TypeAnimation
    {
        RunLeft,
        RunRight,
        WaitLeft,
        WaitRight,
        JumpLeft,
        JumpRight,
        DeathLeft,
        DeathRight
    }

    public void Desactivation()
    {
        Anim_MainChar_RunLeft   .SetActive(false);
        Anim_MainChar_RunRight  .SetActive(false);
        Anim_MainChar_WaitLeft  .SetActive(false);
        Anim_MainChar_WaitRight .SetActive(false);
        Anim_MainChar_JumpLeft  .SetActive(false);
        Anim_MainChar_JumpRight .SetActive(false);
        Anim_MainChar_DeathRight .SetActive(false);
        Anim_MainChar_DeathRight .SetActive(false);
    }
    public void Activation(TypeAnimation TA)
    {
        if (TA != _actualAnimation)
        {
            switch (_actualAnimation)
            {
                case TypeAnimation.RunLeft:
                    Anim_MainChar_RunLeft.SetActive(false);
                    break;
                case TypeAnimation.RunRight:
                    Anim_MainChar_RunRight.SetActive(false);
                    break;
                case TypeAnimation.WaitLeft:
                    Anim_MainChar_WaitLeft.SetActive(false);
                    break;
                case TypeAnimation.WaitRight:
                    Anim_MainChar_WaitRight.SetActive(false);
                    break;
                case TypeAnimation.JumpLeft:
                    Anim_MainChar_JumpLeft.SetActive(false);
                    break;
                case TypeAnimation.JumpRight:
                    Anim_MainChar_JumpRight.SetActive(false);
                    break;
                case TypeAnimation.DeathLeft:
                    Anim_MainChar_DeathLeft.SetActive(false);
                    break;
                case TypeAnimation.DeathRight:
                    Anim_MainChar_DeathRight.SetActive(false);
                    break;

            }

            switch (TA)
            {
                case TypeAnimation.RunLeft:
                    Anim_MainChar_RunLeft.SetActive(true);
                    break;
                case TypeAnimation.RunRight:
                    Anim_MainChar_RunRight.SetActive(true);
                    break;
                case TypeAnimation.WaitLeft:
                    Anim_MainChar_WaitLeft.SetActive(true);
                    break;
                case TypeAnimation.WaitRight:
                    Anim_MainChar_WaitRight.SetActive(true);
                    break;
                case TypeAnimation.JumpLeft:
                    Anim_MainChar_JumpLeft.SetActive(true);
                    break;
                case TypeAnimation.JumpRight:
                    Anim_MainChar_JumpRight.SetActive(true);
                    break;
                case TypeAnimation.DeathLeft:
                    Anim_MainChar_DeathLeft.SetActive(true);
                    break;
                case TypeAnimation.DeathRight:
                    Anim_MainChar_DeathRight.SetActive(true);
                    break;

            }
            _actualAnimation = TA;
        }
    }

    private static MainCharAnimator instance;
    public static MainCharAnimator Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<MainCharAnimator>();
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
        instance = this;
    }
}
