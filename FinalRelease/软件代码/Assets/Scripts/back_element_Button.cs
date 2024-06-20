using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_element_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public Property myProperty;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        //GetComponent<Animator>().SetBool("isRecover", false);
        if (BackEnergy.Instance.backtotalEnergy <= 0) {Invoke("recover",1f) ; return; }
        PropertiesManager.Instance.updateProperty(myProperty);
    }
    public void recover()
    {
        anim.SetTrigger("Pressed");
    }
}
