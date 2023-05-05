using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    [SerializeField]
    private GameObject HelpPanel;
    [SerializeField]
    private Button CharacterSelect, SFX, Music;
    [SerializeField] private Image ImgShow;
    [SerializeField] private List<Sprite> Show_Images;
    private int ImgIndex;
    private void Start()
    {
        ImgShow.sprite = Show_Images[0];
    }
    public void NextImage()
    {
        ImgIndex++;
        if (ImgIndex > Show_Images.Count - 1)
            ImgIndex = 0;
        ImgShow.sprite = Show_Images[ImgIndex];
    }

    public void PreviousImage()
    {
        ImgIndex--;
        if (ImgIndex < 0)
            ImgIndex = Show_Images.Count - 1;
        ImgShow.sprite = Show_Images[ImgIndex];
    }

    public void ExitSlideShow()
    {
        ImgShow.sprite = Show_Images[0];
        ImgShow.gameObject.SetActive(false);
        CharacterSelect.enabled = true;
        SFX.enabled = true;
        Music.enabled = true;
        HelpPanel.SetActive(false);
    }
    public void Activate_HelpPanel()
    {
        HelpPanel.SetActive(true);
        ImgShow.gameObject.SetActive(true);
        CharacterSelect.enabled = false;
        SFX.enabled = false;
        Music.enabled = false;
    }
}
