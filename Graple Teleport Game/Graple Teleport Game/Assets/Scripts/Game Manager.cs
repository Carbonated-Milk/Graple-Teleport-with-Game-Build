using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static MenuManager menuManager;

    public static Player player;
    public static int playerCount = 0;

    public static bool isDead;


    public static AudioManager audioManager;

    //public static Lives lives;

    public static ArrayList coinManagers = new ArrayList();
}
