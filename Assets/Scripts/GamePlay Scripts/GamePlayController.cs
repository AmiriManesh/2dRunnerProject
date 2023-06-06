using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [HideInInspector]
    public int selectedCharacter = 0;
    [SerializeField]
    private int character2UnlockScore = 10 , character3UnlockScore = 20;
    [SerializeField]
    private GameObject[] player;
    public Button Attack_Buttons;
    public Button Jump_Buttons;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            int gameData = DataManager.GetData(TagManager.DATA_INITIALIZED);
            //check if game is initialized
                //PlayerPrefs.DeleteAll();
            if (gameData == 0)
            {
                // first time running the game , initialize data
                selectedCharacter = 0;
                DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedCharacter);
                DataManager.SaveData(TagManager.HIGHSCORE_DATA, 0);
                DataManager.SaveData(TagManager.SFX_DATA, 1);
                DataManager.SaveData(TagManager.MUSIC_DATA, 1);
                DataManager.SaveData(TagManager.CHARACTER_DATA + "0", 1);
                DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 0);
                DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 0);
                DataManager.SaveData(TagManager.DATA_INITIALIZED, 1);
            }
            else if (gameData == 1)
            {
                selectedCharacter = DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA);
            }
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode sceneMode)
    {
        if(scene.name == TagManager.GAMEPLAY_SCENE_NAME)
        {
            Instantiate(player[selectedCharacter]);
            SoundManager.instance.Player = Camera.main.transform;
            Camera.main.GetComponent<CameraFollow>().FindPlayerRefrence();
        }
    }

    public void CheckToUnlockCharacter(int score)
    {
        if(score >= character3UnlockScore)
        {
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 1);
        }
        else if(score >= character2UnlockScore)
        {
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
        }
    }




}
