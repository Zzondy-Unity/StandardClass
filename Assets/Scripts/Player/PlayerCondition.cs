using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    private Condition health { get { return uiCondition.health; } }
    private Condition hunger { get { return uiCondition.hunger; } }
    private Condition stamina { get { return uiCondition.stamina; } }
    private Condition mana { get { return uiCondition.Mana; } }

    public float noHungerHealthDecay;

    public event Action OnTakeDamage;

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);
        mana.Add(mana.passiveValue * Time.deltaTime);

        if(hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("ав╬З╫ю╢о╢ы.");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        OnTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }

    public bool UseMana(float amount)
    {
        if(mana.curValue - amount < 0f)
        {
            return false;
        }

        mana.Subtract(amount);
        return true;
    }

    public void GetMana(float amount)
    {
        mana.Add(amount);
    }
}
