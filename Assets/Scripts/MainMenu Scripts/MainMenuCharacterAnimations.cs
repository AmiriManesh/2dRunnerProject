using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCharacterAnimations : MonoBehaviour
{
    [SerializeField]
    private Sprite[] animSprites;

    [SerializeField]
    private float timeThreshold = 0.1f;
    private float timer;
    private int state = 0;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            img.sprite = animSprites[state];
            state++;
            if (state == animSprites.Length)
                state = 0;

            timer = Time.time + timeThreshold;
        }
    }


}
