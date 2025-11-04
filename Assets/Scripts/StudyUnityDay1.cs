using System;
using UnityEngine;

public class StudyUnityDay1 : MonoBehaviour
{
    // public 접근제한자를 통해 선언된 변수들은
    // 유니티 에디터의 인스펙터(Inspector)창에서
    // 값들을 변경 할 수 있다.
    // private 접근제한자는 에디터에서 값을 수정 할 수 없다.

    public int Number;
    public float fNumber;
    public string Name;
    public bool isTrue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 이제는 텍스트 출력을 위해 Console이 아닌 Debug 객체를 사용합니다.
        //Debug.Log("Start");

        // Debug.Log 계열 함수들
        Debug.Log("Log");
        Debug.LogWarning("LogWarning");
        Debug.LogError("LogError");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right");
        }
    }
}
