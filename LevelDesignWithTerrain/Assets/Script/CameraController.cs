using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for the EventTrigger

public class CameraController : MonoBehaviour
{
    [SerializeField] private Button goRight;
    [SerializeField] private Button goLeft;
    [SerializeField] private Button goUp;
    [SerializeField] private Button goDown;

    [SerializeField] private Slider heightSlider;
    [SerializeField] private Text heightDisplay;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float maxHeight = 50;
    [SerializeField] private float minHeight = 0;
    
    [SerializeField] private float speed = 10;

    private Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        
        float currentValue = MapSliderValue(heightSlider.value, minHeight, maxHeight);
        // Optionally, display the current value if you have a Text component to show it
        if(heightDisplay != null)
        {
            heightDisplay.text = $"Camera Height: {currentValue} m"; // Display the value with 2 decimal places
        }
        cameraTransform.position = new Vector3(cameraTransform.position.x, currentValue, cameraTransform.position.z); // Update the camera height to the current value
        
    }
    
    float MapSliderValue(float sliderValue, float min, float max)
    {
        return Mathf.Lerp(min, max, sliderValue);
    }

    public void StartMovingRight()
    {
        moveDirection = Vector3.right;
    }

    public void StartMovingLeft()
    {
        moveDirection = Vector3.left;
    }

    public void StartMovingUp()
    {
        moveDirection = Vector3.forward;
    }

    public void StartMovingDown()
    {
        moveDirection = Vector3.back;
    }

    public void StopMoving()
    {
        moveDirection = Vector3.zero;
    }
}