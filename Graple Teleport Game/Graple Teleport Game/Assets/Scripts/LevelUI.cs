using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject defualtButton;
    public float rows;
    public Vector2 spacing;
    Levels[] levels;
    private int perRow;
    

    private void Start()
    {
        rows = Mathf.Clamp(rows, 0, 100);
        levels = GameManager.menuManager.levels;
        perRow = (int)Mathf.Ceil((levels.Length - 1)/rows);

        for (int i = 0; i < rows; i++)
        {
            for (int  j= 0; j < perRow; j++)
            {
                int levelIndex = i * perRow + j + 1;
                if (levelIndex == levels.Length) { defualtButton.SetActive(false); return; }
                GameObject newButton = Instantiate(defualtButton);
                newButton.transform.parent = transform;
                newButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing.x * (j - (perRow - 1)/2) , -spacing.y * (i - (rows - 1) / 2), 0f);
                string name = levels[i * perRow + j + 1].levelName;
                newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
                newButton.GetComponent<ButtonSettings>().name = name;
                
            }
        }
        defualtButton.SetActive(false);
    }


}
