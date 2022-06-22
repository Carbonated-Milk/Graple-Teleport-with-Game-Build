using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCues : MonoBehaviour, CueInput
{
    bool state = false;
    public Color col1;
    public Color col2;
    private SpriteRenderer sp;

    private void Start()
    {
        ChangeCue(false);
        sp = GetComponent<SpriteRenderer>();
    }
    public void ChangeCue(bool newState)
    {
        state = newState;
        sp.color = state ? col1 : col2;
    }
}
public interface CueInput
{
    public void ChangeCue(bool state);
}