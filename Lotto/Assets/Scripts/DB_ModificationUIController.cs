using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_ModificationUIController : MonoBehaviour
{
    public GameObject addToDBPanel;
    public GameObject removeFromDBPanel;

    public GameObject DBModificationMenu;

    public GameObject remeovePopUp;
    public GameObject AddPopUp;
    private void Start()
    {
        closeAllPanels();
    }
    public void openAddToDB()
    {
        removeFromDBPanel.SetActive(false);
        DBModificationMenu.SetActive(false);
        addToDBPanel.SetActive(true);
    }

    public void openRemoveFromDB()
    {
        addToDBPanel.SetActive(false);
        DBModificationMenu.SetActive(false);
        removeFromDBPanel.SetActive(true);
    }

    public void openRemovePopUP()
    {
        remeovePopUp.SetActive(true);
    }

    public void openAddPopUp()
    {
        AddPopUp.SetActive(true);
    }

    public void closeAllPanels()
    {
        removeFromDBPanel.SetActive(false);
        remeovePopUp.SetActive(false);
        AddPopUp.SetActive(false);
        addToDBPanel.SetActive(false);
        DBModificationMenu.SetActive(true);
    }

}
