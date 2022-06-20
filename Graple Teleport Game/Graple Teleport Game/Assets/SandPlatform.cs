using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SandPlatform : MonoBehaviour
{
    public float speed;
    public float height;
    public Vector2 interval;
    Vector3 ogPos;
    void Start()
    {
        ogPos = transform.position;
        StartCoroutine(RiseFall(true));
    }

    public IEnumerator RiseFall(bool up)
    {
        float rand = Random.Range(interval.x, interval.y);
        switch(up)
        {
            case true:
                transform.GetChild(0).GetComponent<Sink>().enabled = true;
                while (transform.position != ogPos + transform.up * height)
                {
                    transform.position = Vector3.MoveTowards(transform.position, ogPos + transform.up * height, speed * Time.deltaTime);
                    yield return null;
                }
                break;
            case false:
                while (transform.position != ogPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, ogPos, speed * Time.deltaTime);
                    yield return null;
                }
                transform.GetChild(0).GetComponent<Sink>().enabled = false;
                break;
        }
        
        yield return new WaitForSeconds(rand);
        StartCoroutine(RiseFall(!up));
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SandPlatform))]
public class SandPlatformEditor : Editor
{
    public void OnSceneGUI()
    {
        var linkedObj = target as SandPlatform;

        

        Handles.color = Color.black;

        EditorGUI.BeginChangeCheck();
        float newH = Vector3.Distance(Handles.DoPositionHandle(linkedObj.transform.position + linkedObj.transform.up * linkedObj.height, linkedObj.transform.rotation), linkedObj.transform.position);
        
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Update Hieght");
            linkedObj.height = newH;
        }
    }
}

#endif
