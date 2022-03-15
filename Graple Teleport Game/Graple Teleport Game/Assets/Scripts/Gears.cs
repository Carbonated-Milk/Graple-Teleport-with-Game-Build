using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class Gears : MonoBehaviour
{
    public bool firstGear;
    [HideInInspector]
    public float rotationSpeed;
    public GameObject[] connectedGears;
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * rotationSpeed * Time.deltaTime + transform.rotation.eulerAngles);
        foreach (GameObject gear in connectedGears)
        {
            gear.transform.rotation = Quaternion.Euler(Vector3.forward * -rotationSpeed * transform.localScale.x / gear.transform.localScale.x * Time.deltaTime + gear.transform.rotation.eulerAngles);
        }
    }
}

[CustomEditor(typeof(Gears))]
public class GearEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Gears script = (Gears)target;
        //script.firstGear = EditorGUILayout.Toggle("First Gear", script.firstGear);
        if (script.firstGear)
        { 

            script.rotationSpeed = EditorGUILayout.FloatField("Rotation Speed", script.rotationSpeed);
            //script.rotationSpeed = EditorGUILayout.FloatField("Rotation Speed", script.rotationSpeed, typeof(float), true) as float;
            //script.rotationSpeed = EditorGUILayout.FloatField("Increase scale by:", script.rotationSpeed);
        }
    }
}
