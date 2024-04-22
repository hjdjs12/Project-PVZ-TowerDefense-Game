using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon_Bullet : MonoBehaviour
{
    private float speed = 7;
    private int atkValue = 30;
    public GameObject cannonBulletHitPrefab;
    public GameObject nearestZombie = null;
    public Vector3 nearesrPosition = Vector3.zero;
    public Vector3 direction = Vector3.up;

    private void Start()
    {

        Destroy(gameObject, 10);

        //Debug.Log(this.transform.position);
    }
    private void Awake()
    {
        //SearchForNearestZombie();
    }
    public void SetATKValue(int atkvalue)
    {
        this.atkValue = atkvalue;

    }
    public void SearchForNearestZombie()
    {
        float minDistance = Mathf.Infinity;
        foreach (GameObject prefab in ZombieManager.Instance.zombieList)
        {
            //Debug.Log(prefab.transform.position);
            float distance = Vector3.Distance(prefab.transform.position, this.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestZombie = prefab;
            }
        }
        nearesrPosition = nearestZombie.transform.position;
        direction = nearesrPosition - this.transform.position;
        direction = transform.InverseTransformDirection(direction);
        Debug.Log(nearestZombie.transform.position);
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
        transform.Translate( direction.normalized * speed * Time.deltaTime); 
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Zombie")
        {
            Destroy(gameObject);
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            GameObject go = GameObject.Instantiate(cannonBulletHitPrefab, transform.position, Quaternion.identity);
            Destroy(go, 1);
        }
    }
}