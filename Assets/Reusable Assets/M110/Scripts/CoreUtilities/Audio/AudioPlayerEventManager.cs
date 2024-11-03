using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//this script does the exact same things as the video player, but for audio! 
//GENIUS NO?!?! :p 
[RequireComponent(typeof(AudioSource))]
public class AudioPlayerEventManager : MonoBehaviour
{
    [Header("Editor design")]

    public List<AudioClip> audioClips;
    [SerializeField]
    UnityEvent<AudioClip> audioClipStartedPlayingEvent;

    [SerializeField]
    UnityEvent audioClipFinishedPlayingEvent;

    [SerializeField]
    UnityEvent audioClipsFinishedPlayingEvent;

    [Header("Runtime debug")]
    [SerializeField]
    int counter;
    [SerializeField]
    bool isTracking;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        counter = 0;
        if (audioClips.Count > 0)
        {
            audioSource.clip = audioClips[counter];
        }
    }

    public void LoadTrack(AudioClip clip)
    {
        //audioClips.Add(clip);
        audioSource.clip = clip;
        Debug.Log("AudioClip loaded to player"); 
    }

    //run this after the event end
    //play this 
    public void LoadNextTrack()
    {
        if (counter == audioClips.Count - 1)
        {
            //we re finished
            Debug.Log("Audio finished playing");
            audioClipsFinishedPlayingEvent?.Invoke();
        }
        else //play the next
        {
            counter++;
            audioSource.clip = audioClips[counter];
            //go to play
            PlayTrackedAudio();
        }
    }

    [Button]
    public void TogglePause()
    {
        if (audioSource.isPlaying)
        { //avoid triggering pause as finished;
            isTracking = false;
            audioSource.Pause(); 
            
        }
        else
        {
            audioSource.UnPause();
            isTracking = true;
        }
    }
    public void LoadTrack(int index)
    {
        if (index >= audioClips.Count - 1)
        {
            //we re finished
            Debug.Log("No such track found");
        }
        else //play the next
        {
            audioSource.clip = audioClips[index];
            //go to play
            PlayTrackedAudio();
        }
    }


    private void Update()
    {
        if (isTracking)
        {
            if (!audioSource.isPlaying)
            {
                isTracking = false;
                audioClipFinishedPlayingEvent?.Invoke();
            }
        }
    }


    //start with this with a timer externally
    //add this to the 
    public void PlayTrackedAudio()
    {
        Debug.Log("Playing audio with tracking");
        isTracking = true;
        audioSource.Play();
        audioClipStartedPlayingEvent?.Invoke(audioSource.clip);
    }


}
