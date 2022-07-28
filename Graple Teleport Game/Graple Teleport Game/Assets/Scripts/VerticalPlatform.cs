using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class VerticalPlatform : MonoBehaviour
{
    public float speed;
    public float height;
    public Vector2 interval;
    Vector3 ogPos;
    private Sink sink;
    void Start()
    {
        ogPos = transform.position;
        StartCoroutine(RiseFall(true));
        if(transform.GetChild(0).GetComponent<Sink>() != null) { sink = transform.GetChild(0).GetComponent<Sink>(); }
    }

    public IEnumerator RiseFall(bool up)
    {
        float rand = Random.Range(interval.x, interval.y);
        switch(up)
        {
            case true:
                ChangeSink(true);
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
                ChangeSink(false);
                break;
        }
        
        yield return new WaitForSeconds(rand);
        StartCoroutine(RiseFall(!up));
    }

    public void ChangeSink(bool tf)
    {
        if(sink != null)
        {
            sink.enabled = tf;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(VerticalPlatform))]
public class SandPlatformEditor : Editor
{
    public void OnSceneGUI()
    {
        var linkedObj = target as VerticalPlatform;

        

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
