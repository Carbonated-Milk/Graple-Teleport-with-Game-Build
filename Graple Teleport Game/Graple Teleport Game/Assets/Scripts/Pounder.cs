using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Pounder : MonoBehaviour
{
    public bool useEdit = false;
    public float timeInverval;
    public float offset;
    [HideInInspector] public Vector3 originalPos;
    [HideInInspector] public Vector3 smashPos;
    private bool up = true;
    public float speed;
    private ParticleSystem particals;
    public ArrayList cueInputs = new ArrayList();
    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        originalPos = transform.position;
        if(!useEdit)
        {
            smashPos = Physics2D.Raycast(transform.position, -transform.up).point;
        }
        Invoke("StartRun", offset);
        particals = GetComponent<ParticleSystem>();
        CueInput[] newCues = transform.GetComponentsInChildren<CueInput>();
        cueInputs.AddRange(newCues);
        //foreach(CueInput x in newCues) { x.}
    }

    public void StartRun()
    {
        StartCoroutine(Running());
    }
    public IEnumerator Running()
    {
        float deltaTime = 0;
        while(true)
        {
            deltaTime += Time.deltaTime;
            if(deltaTime > timeInverval)
            {
                if (up) { StartCoroutine(Pound()); }
                else { StartCoroutine(Release()); }
                deltaTime = 0;
            }
            yield return null;
        }
    }

    public IEnumerator Pound()
    {
        ChangeCues(true);
        transform.GetChild(0).tag = "Death";
        while(transform.position != smashPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, smashPos, speed);
            yield return null;
        }
        up = false;
        particals.Play();
    }
    public IEnumerator Release()
    {
        ChangeCues(false);
        transform.GetChild(0).tag = "Untagged";
        while (transform.position != originalPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, speed/2);
            yield return null;
        }
        up = true;
    }

    void ChangeCues(bool state)
    {
        if (cueInputs.Count > 0)
        {
            foreach (CueInput c in cueInputs)
            {
                c.ChangeCue(state);
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Pounder))]
public class PounderEditor : Editor
{
    public void OnSceneGUI()
    {
        var linkedObj = target as Pounder;

        if (linkedObj.useEdit)
        {
            Handles.color = Color.black;

            EditorGUI.BeginChangeCheck();
            float newH = Vector3.Distance(Handles.DoPositionHandle(linkedObj.smashPos, linkedObj.transform.rotation), linkedObj.transform.position);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Update Hieght");
                linkedObj.smashPos = linkedObj.transform.position + -linkedObj.transform.up * newH;
            }
        }
    }
}

#endif
