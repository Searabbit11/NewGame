using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class CardSelector2D : MonoBehaviour
{
    public int ColumnCount = 5;
    public int RowCount = 5;

    private const int COLUMN_MOVE_VALUE = 1;
    private static int ROW_MOVE_VALUE;

    public Transform[] Cards;
    public Transform[,] Cards2D;
    public Transform Cursor;

    public int CurrentIndex = 0;
    public float AdjustYValue = 0.0f;
    public Color SelectColor;

    public int CurrentX = 0;
    public int CurrentY = 0;

    private void Start()
    {
        ROW_MOVE_VALUE = ColumnCount;

        Cards2D = new Transform[RowCount, ColumnCount];

        for(int i = 0; i < Cards.Length; i++)
        {
            Cards2D[i / RowCount, i % ColumnCount] = Cards[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) UpdateIndex(-COLUMN_MOVE_VALUE); //화살표 왼쪽 키 입력
        if (Input.GetKeyDown(KeyCode.RightArrow)) UpdateIndex(COLUMN_MOVE_VALUE); //화살표 오른쪽 키 입력
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpdateIndex(-ROW_MOVE_VALUE); //화살표 왼쪽 키 입력
        if (Input.GetKeyDown(KeyCode.DownArrow)) UpdateIndex(ROW_MOVE_VALUE); //화살표 오른쪽 키 입력
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpriteRenderer sprite = Cards[CurrentIndex].GetComponent<SpriteRenderer>();
            sprite.color = SelectColor;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < Cards.Length; ++i)
            {
                SpriteRenderer sprite = Cards[i].GetComponent<SpriteRenderer>();
                sprite.color = Color.white; // Color는 Color. 을 통해 사전 정의된 색을 코드에서 사용가능합니다.
            }
        }
    }

    private void UpdateIndex(int sumValue)
    {
        CurrentIndex += sumValue;

        if (CurrentIndex >= Cards.Length) CurrentIndex -= Cards.Length;
        else if (CurrentIndex < 0) CurrentIndex += Cards.Length;

        // 2차원 좌표 구하기
        CurrentX = CurrentIndex / RowCount;
        CurrentY = CurrentIndex % ColumnCount;

        Transform currentCard = Cards2D[CurrentX, CurrentY];

        //Cursor의 위치를 갱신한다
        UpdateCursorPosition(currentCard);
    }

    private void UpdateCursorPosition(Transform cardTransform)
    {
        Cursor.position = cardTransform.position + new Vector3(0, AdjustYValue, 0);
    }
}
