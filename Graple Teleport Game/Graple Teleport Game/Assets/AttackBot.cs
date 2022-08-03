using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBot : MonoBehaviour, Hurtable
{
    public float health;
    float currentHealth;
    ArrayList deathList = new ArrayList();
    public GameObject lazer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Attack()
    {
        while(deathList.Count > 0)
        {
            Shoot((GameObject)deathList[0]);
            yield return new WaitForSeconds(5);
        }
    }

    private void Shoot(GameObject targetObj)
    {
        Transform newLazer = Instantiate(lazer).transform;
        newLazer.gameObject.SetActive(true);
        newLazer.transform.position = transform.position;
        newLazer.GetComponent<Rigidbody2D>().velocity = (targetObj.transform.position - transform.position) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            deathList.Add(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= 5;
            if(currentHealth <= 0) { Death(); }
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Hurt(float damage)
    {

    }
}
