using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform firePoint;
    public float bulletForce = 20f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        animator.SetTrigger("Shoot");
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
