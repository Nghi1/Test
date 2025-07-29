using UnityEngine;

public class Ball : MonoBehaviour
{
    public ObjectPool pool; 
    public float lifeTime = 2f;
    void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifeTime);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
    void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }
    void ReturnToPool()
    {
        if (pool != null)
        {
            pool.ReturnToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
