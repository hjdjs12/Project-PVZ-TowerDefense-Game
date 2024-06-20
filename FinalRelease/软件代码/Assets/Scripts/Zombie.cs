using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    Earth,
    Non
}

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    ZombieState zombieState = ZombieState.Move;
    protected Rigidbody2D rgd;//刚体组件
    public float moveSpeed;
    public float moveSpeed2;
    protected Animator anim;
    public int atkValue = 30;
    public float atkDuration = 2;
    protected float atkTimer = 0;
    public Property property = Property.Non;

    protected Plant curentEatPlant;
    public GameObject zombieHeadPrefab;
    protected bool haveHead = true;
    public BoxCollider2D collider;
    public bool isHide = false;
    public bool hideZombie = false;
    public float hideDuration = 5;
    public float simulate = 0;
    public SpriteRenderer spriteRenderer;
    Material material;
    Color color;


    public float Hp ;
    protected float currentHP;
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
    protected Direction[] directionLevel1 = new Direction[]
{
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
        Direction.left,
        Direction.up,
};
    protected Direction[] directionLevel2 = new Direction[]
{

        Direction.left,
        Direction.down,
        Direction.left,

};
    protected Direction[] directionLevel3 = new Direction[]
{
        Direction.down,
        Direction.left,
        Direction.up,
        Direction.left,

};
    protected Direction[] directionLevel5 = new Direction[]
{
        Direction.down,
        Direction.left,
        Direction.down,
        Direction.left,
        Direction.down,
        Direction.left,
        Direction.up,
        Direction.right,
        Direction.up,
        Direction.left
};
    protected int directionIndex = 0;
    public Direction currentDirection = Direction.left;
    protected void Start()
    {
        moveSpeed2 = moveSpeed;
        if (SceneManager.GetActiveScene().name == "LevelScene1")
        {
            currentDirection = Direction.up;
        }
        if (SceneManager.GetActiveScene().name == "LevelScene2")
        {
            currentDirection = Direction.up;
        }
        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = Hp;
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;

    }

    // Update is called once per frame
    protected void Update()
    {
        if (hideZombie)
        {
            simulate += Time.deltaTime;
            if (simulate > hideDuration) { 
                simulate = 0;
                if (isHide)
                {
                    Debug.Log("Dishide");
                    isHide = false;
                    color = material.color;
                    color.a = 1f;
                    material.color = color;
                    ZombieManager.Instance.zombieList.Add(this.gameObject);
                }
                else
                {
                    Debug.Log("hide");
                    isHide = true;
                    color = material.color;
                    color.a = 0.3f;
                    material.color = color;
                    ZombieManager.Instance.zombieList.Remove(this.gameObject);
                }
            }
        }
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
            case Direction.right:
                rgd.MovePosition(rgd.position + Vector2.right * moveSpeed * Time.deltaTime);
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
        else if (collision.tag == "ChangeDirectionLevel1")
        {
            currentDirection = directionLevel1[directionIndex];
            directionIndex += 1;
        }
        else if (collision.tag == "ChangeDirectionLevel2")
        {
            currentDirection = directionLevel2[directionIndex];
            directionIndex += 1;
        }
        else if (collision.tag == "ChangeDirectionLevel3")
        {
            currentDirection = directionLevel3[directionIndex];
            directionIndex += 1;
        }
        else if (collision.tag == "ChangeDirection5")
        {
            currentDirection = directionLevel5[directionIndex];
            directionIndex += 1;
        }
        else if (collision.tag == "finalDirection")
        {
            String user = PlayerPrefs.GetString("userName");
            if (SceneManager.GetActiveScene().name == "GameScene") {
                
                ssButton.Instance.PutSurvivalData(user, "", (int)SceneController.Instance.totalTime);
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "LevelScene1") {
                    ssButton.Instance.PutLevelData(user, 1, (int)BackEnergy.Instance.backtotalEnergy);
                }
                else if (SceneManager.GetActiveScene().name == "LevelScene2")
                {
                    ssButton.Instance.PutLevelData(user, 2, (int)BackEnergy.Instance.backtotalEnergy);
                }
                else if (SceneManager.GetActiveScene().name == "LevelScene3")
                {
                    ssButton.Instance.PutLevelData(user, 3, (int)BackEnergy.Instance.backtotalEnergy);
                }
                else if (SceneManager.GetActiveScene().name == "LevelScene4")
                {
                    ssButton.Instance.PutLevelData(user, 4, (int)BackEnergy.Instance.backtotalEnergy);
                }
                else if (SceneManager.GetActiveScene().name == "LevelScene5")
                {
                    ssButton.Instance.PutLevelData(user, 5, (int)BackEnergy.Instance.backtotalEnergy);
                }

            }
            SceneManager.LoadScene("GameOverScene",LoadSceneMode.Single);
        }
        else if(collision.tag == "Transition")
        {
            if(collision.gameObject == TransitionManager.Instance.transitonList[0] && TransitionManager.Instance.isOpen)
            {
                this.transform.position = TransitionManager.Instance.transitonList[1].transform.position;
                collider.enabled = false;
                Invoke("recoverTrigger", 2f);
                currentDirection = Direction.up;
                directionIndex = 5;
            }
            else if(collision.gameObject == TransitionManager.Instance.transitonList[1] && TransitionManager.Instance.isOpen)
            {
                this.transform.position = TransitionManager.Instance.transitonList[0].transform.position;
                collider.enabled = false;
                Invoke("recoverTrigger", 2f);
                currentDirection = Direction.left;
                directionIndex = 2;

            }
        }
        else if (collision.tag == "Transition2")
        {
            if (collision.gameObject == TransitionManager.Instance.transitonList[0] && TransitionManager.Instance.isOpen)
            {
                this.transform.position = TransitionManager.Instance.transitonList[1].transform.position;
                collider.enabled = false;
                Invoke("recoverTrigger", 2f);
                currentDirection = Direction.left;
                directionIndex = 10;
            }
            else if (collision.gameObject == TransitionManager.Instance.transitonList[1] && TransitionManager.Instance.isOpen)
            {
                this.transform.position = TransitionManager.Instance.transitonList[0].transform.position;
                collider.enabled = false;
                Invoke("recoverTrigger", 2f);
                currentDirection = Direction.left;
                directionIndex = 6;

            }
        }
    }
    public void recoverTrigger()
    {
        collider.enabled = true;
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

    public void TakeDamage(float damage)
    {

        anim.SetBool("isHurt", true);
        if (currentHP <= 0) { return; }
        //金木水火土
        if(PropertiesManager.Instance.currentProperty == Property.Metal)
        {
            if(property == Property.Wood)
            {
                damage *= 2;
            }
            else if(property == Property.Earth)
            {
                damage /= 2;
            }
        }
        if (PropertiesManager.Instance.currentProperty == Property.Wood)
        {
            if (property == Property.Water)
            {
                damage *= 2;
            }
            else if (property == Property.Metal)
            {
                damage /= 2;
            }
        }
        if (PropertiesManager.Instance.currentProperty == Property.Water)
        {
            if (property == Property.Fire)
            {
                damage *= 2;
            }
            else if (property == Property.Wood)
            {
                damage /= 2;
            }
        }
        if (PropertiesManager.Instance.currentProperty == Property.Fire)
        {
            if (property == Property.Earth)
            {
                damage *= 2;
            }
            else if (property == Property.Water)
            {
                damage /= 2;
            }
        }
        if (PropertiesManager.Instance.currentProperty == Property.Earth)
        {
            if (property == Property.Metal)
            {
                damage *= 2;
            }
            else if (property == Property.Fire)
            {
                damage /= 2;
            }
        }
        this.currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = -1;
            Dead();
        }
        float hpPercent = currentHP * 1f / Hp;
        anim.SetFloat("HPPercent", hpPercent);

    }
    public void delayRecover()
    {
        Invoke("recover", 0.3f);
    }
    public void recover()
    {
        anim.SetBool("isHurt", false);
    }
    protected void Dead()
    {
        ZombieManager.Instance.deadCount++;
        ZombieManager.Instance.RemoveZombieFromList(this.gameObject);
        int randomnumber = UnityEngine.Random.Range(1, 11);
        BackEnergy.Instance.backtotalEnergy += Hp / 50;
        anim.SetBool("isDead", true);
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

    public void  delayRecoverSpeed()
    {
        Invoke("recoverSpeed", 1f);
    }

    public void recoverSpeed()
    {
        this.moveSpeed = moveSpeed2;
    }

}
