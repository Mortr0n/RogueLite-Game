using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHp = 1000f;
    public float currentHp = 1000f;
    [SerializeField] StatusBar healthBar;

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Debug.Log("Player is dead!");
            Destroy(gameObject);
        }
        healthBar.SetState((int)currentHp, (int)maxHp);
    }

    public void Heal(float amount)
    {
        if(currentHp <= 0) { return; }

        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
