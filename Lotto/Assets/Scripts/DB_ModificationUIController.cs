using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_ModificationUIController : MonoBehaviour
{
    public GameObject addToDBPanel;
    public GameObject removeFromDBPanel;
    private void Start()
    {
        closeAllPanels();
    }
    public void openAddToDB()
    {
        removeFromDBPanel.SetActive(false);
        addToDBPanel.SetActive(true);
    }

    public void openRemoveFromDB()
    {
        addToDBPanel.SetActive(false);
        removeFromDBPanel.SetActive(true);
    }

    public void closeAllPanels()
    {
        removeFromDBPanel.SetActive(false);
        addToDBPanel.SetActive(false);
    }

}
