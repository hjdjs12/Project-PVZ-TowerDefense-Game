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
    public float atkValue = 20;
    public float minDistance = Mathf.Infinity;

    public GameObject cannonBulletHitPrefab;
    public GameObject nearestZombie = null;
    public Vector3 nearesrPosition = Vector3.zero;
    public Vector3 direction = Vector3.up;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    protected override void EnableUpdate()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDuration)
        {
            shootTimer = 0;
            Shoot();

        }
    }
    public void Shoot()
    {
        this.transform.rotation = Quaternion.identity;
        SearchForNearestZombie();
        if(nearestZombie == null) {shootTimer = shootDuration; return; }
        nearesrPosition = nearestZombie.transform.position;
        Enemy1 tmp = nearestZombie.GetComponent<Enemy1>();
        if (tmp == null) { return; }
        if (audioSource != null)
        {
            audioSource.time = 0.35f;
            audioSource.Play();
        }

        if (tmp.currentDirection == Direction.up)
        {
            nearesrPosition.y += tmp.moveSpeed *(minDistance/ bulletSpeed)*0.8f;
        }
        else if (tmp.currentDirection == Direction.down)
        {
            nearesrPosition.y += tmp.moveSpeed*0.15f;
        }
        else if (tmp.currentDirection == Direction.left)
        {
            nearesrPosition.x -=  tmp.moveSpeed *(minDistance / bulletSpeed) * 0.6f;
        }
        else
        {
            nearesrPosition.x += tmp.moveSpeed *(minDistance / bulletSpeed) * 0.6f;
        }
        direction = nearesrPosition - shootPointTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle-84f);
        rotation *= Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);

        Vector3 localRotationAxis = transform.InverseTransformDirection(rotation.eulerAngles);
        Quaternion localRotation = Quaternion.AngleAxis(localRotationAxis.z, transform.forward);
        Cannon_Bullet pb;

        if (base.plantType == PlantType.FireShooter)
        {
           pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + direction.normalized*4 - Vector3.Cross(direction.normalized,Vector3.forward).normalized/2), localRotation);
        }
        else if(base.plantType == PlantType.CircleCannon1)
        {
            pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + direction.normalized), localRotation);
            for (int i = 1; i <= 3; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, 15 * i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }
            for (int i = 1; i < 3; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, -15 * i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }
        }
        else if(base.plantType == PlantType.CircleCannon2)
        {
            pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + direction.normalized), localRotation);
            for (int i = 1; i <= 6; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, 15 * i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }
            for (int i = 1; i < 6; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, -15 * i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }

        }
        else if(base.plantType == PlantType.CircleCannon3)
        {
            pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + direction.normalized), localRotation);
            for (int i = 1; i<= 12; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, 15*i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, 15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }
            for (int i = 1; i < 12; i++)
            {
                Cannon_Bullet pb1;
                Vector3 rotatedDirection = Quaternion.Euler(new Vector3(0, 0, -15 * i)) * direction;
                pb1 = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + rotatedDirection.normalized), localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)));
                pb1.SetDirection(localRotation * Quaternion.Euler(new Vector3(0, 0, -15 * i)) * Vector3.up);
                pb1.SetSpeed(bulletSpeed);
                pb1.SetATKValue(atkValue);
            }


        }
        else
        {

            pb = GameObject.Instantiate(cannonBulletPrefab, (this.transform.position + direction.normalized), localRotation);

        }
        nearestZombie = null;
        if (base.plantType == PlantType.Missle1)
        {
            pb.isMustiple = true;
        }
        if (base.plantType == PlantType.Missle2)
        {
            pb.isTriangle = true;
        }
        if (base.plantType == PlantType.Missle3)
        {
            pb.isMax = true;
        }
        if (base.plantType == PlantType.CardFreeze1)
        {
            pb.isFreeze1 = true;
        }
        if (base.plantType == PlantType.CardFreeze2)
        {
            pb.isFreeze2 = true;
        }
        if (base.plantType == PlantType.CardFreeze3)
        {
            pb.isFreeze3 = true;
        }
        pb.SetDirection(localRotation*Vector3.up);
        this.transform.rotation = localRotation;
        pb.SetSpeed(bulletSpeed);
        pb.SetATKValue(atkValue);    

    }
    public void SearchForNearestZombie()
    {
        minDistance = Mathf.Infinity;
        //foreach (GameObject prefab in ZombieManager.Instance.zombieList)'
        for(int i = 0; i < ZombieManager.Instance.zombieList.Count;i++)
        {
            GameObject prefab = ZombieManager.Instance.zombieList[i];
            //Debug.Log(prefab.transform.position);
            if(prefab == null||prefab.GetComponent<Zombie>().isHide)
            {
                continue;
            }
            float distance = Vector3.Distance(prefab.transform.position, this.transform.position);

            if (distance < minDistance && distance <=8 )
            {
                minDistance = distance;
                nearestZombie = prefab;

            }
        }
        if(nearestZombie == null) { return; }
    }


}
