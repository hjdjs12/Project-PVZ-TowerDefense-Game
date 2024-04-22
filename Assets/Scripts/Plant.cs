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
    private Cell inCell = null;

 
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
    public void addCell(Cell cell)
    {
        this.inCell = cell;
    }
    protected virtual void EnableUpdate()
    {
        
    }
    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        if(GetComponent<Animator>()!=null) { GetComponent<Animator>().enabled = false; }
        GetComponent<Collider2D>().enabled = false;
    }

     public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        if (GetComponent<Animator>() != null) { GetComponent<Animator>().enabled = true; }

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
        if(inCell.currentPlant2 != null) {
            Destroy(inCell.currentPlant2.gameObject );
            WeaponManager.Instance.weaponList.Remove(inCell.currentPlant2.gameObject);
        }
        WeaponManager.Instance.weaponList.Remove(gameObject);
    }


}
