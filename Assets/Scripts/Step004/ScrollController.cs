using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float Speed = 1.0f;

    [Header("Ref Objects")]
    public Transform[] BackGrounds;

    public Transform StartPivot;
    public Transform EndPivot;

    private Queue<Transform> scrollObjects = new Queue<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < BackGrounds.Length; i++)
        {
            scrollObjects.Enqueue (BackGrounds[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = Vector3.left * Speed * Time.deltaTime;

        foreach (Transform scroll in scrollObjects)
        {
            scroll.position += moveVector;
        }

        // 1.가장 앞단에 있는 녀석이
        // 2.EndPivot 의 x 값보다 작아진다면
        // 3.StartPivot 으로 옮겨준다.

        // 1번 
        Transform headScroll = scrollObjects.Peek();

        // 2번
        if(headScroll.position.x < EndPivot.position.x)
        {
            // 3번 
            Transform endedScroll = scrollObjects.Dequeue();
            endedScroll.position = StartPivot.position;
            scrollObjects.Enqueue(endedScroll);
        }

    }
}
