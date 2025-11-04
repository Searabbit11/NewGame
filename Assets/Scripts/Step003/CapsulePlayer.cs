using UnityEngine;

public class CapsulePlayer : MonoBehaviour
{
    public int CoinCount = 0;
    public float Speed = 1.0f;
    public float JumpPower; 
    Rigidbody2D rigid;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //이젠 CapsulePlayer를 좌우로 움직이는 로직을 작성해봅시다.
        //Transform 클래스는 모든 GameObject가 가지고 있기에
        //모든 MonoBehaviour 컴포넌트에서 transform으로 접근이 가능합니다.

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //이렇게 하면 컴퓨터의 사양에 따라서 이동속도가 바뀝니다.
            //절대적인 시간을 기준으로 이동속도를 제어 할 필요가 있습니다.
            // Speed * Time.deltaTime = 초당 Speed 만큼 이동합니다
            transform.position = transform.position + new Vector3(-Speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(Speed * Time.deltaTime, 0, 0);
        }
        //z키 점프
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }


    // OnTriggerEnter는 물리적 연산을 수행하지 않는 Collider(IsTrigger가 True인)와
    // 충돌했을때 게임 엔진에서 호출해주는 이벤트 함수.
    // 매개변수로 전달된 other = 충돌한 개체(Collider 클래스 인스턴스)
    // other를 이용해서 게임 로직 작성이 가능합니다.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        CoinCount += 1;
        Debug.Log($"Coin을 획득했습니다. 획득한 코인 개수 : {CoinCount}");
    }
}
