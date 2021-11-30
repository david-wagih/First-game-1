using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

      private int health = 25;



      private Animator anim;
      private Rigidbody2D myBody;
      private SpriteRenderer sr;
      private CapsuleCollider2D coll;


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

      }

      // Update is called once per frame
      void Update()
      {

      }

      int getHealth()
      {
            return health;
      }

      void setHealth(int health)
      {
            this.health = health;
      }

}