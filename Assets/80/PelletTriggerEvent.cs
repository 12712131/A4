using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletTriggerEvent : MyTriggerEvnet
{
    private void Start()
    {
        MainUICtrl.Instance.PelletCount++;
    }
}
