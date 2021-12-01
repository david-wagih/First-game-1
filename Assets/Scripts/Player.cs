using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     ************************* ISSUES **********************************
     1- I guess the variable naming of Attacking and isAttacking is a bit confusing, maybe change it to something related to animation such as isAttackingAnimation
     
     */
    
    
    private int health =100;
    


    //Attacking modification parameters
    private GameObject attackArea = default;
    private float timeToAttack = 0.25f; //time between two successive attacks
    private float timer = 0f;

    //Components of Player
    private Animator anim;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private CapsuleCollider2D coll;

    //Animation related stuff
    private string ATTACKING_ANIMATION = "isAttacking"; //Animation Parameter to indicate character is attacking

    //State Variables
    private bool attacking = false;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        playerAttack();
    }

    int getHealth()
    {
        return health;
    }

    void setHealth(int health)
    {
        this.health = health;
    }

    void playerAttack()
    {
        if (Input.GetButtonDown("Fire1") && !attacking)   //Fire1 is set to default to mouse left click
        {
            anim.SetBool(ATTACKING_ANIMATION, true);        //Condition to Attack
            attacking = true;
            attackArea.SetActive(attacking);
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                anim.SetBool(ATTACKING_ANIMATION, false);
            }
        }
        
    }









}
