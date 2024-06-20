using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance { get; private set; }
    public bool isOpen = true;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public List<GameObject> transitonList;
    public List<Animator> anim;
    public float durationTime = 5f;
    public float simulateTime = 0;
    void Start()
    {
        for(int i= 0; i < transitonList.Count; i++)
        {
            anim.Add(transitonList[i].GetComponent<Animator>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        simulateTime += Time.deltaTime;
        if (simulateTime >= durationTime) { 
            simulateTime = 0;
            if (isOpen) { TransitionToOff(); }
            else { TransitionToOpen(); }
        }
    }
    public void TransitionToOpen()
    {
        Debug.Log("open");
        isOpen = true;
        
        for (int i = 0; i < anim.Count; i++)
        {
            if (anim[i] != null)
            {
                anim[i].SetBool("isTransition", true);
            }
        }
    }
    public void TransitionToOff()
    {
        Debug.Log("cloas");
        isOpen = false;
        for (int i = 0; i < anim.Count; i++)
        {
            if (anim[i] != null) { 
                anim[i].SetBool("isTransition", false);
            }
        } 
    }
}
