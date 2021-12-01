using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

      private Transform Enemy;


      [SerializeField]
      private float minX, maxX;
      private Vector3 temppos;

      // Start is called before the first frame update
      void Start()
      {
            Enemy = GameObject.FindWithTag("Enemy").transform;

      }

      // Update is called once per frame
      void LateUpdate()
      {
            temppos = transform.position;
            temppos.x = Enemy.position.x;

            if (temppos.x < minX)
                  temppos.x = minX;

            if (temppos.x > maxX)
                  temppos.x = maxX;

            transform.position = temppos;
      }
}
