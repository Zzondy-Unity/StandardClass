using UnityEngine;

public class Arrow : MonoBehaviour, IProjectile, IInteractable
{
    [field: SerializeField] public GameObject prefab {  get; private set; }
    public float speed = 10f;
    private Vector3 Target;

    Camera cam => Camera.main;

    public ProjectileType projectileType => ProjectileType.Straight;

    public void Fire()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Target = hit.point;
        }

        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    private void Update()
    {
        transform.Translate(Target * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        Destroy(gameObject);
    }

    public string GetInteractPrompt()
    {
        return string.Empty;
    }

    public void OnInteract()
    {
        if(CharacterManager.Instance.Player.equip.curEquip is EquipRange equipRange)
        {
            equipRange.SetProjectile(this);
        }
    }
}