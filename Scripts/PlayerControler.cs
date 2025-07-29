using UnityEngine;
using System.Collections.Generic;

public class PlayerControler : MonoBehaviour
{
    private Animator an;
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;
    public Transform firePoint;
    public ObjectPool bulletPool;
    public float bulletForce = 20f;
    void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleShoot();
    }
    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        float speed = move.magnitude * moveSpeed;
        an.SetFloat("Speed", speed);
        if (move != Vector3.zero)
        transform.forward = move.normalized;
    }
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            an.SetBool("IsJumping", true);
            isGrounded = false;
        }
    }
    void HandleShoot()
    {
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            an.SetTrigger("Shoot");
            GameObject bullet = bulletPool.Get();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        rb.MovePosition(rb.position + move.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            an.SetBool("IsJumping", false);
        }
    }
}
