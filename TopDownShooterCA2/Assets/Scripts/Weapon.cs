using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Magazine;//current number of bullets
    public int MaxMagazine;//max number of bullets that can be in the magazine

    public int Reserves;//current reserves
    public int MaxReserves;//max number of bullets that can be in the reserves

    public int AmmoPerShot;//number of bullets used every time the weapon is fired
    public bool IsAutomatic;

    public GameObject BulletPrefab;//bullet to instantiate
    public Transform Spawn;

    void Start()
    {
        Magazine = MaxMagazine;
        Reserves = MaxReserves;
    }

    public bool HasAmmo()
    {
        //is the current number of bullets greater than or equal to the ammount of ammo user per shot
        return Magazine >= AmmoPerShot;
    }

    public void Reload()
    {
        //are there enough bullets in reseves to fill the magazine?
        if(Reserves >= MaxMagazine)
        {
            //determine the required number of bullets
            int required = MaxMagazine - Magazine;

            Magazine += required;//fill magazine
            Reserves -= required;//update reserves
        }
        else//not enough in reserves to fully fill the magazine
        {
            Magazine = Reserves;//load whatever number we have
            Reserves = 0;
        }
    }

    //virtual indicates that this method can be extended in a child class
    public virtual void Fire(Vector3 fireFromPosition)
    {
        //bullets have been fired before this code is executed

        Magazine -= AmmoPerShot;

        if(Magazine <= 0)
        {
            Reload();
        }
    }
}
