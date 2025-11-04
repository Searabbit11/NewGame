using UnityEngine;

public class CardSelector : MonoBehaviour
{
    // ### 카드 선택 로직 만들기
    // 1. Card의 Transform 객체들을 배열 형태로 묶어 준다
    // 2. Cursor의 Transform 객체를 public으로 선언하여 캐싱해준다
    // 3. 키보드의 화살표를 이용하여, Cursor를 Card의 위치로 이동하는 로직을 작성한다
    // 4. 키보드의 Space를 이용하여 Card를 선택하는 로직을 작성한다.
    // 5. 카드가 선택되면 다른 Color로 변경하는 로직을 작성한다.
    
    // 6. F1을 누르면 모든카드의 선택을 처음상태로 되돌리는 로직을 작성한다


    // 배열이란 자료구조는 같은 유형의 객체들을 묶어놓는것
    // 데이터들 끼리의 관계를 맺어주는 것
    public Transform[] Cards;
    public Transform Cursor;


    //현재의 Index 정보를 캐싱하는 변수를 선언해준다
    public int CurrentIndex = 0;

    //y를 보정하는 변수값을 설정해준다
    public float AdjustYValue = 0.0f;

    //Card를 선택하면 출력되는 Color
    public Color SelectColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // 매 프레임마다 호출이 됩니다.
    // Update is called once per frame
    void Update()
    {
        //Input.GetKey          = 해당 키가 눌려있는 상태인지 체크합니다. 눌려있다면 True를 반환
        //Input.GetKeyUp        = 해당 키가 눌려있는 상태에서 해제 됐는지 체크됩니다.
        //                          키보드의 입력이 중단되었을때 True를 반환합니다
        //Input.GetKeyDown      = 해당 키가 눌려있지 않은 상태에서 눌린 상태가 되었는지 체크합니다
        //                          키보드의 입력이 시작되었을때 True를 반홥니다.

        //화살표 왼쪽 키 입력
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Cursor를 현재 가리키고 있는 카드의 왼쪽편으로 이동 시킵니다.
            // CurrentIndex를 -1 해준다
            // Cards의 범위는 [0 ~ 4] => -1을 해줬는데 0보다 작다면 4로 이동시켜야 한다

            CurrentIndex -= 1;
            if (CurrentIndex < 0) CurrentIndex = 4;

            Cursor.position = Cards[CurrentIndex].position + new Vector3(0, AdjustYValue, 0);
        }

        //화살표 오른쪽 키 입력
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Cursor를 현재 가리키고 있는 카드의 오른쪽편으로 이동 시킵니다.
            // CurrentIndex를 +1 해준다
            // Cards의 범위는 [0 ~ 4] => +1을 해줬는데 4보다 크다면 0으로 이동을 시켜줘야 한다

            CurrentIndex += 1;
            if (CurrentIndex > 4) CurrentIndex = 0;

            Cursor.position = Cards[CurrentIndex].position + new Vector3(0, AdjustYValue, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Card 선택하는 로직을 작성해 봅시다.
            // Card는 선택시 특정한 Color로 변경됩니다.

            //선택된 카드 = Cards[CurrentIndex]

            //아래의 로직으로는 Color를 바꿀수가 없습니다. SpriteRenderer 객체를 수정해야 합니다.
            //Cards[CurrentIndex].Color = SelectColor; 

            //Unity Runtime에서 특정 GameObject의 컴포넌트(Class, 객체)를 가져오는 함수를 알아봅시다.

            //선택된 카드에게서 SpriteRenderer 클래스 타입의 객체(인스턴스)를 가져와라. 그리고 sprite 객체에 할당해라
            SpriteRenderer sprite = Cards[CurrentIndex].GetComponent<SpriteRenderer>();
            sprite.color = SelectColor;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            //모든 카드가 처음의 색깔(White)로 초기화 되는 로직을 작성해 봅시다.

            for(int i = 0; i < Cards.Length; ++i)
            {
                SpriteRenderer sprite = Cards[i].GetComponent<SpriteRenderer>();
                sprite.color = Color.white; // Color는 Color. 을 통해 사전 정의된 색을 코드에서 사용가능합니다.
            }
        }
    }
}
