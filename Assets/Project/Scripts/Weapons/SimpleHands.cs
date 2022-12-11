using System;
using UnityEngine;

public class SimpleHands : Weapon
{
    private bool isAttack = false;
    
    public override void Attack()
    {
        isAttack = true;
    }

    private void Update()
    {
        isAttack = false;
    }


    private void OnTrigerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ILivingObject>() != null)
        {
            collision.gameObject.GetComponent<ILivingObject>().Damage(damage);
            Debug.Log("ddddd");
        }
    }
}
