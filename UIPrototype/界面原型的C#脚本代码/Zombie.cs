using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

enum ZombieState 
{ 
    Move,
    Eat,
    Die
}

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    ZombieState zombieState = ZombieState.Move;
    private Rigidbody2D rgd;//¸ÕÌå×é¼þ
    public float moveSpeed = 1;
    private Animator anim;
    public int atkValue = 30;
    public float atkDuration = 2;
    private float atkTimer = 0;

    private Plant curentEatPlant;
    public GameObject zombieHeadPrefab;
    private bool haveHead = true;
    
    
    public int Hp = 100;
    private int currentHP;
    void Start()
    {

        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        switch (zombieState){ 
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eat:
                EatUpdate();
                break;
            case ZombieState.Die:
                break;
            default:
                break;
        }   
    }
    void MoveUpdate()
    {
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }
    void EatUpdate()
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= atkDuration && curentEatPlant != null)
        {
            atkTimer = 0;
            curentEatPlant.TakeDamage(atkValue);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", true);
            TransitionToEat();
            curentEatPlant = collision.GetComponent<Plant>();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = ZombieState.Move;
        }
    }
    void TransitionToEat()
    {
        atkTimer = 0;
        zombieState = ZombieState.Eat;
    }

    public void TakeDamage(int damage)
    {
        if (currentHP <= 0) { return; }
        this.currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = -1;
            Dead();
        }
        float hpPercent = currentHP * 1f / Hp;
        anim.SetFloat("HPPercent", hpPercent);
        if(hpPercent < 0.5f && haveHead)
        {
            haveHead = false;
            GameObject go = GameObject.Instantiate(zombieHeadPrefab, transform.position,Quaternion.identity);
            Destroy(go,2);
        }

    }
    private void Dead()
    {
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject,2);
    }
}
