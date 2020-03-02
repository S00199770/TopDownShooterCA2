using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon activeWeapon;
    public Transform AttachPoint;

    void Start()
    {
    }

    private void PickUpWeapon()
    {
        activeWeapon = Instantiate(activeWeapon, transform);
        activeWeapon.transform.position = AttachPoint.position;
    }

    void DropWeapon()
    {

    }

    void Update()
    {
        //if activeWeapon is not null (has teh weapon prefab been cloned)
        if(activeWeapon)
        {
            if(activeWeapon.IsAutomatic)
            {
                if (Input.GetButton("Fire1"))//left mouse button and right controller trigger
                {
                    if (activeWeapon.HasAmmo())
                        activeWeapon.Fire(activeWeapon.Spawn.position);
                }
            }
            else
            {
                if(Input.GetButtonDown("Fire1"))//left mouse button and right controller trigger
                {
                    if (activeWeapon.HasAmmo())
                        activeWeapon.Fire(activeWeapon.Spawn.position);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            activeWeapon = collision.GetComponent<Weapon>();
            PickUpWeapon();

            Destroy(collision.gameObject);
        }
    }
}
