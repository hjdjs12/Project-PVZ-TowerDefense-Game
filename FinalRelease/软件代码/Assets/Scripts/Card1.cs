using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card1 : MonoBehaviour, IPointerClickHandler
{
    public PlantType plantType;
    public GameObject darkBg;
    public WeaponInfoItem weaponInfo;
    public bool hasUse = false;
    public bool hasLock = false;
    public bool isMoving = false;
    

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
        if (isMoving)
            return;

        if (hasLock)
            return;

        if (hasUse)
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
        ChooseCardPanel chooseCardPanel = UIManager.Instance.chooseCardPanel;
        if (chooseCardPanel.ChooseCard.Contains(removeCard))
        {
            //移除操作
            removeCard.GetComponent<Card1>().isMoving = true;
            chooseCardPanel.ChooseCard.Remove(removeCard);
            chooseCardPanel.UpdateCardPosition();
            //移动回来到原来的位置
            Transform cardParent = UIManager.Instance.allCardPanel.Bg.transform.Find("Card" + removeCard.GetComponent<Card1>().weaponInfo.weaponId);
            Vector3 curPostion = removeCard.transform.position;
            removeCard.transform.SetParent(UIManager.Instance.transform, false);
            removeCard.transform.position = curPostion;

            //DOMove
            removeCard.transform.DOMove(cardParent.position, 0.3f).OnComplete(
                () =>
                {
                    cardParent.Find("BeforeCard").GetComponent<Card1>().darkBg.SetActive(false);
                    cardParent.Find("BeforeCard").GetComponent<Card1>().hasLock = false;
                    removeCard.GetComponent<Card1>().isMoving = false;
                    Destroy(removeCard);
                }
            );
            ChooseManager.Instance.removeChooseCard(this.plantType);
        }
    }

    public void AddCard()
    {
        ChooseCardPanel chooseCardPanel = UIManager.Instance.chooseCardPanel;
        int curIndex = chooseCardPanel.ChooseCard.Count;
        if(curIndex >= 8)
        {
            print("Maximum Card Number!");
            return;
        }
        GameObject useCard = Instantiate(weaponInfo.cardPrefab);
        useCard.transform.SetParent(UIManager.Instance.transform);
        useCard.transform.position = transform.position;
        useCard.name = "Card";
        useCard.GetComponent<Card1>().weaponInfo = weaponInfo;
        hasLock = true;
        darkBg.SetActive(true);
        //移动到目标位置
        Transform targetObject = chooseCardPanel.cards.transform.Find("Card" + curIndex);
        useCard.GetComponent<Card1>().isMoving = true;
        useCard.GetComponent<Card1>().hasUse = true;
        chooseCardPanel.ChooseCard.Add(useCard); ;

        //DoMove进行移动
        useCard.transform.DOMove(targetObject.position, 0.3f).OnComplete(
            () =>
            {
                useCard.transform.SetParent(targetObject, false);
                useCard.transform.localPosition = Vector3.zero;
                useCard.GetComponent<Card1>().isMoving = false;
            });
        ChooseManager.Instance.addChooseCard(this.plantType);
        Debug.Log("aaa");
    }
}
