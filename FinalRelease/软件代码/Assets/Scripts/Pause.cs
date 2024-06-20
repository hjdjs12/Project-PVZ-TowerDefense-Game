using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private Vector3 initialScale;
    private Animator anim;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TransitionAndLoadScene()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0);

        // ????????

        Debug.Log(SceneController.Instance.isPause);
        SceneController.Instance.PauseGame();
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        
        SceneController.Instance.isPause = true;
        StartCoroutine(TransitionAndLoadScene());

    }
     
}
