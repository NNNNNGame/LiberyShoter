using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour,ILivingObject
{
    [SerializeField] private float speed;

    private InputNew _inputNew;

    public List<Thing> things = new List<Thing>();

    public List<Weapon> weapons = new List<Weapon>();

    public Weapon chosenWeapon;

    public int health = 100;
        
    private void Awake() 
    {
        _inputNew = new InputNew();

        _inputNew.Main.Attack.performed += context => Attack();
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

    private void OnEnable()
    {
        _inputNew.Enable();
    }

    private void OnDisable()
    {
        _inputNew.Disable();
    }

    virtual public void Move()
    {
        transform.Translate(speed * _inputNew.Main.Move.ReadValue<Vector2>() * Time.deltaTime);
    }

    private void Attack()
    {
        if (chosenWeapon != null)
        {
            chosenWeapon.Attack();
            Debug.Log("dddrrrrrrrrrrrrrrrr");
        }
    }
    
    private void Update()
    {
        Move();
    }
    
    
}
