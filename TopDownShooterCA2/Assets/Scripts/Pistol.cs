using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Fire(Vector3 fireFromPosition)
    {
        //create a clone of the bullet prefab
        GameObject projectile = Instantiate(BulletPrefab, fireFromPosition, Quaternion.identity);

        Bullet bullet = projectile.GetComponent<Bullet>();
        //fire the bullet in the direction the gun is facing
        bullet.SetDirection(transform.up);

        base.Fire(fireFromPosition);
    }
}
