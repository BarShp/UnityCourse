using UnityEngine;

// Include the namespace required to use Unity UI
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public Transform mainCamera;
	public float speed;
	public float sprintModeMultiplier;
	public Text countText;
	public Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;
	private int countGoal;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";

		countGoal = GameObject.FindGameObjectsWithTag("Pick Up").Length;
	}

	// Each physics step..
	void FixedUpdate()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

		// Change movement to camera direction
		Vector3 movementCameraDirection = mainCamera.TransformDirection(movement);
		movementCameraDirection.y = 0;

		// Calculate speed
		bool sprintMode = Input.GetKey(KeyCode.LeftShift);
		float speedToAdd = sprintMode ? speed * sprintModeMultiplier : speed;

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce(movementCameraDirection * speedToAdd);

		// TODO: Fix the bug - 
		//		When looking down without setting the .y -> 0, speed uphill is 2.0.
		//		When looking down with setting the .y -> 0, speed uphill is ~4.4 (even with leverage)
		//		When looking up		//	//		//	//	//, speed uphill is ~4.5 without leverage, but up to 9.0 with leverage
		Debug.Log("Velocity" + rb.velocity);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other)
	{
		string otherObjectTag = other.gameObject.tag;
		switch (otherObjectTag)
		{
			case "Pick Up":
				// Make the other game object (the pick up) inactive, to make it disappear
				other.gameObject.SetActive(false);
				// Add one to the score variable 'count'
				count = count + 1;
				// Run the 'SetCountText()' function (see below)
				SetCountText();
				break;
			case "Mine":
				gameObject.SetActive(false);
				winText.text = "You Lose!";
				break;
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= countGoal)
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
}