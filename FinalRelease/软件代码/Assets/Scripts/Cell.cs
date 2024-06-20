using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;
    public Plant currentPlant2;


    public bool AddPlant(Plant plant)
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Collider2D collider = GetComponent<Collider2D>();
        Vector3 centerPosition = bounds.center;
        if (currentPlant != null) Debug.Log(currentPlant.plantType);
        Debug.Log(plant.plantType);
        if (currentPlant != null && (currentPlant.plantType == PlantType.Tower || currentPlant.plantType == PlantType.Tower2) && currentPlant2 != null && ((currentPlant2.plantType == PlantType.MG2 && plant.plantType == PlantType.MG3) || (currentPlant2.plantType == PlantType.Cannon2 && plant.plantType == PlantType.Cannon3) || (currentPlant2.plantType == PlantType.Missle2 && plant.plantType == PlantType.Missle3) || (currentPlant2.plantType == PlantType.CannonLinear2 && plant.plantType == PlantType.CannonLinear3) || (currentPlant2.plantType == PlantType.CardFreeze2 && plant.plantType == PlantType.CardFreeze3) || (currentPlant2.plantType == PlantType.CircleCannon2 && plant.plantType == PlantType.CircleCannon3)))
        {//三级进化
            Destroy(currentPlant2.gameObject);
            WeaponManager.Instance.weaponList.Remove(currentPlant2.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;

        }
        if (currentPlant != null && (currentPlant.plantType == PlantType.Tower || currentPlant.plantType == PlantType.Tower2) && currentPlant2 == null && (plant.plantType == PlantType.Cannon1 || plant.plantType == PlantType.MG1 || plant.plantType == PlantType.Missle1 || plant.plantType == PlantType.FireShooter || plant.plantType == PlantType.CannonLinear || plant.plantType == PlantType.Bounce || plant.plantType == PlantType.CardFreeze1 || plant.plantType == PlantType.CircleCannon1)) {
            // 一级进化
            //centerPosition.y += 0.4f;

            WeaponManager.Instance.weaponList.Remove(currentPlant.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;
        }
        else if (currentPlant != null && (currentPlant.plantType == PlantType.Tower || currentPlant.plantType == PlantType.Tower2) && currentPlant2 != null && ((currentPlant2.plantType == PlantType.Missle1 && plant.plantType == PlantType.Missle2) || (currentPlant2.plantType == PlantType.MG1 && plant.plantType == PlantType.MG2)   || (currentPlant2.plantType == PlantType.Cannon1 && plant.plantType == PlantType.Cannon2 ) || (currentPlant2.plantType == PlantType.CannonLinear && plant.plantType == PlantType.CannonLinear2) || (currentPlant2.plantType == PlantType.CardFreeze1 && plant.plantType == PlantType.CardFreeze2) || (currentPlant2.plantType == PlantType.CircleCannon1 && plant.plantType == PlantType.CircleCannon2)))
        {//二级进化
            Destroy(currentPlant2.gameObject);
            WeaponManager.Instance.weaponList.Remove(currentPlant2.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;
        }
        else if (currentPlant == null && (plant.plantType == PlantType.Cannon1 || plant.plantType == PlantType.MG1 || plant.plantType == PlantType.MG2 || plant.plantType == PlantType.MG3 || plant.plantType == PlantType.Cannon2||plant.plantType == PlantType.Cannon3 || plant.plantType == PlantType.Missle1 || plant.plantType == PlantType.Missle2 || plant.plantType == PlantType.Missle3 || plant.plantType == PlantType.FireShooter || plant.plantType == PlantType.Bounce || plant.plantType == PlantType.CannonLinear || plant.plantType == PlantType.CannonLinear2 || plant.plantType == PlantType.CannonLinear3 || plant.plantType == PlantType.CardFreeze1 || plant.plantType == PlantType.CardFreeze2 || plant.plantType == PlantType.CardFreeze3 || plant.plantType == PlantType.CircleCannon1 || plant.plantType == PlantType.CircleCannon2 || plant.plantType == PlantType.CircleCannon3)) { return false; }
        else if (currentPlant != null) {  return false; }
        currentPlant = plant;
        currentPlant.transform.position = centerPosition;
        plant.TransitionToEnable();
        return true;
    }
    private void OnMouseDown()
    {
        if(HandManager.Instance != null){
            HandManager.Instance.OnCellClick(this);
        }
    }
}
