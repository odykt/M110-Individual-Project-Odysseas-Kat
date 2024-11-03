using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerEventManager : MonoBehaviour
{
    [SerializeField]
    UnityEvent videoFinishedPlayingEvent;
    [SerializeField]
    UnityEvent videoStartedPlayingEvent;

    VideoPlayer VideoPlayer;

    [SerializeField]
    bool debugMode;
    private void Awake()
    {
        VideoPlayer = GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        VideoPlayer.loopPointReached += HandleVideoLoopPointReached;
    }

    private void Update()
    {
        if (debugMode)
        {
            if (VideoPlayer.isPlaying)
            {
                Debug.Log(VideoPlayer.time);
            }
        }
    }

    public void SubstitutePlayCommandToSyncOtherThingsWithIt()
    {
        VideoPlayer.Play();
        videoStartedPlayingEvent?.Invoke();
    }

    [Button]
    void HandleVideoLoopPointReached(object obj)
    {
        Debug.Log("The object " + obj.ToString() + " raised this event 'videoFinishedPlayingEvent'.");
        videoFinishedPlayingEvent?.Invoke();
    }

}
