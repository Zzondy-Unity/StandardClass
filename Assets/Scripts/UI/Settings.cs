using UnityEngine;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.settings = this;
    }
}