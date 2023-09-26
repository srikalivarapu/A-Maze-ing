using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SaturationController : MonoBehaviour
{
    public float transitionDuration = 5f;  // Total time for the saturation transition (in seconds)

    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;
    private float initialSaturation = 0f;
    private float targetSaturation = -100f;
    private float elapsedTime = 0f;

    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
        initialSaturation = colorGrading.saturation.value;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= transitionDuration)
        {
            // Ensure we reach exactly the target saturation
            colorGrading.saturation.value = targetSaturation;
        }
        else
        {
            float t = elapsedTime / transitionDuration;  // Interpolation parameter
            colorGrading.saturation.value = Mathf.Lerp(initialSaturation, targetSaturation, t);
        }
    }
}
