using UnityEngine;
using UnityEngine.UIElements;

public class FireBall : MonoBehaviour
{
    public GameObject fireballPrefab;

    private Rigidbody rb;

    public float UseMana = 30;
    public int damage = 30;
    public float fireBallSpeed = 5;

    private Vector3 dir;
    private Camera cam;
    private Vector3 rot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent(out IDamagable Idamage))
            {
                Idamage.TakePhysicalDamage(damage);
            }

        }
    }

    private void OnEnable()
    {
        cam = Camera.main;
        FireBallMove();
        Rotate();
    }

    private void FireBallMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        //ȭ�� �߾��� ��¹��...
        if(Physics.Raycast(ray, out hit, 30f))
        {
            dir = (hit.point - transform.position).normalized;
        }
        else
        {
            //�̻��ѵ���ų� ������ ��� �������
            Destroy(gameObject);
        }
        rb.velocity = dir * fireBallSpeed;
    }

    private void Rotate()
    {
        //z������ ������ x���� -90��
        //x������ ������ z���� 90��
        float x = -dir.z * 90;
        float z = dir.x * 90;
        float y = dir.y;

        transform.eulerAngles = new Vector3(x, y, z);
    }
}