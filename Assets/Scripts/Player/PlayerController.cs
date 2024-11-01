using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;  //회전범위지정
    public float maxXLook;
    public float lookSensitivity;
    private float camCurXRot;
    private Vector2 mouseDelta;
    public bool canLook = true;

    [Header("Settings")]
    public GameObject SettingCanvas;

    public Action inventory;

    private Rigidbody _rigidbody;
    private Skill skill;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //커서 none, lock, confine종류가있다.
        skill = CharacterManager.Instance.Player.skill;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y; //점프했을 때에만 위아래로 움직여야한다.

        _rigidbody.velocity = dir;
    }

    private void CameraLook()
    {
        //마우스를 움직일 시 mouseDelta.x가 변경 하지만 움직이려면 y축을 중심으로 회전한다.
        //mouseDelta.x값을 민감도랑 곱해서 y값에 추가한 것.
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);  //마우스를 내리면 음수가되면서 내려간다.(위를본다)

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            //책상다리 만들기 현재위치             살짝 앞에서                  조금 위로올라와서
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            //                          짧게    이 마스크에 해당하는 것만
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    public void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            //스킬을 사용합니다.
            skill.UseQSkill(skill.FireBall.UseMana);
        }
    }

    public void OnSettings(InputAction.CallbackContext context)
    {
        GameObject setting = UIManager.Instance.settings.gameObject;
        if (context.phase == InputActionPhase.Started)
        {
            setting.SetActive(!gameObject.activeSelf);
            Cursor.lockState = setting.activeSelf ? CursorLockMode.Locked : CursorLockMode.None;
            ToggleCursor();
            Time.timeScale = setting.activeSelf ? 0f : 1f;
        }

    }

}
