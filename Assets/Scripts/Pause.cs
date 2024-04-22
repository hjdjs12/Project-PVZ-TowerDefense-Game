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
        SceneManager.LoadScene("PauseScene");
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        Debug.Log(SurvivalButton.Instance.screen);
        StartCoroutine(TransitionAndLoadScene());

    }
     
}
