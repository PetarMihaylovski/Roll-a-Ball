using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {
    //publics
    public Sound[] sounds;

    private static AudioManager instance;
    private void Awake() {
          
        //singleton so the music does not change when changing scenes
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
            return; 
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (var sound in sounds) {
            //add an audio source to the sound
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            
        }
    }

    //play sounds
    public void Play(string name) {
        //find the sound we need 
        Sound sound = Array.Find(sounds, s => s.name == name);
        if(sound == null) {
            return;
        }
        //play it
        sound.source.Play();
    }

}
