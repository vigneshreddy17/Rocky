using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;
    public AudioSource EntryMusic, DeathMusic, VictoryMusic;
    public AudioSource[] sfx;
    private void Awake()
    {
        audioManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathMusic()
    {
        EntryMusic.Stop();
        DeathMusic.Play();
    }

    public void PlayVictoryMusic()
    {
        EntryMusic.Stop();
        VictoryMusic.Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
