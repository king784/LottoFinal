using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddToDBFormManagement : MonoBehaviour
{
    //add items
    public TMP_InputField itemName;
    public TMP_InputField description;
    public TMP_InputField quantity;

    //reaffle settings
    public TMP_InputField totalTickets;
    public TMP_InputField winningChance;
    public TMP_InputField raffleName;

    //errors
    public TMP_Text chanceError;
    public TMP_Text totalError;
    public GameObject errorMessagePanel;

    public void resetFields()
    {
        //add item to db form
        itemName.text = "";
        description.text = "";
        quantity.text = "1";

        //raffle settings form
        raffleName.text = "";
        totalTickets.text = "20";
        winningChance.text = "50";
    }

    public void checkSettingsInput()
    {
        bool errorsExist = false;
        int chancePercent;
        bool winChanceWasNumber = int.TryParse(winningChance.text, out chancePercent);

        if (winChanceWasNumber)
        {
            if (chancePercent < 0 || chancePercent > 100)
            {
                chanceError.text = "Voitto mahdollisuuden tulee olla väliltä 0-100.";
                errorsExist = true;
            }
        }
        else
        {
            chanceError.text = "Voitto mahdollisuus kenttään pitää laittaa numero väliltä 0-100.";
            errorsExist = true;
        }
        if (winningChance.text == "")
        {
            chanceError.text = "Voitto mahdollisuus kenttä ei saa olla tyhjä.";
            errorsExist = true;
        }

        int totalTicketsNum;
        bool totalTicketsWasNumber = int.TryParse(totalTickets.text, out totalTicketsNum);

        if (totalTicketsWasNumber)
        {
            if (totalTicketsNum < 10 || totalTicketsNum > 40)
            {
                totalError.text = "Pallojen määrä pitää olla enemmän kuin 10 ja vähemmän kuin 40";
                errorsExist = true;
            }
        }
        else
        {
            totalError.text = "Pallojen määrä tulee olla numero";
        }
        if (totalTickets.text == "")
        {
            totalError.text = "Pallojen määrä ei saa olla tyhjä.";
            errorsExist = true;
        }

        if(errorsExist){
            errorMessagePanel.SetActive(true);
            return;
        }else{// if no errors send info to database
        //Debug.Log("Raffle settings are ok");
        FindObjectOfType<DoPHPStuff>().SaveRaffleSettingsToDB();
        FindObjectOfType<DB_ModificationUIController>().closeAllPanels();
        }
    }

}
