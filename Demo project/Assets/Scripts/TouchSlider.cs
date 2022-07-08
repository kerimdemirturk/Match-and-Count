using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //events for informing other script when pointerValue change
    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction OnPointerUpEvent;

    //Component uý Slider
    private Slider uiSlider;

    //Acsess slider
    private void Awake()
    {
        uiSlider = GetComponent<Slider>();
        uiSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    //events methods
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null)
            OnPointerDownEvent.Invoke();

        if (OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(uiSlider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        if (OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
            OnPointerUpEvent.Invoke();

        // reset slider value:
        uiSlider.value = 0f;
    }

    //remove listeners: to avoid memory leaks
    private void OnDestroy()
    {
        uiSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}
