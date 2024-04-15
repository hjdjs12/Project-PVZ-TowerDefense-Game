using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon1 : Plant
{
    public float shootDuration = 2;
    private float shootTimer = 0;
    public Transform shootPointTransform;
    public Cannon_Bullet cannonBulletPrefab;
    public float bulletSpeed = 50;
    public int atkValue = 20;

    public GameObject cannonBulletHitPrefab;
    public GameObject nearestZombie = null;
    public Vector3 nearesrPosition = Vector3.zero;
    public Vector3 direction = Vector3.up;
    protected override void EnableUpdate()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootDuration)
        {
            shootTimer = 0;
            Shoot();

        }
    }
    public void Shoot()
    {
        this.transform.rotation = Quaternion.identity;
        SearchForNearestZombie();
        if(nearestZombie == null) { return; }
        nearesrPosition = nearestZombie.transform.position;
        Enemy1 tmp = nearestZombie.GetComponent<Enemy1>();
        if (tmp == null) { Debug.Log("aaa"); }
        if (tmp.currentDirection == Direction.up)
        {
            nearesrPosition.y += tmp.collider.bounds.size.y/2f * tmp.moveSpeed/5;
        }
        else if (tmp.currentDirection == Direction.down)
        {
            nearesrPosition.y -= tmp.collider.bounds.size.y/2f;
        }
        else if (tmp.currentDirection == Direction.left)
        {
            nearesrPosition.x -= tmp.collider.bounds.size.x/2f;
        }
        else
        {
            nearesrPosition.x += tmp.collider.bounds.size.x/2f;
        }
        direction = nearesrPosition - shootPointTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle-90);
        rotation *= Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);

        Vector3 localRotationAxis = transform.InverseTransformDirection(rotation.eulerAngles);
        Quaternion localRotation = Quaternion.AngleAxis(localRotationAxis.z, transform.forward);

        Cannon_Bullet pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position+direction.normalized),localRotation);
        pb.SetDirection(this.direction);
        this.transform.rotation = localRotation;
        pb.SetSpeed(bulletSpeed);
        pb.SetATKValue(atkValue);    

    }
    public void SearchForNearestZombie()
    {
        float minDistance = Mathf.Infinity;
        //foreach (GameObject prefab in ZombieManager.Instance.zombieList)'
        for(int i = 0; i < ZombieManager.Instance.zombieList.Count;i++)
        {
            GameObject prefab = ZombieManager.Instance.zombieList[i];
            //Debug.Log(prefab.transform.position);
            float distance = Vector3.Distance(prefab.transform.position, shootPointTransform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestZombie = prefab;

            }
        }
        if(nearestZombie == null) { return; }
        nearesrPosition = nearestZombie.transform.position;
        direction = nearesrPosition - shootPointTransform.position;
        //Debug.Log(nearestZombie.transform.position);
    }
}
