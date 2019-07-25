using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButtonScript : MonoBehaviour
{
    public void DoWinBtn()
    {
        FindObjectOfType<ItemManager>().DeleteFromDBInRaffle();
    }
}
