using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float cayoteTime;
    public float health;
    private float currentHealth;
    static Vector3 respawnPoint;
    public UnityEvent death;
    private Rigidbody2D rb;
    private Transform healthBar;

    public LayerMask jumpTypes;

    public Vector2 moverDir;
    public bool jumped;
    private bool action;
    public Vector2 mousePos;
    public Vector2 mouseCoord;
    public bool actionSwitch = false;

    [HideInInspector] private Vector2 rightDir;
    [HideInInspector] private Vector2 downDir;
    private CameraMovement cam;

    private Camera camera;

    [HideInInspector] public bool canJump;
    [HideInInspector] public bool contained;
    [HideInInspector] public GameObject containedObj;

    public GameObject playerUI;
    public GameObject playerDie;


    public IAction actionObj;

    public void OnMove(InputAction.CallbackContext context)
    {
        moverDir = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jumped = true;
        }
        else
        {
            jumped = false;
        }
    }
    public void OnAction(InputAction.CallbackContext context)
    {
        if (actionObj != null)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    actionObj.Begin();
                    break;
                case InputActionPhase.Canceled:
                    actionObj.Finish();
                    break;
            }
        }
    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            actionSwitch = !actionSwitch;
        }
    }
    public void OnRespawn(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Respawn();
        }
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mouseCoord = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        /*if (GameManager.player == null)
        {
            GameManager.player = this;
        }
        else
        {
            //Destroy(gameObject);
            return;
        }*/
        
    }
    void Start()
    {
        GameManager.isDead = false;
        currentHealth = health;
        contained = false;
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //healthBar = GameManager.menuManager.transform.Find("PlayerUI/Health Bar Holder/HealthBar").transform;
        healthBar = transform.parent.transform.Find("PlayerUI/Health Bar Holder/HealthBar").transform;
        cam = transform.parent.GetChild(0).GetComponent<CameraMovement>();
        camera = cam.GetComponent<Camera>();
        ChangeDown(Vector2.down);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(mouseCoord);

        if (currentHealth / health > 0)
        {
            healthBar.localScale = new Vector3(currentHealth / health * 0.99f, .9f, 1);
        }
        else
        {
            OhNo();
        }

        if (contained)
        {
            transform.position = containedObj.transform.position;
            return;
        }

        rb.AddForce(rightDir * 200 * Time.deltaTime * moverDir.x);


        if (jumped)
        {
            if (canJump)
            {
                rb.AddForce(-downDir * 200f);
                canJump = false;
                jumped = false;
            }
            if (currentHealth <= 0)
            {
                Respawn();
            }
        }

        if (Input.GetKeyDown("tab"))
        {
            GameManager.menuManager.transform.Find("Game Options").gameObject.SetActive(true);
            //GameManager.menuManager.transform.Find("PlayerUI").gameObject.SetActive(false); 
            playerUI.SetActive(false);
            Time.timeScale = 0;
        }

        if ((Vector2)Physics.gravity != Physics2D.gravity) { Physics.gravity = (Vector3)Physics2D.gravity; }
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        GroundCheck();
        if (collider.transform.CompareTag("Death"))
        {
            OhNo();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GroundCheck();
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        Invoke("CayoteTime", cayoteTime);
    }

    public void CayoteTime()
    {
        canJump = false;
    }
    private void GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, downDir, 2f, jumpTypes))
        {
            canJump = true;
        }
    }

    public void Respawn()
    {
        //Time.timeScale = 1;
        currentHealth = health;
        Released();

        transform.position = respawnPoint;
        currentHealth = health;
        //GameManager.menuManager.OpenPanel(GameManager.menuManager.transform.Find("PlayerUI").gameObject);
        GameManager.menuManager.CloseAllPanels();
        playerDie.SetActive(false);
        playerUI.SetActive(true);
        GameManager.isDead = false;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    public void OhNo()
    {
        GameManager.isDead = true;
        currentHealth = 0;
        death.Invoke();
        //GameManager.menuManager.OpenPanel(GameManager.menuManager.transform.Find("You Died").gameObject);
        GameManager.menuManager.CloseAllPanels();
        playerUI.SetActive(false);
        playerDie.SetActive(true);
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
        GrapplingHook.canGraple = false;
        RandomFunctions.TurnOffGrapple();
    }
    public void Released()
    {
        contained = false;
        GetComponent<Renderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        rb.isKinematic = false;
        transform.parent = null;
        GrapplingHook.canGraple = true;
    }

    public bool ChangeDown(Vector2 downVector)
    {
        if (downDir == downVector.normalized)
        {
            return true;
        }
        downVector = downVector.normalized;
        downDir = downVector;
        rightDir = new Vector2(-downVector.y, downVector.x);
        Physics2D.gravity = downVector * 9.81f;

        float neg = 1;
        if (downVector.x < 0) { neg *= -1; }
        cam.RotateCamera(neg * Mathf.Acos(Vector2.Dot(downVector, Vector2.down)));
        return false;
    }
    public bool ChangeDown(Vector2 downVector, float newGravity)
    {
        if (downDir == downVector.normalized && Physics2D.gravity.magnitude == newGravity)
        {
            return true;
        }
        downVector = downVector.normalized;
        downDir = downVector;
        rightDir = new Vector2(-downVector.y, downVector.x);
        Physics2D.gravity = downVector * newGravity * 9.81f;

        float neg = 1;
        if (downVector.x < 0) { neg *= -1; }
        cam.RotateCamera(neg * Mathf.Acos(Vector2.Dot(downVector, Vector2.down)));
        return false;
    }

    

    public void ReturntoMenu()
    {
        GameManager.menuManager.SetTimeScale(1);
        GameManager.menuManager.LoadScene("Main Menu");
    }

}


public interface IAction
{
    public void Begin();
    public void Finish();
}
