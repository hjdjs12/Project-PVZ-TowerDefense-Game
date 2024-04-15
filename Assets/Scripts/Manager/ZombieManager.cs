using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


enum SpawnState
{
    NotStart,
    Spawning,
    End
}
public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance {  get; private set; }
    private SpawnState spawnState = SpawnState.NotStart;
    public Transform[] spawnPointList;
    public GameObject zombiePrefab;
    public List<GameObject> zombieList;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }
    IEnumerator SpawnZombie()
    {
        //先生成第一波
        for (int i = 0;i<5;i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //第二波
        for (int i = 0; i < 10; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //第三波
        for (int i = 0; i < 20; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(3);
        }
    }
    private void SpawnRandomZombie()
    {
        //int index = UnityEngine.Random.Range(0, spawnPointList.Length);
        GameObject go = GameObject.Instantiate(zombiePrefab, spawnPointList[4].position,Quaternion.identity);
        zombieList.Add(go);
    }
    public void RemoveZombieFromList(GameObject deadZombie)
    {
        zombieList.Remove(deadZombie);
    }
}
