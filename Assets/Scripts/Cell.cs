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
        if (currentPlant != null && currentPlant.plantType == PlantType.Tower && currentPlant2 != null && ((currentPlant2.plantType == PlantType.MG2 && plant.plantType == PlantType.MG3) || (currentPlant2.plantType == PlantType.Cannon2 && plant.plantType == PlantType.Cannon3)))
        {//��ֲ��������
            Destroy(currentPlant2.gameObject);
            WeaponManager.Instance.weaponList.Remove(currentPlant2.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;

        }
        if (currentPlant != null && currentPlant.plantType == PlantType.Tower && (plant.plantType == PlantType.Cannon1 || plant.plantType == PlantType.MG1)) {
            // ��ֲһ������
            //centerPosition.y += 0.4f;

            WeaponManager.Instance.weaponList.Remove(currentPlant.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;
        }
        else if (currentPlant != null && currentPlant.plantType == PlantType.Tower && currentPlant2 != null && ((currentPlant2.plantType == PlantType.MG1 && plant.plantType == PlantType.MG2)   || (currentPlant2.plantType == PlantType.Cannon1 && plant.plantType == PlantType.Cannon2 )))
        {//��ֲ������������
            Destroy(currentPlant2.gameObject);
            WeaponManager.Instance.weaponList.Remove(currentPlant2.gameObject);
            centerPosition.z = -5;
            currentPlant2 = plant;
            currentPlant2.transform.position = centerPosition;
            plant.TransitionToEnable();
            return true;
        }
        else if (currentPlant == null && (plant.plantType == PlantType.Cannon1 || plant.plantType == PlantType.MG1 || plant.plantType == PlantType.MG2 || plant.plantType == PlantType.MG3 || plant.plantType == PlantType.Cannon2)) { return false; }
        else if (currentPlant != null) {  return false; }
        currentPlant = plant;
        currentPlant.transform.position = centerPosition;
        plant.TransitionToEnable();
        return true;
    }
    private void OnMouseDown()
    {
        HandManager.Instance.OnCellClick(this);
    }
}
