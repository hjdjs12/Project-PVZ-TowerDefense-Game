using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterButton : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField UserName;
    public TMP_InputField Password;
    public TMP_InputField ConfirmPassword;
    public TMP_InputField Phone;
    public TMP_InputField Email;
    public TextMeshProUGUI output;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(output == )
    }

    public void  OnClick()
    {
        StartCoroutine(RegisterRoutine());
    }
    public  IEnumerator RegisterRoutine()
    {
        if (Password.text == ConfirmPassword.text)
        {
            yield return StartCoroutine(ssButton.Instance.RegisterNewUser(UserName.text, Password.text, Email.text, Phone.text));;
            Debug.Log(output.text);
            if (UserName.text == "" || Password.text == "" || Email.text == "" || Phone.text == "")
            {
                output.text = "Content cannot be empty";
            }
            else if (output.text == "Registration successful")
            {

                SceneManager.LoadScene("LogScene");
            }
        }
        else
        {
            output.text = "Passwords don't match";
        }

    }
}


