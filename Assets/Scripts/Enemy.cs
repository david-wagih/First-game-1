using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      [SerializeField]
      private float moveForce = 10f;

      [SerializeField]
      private float jumpForce = 11f;

      private float movementX;

      private Rigidbody2D myBody;

      private SpriteRenderer sr;
      private Animator anim;

      private bool isGrounded;
      private string WALK_ANIMATION = "Walk";


      // [SerializeField]
      // Transform player;

      // [SerializeField]
      // float agroRange;

      // [SerializeField]
      // public float moveSpeed;

      // private int health = 25;
      // private Animator anim;
      // private Rigidbody2D myBody;
      // private SpriteRenderer sr;
      // private CapsuleCollider2D coll;


      private void Awake()
      {
            myBody = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
      }
      // Start is called before the first frame update
      void Start()
      {

      }


      // Update is called once per frame
      void Update()
      {

            EnemyMoveKeyboard();
            AnimateEnemy();
            EnemyJump();

            // float distToPlayer = Vector2.Distance(transform.position, player.position);
            // if (distToPlayer < agroRange)
            // {
            //       ChasePlayer();
            // }
            // else
            // {
            //       StopChasingPlayer();
            // }
      }

      void EnemyMoveKeyboard()
      {
            movementX = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

      }

      void AnimateEnemy()
      {
            if (movementX > 0)
            // we are going to right
            {
                  sr.flipX = false;
                  anim.SetBool(WALK_ANIMATION, true);
            }
            else if (movementX < 0)
            // we are going to left
            {
                  sr.flipX = true;
                  anim.SetBool(WALK_ANIMATION, true);
            }
            else
            // we are not moving
            {
                  anim.SetBool(WALK_ANIMATION, false);
            }
      }

      void EnemyJump()
      {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                  myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                  isGrounded = false;
            }
      }

      private void OnCollisionEnter2D(Collision2D collision)
      {
            if (collision.gameObject.tag == "Ground")
            {
                  isGrounded = true;
            }
      }

      // void ChasePlayer()
      // {
      // if (transform.position.x < player.position.x)
      // {
      // enemy is to the left of player, so move right
      //       myBody.velocity = new Vector2(moveSpeed, 0);
      // the enemy is facing right
      //       transform.localScale = new Vector2(1, 1);

      // }
      // else
      // {
      // enemy is to the right of player, so move left
      //       myBody.velocity = new Vector2(-moveSpeed, 0);
      // the enemy is facing left
      //       transform.localScale = new Vector2(-1, 1);
      // }
      // }
      // void StopChasingPlayer()
      // {
      //       myBody.velocity = new Vector2(0, 0);
      // }

      // int getHealth()
      // {
      //       return health;
      // }

      // void setHealth(int health)
      // {
      //       this.health = health;
      // }

}