using UnityEngine;

public class SmoothTrackTarget : MonoBehaviour {

	[Tooltip("What you're tryna look at you goob.")]
	[SerializeField]
	Transform target;

	[Tooltip("Smaller number means slower camera tracking.")]
	[SerializeField]
	float smoothSpeed;

	// Logic is placed in LateUpdate to ensure it occurs after player movement
	// which is located in Update.
	void LateUpdate () {
		
		// Create a reference to our current position and our target goal.
		Vector3 currentPosition = transform.position;
		Vector3 desiredPosition = target.position;

		// Calculating interpolation of X axis between our current and target values.
		currentPosition.x = transform.position.x;
		currentPosition.x = currentPosition.x + (smoothSpeed * (desiredPosition.x - currentPosition.x));

		// Calculating interpolation of Z axis between our current and target values.
		currentPosition.y = transform.position.y;
		currentPosition.y = currentPosition.y + (smoothSpeed * ((desiredPosition.y) - currentPosition.y));

		// Applying our calculated interpolation to our camera transform.
		transform.position = currentPosition;
	}
}
