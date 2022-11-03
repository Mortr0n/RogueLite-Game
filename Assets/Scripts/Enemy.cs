using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    [SerializeField] float speed;
    [SerializeField] float hitPoints = 4;

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
        Debug.Log("Attacking the character!");
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
