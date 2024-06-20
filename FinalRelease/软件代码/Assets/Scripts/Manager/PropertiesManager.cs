using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PropertiesManager : MonoBehaviour
{
    public Property currentProperty = Property.Non;
    private Animator currentAnimator = null;
    public static PropertiesManager Instance { get; private set; }
    public List<GameObject> ButtonList;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void allRecover()
    {
        if (currentProperty != Property.Non)
        {
            //先把原来的按钮恢复
            updateCurrentAnimator(currentProperty);
            currentAnimator.SetTrigger("Pressed");
            currentProperty = Property.Non;
            
        }
    }
    public void updateProperty(Property newProperty)
    {
        if(newProperty == currentProperty) {
            currentProperty = Property.Non;
            BackEnergy.Instance.TransitionToOFF();
        }
        else if(currentProperty != Property.Non)
        {
            //先把原来的按钮恢复
            updateCurrentAnimator(currentProperty);
            currentAnimator.SetTrigger("Pressed");
            currentProperty = newProperty;
        }
        else{
            currentProperty = newProperty;
            BackEnergy.Instance.TransitionToOn();
        }
    }
    public void updateCurrentAnimator(Property currentProperty)
    {
        if (currentProperty == Property.Metal)
        {
            currentAnimator = ButtonList[0].GetComponent<Animator>();
        }
        else if (currentProperty == Property.Wood)
        {
            currentAnimator = ButtonList[1].GetComponent<Animator>();
        }
        else if (currentProperty == Property.Water)
        {
            currentAnimator = ButtonList[2].GetComponent<Animator>();
        }
        else if (currentProperty == Property.Fire)
        {
            currentAnimator = ButtonList[3].GetComponent<Animator>();
        }
        else if (currentProperty == Property.Earth)
        {
            currentAnimator = ButtonList[4].GetComponent<Animator>();
        }
    }
}
