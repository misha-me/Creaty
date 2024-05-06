using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Player))]
public class CharacterInputManager : MonoBehaviour
{
    private Transform cameraTransform;
    public InputActionAsset standardInput;

    private InputAction moveAction;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;
        standardInput.actionMaps[0].Enable();

        moveAction = standardInput.FindActionMap("default").FindAction("move");
    }

    private void Update()
    {
        Vector3 projectedCameraRight = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up);
        Vector3 projectedCameraUp = Vector3.ProjectOnPlane(cameraTransform.up, Vector3.up);
        Vector3 moveDirection = projectedCameraRight * moveAction.ReadValue<Vector2>().x + projectedCameraUp * moveAction.ReadValue<Vector2>().y;
        GetComponent<CharacterRigidbodyController>().SetMoveDirection(moveDirection);
    }
    private void OnEnable()
    {
        standardInput.actionMaps[0].Enable();
    }

    private void OnDisable()
    {
        standardInput.actionMaps[0].Disable();
    }
}
