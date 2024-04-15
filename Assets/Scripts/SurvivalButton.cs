using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalButton : MonoBehaviour
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
        // 播放按钮动画

        // 等待一段时间，等待动画播放完毕
        yield return new WaitForSeconds(0.6f);

        // 跳转场景
        SceneManager.LoadScene("GameScene");
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
}
