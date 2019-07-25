using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_ModificationUIController : MonoBehaviour
{
    public GameObject addToDBPanel;
    public GameObject removeFromDBPanel;
    public GameObject raffleSettingsPanel;
    public GameObject wrongInputPopup;
    public GameObject DBModificationMenu;

    private void Start()
    {
        closeAllPanels();
    }
    public void openAddToDB()
    {
        DBModificationMenu.SetActive(false);
        addToDBPanel.SetActive(true);
    }

    public void openRemoveFromDB()
    {
        DBModificationMenu.SetActive(false);
        removeFromDBPanel.SetActive(true);
    }

    public void openRaffleSettings(){
        DBModificationMenu.SetActive(false);
        raffleSettingsPanel.SetActive(true);
    }

    public void closeAllPanels()
    {
        removeFromDBPanel.SetActive(false);
        raffleSettingsPanel.SetActive(false);
        addToDBPanel.SetActive(false);
        wrongInputPopup.SetActive(false);
        DBModificationMenu.SetActive(true);
    }

}
