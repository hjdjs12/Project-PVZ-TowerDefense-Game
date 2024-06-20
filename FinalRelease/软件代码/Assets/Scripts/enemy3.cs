using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Zombie
{

    // Start is called before the first frame update
    private float atkTimer2 = 0;
    private float atkTime2 = 5;
    public Energy_attack attack_move;
    private GameObject nearestWeapon;
    private Vector3 nearestPosition;
    public Vector3 direction2 = Vector3.up;
    private void Awake()
    {
        base.Start();
        base.moveSpeed = 5;
        base.Hp = 100;
 
    }
    public Property property;

    private void Update()
    {
        base.Update();
        atkTimer2 += Time.deltaTime;
        if(atkTimer2 > atkTime2) { 
            Attack();
            atkTimer2 = 0;
        }
    }
    private void Attack()
    {
        this.transform.rotation = Quaternion.identity;
        SearchForNearestWeapon();
        if (nearestWeapon == null) { return; }
        float angle = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 180);
        rotation *= Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);

        Vector3 localRotationAxis = transform.InverseTransformDirection(rotation.eulerAngles);
        Quaternion localRotation = Quaternion.AngleAxis(localRotationAxis.z, transform.forward);

        Energy_attack tmp = GameObject.Instantiate(attack_move, (this.transform.position + direction2.normalized), localRotation);
        tmp.setDirection(direction2);
        tmp.setAtkValue(10);
        tmp.setSpeed(10);
        

    }
    private void SearchForNearestWeapon()
    {
        float minDistance = Mathf.Infinity;
        foreach (GameObject prefab in WeaponManager.Instance.weaponList)
        {
            //Debug.Log(prefab.transform.position);
            float distance = Vector3.Distance(prefab.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestWeapon = prefab;

            }
        }
        if(nearestWeapon == null) { return; }
        nearestPosition = nearestWeapon.transform.position;
        direction2 = nearestPosition - transform.position;
    }
    // Update is called once per frame

}
