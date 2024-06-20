using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }

    public List<Plant> plantPrefabList;//�洢prefabĳ������ļ��ϣ����Ը������ʵ������Ӧprefab

    private Plant currentPlant;

    private void Awake()
    {
        Instance = this;        
    }

    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) { return false; }
        Plant plantPrefab = GetPlantPrefabm(plantType);
        if (plantPrefab == null) {
            print("Ҫ��ֲ��ֲ�ﲻ����");return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        return true;
    }
    private void Update()
    {
        FollowCursors();
    }

    void FollowCursors()
    {
        if (currentPlant == null) return;
        /*�ȵõ�������������
        ScreenToViewportPoint����Ļ����ת��������
        Input.mousePosition:������Ļ����*/
        Vector3 mouthWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouthWorldPosition);
        mouthWorldPosition.z = (float)-0.01;
        currentPlant.transform.position = mouthWorldPosition;
    }

    private Plant GetPlantPrefabm(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if (plant.plantType == plantType) { return plant; }
        }
        return null;
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSuccess = cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            currentPlant = null;
        }

    }
}
