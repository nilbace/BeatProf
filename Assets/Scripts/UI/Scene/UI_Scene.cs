using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        Managers.UI_Manager.SetCanavas(gameObject, false);
    }   
}
