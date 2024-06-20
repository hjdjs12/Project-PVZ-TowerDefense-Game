using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class signInButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialScale;
    private Animator anim;
    public TextMeshProUGUI text;
    public TMP_InputField user;
    public TMP_InputField password;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TransitionAndLoadScene()
    {
        // ���Ű�ť����
        anim.SetBool("down", true);

        // �ȴ�һ��ʱ�䣬�ȴ������������
        yield return new WaitForSeconds(0.6f);

        ssButton.Instance.CheckUserPassword(user.text, password.text);

        Invoke("setError", 0.5f);
        // ��ת����

    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
    public void setError() { text.text = "User Or Password Error!"; }
    
    /*public void FunctionToInvoke()
    {
        SceneManager.LoadScene("GameScene");
    }*/
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    // �������ͣ�ڰ�ť��ʱ����������
    //    transform.localScale = initialScale * 1.1f;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    // ������ƿ���ťʱ���ָ�ԭʼ��С
    //    transform.localScale = initialScale;
    //}
}
