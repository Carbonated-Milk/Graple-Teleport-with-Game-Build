using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Panel[] panels;
    //public GameObject standardMenu;
    //public GameObject optionsMenu;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsPressed()
    {
        panels[FindName("StartMenu")].Deactivate();
        panels[FindName("Options")].Activate();
        //standardMenu.SetActive(false);
        //optionsMenu.SetActive(true);
    }   
    public void BackPressed()
    {
        panels[FindName("StartMenu")].Activate();
        panels[FindName("Options")].Deactivate();
        //standardMenu.SetActive(true);
        //optionsMenu.SetActive(false);
    }

    public int FindName(string name)
    {
        for (int i = 0; i < panels.Length; i ++)
        {
            if(panels[i].panelName == name)
            {
                return i;
            }
        }
        return -1;
    }
}


[System.Serializable]
public class Panel
{
    public string panelName;
    public GameObject menu;
    public GameObject background;

    public void Activate()
    {
        menu.SetActive(true);
        background.SetActive(true);
    }
    public void Deactivate()
    {
        menu.SetActive(false);
        background.SetActive(false);
    }
}
