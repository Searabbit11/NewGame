using Unity.Android.Gradle.Manifest;
using UnityEngine;
using static CapsulePlayer_v02;

public class WolfPlayer : MonoBehaviour
{
    public float JumpPower = 10.0f;
    public float DubleJumpPower;
    public float CurrentJumpPower = 0.0f;

    public bool IsDubleJumped = false;
    private float GRAVITY = -9.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveVector = new Vector3(0, 0, 0);

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
    }
}
