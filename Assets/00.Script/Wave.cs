using UnityEngine;

public class SeaGroupWaveMover : MonoBehaviour
{
    [Header("바다 군무 위아래 설정")]
    public float waveAmplitude = 0.1f;
    public float waveSpeed = 2f;

    private float startY;
    private float timeAccumulator;

    void Start()
    {
        startY = transform.position.y;
        timeAccumulator = 0f;
    }

    void Update()
    {
        timeAccumulator += Time.deltaTime * waveSpeed;

        float waveOffsetY = Mathf.Sin(timeAccumulator) * waveAmplitude;

        transform.position = new Vector3(transform.position.x, startY + waveOffsetY, transform.position.z);
    }
}