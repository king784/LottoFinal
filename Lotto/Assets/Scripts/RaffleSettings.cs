using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaffleSettings : MonoBehaviour
{
    private string raffleName;
    private int totalTickets;
    private int winningChance;

    public string RaffleName { get => raffleName;}
    public int TotalTickets { get => totalTickets;}
    public int WinningChance { get => winningChance;}

    public TMP_Text raffleNameText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGettingRaffleSettings());
    }

    public void setSettings(string name, string total, string winchance)
    {
        this.raffleName = name;
        int totalthings;
        int chances;
        int.TryParse(total, out totalthings);
        int.TryParse(winchance, out chances);

        this.totalTickets = totalthings;
        this.winningChance = chances;
    }

    IEnumerator StartGettingRaffleSettings()
    {
        yield return StartCoroutine(FindObjectOfType<DoPHPStuff>().GetRaffleSettings());
        raffleNameText.text = RaffleName;
    }
}
