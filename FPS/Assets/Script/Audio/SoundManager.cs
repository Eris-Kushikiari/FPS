using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    // Empty bullet Sound
    public AudioSource emptySoundM1911;

    //Shooting Sound Channel
    public AudioSource shootingChannel;

    //Guns Sound
    public AudioClip M1911Sound;
    public AudioClip AK74Sound;

    public AudioSource reloadingSoundAK74;
    public AudioSource reloadingSoundM1911;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.M1911:
                shootingChannel.PlayOneShot(M1911Sound);
                break;
            case WeaponModel.AK74:
                shootingChannel.PlayOneShot(AK74Sound);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.M1911:
                reloadingSoundM1911.Play();
                break;
            case WeaponModel.AK74:
                reloadingSoundAK74.Play();
                break;
        }
    }
}
