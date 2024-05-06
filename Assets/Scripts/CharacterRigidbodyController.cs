using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CharacterRigidbodyController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] Transform playerRestartPoint;

    Vector3 moveDrection;

    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;

    [Header("Ground Checks")]
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundDrag;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDrection = direction;
    }

    private void Update()
    {
        if (isGrounded)
        {
            playerRigidbody.drag = groundDrag;
        }
        else
        {
            playerRigidbody.drag = 0;
        }

        SpeedControll();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 2f, groundLayerMask);

        playerRigidbody.AddForce(moveDrection.normalized * acceleration, ForceMode.Acceleration);
    }

    private void SpeedControll()
    {
        Vector3 flatVelocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            playerRigidbody.velocity = new Vector3(limitedVelocity.x, playerRigidbody.velocity.y, limitedVelocity.z);
        }
    }
}
