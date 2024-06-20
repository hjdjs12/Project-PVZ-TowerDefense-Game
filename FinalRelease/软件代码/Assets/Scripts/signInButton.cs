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
        // 播放按钮动画
        anim.SetBool("down", true);

        // 等待一段时间，等待动画播放完毕
        yield return new WaitForSeconds(0.6f);

        ssButton.Instance.CheckUserPassword(user.text, password.text);

        Invoke("setError", 0.5f);
        // 跳转场景

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
    //    // 当鼠标悬停在按钮上时，将其缩放
    //    transform.localScale = initialScale * 1.1f;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    // 当鼠标移开按钮时，恢复原始大小
    //    transform.localScale = initialScale;
    //}
}
