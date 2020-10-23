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
		target = GameObject.FindGameObjectWithTag("Player").transform;
		offset = transform.position - target.position;
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
				}

			}
		}
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
