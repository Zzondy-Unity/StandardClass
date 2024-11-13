using UnityEngine;

public class Arrow : MonoBehaviour, IProjectile, IInteractable
{
    [field: SerializeField] public GameObject prefab {  get; private set; }
    public float speed = 10f;
    private Vector3 dir;

    Camera cam => Camera.main;

    public ProjectileType projectileType => ProjectileType.Straight;

    public void Fire()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            dir = (hit.point - transform.position).normalized;
            transform.up = dir;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("����ε� �߻簡 �ƴ϶� �����");
        }
    }

    private void Update()
    {
        if(dir != Vector3.zero)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        Destroy(gameObject);
    }

    public string GetInteractPrompt()
    {
        return "Arrow";
    }

    public void OnInteract()
    {
        if(CharacterManager.Instance.Player.equip.curEquip is EquipRange equipRange)
        {
            equipRange.SetProjectile(this);
        }
    }
}