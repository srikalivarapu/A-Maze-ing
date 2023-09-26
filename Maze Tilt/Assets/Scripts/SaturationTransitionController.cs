using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SaturationTransitionController : MonoBehaviour
{
    public float transitionDuration = 5f;  // Total time for each saturation transition (in seconds)
    public float saturationAtZeroDuration = 2f;  // Time taken to reach saturation 0

    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;
    private float initialSaturation = 0f;
    private float targetSaturation = 0f;  // Initial target saturation is 0
    private float elapsedTime = 0f;
    private bool isTransitioning = false;

    private int clickCount = 0;
    [SerializeField] public GameObject yourButtonGameObject;
    [SerializeField] public GameObject hinttext;

    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
        StartSaturationTransition();
    }

    void Update()
    {
        if (isTransitioning)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / (targetSaturation == 0f ? saturationAtZeroDuration : transitionDuration);

            if (targetSaturation == 0f)
            {
                colorGrading.saturation.value = Mathf.Lerp(initialSaturation, targetSaturation, t);
            }
            else
            {
                colorGrading.saturation.value = Mathf.Lerp(initialSaturation, targetSaturation, t);
            }

            if (elapsedTime >= (targetSaturation == 0f ? saturationAtZeroDuration : transitionDuration))
            {
                // Switch target saturation when reaching 0
                if (targetSaturation == 0f)
                    targetSaturation = -100f;

                initialSaturation = colorGrading.saturation.value;
                elapsedTime = 0f;
            }
        }
    }
    public void ButtonClickHandler()
    {
        if (clickCount < 2)
        {
            StartSaturationTransition();
            clickCount++;

            if (clickCount == 2)
            {
                // Disable the button (hide the whole GameObject) after the second click
                yourButtonGameObject.SetActive(false);
                hinttext.SetActive(false);
            }
        }
    }

    public void StartSaturationTransition()
    {
        // Reset initialSaturation and set targetSaturation to 0 to start the transition to 0
        initialSaturation = colorGrading.saturation.value;
        targetSaturation = 0f;
        elapsedTime = 0f;
        isTransitioning = true;
    }


}
