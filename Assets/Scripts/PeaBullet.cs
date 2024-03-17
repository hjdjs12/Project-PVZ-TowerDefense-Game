using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3;
    private int atkValue = 30;
    public GameObject peaBulletHitPrefab;

    private void Start()
    {
        Destroy(gameObject,10);
    }
    public void SetATKValue(int atkvalue)
    {
        this.atkValue = atkvalue;
    }
    public  void SetSpeed(float speed)
    {
        this.speed = speed; ;
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); ;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Zombie")
        {
            Destroy(gameObject);
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            GameObject go = GameObject.Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity);
            Destroy(go,1);
        }
    }
}
