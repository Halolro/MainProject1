using UnityEngine;

public class RodSwaying : MonoBehaviour
{
    [Header("³¬½Ã´ë Èçµé¸² ¼³Á¤")]
    public float swaySpeed = 2f;   
    public float swayAngle = 5f;   

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swaySpeed) * swayAngle;
        transform.rotation = startRotation * Quaternion.Euler(0, 0, angle);
    }
}