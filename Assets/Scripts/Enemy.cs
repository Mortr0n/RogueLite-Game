using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;

    [SerializeField] float speed;
    [SerializeField] float hitPoints = 4;
    [SerializeField] float damage = 1;

    Rigidbody2D rgbd2d;

    private void Awake() 
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate() 
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;    
        rgbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log(hitPoints);

        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
