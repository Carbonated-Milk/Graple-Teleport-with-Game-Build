using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static MenuManager menuManager;

    public static Player player;

    public static bool isDead;

    public static float coinCount = 0;

    public static AudioManager audioManager;

    //public static Lives lives;

    public static void AddCoin()
    {
        coinCount += 1;
        //menuManager
    }
}
