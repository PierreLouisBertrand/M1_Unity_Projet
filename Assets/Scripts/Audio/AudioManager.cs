using UnityEngine.Audio;
using System;
using UnityEngine;

// Classe qui vient du tutoriel de Brackeys https://www.youtube.com/watch?v=6OT43pvUyfY
// (libre de droits)
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance; // singleton utilisé dans tout le jeu
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // pour éviter d'appeler le code qui suit
        }
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private Sound FindSound(string soundName)
    {
        return Array.Find(sounds, s => s.name == soundName);
    }

    public void Play(string soundName)
    {
        FindSound(soundName)?.source.Play(); // le ? veut dire "si sound n'est pas null"
    }

    public void Stop(string soundName)
    {
        FindSound(soundName)?.source.Stop();
    }
}
