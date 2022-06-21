using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Roller : MonoBehaviour
{
    public int tries;
    Rigidbody2D rb;
    float dir = 1;
    public float radius;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, radius);

        /*if (hitDown.collider == null)
        {
            for (int i = 0; i < tries; i++)
            {
                float deg = (240 + 60 / tries * i) * Mathf.Deg2Rad;
                Vector2 newVec = new Vector2(Mathf.Cos(deg), Mathf.Sin(deg));
                RaycastHit2D hitDown2 = Physics2D.Raycast(transform.position, newVec, radius);
                if (hitDown2.point != null)
                {
                    hitDown = hitDown2;
                    break;
                }
            }
        }*/
        if(hitDown.collider != null)
        {
            rb.velocity = dir * speed * new Vector2(hitDown.normal.y, -hitDown.normal.x);
        }
        Debug.DrawLine(transform.position, hitDown.point, Color.red);

        RaycastHit2D hitRL = Physics2D.Raycast(transform.position, Vector2.right * dir, radius);
        if (hitRL.collider != null)
        {
            dir *= -1;
        }
        Debug.DrawLine(transform.position, hitRL.point, Color.green);

        transform.Rotate(Vector3.forward *  -dir * speed * radius / (4 * Mathf.PI));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Hurt(10);
            var newVel = (collision.transform.position - transform.position).normalized * 5;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVel;
        }
    }
}



#if UNITY_EDITOR
[CustomEditor(typeof(Roller))]
public class RollerEditor : Editor
{
    public void OnSceneGUI()
    {
        var linkedObj = target as Roller;



        Handles.color = Color.black;

        EditorGUI.BeginChangeCheck();
        float newH = Vector3.Distance(Handles.DoPositionHandle(linkedObj.transform.position + linkedObj.transform.up * linkedObj.radius, linkedObj.transform.rotation), linkedObj.transform.position);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Update Hieght");
            linkedObj.radius = newH;
        }
    }
}

#endif
