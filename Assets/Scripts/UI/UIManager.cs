using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public GameObject _UI;
    private GameObject curUI;

    public UIInventory inventory;
    public UICondition uiCondition;
    public Settings settings;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if(instance == null)
                {
                    instance = new GameObject("UIManager").AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance == this)
            Destroy(gameObject);
        }
        UISetting();
    }

    private void UISetting()
    {
        if (curUI == null)
        {
            curUI = Instantiate(_UI);
        }
    }
}