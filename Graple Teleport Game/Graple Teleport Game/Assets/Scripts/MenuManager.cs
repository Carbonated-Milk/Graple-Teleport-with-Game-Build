using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
public class MenuManager : MonoBehaviour
{
    public Levels[] levels;

    public Animator topDoor;

    private GameObject[] panels;

    private float waitTime = 1.5f;

    void Awake()
    {
        
        //doesn't destroy menu manager
        if (GameManager.menuManager == null)
        {
            GameManager.menuManager = this; 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        panels = new GameObject[transform.childCount - 3];
        for (int i = 0; i < transform.childCount - 3; i++)
        {
            panels[i] = transform.GetChild(i).gameObject;
        }

        foreach (Levels level in levels)
        {
            level.FindIndex();
        }

        Levels l = Array.Find(levels, levels => levels.levelIndex == SceneManager.GetActiveScene().buildIndex);
        GameManager.audioManager.Play(l.startingThemeName);
    }

    public void OpenPanel(GameObject open)
    {
        CloseAllPanels();
        open.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {

        Levels l = null;
        if (sceneName == "Next")
        {
            l = Array.Find(levels, levels => levels.levelIndex == SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            l = Array.Find(levels, levels => levels.levelName == sceneName);
        }
         StartCoroutine(LevelTransitioner(l)); 
    }

    public IEnumerator LevelTransitioner(Levels l)
    {
        topDoor.SetTrigger("Close");

        yield return new WaitForSeconds(waitTime);

        GameManager.playerCount = 0;
        SceneManager.LoadScene(l.levelIndex);

        CloseAllPanels();

        switch (l.levelIndex)
        {
            case 0:
                transform.Find("StartMenu").gameObject.SetActive(true);
                break;
            default:
                transform.Find("PlayerUI").gameObject.SetActive(true);
                break;
        }

        if (GameManager.player != null)
        {
            //GameManager.player.playerControls.Player.Disable();
            //GameManager.shoot.playerControls.Player.Disable();
        }



        topDoor.SetTrigger("Open"); 
        GameManager.audioManager.StopAllSongs();
        GameManager.audioManager.Play(l.startingThemeName);
    }
    public void SetTimeScale(float newTime)
    {
        Time.timeScale = newTime;
    }

    public void CloseAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
}

[System.Serializable]
public class Levels
{
    public string levelName;
    [HideInInspector]public int levelIndex;
    public string startingThemeName;
    public bool isLevel;

    public void FindIndex()
    {
        //Debug.Log(levelName);
        //levelIndex = SceneManager.GetSceneByName(levelName).buildIndex;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            string theName =  name.Substring(0, dot);
            if (theName == levelName)
            {
                levelIndex = i;
                break;
            }
        }
    }
}
