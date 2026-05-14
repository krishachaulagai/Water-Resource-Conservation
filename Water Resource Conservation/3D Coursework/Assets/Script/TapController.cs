using UnityEngine;

public class TapController : MonoBehaviour
{
    public ParticleSystem waterFlow;
    private bool tapOn = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tapOn)
            {
                waterFlow.Stop();
                tapOn = false;
                Debug.Log("Tap Turned Off");
            }
            else
            {
                waterFlow.Play();
                tapOn = true;
                Debug.Log("Tap Turned On");
            }
        }
    }
}