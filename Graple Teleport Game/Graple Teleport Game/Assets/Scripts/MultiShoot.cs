using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : MonoBehaviour
{
    public int multiNum;
    public float rotateSpeed;

    public GameObject shootHeadFab;

    private ShootHeads[] shootHeads;

    void Start()
    {
        shootHeads = new ShootHeads[multiNum];
        for (int i = 0; i < multiNum; i++)
        {
            GameObject t = Instantiate(shootHeadFab);
            shootHeads[i].shootHead = t.transform;
            shootHeads[i].shootHead.position = transform.position;
            shootHeads[i].shootHead.Rotate(i * 360 / multiNum * Vector3.forward);
            shootHeads[i].lineRen = shootHeads[i].shootHead.GetComponent<LineRenderer>();
        }
    }

    void Update()
    {
        for (int i = 0; i < multiNum; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, shootHeads[i].shootHead.up);
            shootHeads[i].shootHead.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
            shootHeads[i].lineRen.SetPosition(0, transform.position);
            shootHeads[i].lineRen.SetPosition(1, hit.point);
            Debug.DrawLine(transform.position, hit.point, Color.red);

            if(hit.collider.CompareTag("Player"))
            {
                hit.collider.GetComponent<Player>().Hurt(1f);
            }
        }
    }
}

public struct ShootHeads
{
    public Transform shootHead;

    public LineRenderer lineRen;
}
