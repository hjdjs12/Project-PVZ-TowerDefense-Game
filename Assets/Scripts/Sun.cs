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
        //DoPath λ��·���㣬�˶�ʱ�䣬�˶��켣��״
        //setEase Ease.OutQuad �ȿ����
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);

    }
    public void OnMouseDown()
    {
        //���ⱻ������ƶ������Ͻǵļ���̫��ֵ�Ŀ�
        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), 0.5f).SetEase(Ease.OutQuad).OnComplete(
            () =>
            {
                Destroy(this.gameObject);
                SunManager.Instance.AddSun(point);
            }
            );
    
    }
}
