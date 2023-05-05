using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSelectMenuPanel;
    [SerializeField]
    private Text highscoreTxt;
    private CharacterSelectMenu charSelectMenu;
    [SerializeField]
    private Image musicImg;
    [SerializeField]
    private Image SFXImg;
    [SerializeField]
    private Sprite musicOnSprite, musicOffSprite;
    [SerializeField]
    private Sprite SFXOnSprite, SFXOffSprite;

    private void Awake()
    {
        
    }

    private void Start()
    {
        if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
        {
            musicImg.sprite = musicOnSprite;
        }
        else
        {
            musicImg.sprite = musicOffSprite;
        }
        if (DataManager.GetData(TagManager.SFX_DATA) == 1)
        {
            SFXImg.sprite = SFXOnSprite;
        }
        else
        {
            SFXImg.sprite = SFXOffSprite;
        }
        highscoreTxt.text = "HighScore : " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "M";
        charSelectMenu = GetComponent<CharacterSelectMenu>();
    }

    public void OpenCloseCharacterSelectMenu(bool open)
    {
        if (open)
            charSelectMenu.InitializeCharacterMenu();

        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
    {
        int selectChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GamePlayController.instance.selectedCharacter = selectChar;
        DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectChar);
        charSelectMenu.InitializeCharacterMenu();
    }
    public void PlayGame()
    {
        if (DataManager.GetData(TagManager.SFX_DATA) == 1)
        {
            SoundManager.instance.SFXSoundsIs = true;
        }
        else
        {
            SoundManager.instance.SFXSoundsIs = false;
        }
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void TurnMusicOnOrOff()
    {
        if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
        {
            DataManager.SaveData(TagManager.MUSIC_DATA, 0);
            musicImg.sprite = musicOffSprite;
            SoundManager.instance.StopBGMusic();
        }
        else
        {
            DataManager.SaveData(TagManager.MUSIC_DATA, 1);
            musicImg.sprite = musicOnSprite;
            SoundManager.instance.PlayBGMusic(false);
        }
    }
    public void TurnSFXOnOrOff()
    {
        if (DataManager.GetData(TagManager.SFX_DATA) == 1)
        {
            DataManager.SaveData(TagManager.SFX_DATA, 0);
            SFXImg.sprite = SFXOffSprite;
            SoundManager.instance.SFXSoundsIs = false;
        }
        else
        {
            DataManager.SaveData(TagManager.SFX_DATA, 1);
            SFXImg.sprite = SFXOnSprite;
            SoundManager.instance.SFXSoundsIs = true;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
