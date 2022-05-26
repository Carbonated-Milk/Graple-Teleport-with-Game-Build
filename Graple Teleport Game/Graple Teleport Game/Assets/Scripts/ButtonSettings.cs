using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    public string name;

    public void WhenClick()
    {
        GameManager.menuManager.LoadScene(name);
    }
}
