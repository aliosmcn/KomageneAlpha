using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 6f; // Karakterin hareket h�z�
    [SerializeField] private Vector3 movement; // Hareket vekt�r�

    [Header("Base Events")]
    [SerializeField] private FloatEvent onHorizontalValueChanged;
    [SerializeField] private FloatEvent onVerticalValueChanged;
    [SerializeField] private VoidEvent onSliceToggle;

    private Animator animator;
    private Rigidbody rb; // Karakterin Rigidbody bile�eni

    private bool canMove = true;

    float verticalValue, horizontalValue;



    protected virtual void OnEnable()
    {
        onHorizontalValueChanged.AddListener(HorizontalValueChanged);
        onVerticalValueChanged.AddListener(VerticalValueChanged);
        onSliceToggle.AddListener(MoveLock);
    }

    protected virtual void OnDisable()
    {
        onHorizontalValueChanged.RemoveListener(HorizontalValueChanged);
        onVerticalValueChanged.RemoveListener(VerticalValueChanged);
        onSliceToggle.RemoveListener(MoveLock);
    }

    private void HorizontalValueChanged(float value)
    {
        horizontalValue = value;
    }

    private void VerticalValueChanged(float value)
    {
        verticalValue = value;
    }

    protected virtual void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        if (canMove) Move();
    }

    private void Move()
    {
        // Kullan�c� giri�ini al
        float horizontalInput = horizontalValue;
        float verticalInput = verticalValue;

        // Hareket vekt�r�n� olu�tur
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;


        // Karakterin gitti�i y�ne d�n
        if (movement != Vector3.zero)
        {
            animator.SetBool("IsWalk", true);
            Quaternion targetRotation = Quaternion.LookRotation(movement); // Hedef rotasyonu hesapla
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20f); // Yumu�ak bir d�n�� sa�la
        }
        if (movement == Vector3.zero)
        {
            animator.SetBool("IsWalk", false);
        }
    }

    protected virtual void FixedUpdate()
    {
        // Karakterin hareketini uygular
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Hareketi slice durumuna g�re freeze eder.
    private void MoveLock()
    {
        canMove = !canMove;
        movement = Vector3.zero;
        animator.SetBool("IsWalk", false);
    }

}
