using UnityEngine;

public class CapsulePlayer_v02 : MonoBehaviour
{
    public int CoinCount = 0;
    public float Speed = 1.0f;

    public float JumpPower = 10.0f;
    public float DubleJumpPower;
    public float CurrentJumpPower = 0.0f;

    public bool IsDubleJumped = false;
    private float GRAVITY = -9.8f;

    public Transform SunGlass;

    //private Rigidbody2D rBody;
    //private bool isGrounded;

    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임당 이동량을 넣어주는 Vector, 마지막에 transform.position 에 넣어준다
        Vector3 moveVector = new Vector3(0,0,0);

        Diretion diretion = Diretion.Idle; 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector += new Vector3(-Speed * Time.deltaTime, 0, 0);
            diretion = Diretion.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector += new Vector3(Speed * Time.deltaTime, 0, 0);
            diretion = Diretion.Right;
        }

        ChangeSunGlass(diretion);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 점프에 대해서 생각을 해봅시다
            // 캐릭터가 점프를 하면 하늘을 향해 상승합니다
            // 일정 높이에 도달하면 중력에 의해 아래로 떨어집니다.

            if (IsDubleJumped == false && CurrentJumpPower > (JumpPower / 2))
            {
                // 이단 점프
                CurrentJumpPower = JumpPower + DubleJumpPower;
                IsDubleJumped = true;
            }
            else
            {
                // 점프
                CurrentJumpPower = JumpPower;
            }
        }

        CurrentJumpPower += Time.deltaTime * GRAVITY;
        if (CurrentJumpPower > 0)
        {
            moveVector += Vector3.up * CurrentJumpPower * Time.deltaTime;
        }
        else
        {
            IsDubleJumped = false;
        }

        transform.position += moveVector;

        ////z키 점프 내가 처음했던거
        //if (Input.GetKeyDown(KeyCode.Z) && 
        //    //RigidBody = 물리운동을 하는 강체. 따라서 등속운동의 힘의 데이터를 늘 갖고 있음
        //    (-0.02f < rBody.linearVelocityY &&  rBody.linearVelocityY < 0.02f))
        //{
        //    rBody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        CoinCount += 1;
        Debug.Log($"Coin을 획득했습니다. 획득한 코인 개수 : {CoinCount}");
    }
    
    // 사용자 자료형 enum(열거형)
    // 프로그래머 데이터의 맥락에 맞게 데이터의 네이밍을 정의하여 나열 할 수 있는 자료형

    // 접근제한자 enum 자료형이름
    // {
    //      값 이름1,
    //      값 이름2,
    // }

    public enum Diretion
    {
        Idle,
        Left,
        Right,
    }

    private void ChangeSunGlass(Diretion diretion)
    {
        // 선글라스의 형태를 수정해서 간단한 애니메이션을 표현해봅시다.

        Vector3 position;
        Vector3 scale;

        switch(diretion)
        {
            case Diretion.Idle:
                position = new Vector3(0, 0.5f, -0.1f);
                scale = new Vector3(0.9f, 0.25f, 1);
                break;
            case Diretion.Left:
                position = new Vector3(-0.5f, 0.5f, -0.1f);
                scale = new Vector3(-0.2f, 0.25f, 1);
                break;
            case Diretion.Right:
                position = new Vector3(0.5f, 0.5f, -0.1f);
                scale = new Vector3(-0.2f, 0.25f, 1);
                break;
            default:
                position = new Vector3(0, 0.5f, -0.1f);
                scale = new Vector3(0.9f, 0.25f, 1);
                break;
        }

        SunGlass.localPosition = position;
        SunGlass.localScale = scale;

    }
}
