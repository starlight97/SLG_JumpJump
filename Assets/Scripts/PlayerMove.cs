using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;

    public float speed;
    private float jumpPower;
    private float currentJumpPower;
    private float gravity;
    private float currentGravity;

    private bool readyJump;
    
    private Transform _transform;
    private Player player;
    private bool _isJumping;
    private float _posY;        //오브젝트의 초기 높이
    private float _jumpTime;    //점프 이후 경과시간   

    public bool ReadyJump
    {
        get => readyJump;
        set => readyJump = value;
    }
    public float JumpPower
    {
        get => jumpPower;
        set => jumpPower = value;
    }
    public float Gravity
    {
        get => gravity;
        set => gravity = value;
    }


    void Awake()
    {
        player = GetComponent<Player>();
        readyJump = true;

        _transform = transform;
        _isJumping = false;
        _posY = transform.position.y;
        _jumpTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyJump)   
        {
            currentGravity = gravity;
            currentJumpPower = jumpPower;
            player.PlaySound("PLAYERJUMP");
            _isJumping = true;
            readyJump = false;
            _jumpTime = 0.0f;
            _posY = _transform.position.y;
        }

        // 게임 오버시 무한 추락 방지
        if (_isJumping && transform.position.y > -10f)
        {
            Jump();
        }
        Move();
    }


    private void Move()
    {
        //Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        //transform.position += rightMovement;

        float h = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = Vector3.zero;

        // 왼쪽 입력
        if((h == -1 || joystick.Horizontal < 0 )&& transform.position.x > -5.6)
        {
            moveDirection = Vector3.left;
        }
        else if((h == 1  || joystick.Horizontal > 0) && transform.position.x < 5.6)
        {
            moveDirection = Vector3.right;            
        }
        transform.position += (moveDirection * speed * Time.deltaTime);

    }

    private void Jump()
    {
        //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
        //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
        //변화된 높이 height를 기존 높이 _posY에 더한다.
        float height = (_jumpTime * _jumpTime * (-currentGravity) / 2) + (_jumpTime * currentJumpPower);

        _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
        //점프시간을 증가시킨다.
        _jumpTime += Time.deltaTime;

        //transform.Translate(Vector3.up * Time.deltaTime * jumpPower);
        //rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); 
    }

    public void JumpButtonClick()
    {
        if(Input.GetKeyDown(KeyCode.Space) || readyJump == true)
        {
            currentGravity = gravity;
            currentJumpPower = jumpPower;
            player.PlaySound("PLAYERJUMP");
            _isJumping = true;
            readyJump = false;
            _jumpTime = 0.0f;
            _posY = _transform.position.y;
        }
    }

}
