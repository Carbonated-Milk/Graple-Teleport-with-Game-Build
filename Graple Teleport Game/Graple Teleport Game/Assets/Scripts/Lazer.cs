using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private Lazer copy;
    private bool reflection;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public Vector3 initPoint;
    private LineRenderer lineRen;
    private ParticleSystem particles;
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        particles = GetComponent<ParticleSystem>();
        Physics2D.queriesStartInColliders = false;
        Physics2D.queriesHitTriggers = false;


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        if (reflection)
        {
            hit = Physics2D.Raycast(initPoint, direction);
        }
        else
        {
            initPoint = transform.parent.transform.position;
            direction = transform.parent.transform.up;
            hit = Physics2D.Raycast(transform.parent.position, direction);
        }

        if (copy == null)
        {
            ParticleSystem.ShapeModule pos = particles.shape;
            pos.position = hit.point;

            if (!reflection) { pos.position -= transform.parent.transform.position; }

            if (hit.transform.CompareTag("Mirror"))
            {
                particles.Stop();
                copy = Instantiate(gameObject).GetComponent<Lazer>();
                copy.reflection = true;
            }
        }

        if (copy != null)
        {
            if (!hit.transform.CompareTag("Mirror"))
            {
                particles.Play();
                ParticleSystem.ShapeModule pos = particles.shape;
                pos.position = hit.point;
                DestroyChild();
            }
            else
            {
                copy.initPoint = hit.point;
                copy.direction = direction.normalized - 2 * hit.normal * Vector2.Dot(direction.normalized, hit.normal);
            }
        }

        if (hit.transform.CompareTag("Player"))
        {
            hit.collider.gameObject.GetComponent<Player>().Hurt(5 * Time.deltaTime);
        }

        lineRen.SetPosition(0, initPoint);
        lineRen.SetPosition(1, hit.point);
    }

    private void DestroyChild()
    {
        copy.DestroySelf();
    }
    private void DestroySelf()
    {
        if (copy != null)
        {
            copy.DestroySelf();
        }
        Destroy(gameObject);
    }
}
