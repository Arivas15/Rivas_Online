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
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(localPlayer != null)
        {
            foreach(PlayerMovement pm in FindObjectsOfType<PlayerMovement>())
            {
                if(pm.isLocalPlayer)
                {
                    localPlayer = pm;
                    playerHealth = localPlayer.GetComponent<PlayerHealth>();
                }
            }
        }

        if (playerHealth != null && playerHealth.currentHealth <= 0)
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
