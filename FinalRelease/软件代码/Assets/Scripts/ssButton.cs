using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Networking;
using static ssButton;
using System.Net.Cache;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using TMPro;

public class ssButton : MonoBehaviour
{
    // Start is called before the first frame update
    bool isError = false;
    public TextMeshProUGUI output;
    public static ssButton Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public class user
    {
        public string userNmae;
        public string password;
        public user(string userNmae, string password)
        {
            this.userNmae = userNmae;
            this.password = password;
        }
    }

    public class GameData
    {
        public  String username;
        public String password;
        public int record;
        public String date;
        public int eleft;
        public String email;
        public String phone;

        public GameData(String username1,String password1,int record1,String dateString1,int eleft1,String email,String phone)
        {
            this.username = username1;
            this.password = password1;
            this.record = record1;
            this.date = dateString1;
            this.eleft = eleft1;
            this.email = email;
            this.phone = phone;
        }


    }
    void Start()
    {
        
    }

    //public void OnRecordLevelClick()
    //{
    //    user tmp = new user("juliano", "123456");
    //    StartCoroutine(GetUserByIdCoroutine(tmp)); // ����һ��Э�̣�������ΪGetUserByIdCoroutine�ķ�����������userId����


    //    GameData record = new GameData("juliano1", "12345", 5, " ", 6);
    //    StartCoroutine(checkSign(record)); // ����һ��Э�̣�������ΪGetUserByIdCoroutine�ķ�����������userId����

    //}
    public void PutLevelData(String UserName, int data,int element)
    {

        String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        GameData record = new GameData(UserName, "", data, date, element,"","");
        StartCoroutine(PutGameDataL(record));
    }

    public void PutSurvivalData(String UserName,String Password,int data)
    {

        String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        GameData record = new GameData(UserName,Password, data, date, 0,"","");
        StartCoroutine(PutGameDataS(record));
    }

    public void  CheckUserPassword(String UserName, String Password)
    {
        String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        GameData record = new GameData(UserName, Password, 0, date, 0, "", "");
        StartCoroutine(checkUserPassMatch(record));
    }


    public IEnumerator RegisterNewUser(String UserName, String Password,String email, String phone)
    {
        String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        GameData record = new GameData(UserName, Password, 0, date, 0,email,phone);
        yield return StartCoroutine(PutRegisterUser(record));
    }

    IEnumerator PutRegisterUser(GameData record)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/register"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��

            // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
            else // �������ɹ�
            {
                string json2 = request.downloadHandler.text; // ��ȡ��Ӧ���е��ı�����
                Debug.Log(json2);
                if (json2 == "�û����Ѵ���")
                {
                    output.text = "Username already exists";
                }
                else if (json2 == "�ֻ������ʽ����")
                {
                    output.text = "The phone number format is incorrect";
                }else if (json2 == "�����ʽ����")
                {
                    output.text = "The email number format is incorrect";
                }
                else if (json2 == "ע��ɹ�")
                {
                    output.text = "Registration successful";
                }
            }
        }
    }
    IEnumerator checkSign(GameData record)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/register"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��

            // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
            else // �������ɹ�
            {
                string json2 = request.downloadHandler.text; // ��ȡ��Ӧ���е��ı�����
                Debug.Log(json2);
            }
        }
    }






    //����û������Ƿ���ȷ
    IEnumerator checkUserPassMatch(GameData record)
    {
        // ʹ��UnityWebRequest����һ��GET���������URL��baseUrl��userIdƴ�Ӷ���
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/verLogin"))
        {
            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��

            // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
            else // �������ɹ�
            {
                string json2 = request.downloadHandler.text; // ��ȡ��Ӧ���е��ı�����
                if(json2 == "����ɹ�") {
                    PlayerPrefs.SetString("userName", record.username);
                    SceneManager.LoadScene("SelectScene");
                }
                else {
                    isError = true;
                }
            }
        }
    }


    IEnumerator Getrecord(GameData record)
    {
        // ʹ��UnityWebRequest����һ��GET���������URL��baseUrl��userIdƴ�Ӷ���
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/getDataIndS"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��

            // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
            else // �������ɹ�
            {
                string json2 = request.downloadHandler.text; // ��ȡ��Ӧ���е��ı�����
                Debug.Log(json2);
            }
        }
    }



    
   
    //��levelrecord�����ݼ������ݿ⣡����
    IEnumerator PutGameDataL(GameData record)
    {
        //// ʹ��UnityWebRequest����һ��GET���������URL��baseUrl��userIdƴ�Ӷ���
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/setDataIndL"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��



        // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
        }
    }

    IEnumerator PutGameDataS(GameData record)
    {
        //// ʹ��UnityWebRequest����һ��GET���������URL��baseUrl��userIdƴ�Ӷ���
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/setDataIndS"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // ��JSON�ַ���ת��Ϊ�ֽ�����
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // ����������ϴ��������������ϴ�JSON����
            request.SetRequestHeader("Content-Type", "application/json"); // ��������ͷ��ָ��JSON��ʽ

            yield return request.SendWebRequest(); // �������󣬲���������ɺ����ִ��



            // �������Ľ�����������ʧ��
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // ���������Ϣ������̨
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
