using UnityEngine;
using System.Collections;

public class FollowBuilding : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	
	public Transform Building;		// Reference to the player.



	void Update ()
	{
		// Set the position to the player's position with the offset.
		transform.position = Building.position + offset;
	}
}
