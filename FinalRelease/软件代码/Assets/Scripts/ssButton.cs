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
    //    StartCoroutine(GetUserByIdCoroutine(tmp)); // 启动一个协程，调用名为GetUserByIdCoroutine的方法，并传入userId参数


    //    GameData record = new GameData("juliano1", "12345", 5, " ", 6);
    //    StartCoroutine(checkSign(record)); // 启动一个协程，调用名为GetUserByIdCoroutine的方法，并传入userId参数

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
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行

            // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
            else // 如果请求成功
            {
                string json2 = request.downloadHandler.text; // 获取响应体中的文本内容
                Debug.Log(json2);
                if (json2 == "用户名已存在")
                {
                    output.text = "Username already exists";
                }
                else if (json2 == "手机号码格式错误")
                {
                    output.text = "The phone number format is incorrect";
                }else if (json2 == "邮箱格式错误")
                {
                    output.text = "The email number format is incorrect";
                }
                else if (json2 == "注册成功")
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
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行

            // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
            else // 如果请求成功
            {
                string json2 = request.downloadHandler.text; // 获取响应体中的文本内容
                Debug.Log(json2);
            }
        }
    }






    //检测用户密码是否正确
    IEnumerator checkUserPassMatch(GameData record)
    {
        // 使用UnityWebRequest创建一个GET请求，请求的URL由baseUrl和userId拼接而成
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/verLogin"))
        {
            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行

            // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
            else // 如果请求成功
            {
                string json2 = request.downloadHandler.text; // 获取响应体中的文本内容
                if(json2 == "登入成功") {
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
        // 使用UnityWebRequest创建一个GET请求，请求的URL由baseUrl和userId拼接而成
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/getDataIndS"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行

            // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
            else // 如果请求成功
            {
                string json2 = request.downloadHandler.text; // 获取响应体中的文本内容
                Debug.Log(json2);
            }
        }
    }



    
   
    //将levelrecord的数据加入数据库！！！
    IEnumerator PutGameDataL(GameData record)
    {
        //// 使用UnityWebRequest创建一个GET请求，请求的URL由baseUrl和userId拼接而成
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/setDataIndL"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行



        // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
        }
    }

    IEnumerator PutGameDataS(GameData record)
    {
        //// 使用UnityWebRequest创建一个GET请求，请求的URL由baseUrl和userId拼接而成
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/gamedata/setDataIndS"))
        {

            string json = JsonUtility.ToJson(record);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json); // 将JSON字符串转换为字节数组
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // 设置请求的上传处理器，用于上传JSON数据
            request.SetRequestHeader("Content-Type", "application/json"); // 设置请求头，指定JSON格式

            yield return request.SendWebRequest(); // 发送请求，并在请求完成后继续执行



            // 检查请求的结果，如果请求失败
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error); // 输出错误信息到控制台
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
