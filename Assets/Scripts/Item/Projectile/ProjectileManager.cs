using UnityEngine;

public enum ProjectileType
{
    Straight,
    Parabola,
    Circle
}

public interface IProjectile
{
    public void Fire();
    public ProjectileType projectileType { get; }
    public GameObject prefab { get; }
}

public class ProjectileManager : MonoBehaviour
{

}