using UnityEngine;

public class Plate : MonoBehaviour, IProjectile, IInteractable
{
    [field: SerializeField] public GameObject prefab { get; private set; }
    Camera cam => Camera.main;

    public float bulletSpeed = 10f;
    public float bulletCount = 20;
    public float offsetDistance = 0.5f;


    public ProjectileType projectileType => ProjectileType.Circle;

    public void Fire()
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float bulletDirX = Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirZ = Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector3(bulletDirX, 0, bulletDirZ);
            Vector3 bulletMoveDirection = bulletVector.normalized;

            Vector3 spawnPosition = CharacterManager.Instance.Player.transform.position + bulletMoveDirection * offsetDistance;
            GameObject projectiles = Instantiate(prefab);

            Rigidbody bulletRb = projectiles.GetComponent<Rigidbody>();

            projectiles.transform.forward = bulletMoveDirection;

            bulletRb.velocity = bulletMoveDirection * bulletSpeed;

            angle += angleStep;
        }
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