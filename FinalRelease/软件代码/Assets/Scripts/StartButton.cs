using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    private Vector3 initialScale;
    private Animator anim;
    public AudioSource audioSource;
    void Start()
    {
        initialScale = transform.localScale;
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TransitionAndLoadScene()
    {
        // ���Ű�ť����
        anim.SetBool("down",true);

        // �ȴ�һ��ʱ�䣬�ȴ������������
        yield return new WaitForSeconds(0f);

        // ��ת����
        SceneManager.LoadScene("LogScene");
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
    /*public void FunctionToInvoke()
    {
        SceneManager.LoadScene("GameScene");
    }*/
    public void OnPointerEnter(PointerEventData eventData)
    {
        // �������ͣ�ڰ�ť��ʱ����������
        transform.localScale = initialScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ������ƿ���ťʱ���ָ�ԭʼ��С
        transform.localScale = initialScale;
    }
}
