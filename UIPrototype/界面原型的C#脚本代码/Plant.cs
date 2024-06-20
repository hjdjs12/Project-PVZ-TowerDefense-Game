using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.Sunflower;
    public int HP = 100;

    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }
    void DisableUpdate()
    {
            
    }
    protected virtual void EnableUpdate()
    {
        
    }
    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

     public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
    private void Start()
    {
        TransitionToDisable();
    }
    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        if(HP < 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }


}
