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
        TargetPosition = CharacterManager.Instance.Player.transform.position + Vector3.up * 1.7f;   //캐릭터의 머리부분을 노리도록
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
        Debug.Log($"{other.name}와 부딪힘");
        if(other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakePhysicalDamage(damage);
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}