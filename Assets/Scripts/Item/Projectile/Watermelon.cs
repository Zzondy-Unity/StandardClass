using System;
using UnityEngine;

public class Watermelon : MonoBehaviour, IProjectile, IInteractable
{
    [field: SerializeField] public GameObject prefab { get; private set; }

    private float ThrowPower = 10f;
    private float gravity => Physics.gravity.y;
    private float elapsedTime = 0f;
    private Vector3 startPos;
    private Vector3 ThrowDir;

    private bool isThrowing = false;
    Camera cam => Camera.main;

    public ProjectileType projectileType => ProjectileType.Parabola;

    public void Fire()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        ThrowDir = ray.direction;
        startPos = transform.position;
        elapsedTime = 0f;
        isThrowing = true;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        Vector3 currentPosition = CalculateParabolicPosition(startPos, ThrowDir, ThrowPower, elapsedTime);
        transform.position = currentPosition;

        if(currentPosition.y <= 0f)
        {
            isThrowing = false ;
        }
    }

    private Vector3 CalculateParabolicPosition(Vector3 startPos, Vector3 throwDir, float throwPower, float elapsedTime)
    {
        //수평이동 : 방향*속도*시간
        Vector3 horizontalMovement = throwDir * throwPower * elapsedTime;

        //수직이동 : 1/2 * 중력 * 시간^2
        float verticalMovement = 0.5f * gravity * elapsedTime * elapsedTime;

        return startPos + horizontalMovement + Vector3.up * verticalMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))

            Destroy(gameObject);
    }


    public string GetInteractPrompt()
    {
        return string.Empty;
    }

    public void OnInteract()
    {
        if (CharacterManager.Instance.Player.equip.curEquip is EquipRange equipRange)
        {
            equipRange.SetProjectile(this);
        }
    }

}