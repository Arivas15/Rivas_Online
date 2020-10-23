using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameOverManager : NetworkBehaviour
{
    PlayerMovement localPlayer;
    PlayerHealth playerHealth;
	public float restartDelay = 5f;

    Animator anim;
	float restartTimer;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (localPlayer.GetComponent<PlayerHealth>() == null)
        {
            foreach (PlayerMovement pm in FindObjectsOfType<PlayerMovement>())
            {
                if (pm.isLocalPlayer)
                {
                    localPlayer = pm;
                }

            }
        }
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) 
            {
                SceneManager.LoadScene(0);
			}
        }
    }
}
