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
        //화면 중앙을 쏘는방법...
        if(Physics.Raycast(ray, out hit, 30f))
        {
            dir = (hit.point - transform.position).normalized;
        }
        else
        {
            //이상한데쏘거나 공중을 쏘면 공격취소
            Destroy(gameObject);
        }
        rb.velocity = dir * fireBallSpeed;
    }

    private void Rotate()
    {
        //z축으로 나갈때 x축이 -90도
        //x축으로 나갈때 z축이 90도
        float x = -dir.z * 90;
        float z = dir.x * 90;
        float y = dir.y;

        transform.eulerAngles = new Vector3(x, y, z);
    }
}