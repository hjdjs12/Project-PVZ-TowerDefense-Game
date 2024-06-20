using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public List<Transform> spawnPointList;
    public List<GameObject> zombiePrefab;
    public List<GameObject> zombieList;
    public int deadCount = 0;
    public float transitionTime = 0;
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
        if(SceneManager.GetActiveScene().name != "GameScene")
        {
            yield return new WaitForSeconds(5);
            //先生成第一波
            for (int i = 0; i < 1; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(5);
            for (int i = 0; i < 2; i++) 
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(5);
            for (int i = 0; i < 3; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(5);
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            //第二波
            for (int i = 0; i < 10; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            //第三波
            for (int i = 0; i < 10; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            for (int i = 0; i < 15; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            for (int i = 0; i < 15; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(10);
            for (int i = 0; i < 20; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }
            yield return new WaitForSeconds(25);
            for (int i = 0; i < 40; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(2F);
            }

        }
        else
        {
            int circle = 1;
            yield return new WaitForSeconds(5);
            while (true)
            {
                
                int randomGap = UnityEngine.Random.Range(circle * 1, circle*2 > 100 ? 100 :circle*2);
                Debug.Log(randomGap);
                for (int i = 0; i < randomGap; i++)
                {
                    SpawnRandomZombie();
                    yield return new WaitForSeconds(2F);
                }
                yield return new WaitForSeconds(10);
                circle++;
            }
        }

    }
    private void SpawnRandomZombie()
    {
        int index = UnityEngine.Random.Range(0, zombiePrefab.Count);
        GameObject go = null;
        if (spawnPointList != null)
        {
            go = GameObject.Instantiate(zombiePrefab[index], spawnPointList[4].position, Quaternion.identity);
        }
        zombieList.Add(go);
    }
    public void RemoveZombieFromList(GameObject deadZombie)
    {
        zombieList.Remove(deadZombie);
    }

    public void attackAll()
    {
        for(int i = 0; i < zombieList.Count;)
        {
            GameObject tmp = zombieList[i];
            tmp.GetComponent<Zombie>().TakeDamage(100);
            if (zombieList.Contains(tmp) )
            {
                i++;
            }
        }
    }
    private void Update()
    {
        if (deadCount == 120 && SceneManager.GetActiveScene().name != "GameScene")
        {
            transitionTime += Time.deltaTime;
        }
        if(transitionTime >= 2)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }
}
