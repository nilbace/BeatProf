using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sp;
    float MoveSpeed;
    public float[] speed = new float[3];
    public AttackType mytype;
    public bool DestroyAble = false;
    
    public void Setting(AttackType type)
    {
        switch (type)
        {
            case AttackType.Assign:
                SetColorAndSpeed(Color.red, speed[0], type);
                break;
            case AttackType.Team:
                SetColorAndSpeed(Color.green, speed[1], type);
                break;
            case AttackType.Attendance:
                SetColorAndSpeed(Color.yellow, speed[2], type);
                break;
        }
    }

    void SetColorAndSpeed(Color C, float S, AttackType attack)
    {
        MoveSpeed = S; sp.color = C; mytype = attack;
    }

    private void FixedUpdate()
    {
        transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ParryZone")
        {
            DestroyAble = true;
            UI_InGame.instance.nowBulletType = mytype;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ParryZone")
        {
            DestroyAble = false;
            UI_InGame.instance.nowBulletType = AttackType.Null;
        }
    }

}