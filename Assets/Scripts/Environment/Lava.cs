using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float damageTimeRate;
    public float damage;

    private List<IDamagable> damagables = new List<IDamagable>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0f, damageTimeRate);
    }

    private void DealDamage()
    {
        for(int i = 0; i < damagables.Count; i++)
        {
            damagables[i].TakePhysicalDamage((int)damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagables.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagables.Remove(damagable);
        }
    }
}