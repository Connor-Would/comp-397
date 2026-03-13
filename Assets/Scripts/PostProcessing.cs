using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    [SerializeField] private Volume globalVolume;
    private ColorAdjustments colourOveride;
    private Color defaultColour = Color.white;
    private Color poisonColour = Color.green;
    private float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            if (globalVolume.profile.TryGet(out colourOveride))
                colourOveride.colorFilter.Override(poisonColour);
        }
        if (timer > 2.75f)
        {
            if (globalVolume.profile.TryGet(out colourOveride))
                colourOveride.colorFilter.Override(defaultColour);
            timer = 0f;
        }
    }
}
