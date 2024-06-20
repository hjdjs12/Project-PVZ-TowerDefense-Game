using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCannon : MonoBehaviour
{
    // Start is called before the first frame update
    public Property property;
    public GameObject big;
    public Animator anim;
    void Start()
    {
        anim = big.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (BackEnergy.Instance.backtotalEnergy >= 100)
        {
            BackEnergy.Instance.decreaseOfUtimate();
            anim.SetBool("isFire", true);
            Invoke("recover", 0.1f);
            ZombieManager.Instance.attackAll();
        }
    }
    public void recover()
    {
        anim.SetBool("isFire", false);
    }
}
