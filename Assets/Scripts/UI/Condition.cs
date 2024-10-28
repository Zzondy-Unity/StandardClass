using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;  //주기적으로 변하는 값
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;  //저장된 데이터를 가져오는것도 가능
    }

    private void Update()
    {
        //ui업데이트
        uiBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(0, curValue - value);
    }
}
