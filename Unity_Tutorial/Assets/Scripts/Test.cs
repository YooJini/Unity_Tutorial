using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;



public class Test : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField] private RectTransform rect_BackGround;
    [SerializeField] private RectTransform rect_JoyStick;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;


    private void Start()
    {
        radius = rect_BackGround.rect.width * 0.5f;
    }
    void Update()
    {
        if (isTouch) go_Player.transform.position += movePosition;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_BackGround.position;

        //가두기
        value = Vector2.ClampMagnitude(value, radius);

        rect_JoyStick.localPosition = value;

        float distance = Vector2.Distance(rect_BackGround.position, rect_JoyStick.position)/radius;
        value = value.normalized;
        movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f, value.y * moveSpeed * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_JoyStick.localPosition = Vector3.zero;
        movePosition = Vector3.zero;
    }
}
   
