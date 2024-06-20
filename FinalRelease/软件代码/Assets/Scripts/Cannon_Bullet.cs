using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon_Bullet : MonoBehaviour
{
    public float speed = 7;
    private float atkValue = 30;
    public GameObject cannonBulletHitPrefab;
    public GameObject nearestZombie = null;
    public GameObject nearestZombie2= null;
    public GameObject nearestZombie3= null;
    public GameObject nearestZombie4= null;
    public GameObject nearestZombie5= null;
    public GameObject nearestZombie6= null;
    public GameObject nearestZombie7= null;
    public Vector3 nearesrPosition = Vector3.zero;
    public Vector3 direction = Vector3.up;
    public bool isMustiple = false;
    public bool isTriangle = false;
    public bool isMax = false;
    public bool isFire = false;
    public bool isBounce = false;
    public float fireDuration;
    public float maxFireDuration;
    public float BounceDuration = 10;
    public float BounceTimer = 0;
    private bool hasAttacked = false;
    public bool isLinear = false;
    public bool isFreeze1 = false;
    public bool isFreeze2 = false;
    public bool isFreeze3 = false;
    public List<GameObject> LinearHit;

    private void Start()
    {
        if (!isFire)
        {
            Destroy(gameObject, 15);
        }
        else
        {
            
            Destroy(gameObject, 5);
        }

        //Debug.Log(this.transform.position);
    }
    private void Awake()
    {
        //SearchForNearestZombie();
    }
    public void SetATKValue(float atkvalue)
    {
        this.atkValue = atkvalue;

    }
    public void SearchForNearestZombie()
    {
        float minDistance = Mathf.Infinity;
        foreach (GameObject prefab in ZombieManager.Instance.zombieList)
        {
            //Debug.Log(prefab.transform.position);
            if (prefab == null) { continue; }
            float distance = Vector3.Distance(prefab.transform.position, this.transform.position);
            if (distance < minDistance && distance <= 7)
            {
                minDistance = distance;
                nearestZombie = prefab;
            }
        }
    }

    public void SearchForNearestZombie3()
    {
        float minDistance = Mathf.Infinity;
        float minDistance2 = Mathf.Infinity;
        float minDistance3 = Mathf.Infinity;
        foreach (GameObject prefab in ZombieManager.Instance.zombieList)
        {
            //Debug.Log(prefab.transform.position);
            if (prefab == null) { continue; }
            float distance = Vector3.Distance(prefab.transform.position, nearestZombie.transform.position);
            if (prefab == nearestZombie) { continue; }
            //if (distance < minDistance && distance <=15)
            //{
            //    nearestZombie3 = nearestZombie2;
            //    minDistance3 = minDistance2;
            //    nearestZombie2 = nearestZombie;
            //    minDistance2 = minDistance;
            //    nearestZombie = prefab;
            //    minDistance = distance;

            //}
             if (distance <= minDistance2 )
            {
                nearestZombie3 = nearestZombie2;
                minDistance3 = minDistance2;
                nearestZombie2 = prefab;
                minDistance2 = distance;
            }
            else if (distance <= minDistance3)
            {
                nearestZombie3 = prefab;
                minDistance3 = distance;
            }
        }

    }

    public void SearchForNearestZombie5()
    {
        float minDistance = Mathf.Infinity;
        float minDistance2 = Mathf.Infinity;
        float minDistance3 = Mathf.Infinity;
        float minDistance4 = Mathf.Infinity;
        float minDistance5 = Mathf.Infinity;
        foreach (GameObject prefab in ZombieManager.Instance.zombieList)
        {
            //Debug.Log(prefab.transform.position);
            if (prefab == null) { continue; }
            float distance = Vector3.Distance(prefab.transform.position, nearestZombie.transform.position);
            if (prefab == nearestZombie) { continue; }
            //if (distance < minDistance && distance <= 15)
            //{
            //    nearestZombie5 = nearestZombie4;
            //    minDistance5 = minDistance4;
            //    nearestZombie4 = nearestZombie3;
            //    minDistance4 = minDistance3;
            //    nearestZombie3 = nearestZombie2;
            //    minDistance3 = minDistance2;
            //    nearestZombie2 = nearestZombie;
            //    minDistance2 = minDistance;
            //    nearestZombie = prefab;
            //    minDistance = distance;

            //}
            if (distance < minDistance2 && distance <=15)
            {
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = nearestZombie3;
                minDistance4 = minDistance3;
                nearestZombie3 = nearestZombie2;
                minDistance3 = minDistance2;
                nearestZombie2 = prefab;
                minDistance2 = distance;
            }
            else if (distance < minDistance3 && distance <= 15)
            {
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = nearestZombie3;
                minDistance4 = minDistance3;
                nearestZombie3 = prefab;
                minDistance3 = distance;
            }
            else if (distance < minDistance4 && distance <= 15)
            {
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = prefab;
                minDistance4 = distance;
            }
            else if (distance < minDistance5 && distance <= 15)
            {
                nearestZombie5 = prefab;
                minDistance5 = distance;
            }
        }

    }

    public void SearchForNearestZombie7()
    {
        float minDistance = Mathf.Infinity;
        float minDistance2 = Mathf.Infinity;
        float minDistance3 = Mathf.Infinity;
        float minDistance4 = Mathf.Infinity;
        float minDistance5 = Mathf.Infinity;
        float minDistance6 = Mathf.Infinity;
        float minDistance7 = Mathf.Infinity;
        foreach (GameObject prefab in ZombieManager.Instance.zombieList)
        {
            //Debug.Log(prefab.transform.position);
            if (prefab == null) { continue; }
            float distance = Vector3.Distance(prefab.transform.position, nearestZombie.transform.position);
            if (prefab == nearestZombie) { continue; }
            //if (distance < minDistance && distance <= 15)
            //{
            //    nearestZombie7 = nearestZombie6;
            //    minDistance7 = minDistance6;
            //    nearestZombie6 = nearestZombie5;
            //    minDistance6 = minDistance5;
            //    nearestZombie5 = nearestZombie4;
            //    minDistance5 = minDistance4;
            //    nearestZombie4 = nearestZombie3;
            //    minDistance4 = minDistance3;
            //    nearestZombie3 = nearestZombie2;
            //    minDistance3 = minDistance2;
            //    nearestZombie2 = nearestZombie;
            //    minDistance2 = minDistance;
            //    nearestZombie = prefab;
            //    minDistance = distance;

            //}
            if (distance < minDistance2 && distance <= 15)
            {
                nearestZombie7 = nearestZombie6;
                minDistance7 = minDistance6;
                nearestZombie6 = nearestZombie5;
                minDistance6 = minDistance5;
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = nearestZombie3;
                minDistance4 = minDistance3;
                nearestZombie3 = nearestZombie2;
                minDistance3 = minDistance2;
                nearestZombie2 = prefab;
                minDistance2 = distance;
            }
            else if (distance < minDistance3 && distance <= 15)
            {
                nearestZombie7 = nearestZombie6;
                minDistance7 = minDistance6;
                nearestZombie6 = nearestZombie5;
                minDistance6 = minDistance5;
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = nearestZombie3;
                minDistance4 = minDistance3;
                nearestZombie3 = prefab;
                minDistance3 = distance;
            }
            else if (distance < minDistance4 && distance <= 15)
            {
                nearestZombie7 = nearestZombie6;
                minDistance7 = minDistance6;
                nearestZombie6 = nearestZombie5;
                minDistance6 = minDistance5;
                nearestZombie5 = nearestZombie4;
                minDistance5 = minDistance4;
                nearestZombie4 = prefab;
                minDistance4 = distance;
            }
            else if (distance < minDistance5 && distance <= 15)
            {
                nearestZombie7 = nearestZombie6;
                minDistance7 = minDistance6;
                nearestZombie6 = nearestZombie5;
                minDistance6 = minDistance5;
                nearestZombie5 = prefab;
                minDistance5 = distance;
            }
            else if (distance < minDistance6 && distance <= 15)
            {
                nearestZombie7 = nearestZombie6;
                minDistance7 = minDistance6;
                nearestZombie6 = prefab;
                minDistance6 = distance;
            }
            else if (distance < minDistance7 && distance <= 15)
            {

                nearestZombie7 = prefab;
                minDistance7 = distance;
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed; ;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = transform.InverseTransformDirection(direction);
    }
    private void Update()
    {

        //Quaternion targetRotation = Quaternion.LookRotation(direction);
        //float angle = Vector3.Angle(direction, this.transform.forward);
        if (!isFire)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        if (isBounce)
        {
            BounceTimer += Time.deltaTime;
            if(BounceTimer >= BounceDuration)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            //if (!isFire && gameObject != null)
            //{
            //    Destroy(gameObject);
            //}
            if (!isFire) { return; }
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            //nearestZombie = collision.gameObject;
            //if (isMustiple)
            //{
            //    Debug.Log("hit");
            //    SearchForNearestZombie3();
            //    if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
            //}
            //else if (isTriangle)
            //{
            //    SearchForNearestZombie5();
            //    if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().TakeDamage(atkValue); }
            //}
            //else if (isMax)
            //{
            //    SearchForNearestZombie7();
            //    if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie6 != null) { nearestZombie6.GetComponent<Zombie>().TakeDamage(atkValue); }
            //    if (nearestZombie7 != null) { nearestZombie7.GetComponent<Zombie>().TakeDamage(atkValue); }
            //}

            //GameObject go = GameObject.Instantiate(cannonBulletHitPrefab, transform.position, Quaternion.identity);
            //Destroy(go, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFire) { return; }
        if (collision.tag == "Zombie")
        {
            if (!isFire && gameObject != null&& !isBounce&&!isLinear)
            {
                Destroy(gameObject);
            }
            if (isLinear)
            {
                if (!LinearHit.Contains(collision.gameObject))
                {
                    collision.GetComponent<Zombie>().TakeDamage(atkValue);
                    LinearHit.Add(collision.gameObject);
                }
                return;
            }
            if (!hasAttacked)
            {
                collision.GetComponent<Zombie>().TakeDamage(atkValue);
                hasAttacked = true;
            }
            nearestZombie = collision.gameObject;
            if (isMustiple)
            {
                SearchForNearestZombie3();
                if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
            }
            else if (isTriangle)
            {
                SearchForNearestZombie5();
                if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().TakeDamage(atkValue); }
            }
            else if (isMax)
            {
                SearchForNearestZombie7();
                if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie6 != null) { nearestZombie6.GetComponent<Zombie>().TakeDamage(atkValue); }
                if (nearestZombie7 != null) { nearestZombie7.GetComponent<Zombie>().TakeDamage(atkValue); }
            }
            else if (isFreeze1)
            {
                
                nearestZombie.GetComponent<Zombie>().moveSpeed = 0;
                nearestZombie.GetComponent<Zombie>().delayRecoverSpeed();
            }
            else if (isFreeze2)
            {
                SearchForNearestZombie3();
                nearestZombie.GetComponent<Zombie>().moveSpeed = 0;
                nearestZombie.GetComponent<Zombie>().delayRecoverSpeed();
                if (nearestZombie2 != null)
                {
                    nearestZombie2.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie2.GetComponent<Zombie>().delayRecoverSpeed();
                }
                if (nearestZombie3 != null)
                {
                    nearestZombie3.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie3.GetComponent<Zombie>().delayRecoverSpeed();
                }
            }
            else if (isFreeze3)
            {
                SearchForNearestZombie5();
                nearestZombie.GetComponent<Zombie>().moveSpeed = 0;
                nearestZombie.GetComponent<Zombie>().delayRecoverSpeed();
                if (nearestZombie2 != null)
                {
                    nearestZombie2.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie2.GetComponent<Zombie>().delayRecoverSpeed();
                }
                if (nearestZombie3 != null)
                {
                    nearestZombie3.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie3.GetComponent<Zombie>().delayRecoverSpeed();
                }
                if (nearestZombie4 != null)
                {
                    nearestZombie4.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie4.GetComponent<Zombie>().delayRecoverSpeed();
                }
                if (nearestZombie5 != null)
                {
                    nearestZombie5.GetComponent<Zombie>().moveSpeed = 0;
                    nearestZombie5.GetComponent<Zombie>().delayRecoverSpeed();
                }
            }
            else if (isBounce)
            {
                hasAttacked = false;
                // 计算碰撞点
                Vector2 collisionPoint = transform.position;

                // 计算碰撞点处的法线
                Vector2 normal = (collisionPoint - (Vector2)collision.transform.position).normalized;

                // 计算反射方向
                Vector2 reflectDirection = Vector2.Reflect(direction.normalized, normal);

                direction = reflectDirection;
            }

            //GameObject go = GameObject.Instantiate(cannonBulletHitPrefab, transform.position, Quaternion.identity);
            //Destroy(go, 1);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision != null)
        {
            if (collision.gameObject != null && collision.GetComponent<Zombie>() != null)
            {
                collision.GetComponent<Zombie>().delayRecover();
            }
        }
        nearestZombie = collision.gameObject;
        if (isMustiple || isFreeze2)
        {
            SearchForNearestZombie3();
            if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().delayRecover(); }
            nearestZombie2 = null;
            nearestZombie3 = null;
        }                                                                       
        else if (isTriangle || isFreeze3)                                                    
        {
            SearchForNearestZombie5();
            if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().delayRecover(); }
            nearestZombie2 = null;
            nearestZombie3 = null;
            nearestZombie4 = null;
            nearestZombie5 = null;
        }                                                                       
        else if (isMax )                                                         
        {
            SearchForNearestZombie7();
            if (nearestZombie2 != null) { nearestZombie2.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie3 != null) { nearestZombie3.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie4 != null) { nearestZombie4.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie5 != null) { nearestZombie5.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie6 != null) { nearestZombie6.GetComponent<Zombie>().delayRecover(); }
            if (nearestZombie7 != null) { nearestZombie7.GetComponent<Zombie>().delayRecover(); }
            nearestZombie2 = null;
            nearestZombie3 = null;
            nearestZombie4 = null;
            nearestZombie5 = null;
            nearestZombie6 = null;
            nearestZombie7 = null;
        }
    }
}