using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip pUPDoubleJumpSFX;
    [SerializeField] AudioClip shieldSFX;
    [SerializeField] AudioClip shieldBreakSFX;
    [SerializeField] AudioClip landSFX;


    public void PlaySFX(string clip)
    {

        switch (clip)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJumpSFX;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = pUPDoubleJumpSFX;
                break;
           case "PowerupShield":
                audioSource.clip = shieldSFX;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreakSFX;
                break;
            case "Land":
                audioSource.clip = landSFX;
                break;
        }

        audioSource.Play();
    }
}
