using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterManager : MonoBehaviour
{
    public float waterLevel = 100f;
    public float drainSpeed = 5f;

    public bool leak1;
    public bool leak2;
    public bool leak3;

    public TextMeshProUGUI waterText;
    public TextMeshProUGUI warningText;
    public Slider waterBar;

    // Water particle systems
    public ParticleSystem leak1Water;
    public ParticleSystem leak2Water;
    public ParticleSystem leak3Water;

    void Update()
    {
        DrainWater();
        UpdateUI();
        HandleParticles();
    }

    void DrainWater()
    {
        float drain = 0f;

        if (leak1) drain += drainSpeed;
        if (leak2) drain += drainSpeed;
        if (leak3) drain += drainSpeed;

        waterLevel -= drain * Time.deltaTime;

        waterLevel = Mathf.Clamp(waterLevel, 0f, 100f);

        // Stop all leaks if water empty
        if (waterLevel <= 0)
        {
            leak1 = false;
            leak2 = false;
            leak3 = false;
        }
    }

    void UpdateUI()
    {
        waterText.text = "Water: " + Mathf.Round(waterLevel) + "%";

        waterBar.value = waterLevel;

        if (waterLevel > 50)
            waterText.color = Color.green;
        else if (waterLevel > 20)
            waterText.color = Color.yellow;
        else
            waterText.color = Color.red;

        if (waterLevel <= 20 && waterLevel > 5)
        {
            warningText.text = "⚠ LOW WATER!";
        }
        else if (waterLevel <= 5 && waterLevel > 0)
        {
            warningText.text = "🚨 CRITICAL WATER!";
        }
        else if (waterLevel <= 0)
        {
            warningText.text = "💀 WATER EMPTY!";
        }
        else
        {
            warningText.text = "";
        }
    }

    void HandleParticles()
    {
        HandleLeakParticle(leak1, leak1Water);
        HandleLeakParticle(leak2, leak2Water);
        HandleLeakParticle(leak3, leak3Water);
    }

    void HandleLeakParticle(bool leakOn, ParticleSystem water)
    {
        if (leakOn && waterLevel > 0)
        {
            if (!water.isPlaying)
                water.Play();
        }
        else
        {
            if (water.isPlaying)
                water.Stop();
        }
    }
}