using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraFollow : NetworkBehaviour
{
	PlayerMovement localPlayer;
	Transform target;
	public float smoothing = 5f;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position - FindObjectOfType<NetworkManager>().transform.position;
	}

	void FixedUpdate()
	{
		if (localPlayer == null)
		{
			foreach (PlayerMovement pm in FindObjectsOfType<PlayerMovement>())
			{
				if (pm.isLocalPlayer)
				{
					localPlayer = pm;
					target = localPlayer.transform;
				}

			}
			return;
		}
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
