using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2;
    public GameObject LeftBTN; public GameObject RightBTN; 
    [SerializeField] float moveSpeed;
    float XValue;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        EventTrigger LeftEventTrigger = LeftBTN.GetComponent<EventTrigger>();

        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { LeftDown((PointerEventData)data); });
        LeftEventTrigger.triggers.Add(entryDown);


        EventTrigger RightEventTrigger = RightBTN.GetComponent<EventTrigger>();

        EventTrigger.Entry entryDown2 = new EventTrigger.Entry();
        entryDown2.eventID = EventTriggerType.PointerDown;
        entryDown2.callback.AddListener((data) => { RightDown((PointerEventData)data); });
        RightEventTrigger.triggers.Add(entryDown2);


        EventTrigger.Entry entryup = new EventTrigger.Entry();
        entryup.eventID = EventTriggerType.PointerUp;
        entryup.callback.AddListener((data) => { UP((PointerEventData)data); });
        LeftEventTrigger.triggers.Add(entryup);
        RightEventTrigger.triggers.Add(entryup);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(XValue * moveSpeed * Time.deltaTime, 0, 0);
        GameObject.Find("ParryZone").transform.position += new Vector3(XValue * moveSpeed * Time.deltaTime, 0, 0);
    }

    void LeftDown(PointerEventData data)
    {
        XValue = -1;
    }

    void UP(PointerEventData data)
    {
        XValue = 0;
    }

    void RightDown(PointerEventData data)
    {
        XValue = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UI_InGame.instance.GradeDown();
    }
}
