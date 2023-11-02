using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour
{
    public GameObject Player;
    public GameObject PahtObj;

    public GameObject HeartUI;

    public GameObject Npc;

    void Start()
    {
        Player.SetActive(true);
        PahtObj.SetActive(true);
        HeartUI.SetActive(true);
        Npc.SetActive(true);
    } 
}
