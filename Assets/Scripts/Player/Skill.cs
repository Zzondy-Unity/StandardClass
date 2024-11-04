using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private Transform FirePos;
    public FireBall FireBall;

    public void UseQSkill()
    {
        if (CharacterManager.Instance.Player.condition.UseMana(FireBall.UseMana))
        {
            GameObject fire = Instantiate(FireBall.fireballPrefab, FirePos.position, Quaternion.identity);
            Rigidbody rb = fire.GetComponent<Rigidbody>();
        }
    }

}