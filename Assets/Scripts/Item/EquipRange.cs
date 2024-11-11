using UnityEngine;

public class EquipRange : Equip
{
    [Header("Bow")]
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;

    [Header("Wand")]
    public float useMana;

    public Transform ProjectilePosition;

    private Animator animator;
    private Camera cam;


    private void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }


    private IProjectile projectile;

    public void SetProjectile(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking = true;

                projectile?.Fire();

                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }


    private void OnCanAttack()
    {
        attacking = false;
    }

}