using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    public RectTransform joystickOutline;
    public RectTransform joystickButton;
    private bool canControlJoystick;
    private Vector3 tapPosition;
    [SerializeField] private float moveFactor;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        HideJoystick();
    }

    public void TappedOnJoystickZone()
    {
        Debug.Log("Tapped");
        ShowJoystick();
        tapPosition = Input.mousePosition;
        joystickOutline.position = tapPosition;

    }

    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
        canControlJoystick = true;

    }

    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        canControlJoystick = false;
        move = Vector3.zero;

    }

    private void ControlJoystick()
{
    Vector3 currentPosition = Input.mousePosition;
    Vector3 direction = currentPosition - tapPosition;

    float canvasYScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
    float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

    float joystickOutlineHalfWidth = joystickOutline.rect.width / 2;
    float newWidth = joystickOutlineHalfWidth * canvasYScale;

    moveMagnitude = Mathf.Min(moveMagnitude, newWidth);
    move = direction.normalized * moveMagnitude;
    Vector3 targetPos = tapPosition + move;

    UpdateJoystickPosition(targetPos);

    if (Input.GetMouseButtonUp(0))
    {
        HideJoystick();
    }
}

private void UpdateJoystickPosition(Vector3 targetPosition)
{
    joystickButton.position = targetPosition;
}

    public Vector3 GetMovePosition()
    {
        return move / 1.75f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canControlJoystick)
        {
            ControlJoystick();

        }
        
    }
}
