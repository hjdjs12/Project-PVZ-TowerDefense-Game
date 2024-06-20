using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 25;
    public void LinearTo(Vector3 targetPos)
    {
        transform.DOMove(targetPos,moveDuration);
    }
    public void JumpTo(Vector3 targetPos)
    {
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);
        centerPos.y += distance/2;
        //DoPath 位置路径点，运动时间，运动轨迹形状
        //setEase Ease.OutQuad 先快后慢
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);

    }
    public void OnMouseDown()
    {
        //阳光被点击后移动到左上角的计算太阳值的框
        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), 0.5f).SetEase(Ease.OutQuad).OnComplete(
            () =>
            {
                Destroy(this.gameObject);
                SunManager.Instance.AddSun(point);
            }
            );
    
    }
}
