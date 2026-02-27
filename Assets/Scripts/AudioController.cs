using UnityEngine;
using System.Collections;


public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    
    private IEnumerator Start()
    {
        Debug.Log("AudioController Start"); //the small sphere in the audio souruce is where max volume is played
        yield return new WaitForSeconds(4f); // Wait a moment to ensure all components are initialized
        Debug.Log("Playing background music");
        PlayBackgroundMusic();
    }
    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();
    }
    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();
    }
    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}