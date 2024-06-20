using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;
    public AllCardPanel allCardPanel;
    public AllCardPanel1 allCardPanel1;
    public ChooseCardPanel chooseCardPanel;
    public ChooseCardPanel1 chooseCardPanel1;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitUI()
    {
        allCardPanel.InitCards();
        allCardPanel1.InitCards();
    }
}
