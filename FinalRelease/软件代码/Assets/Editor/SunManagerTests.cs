using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using static SunManager;
using NUnit.Framework;
using System;
using Unity.VisualScripting;

public class SunManagerTests
{
    private GameObject go;
    private SunManager sunManager;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject();
        sunManager = go.AddComponent<SunManager>();
        sunManager.sunPointText = go.AddComponent<TMPro.TextMeshProUGUI>();
    }

    [Test]
    public void InitialValue()
    {
        if (sunManager != null)
        {
            Assert.Pass("Is not null");
        } else
        {
            Assert.Fail("Is null");
        }
        Assert.AreEqual(0, sunManager.SunPoint);
    }

    [Test]
    public void SunPoint_UIUpdate_Test()
    {
        sunManager.AddSun(100);
        Assert.AreEqual(100, sunManager.SunPoint, "Sun point must be 100");
        Assert.AreEqual("100", sunManager.sunPointText.text);

        sunManager.AddSun(20);
        Assert.AreEqual(120, sunManager.SunPoint, "Sun point must be 120");
        Assert.AreEqual("120", sunManager.sunPointText.text);

        sunManager.SubSun(10);
        Assert.AreEqual(110, sunManager.SunPoint, "Sun point must be 110");
        Assert.AreEqual("110", sunManager.sunPointText.text);

        sunManager.SubSun(50);
        Assert.AreEqual(60, sunManager.SunPoint, "Sun point must be 60");
        Assert.AreEqual("60", sunManager.sunPointText.text);
    }

    [Test]
    public void CalcSunPointTextPosition_Test()
    {
        //sunManager.sunPointTextPosition = new Vector3(0, 0, 0);
        sunManager.CalcSunPointTextPosition();
        //Debug.Log(sunManager.GetSunPointTextPosition().x);
        Assert.AreEqual(-10.68,Math.Round(sunManager.GetSunPointTextPosition().x,2)  );
        Assert.AreEqual(-7.41, Math.Round(sunManager.GetSunPointTextPosition().y,2)  ) ;
        Assert.AreEqual(0.0, sunManager.GetSunPointTextPosition().z);
    }

    [UnityTest]
    public IEnumerator ProduceSun_Test()
    {
        Assert.AreEqual(0.0, sunManager.produceTime);
        Assert.AreEqual(0.0, sunManager.produceTimer);

        // ����ִ����һ֡
        yield return null;
        // ����ProduceSun�Ĵ���������produceTimeһֱ����
        // ִ��һ��produceTimer += Time.deltaTime �ض�ʹif��������
        // produceTimer�ٴα���Ϊ��
        // ����Ϸ������ʱû�г����ʿ�����Ϊ�ú���û���κ�����
        Assert.AreEqual(0.0, sunManager.produceTime);
        Assert.AreEqual(0.0, sunManager.produceTimer);
    }
}
