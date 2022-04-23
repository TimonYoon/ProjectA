using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CharController : MonoBehaviour
{
    [SerializeField] private GameObject charRoot;
    [SerializeField] private float speed = 0.001f;
    [FormerlySerializedAs("boustDelaySec")] [SerializeField] private float boosterDelaySec = 1.5f; 
    
    private SpriteRenderer charImage;
    private Animator charAnim;
    private KeyCode[] commendKeyCodes = new[] {KeyCode.None, KeyCode.None};

    private void Awake()
    {
        charImage = charRoot.GetComponent<SpriteRenderer>();
        charAnim = charRoot.GetComponent<Animator>();
    }

    void Update()
    {
        InputBoust();
        InputKey(KeyCode.W);
        InputKey(KeyCode.A);
        InputKey(KeyCode.S);
        InputKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKey(KeyCode keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            SetCommend(KeyCode.None, keyCode);
        }
        else if(Input.GetKeyUp(keyCode))
        {
            SetCommend(keyCode, KeyCode.None);
        }

        SetFlip();
    }

    void InputBoust()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("부스터 눌림");
            if (boosterDelaySecCoroutine != null)
            {
                return;
            }
            boosterDelaySecCoroutine = StartCoroutine(BoosterDelaySecCoroutine());
        }
    }

    private Coroutine boosterDelaySecCoroutine;
    private bool isInputBoosterKey = false;
    [SerializeField] private float boosterPower = 3f;
    IEnumerator BoosterDelaySecCoroutine()
    {
        isInputBoosterKey = true;
        yield return new WaitForSeconds(boosterDelaySec);
        boosterDelaySecCoroutine = null;
    }
    void SetCommend(KeyCode checkKeyCode, KeyCode inputKeyCode)
    {
        if (commendKeyCodes.Contains(inputKeyCode) && inputKeyCode != KeyCode.None)
        {
            return;
        }
        
        if (commendKeyCodes[0] == checkKeyCode)
        {
            commendKeyCodes[0] = inputKeyCode;
        }
        else if(commendKeyCodes[1] == checkKeyCode)
        {
            commendKeyCodes[1] = inputKeyCode;
        }        
    }

    void Move()
    {
        Vector3 A = keyCodeForVector2(commendKeyCodes[0]);
        Vector3 B = keyCodeForVector2(commendKeyCodes[1]);
        var direction = (A + B);
        if (direction == Vector3.zero)
        {
            return;
        }
        var pos = direction * speed;
        if (isInputBoosterKey)
        {
            pos = direction * boosterPower;
            isInputBoosterKey = false;
        }
        
        if (pos == Vector3.zero)
        {
            charAnim.SetBool("isMove", false);
            return;
        }
        charAnim.SetBool("isMove", true);
        transform.position += pos;

    }

    void SetFlip()
    {
        var isRight = commendKeyCodes.Contains(KeyCode.D);
        if (isRight)
        {
            charImage.flipX = true;
        }
        
        var isLeft = commendKeyCodes.Contains(KeyCode.A);
        if (isLeft)
        {
            charImage.flipX = false; 
        }
    }

    Vector2 keyCodeForVector2(KeyCode keyCode)
    {
        var pos = Vector2.zero;

        if (keyCode == KeyCode.W)
        {
            pos = new Vector2(0, 1);
        }
        else if(keyCode == KeyCode.A)
        {
            pos = new Vector2(-1, 0);
        }
        else if(keyCode == KeyCode.S)
        {
            pos = new Vector2(0, -1);
        }
        else if(keyCode == KeyCode.D)
        {
            pos = new Vector2(1, 0);
        }

        return pos;
    }
}
