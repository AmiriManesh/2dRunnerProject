using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetUIButtons : MonoBehaviour
{
    public GameObject Player;
    public Button Attack_Button;
    public Button Jump_Button;
    public Button Panda;
    public bool Clicked_Activate_UI = false;
    void Start()
    {
        Player = GameObject.FindWithTag(TagManager.PLAYER_TAG);
    }
    public void GetAttackInput()
    {
        if (Time.time > Player.GetComponent<PlayerMovement>().attackTimer && Player.GetComponent<PlayerMovement>().Dead == false)
        {
            Player.GetComponent<PlayerMovement>().attackTimer = Time.time + Player.GetComponent<PlayerMovement>().attackWaitTime;
            Player.GetComponent<PlayerMovement>().canAttack = true;
            SoundManager.instance.Play_PlayerAttack_Sound();
            //Attack_Button.onClick.RemoveListener(GetAttackInput);
        }
    }

    public void PlayerJump()
    {
        if (!Player.GetComponent<PlayerMovement>().IsGrounded() && Player.GetComponent<PlayerMovement>().CanDoubleJump 
            && Player.GetComponent<PlayerMovement>().Dead == false)
        {
            Player.GetComponent<PlayerMovement>().CanDoubleJump = false;
            Player.GetComponent<PlayerMovement>().MyBody.velocity = Vector2.zero;
            Player.GetComponent<PlayerMovement>().MyBody.AddForce(
            new Vector2(0f,Player.GetComponent<PlayerMovement>().JumpForce), ForceMode2D.Impulse);
            Player.GetComponent<PlayerMovement>().playerAnim.PlayDoubleJump();
            SoundManager.instance.Play_PlayerJump_Sound();
        }

        if (Player.GetComponent<PlayerMovement>().IsGrounded() && Player.GetComponent<PlayerMovement>().Dead == false)
        {
            Player.GetComponent<PlayerMovement>().CanDoubleJump = true;
            Player.GetComponent<PlayerMovement>().MyBody.AddForce(
            new Vector2(0f,Player.GetComponent<PlayerMovement>().JumpForce), ForceMode2D.Impulse);
            SoundManager.instance.Play_PlayerJump_Sound();
        }
    }

    public void Activate_UI_Icons()
    {
        if(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return)
            && !Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(!Clicked_Activate_UI)
            {
                Jump_Button.gameObject.SetActive(true);
                Attack_Button.gameObject.SetActive(true);
                Clicked_Activate_UI = true;
            }
            else
            {
                Jump_Button.gameObject.SetActive(false);
                Attack_Button.gameObject.SetActive(false);
                Clicked_Activate_UI = false;
            }
        }
    }
}
