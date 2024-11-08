using UnityEngine;


public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public Vector3 TargetPosition;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TargetPosition = CharacterManager.Instance.Player.transform.position + Vector3.up * 1.7f;   //ĳ������ �Ӹ��κ��� �븮����
        Rotate();
        MoveToTarget();
        Invoke("DestroyThisProjectile", 3f);
    }

    private void DestroyThisProjectile()
    {
        Destroy(gameObject);
    }

    private void Rotate()
    {
        transform.LookAt(TargetPosition - transform.position);
    }

    private void MoveToTarget()
    {
        rb.velocity = (TargetPosition - transform.position).normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}�� �ε���");
        if(other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakePhysicalDamage(damage);
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}