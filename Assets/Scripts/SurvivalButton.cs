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
        // ���Ű�ť����

        // �ȴ�һ��ʱ�䣬�ȴ������������
        yield return new WaitForSeconds(0.6f);

        // ��ת����
        SceneManager.LoadScene("GameScene");
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
}
