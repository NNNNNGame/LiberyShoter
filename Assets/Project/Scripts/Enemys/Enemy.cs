using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour,ILivingObject
{
    public float visibilityRadius = 10;

    private GameObject _hostilObject;

    public float speed;
    
    public int health = 100;

    public int demage;
    
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = gameObject.AddComponent<NavMeshAgent>();
    }

    private void AssignmentHostilObject()
    {
        if (_hostilObject == null)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, visibilityRadius, transform.position,0f);

            if (hit.collider.gameObject.GetComponent<Player>() != null)
            {
                _hostilObject = hit.collider.gameObject;

            }
        }
    }

    private void Attack()
    {
        
    }

    private void GoToHostilObject()
    {
        if (Vector2.Distance(transform.position,_hostilObject.transform.position) < 3)
        {
            _agent.SetDestination(_hostilObject.transform.position);
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        AssignmentHostilObject();
        
        if (_hostilObject)
        {
            GoToHostilObject();
        }
    }
}
