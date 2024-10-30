using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�÷��̾ �ʿ��� ��ɵ�

    public PlayerController controller;
    public PlayerCondition condition;
    public Equipment equip;

    public ItemData itemData;
    public Action addItem;

    public Transform dropPosition;
    public Skill skill;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;    //�ܺο��� �÷��̾�� �����ϰ� ���� �� �� �Լ��� ���� ���ٰ���
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        equip = GetComponent<Equipment>();
        skill = GetComponent<Skill>();
    }


}
