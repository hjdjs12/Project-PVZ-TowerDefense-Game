using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card2 : MonoBehaviour, IPointerClickHandler
{
    public PlantType plantType;
    public GameObject darkBg;
    public UpgradeWeaponInfoItem upgradeWeaponInfo;
    public bool hasUse1 = false;
    public bool hasLock1 = false;
    public bool isMoving1 = false;

    // Start is called before the first frame update
    void Start()
    {
        //darkBg = transform.Find("dark").gameObject;
        darkBg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameStart)
        {
            return;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isMoving1)
            return;

        if (hasLock1)
            return;

        if (hasUse1)
        {
            RemoveCard(gameObject);
        }

        else
        {
            AddCard();
        }
    }

    public void RemoveCard(GameObject removeCard)
    {
        ChooseCardPanel1 chooseCardPanel1 = UIManager.Instance.chooseCardPanel1;
        if (chooseCardPanel1.ChooseCard1.Contains(removeCard))
        {
            //移除操作
            removeCard.GetComponent<Card2>().isMoving1 = true;
            chooseCardPanel1.ChooseCard1.Remove(removeCard);
            chooseCardPanel1.UpdateCardPosition();
            //移动回来到原来的位置
            Transform cardParent = UIManager.Instance.allCardPanel1.Bg.transform.Find("Card" + removeCard.GetComponent<Card2>().upgradeWeaponInfo.upgradeWeaponId);
            Vector3 curPostion = removeCard.transform.position;
            removeCard.transform.SetParent(UIManager.Instance.transform, false);
            removeCard.transform.position = curPostion;

            //DOMove
            removeCard.transform.DOMove(cardParent.position, 0.3f).OnComplete(
                () =>
                {
                    cardParent.Find("BeforeCard").GetComponent<Card2>().darkBg.SetActive(false);
                    cardParent.Find("BeforeCard").GetComponent<Card2>().hasLock1 = false;
                    removeCard.GetComponent<Card2>().isMoving1 = false;
                    Destroy(removeCard);
                }
            );
            ChooseManager.Instance.removeChooseCard1(this.plantType);
        }
    }

    public void AddCard()
    { 
        //第二个选卡栏
        ChooseCardPanel1 chooseCardPanel1 = UIManager.Instance.chooseCardPanel1;
        int curIndex1 = chooseCardPanel1.ChooseCard1.Count;
        if (curIndex1 >= 8)
        {
            print("Maximum Card Number!");
            return;
        }
        GameObject useCard1 = Instantiate(upgradeWeaponInfo.cardPrefab2);
        useCard1.transform.SetParent(UIManager.Instance.transform);
        useCard1.transform.position = transform.position;
        useCard1.name = "Card";
        useCard1.GetComponent<Card2>().upgradeWeaponInfo = upgradeWeaponInfo;
        hasLock1 = true;
        darkBg.SetActive(true);

        //移动到目标位置
        Transform targetObject1 = chooseCardPanel1.cards.transform.Find("Card" + curIndex1);
        useCard1.GetComponent<Card2>().isMoving1 = true;
        useCard1.GetComponent<Card2>().hasUse1 = true;
        chooseCardPanel1.ChooseCard1.Add(useCard1); ;

        //DoMove进行移动
        useCard1.transform.DOMove(targetObject1.position, 0.3f).OnComplete(
            () =>
            {
                useCard1.transform.SetParent(targetObject1, false);
                useCard1.transform.localPosition = Vector3.zero;
                useCard1.GetComponent<Card2>().isMoving1 = false;
            });
        ChooseManager.Instance.addChooseCard1(this.plantType);
    }
}
