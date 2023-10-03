using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Define;


public class UI_InGame : UI_Scene
{
    public static UI_InGame instance;
    public AttackType nowBulletType;
    public Grade nowGrade;
    private void Awake()
    {
        instance = this;
    }


    enum Buttons
    {
        Young, Laptop, IPad
    }
    enum Texts {
        GradeText
    }


    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TMPro.TMP_Text>(typeof(Texts));

        nowBulletType = AttackType.Null;

        GetButton((int)Buttons.IPad).onClick.AddListener(UsePad);
        GetButton((int)Buttons.Laptop).onClick.AddListener(UseLaptop);
        GetButton((int)Buttons.Young).onClick.AddListener(UseYoung);
        GetText((int)Texts.GradeText).text = nowGrade.ToString();
    }

    public void GradeDown()
    {
        nowGrade++;
        if(nowGrade == Grade.Death)
        {
            SceneManager.LoadScene("Title");
        }
        GetText((int)Texts.GradeText).text = nowGrade.ToString();
        
    }

    void UsePad()
    {
        if (nowBulletType == AttackType.Assign)
        {
            Prof.instance.DestroyBullet();
        }
        else
        {
            Debug.Log("바보");
        }
    }

    void UseYoung()
    {
        if (nowBulletType == AttackType.Attendance)
        {
            Prof.instance.DestroyBullet();
        }
        else
        {
            Debug.Log("바보");
        }
    }

    void UseLaptop()
    {
        if (nowBulletType == AttackType.Team)
        {
            Prof.instance.DestroyBullet();
        }
        else
        {
            Debug.Log("바보");
        }
    }

}
