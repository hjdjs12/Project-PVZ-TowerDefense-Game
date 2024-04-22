using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_attack : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    float speed;
    int atkValue = 10;
    BoxCollider2D collider;
    public GameObject attackHitPrefab;
    private Animator anim;
    private bool isHit = false;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        
    }
    public void setDirection(Vector3 directionFromEnemy)
    {
        this.direction = transform.InverseTransformDirection(directionFromEnemy);
    }
    public void setSpeed(float speedFromEnemy)
    {
        speed = speedFromEnemy;
    }
    public void setAtkValue(int atkValueFromEnemy)
    {
        atkValue = atkValueFromEnemy;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("ishit", true);
            isHit = true;
            Destroy(this.gameObject,0.25f);
            collision.GetComponent<Plant>().TakeDamage(atkValue);
            //GameObject go = GameObject.Instantiate(attackHitPrefab, transform.position + direction.normalized, Quaternion.identity);
            //Destroy(go, 0.2f);
        }
    }
}
