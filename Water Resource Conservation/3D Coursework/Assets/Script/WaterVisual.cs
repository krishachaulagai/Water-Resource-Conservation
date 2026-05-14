using UnityEngine;

public class WaterVisual : MonoBehaviour
{
    public WaterManager manager;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float height = manager.waterLevel / 100f;

        transform.localScale = new Vector3(
            startScale.x,
            height * startScale.y,
            startScale.z
        );
    }
}