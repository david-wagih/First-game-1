using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
      [SerializeField]
      private GameObject[] enemies;

      private GameObject spawnedEnemy;

      private int randomSide;

      [SerializeField]
      private Transform leftpos, rightpos;


      // Start is called before the first frame update
      void Start()
      {
            StartCoroutine(SpawnEnemy());

      }

      IEnumerator SpawnEnemy()
      {
            yield return new WaitForSeconds(Random.Range(1, 5));
            //randomIndex = Random.Range(0, enemies.Length);
            randomSide = Random.Range(0, 2);
            spawnedEnemy = Instantiate(enemies[0]);
            // left 
            if (randomSide == 0)
            {
                  spawnedEnemy.transform.position = leftpos.position;
            }
            // right
            else
            {
                  spawnedEnemy.transform.position = rightpos.position;
            }
      }
}
