using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    public float cayoteTime;
    public float health;
    private float currentHealth;
    Vector3 respawnPoint;
    public UnityEvent death;
    private Rigidbody2D rb;
    private Transform healthBar;

    [HideInInspector] public bool canJump;
    [HideInInspector] public bool contained;
    [HideInInspector] public GameObject containedObj;

    private void Awake()
    {
        if (GameManager.player == null)
        {
            GameManager.player = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        currentHealth = health;
        contained = false;
        respawnPoint = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameManager.menuManager.transform.Find("PlayerUI/Health Bar Holder/HealthBar").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth/health > 0)
        {
            healthBar.localScale = new Vector3(currentHealth / health * 0.99f, .9f, 1);
        }
        else
        {
            OhNo();
        }

        if(contained)
        {
            transform.position = containedObj.transform.position;
            return;
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * 200 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * 200 * Time.deltaTime);
        }

        if (Input.GetKeyDown("space"))
        {
            if(canJump)
            {
                rb.AddForce(new Vector2(0f, 200f));
                canJump = false;
            }
            if(currentHealth <= 0)
            {
                Respawn();
            }
        }

        if (Input.GetKeyDown("tab"))
        {
            GameManager.menuManager.transform.Find("Game Options").gameObject.SetActive(true);
            GameManager.menuManager.transform.Find("PlayerUI").gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RespawnPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        canJump = true;
        if(collider.transform.CompareTag("Death"))
        {
            OhNo();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        Invoke("CayoteTime", cayoteTime);
    }

    public void CayoteTime()
    {
        canJump = false;
    }

    internal void Respawn()
    {
        //Time.timeScale = 1;
        currentHealth = health;

        transform.position = respawnPoint;
        currentHealth = health;
        GameManager.menuManager.OpenPanel(GameManager.menuManager.transform.Find("PlayerUI").gameObject);
        GameManager.isDead = false;
    }

    public void OhNo()
    {
        GameManager.isDead = true;
        currentHealth = 0;
        death.Invoke();
        GameManager.menuManager.OpenPanel(GameManager.menuManager.transform.Find("You Died").gameObject);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        canJump = false;
        //Time.timeScale = 0.8f;
    }

    public void Contained(GameObject container)
    {
        containedObj = container;
        contained = true;
        GetComponent<Renderer>().enabled = false;
        transform.position = container.transform.position;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        transform.parent = container.transform;
    }
    public void Released()
    {
        contained = false;
        GetComponent<Renderer>().enabled = true;
        rb.isKinematic = false;
        transform.parent = null;
    }
}
