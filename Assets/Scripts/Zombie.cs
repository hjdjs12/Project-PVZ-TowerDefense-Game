using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum ZombieState 
{ 
    Move,
    Eat,
    Die
}
public enum Direction
{
    left,
    right,
    up,
    down,
}
public enum Property
{
    Metal,
    Wood,
    Water,
    Fire,
    Earth
}

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    ZombieState zombieState = ZombieState.Move;
    protected Rigidbody2D rgd;//¸ÕÌå×é¼þ
    public float moveSpeed;
    protected Animator anim;
    public int atkValue = 30;
    public float atkDuration = 2;
    protected float atkTimer = 0;

    protected Plant curentEatPlant;
    public GameObject zombieHeadPrefab;
    protected bool haveHead = true;
    public BoxCollider2D collider;
    
    
    public int Hp = 100;
    protected int currentHP;
    public GameObject money;
    public GameObject serum;

    protected Direction[]direction = new Direction[]
    {
        Direction.up,
        Direction.left,
        Direction.down,
        Direction.left,
        Direction.up,
        Direction.left
    };
    protected int directionIndex = 0;
    public Direction currentDirection = Direction.left;
    protected void Start()
    {

        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = Hp;
        collider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    protected void Update()
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
    protected void MoveUpdate()
    {
        switch (currentDirection)
         {
             case Direction.left:
                 rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
                 break;
             case Direction.up:
                 rgd.MovePosition(rgd.position + Vector2.up * moveSpeed * Time.deltaTime);
                break;
             case Direction.down:
                 rgd.MovePosition(rgd.position + Vector2.down* moveSpeed * Time.deltaTime);
                break;
             default: break;
         }


    }
    protected void EatUpdate()
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= atkDuration && curentEatPlant != null)
        {
            atkTimer = 0;
            curentEatPlant.TakeDamage(atkValue);
        }
    }
    protected private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", true);
            TransitionToEat();
            curentEatPlant = collision.GetComponent<Plant>();

        }
        else if (collision.tag == "ChangeDirection")
        {
            currentDirection = direction[directionIndex];
            directionIndex += 1;
        }
    }
    protected private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = ZombieState.Move;
        }


    }
    protected void TransitionToEat()
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
    protected void Dead()
    {

        int randomnumber = UnityEngine.Random.Range(1, 11);

        
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject,2);
        if(randomnumber <= 3)
        {
            ProduceSun();
        }
        if(randomnumber <= 1)
        {
            ProduceSerum();
        }
        ZombieManager.Instance.RemoveZombieFromList(this.gameObject);
    }

    public void ProduceSerum()
    {
        GameObject go = GameObject.Instantiate(serum, transform.position, Quaternion.identity);

    }
    public void ProduceSun()
    {
        GameObject go = GameObject.Instantiate(money, transform.position, Quaternion.identity);
        float distance = UnityEngine.Random.Range(0.3f, 1);
        distance = UnityEngine.Random.Range(0, 2) < 1 ? distance : -distance;
        Vector3 position = transform.position;
        position.x += distance;
        position.z = -1;
        go.GetComponent<Sun>().JumpTo(position);
    }
}
