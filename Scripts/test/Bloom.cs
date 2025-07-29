using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomTrigger : MonoBehaviour
{
    public Volume volume;           
    private Bloom bloom;

    private void Start()
    {
        
        volume.profile.TryGet(out bloom);
        bloom.intensity.value = 0f; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bloom.intensity.value = 1000000f;  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bloom.intensity.value = 0f;  
        }
    }
}
