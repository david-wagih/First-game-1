using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    
    [SerializeField]
    private int attackDamage = 20;  //Default attack damage

    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            SampleEnemy enemy = collision.gameObject.GetComponent<SampleEnemy>();
            int currentHealth = enemy.getHealth();
            currentHealth -= attackDamage;
            Debug.Log("Enemy Health is " + currentHealth);
            
            enemy.setHealth(currentHealth);
            
        }
    }
}
