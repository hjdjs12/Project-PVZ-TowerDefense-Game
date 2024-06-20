using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChooseCardPanel1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cards;
    public GameObject beforeCardPrefab;
    public List<GameObject> ChooseCard1;

    void Start()
    {
        ChooseCard1 = new List<GameObject>();
        for(int i = 0; i < 8; i++)
        {
            GameObject beforeCard = Instantiate(beforeCardPrefab);
            beforeCard.transform.SetParent(cards.transform, false);
            beforeCard.name = "Card" + i.ToString();
            beforeCard.transform.Find("Bg").gameObject.SetActive(false);
        }
    }

    public void UpdateCardPosition()
    {
        for(int i = 0; i < ChooseCard1.Count; i++)
        {
            GameObject useCard = ChooseCard1[i];
            Transform targetObject = cards.transform.Find("Card" + i.ToString());
            useCard.GetComponent<Card2>().isMoving1 = true;

            //DOMove�����ƶ�
            useCard.transform.DOMove(targetObject.position, 0.3f).OnComplete(
                () =>
                {
                    useCard.transform.SetParent(targetObject, false);
                    useCard.transform.localPosition = Vector3.zero;
                    useCard.GetComponent<Card2>().isMoving1 = false;
                });
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
