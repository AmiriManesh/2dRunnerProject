using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    public AudioSource bgAudio, gameOverAudio;
    [SerializeField]
    public AudioSource player_att;
    [SerializeField]
    private AudioClip bgMusic, mainMenuMusic, playerAttackSound, playerJumpSound, 
        playerDeathSound, enemyAttackSound, enemyDeathSound, collectableSound, destroyObstacleSound
         , obstacleAttackSound;
    [SerializeField]
    public bool SFXSoundsIs;
    public Transform Player;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        bgAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == TagManager.GAMEPLAY_SCENE_NAME)
        {
            if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
                PlayBGMusic(true);
        }
        else
        {
            if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
                PlayBGMusic(false);
        }
    }

    public void PlayBGMusic(bool gameplay)
    {
        if(gameplay)
        {
            bgAudio.clip = bgMusic;
        }
        else
        {
            bgAudio.clip = mainMenuMusic;
        }
        bgAudio.Play();
    }

    public void StopBGMusic()
    {
        bgAudio.Stop();
    }
    public void Play_GameOverSound()
    {
        if (SFXSoundsIs)
            gameOverAudio.Play();
        else
            return;
    }
    public void Play_PlayerAttack_Sound()
    {
        if(SFXSoundsIs)
            AudioSource.PlayClipAtPoint(playerAttackSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else    
            AudioSource.PlayClipAtPoint(playerAttackSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

    public void Play_PlayerJump_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(playerJumpSound,/*Player.position*/new Vector3(Player.position.x, Player.position.y + 1.5f, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(playerJumpSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

    public void Play_PlayerDeath_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(playerDeathSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(playerDeathSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

    public void Play_EnemyAttack_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(enemyAttackSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(enemyAttackSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

    public void Play_EnemyDeath_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(enemyDeathSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(enemyDeathSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

    public void Play_Collectable_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(collectableSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(collectableSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }
    public void Play_ObstacleDestroy_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(destroyObstacleSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(destroyObstacleSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }
    public void Play_ObstacleAttack_Sound()
    {
        if (SFXSoundsIs)
            AudioSource.PlayClipAtPoint(obstacleAttackSound, new Vector3(Player.position.x, Player.position.y + 6, Player.position.z));
        else
            AudioSource.PlayClipAtPoint(obstacleAttackSound, new Vector3(Player.position.x, Player.position.y + 10000, Player.position.z));
    }

}
