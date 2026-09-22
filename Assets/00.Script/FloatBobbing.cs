using UnityEngine;

public class FloatBobbing : MonoBehaviour
{
    [Header("찌 움직임 설정")]
    public float floatSpeed = 2f;    
    public float floatHeight = 0.1f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + (Mathf.Sin(Time.time * floatSpeed) * floatHeight);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}