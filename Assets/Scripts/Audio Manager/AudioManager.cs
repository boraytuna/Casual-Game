using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private Action customPauseActions;
    private Action customResumeActions;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Ensure only one AudioManager exists
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    // Method to pause all audio
    // public void PauseAll()
    // {
    //     foreach (Sound s in sounds)
    //     {
    //         if (s.source.isPlaying)
    //         {
    //             s.source.Pause();
    //         }
    //     }
    // }

    // // Method to resume all audio
    // public void ResumeAll()
    // {
    //     foreach (Sound s in sounds)
    //     {
    //         if (!s.source.isPlaying)
    //         {
    //             s.source.UnPause();
    //         }
    //     }
    // }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Resume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s != null && s.source.isPlaying;
    }

    public void RegisterCustomPauseAction(Action pauseAction, Action resumeAction)
    {
        customPauseActions += pauseAction;
        customResumeActions += resumeAction;
    }

    public void DeregisterCustomPauseAction(Action pauseAction, Action resumeAction)
    {
        customPauseActions -= pauseAction;
        customResumeActions -= resumeAction;
    }

    public void PauseAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Pause();
            }
        }
        customPauseActions?.Invoke();
    }

    public void ResumeAll()
    {
        foreach (Sound s in sounds)
        {
            if (!s.source.isPlaying)
            {
                s.source.UnPause();
            }
        }
        customResumeActions?.Invoke();
    }

}
