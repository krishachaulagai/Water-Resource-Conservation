using UnityEngine;

public class LeakToggle : MonoBehaviour
{
    public WaterManager manager;
    public int leakNumber;

    private bool isOn = false;

    public ParticleSystem waterParticle;

    public Transform player;
    public float interactDistance = 3f;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOn = !isOn;

                if (leakNumber == 1)
                    manager.leak1 = isOn;

                if (leakNumber == 2)
                    manager.leak2 = isOn;

                if (leakNumber == 3)
                    manager.leak3 = isOn;

                if (isOn)
                    waterParticle.Play();
                else
                    waterParticle.Stop();
            }
        }
    }
}