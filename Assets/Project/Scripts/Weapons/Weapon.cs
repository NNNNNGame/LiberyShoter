using UnityEngine;

public abstract class Weapon : Thing
{
    public int damage = 10;
    
    public abstract void Attack();

    private void RotateToMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90);
    }

    private void Update()
    {
        Debug.Log("ggggg");
        
        RotateToMouse();
    }
}
