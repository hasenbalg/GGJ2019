

using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
    [Tooltip("Grad pro Sekunde")]
    public float rotSpeed = 300.0f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start()
	{
		controller = GetComponent<CharacterController>();

		// let the gameObject fall down
		gameObject.transform.position = new Vector3(0, 5, 0);
	}

	void Update()
	{
		if (controller.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes

			moveDirection = new Vector3(0.0f , 0.0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection * speed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		// Apply gravity
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);


        Quaternion destRotation = controller.transform.rotation;
        destRotation.eulerAngles = destRotation.eulerAngles + new Vector3(0, Input.GetAxis("Horizontal") * 2, 0);
        controller.transform.rotation = Quaternion.RotateTowards(transform.rotation, destRotation, Time.deltaTime * rotSpeed);
    }
}