using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject[] healthBars;
    private int currentHealthBarIndex;
    public int health;
    public PlayerAnimationsWithTransitions playerAnim;

    private void Awake()
    {
        healthBars = GameObject.FindWithTag(TagManager.HEALTH_BAR_HOLDER_TAG)
            .GetComponent<HealthBarHolder>().healthBars;
    }

    private void Start()
    {
        health = healthBars.Length;
        currentHealthBarIndex = health - 1;
    }

    public void SubtractHealth()
    {
        healthBars[currentHealthBarIndex].SetActive(false);
        currentHealthBarIndex--;
        health--;
        SoundManager.instance.Play_ObstacleAttack_Sound();
        if(health<=0)
        {
            GetComponent<PlayerMovement>().Dead = true;
            GetComponent<CapsuleCollider2D>().excludeLayers = LayerMask.NameToLayer("Obstacle");
            if (GetComponent<PlayerMovement>().IsGrounded())
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CapsuleCollider2D>().enabled = false;
                StartCoroutine(PlayerDeathAnimation());
            }
            else
            {
                StartCoroutine(PlayerDeathAnimation_InAir());
            }
        }
    }

    public IEnumerator PlayerDeathAnimation_InAir()
    {
        SoundManager.instance.Play_PlayerDeath_Sound();
        playerAnim.PlayDeath();
        for (float i = GetComponent<PlayerMovement>().MoveSpeed; i > 0; i -= 0.5f)
        {
            GetComponent<PlayerMovement>().MoveSpeed = i;
            yield return new WaitForSeconds(0.1f);
        }  
        GameObject.FindGameObjectWithTag(TagManager.GAMEPLAY_CONTROLLER_TAG)
            .GetComponent<GameOverController>().GameOverShowPanel();
        GetComponent<PlayerMovement>().Dead = false;
        Destroy(gameObject);
    }

    public IEnumerator PlayerDeathAnimation()
    {
        SoundManager.instance.Play_PlayerDeath_Sound();
        playerAnim.PlayDeath();
        transform.position = new Vector3(transform.position.x , -2.800f , transform.position.z);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        for (float i = GetComponent<PlayerMovement>().MoveSpeed; i > 0 ; i-= 0.5f)
        {
            GetComponent<PlayerMovement>().MoveSpeed = i;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.FindGameObjectWithTag(TagManager.GAMEPLAY_CONTROLLER_TAG)
            .GetComponent<GameOverController>().GameOverShowPanel();
        GetComponent<PlayerMovement>().Dead = false;
        Destroy(gameObject);
    }
    void AddHealth()
    {
        if (health == healthBars.Length)
            return;

        health++;
        currentHealthBarIndex = health - 1;
        healthBars[currentHealthBarIndex].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.HEALTH_TAG))
        {
            SoundManager.instance.Play_Collectable_Sound();
            AddHealth();
            other.gameObject.SetActive(false);
        }
    }

}
