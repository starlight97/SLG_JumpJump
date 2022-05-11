using UnityEngine.EventSystems;
using UnityEngine;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public RectTransform outLine;

    private float deadZone = 0;
    private float handleRange = 1;
    private Vector3 input = Vector3.zero;
    private Canvas canvas;

    public float Horizontal { get { return input.x; } }
    public float Vertical { get { return input.y; } }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 radius = outLine.sizeDelta / 2;
        input = (eventData.position - outLine.anchoredPosition) / (radius * canvas.scaleFactor);
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius * handleRange;
    }

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                input = normalised;
            }
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;

    }
}

/*
EventHandler인 IDragHandler, IPointerUpHandler, IPointerDownHandler를 이용해 
터치를 감지하고 매개변수인 eventData를 통해 터지지점의 좌표값을 가져올 수 있습니다.

OnDrag가 활성화되는동안 드래그된 지점과 시작지점을 차감 계산하여 방향과 크기를 구하고 
DeadZone이라는 변수를 활용하여 Joystick Handle이 일정범위 이상을 벗어나지 않게 제어합니다.
Player스크립트에서 계산되어진 Input값을 Get하여 Joystick이동을 표현합니다.

OnPointerUp 활성화되면 Handle은 초기지점으로 이동시키고 Input값은 초기값으로  수정합니다. 
 */