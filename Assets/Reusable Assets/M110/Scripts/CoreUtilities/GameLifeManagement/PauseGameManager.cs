using UnityEngine;

namespace Assets.Scripts._Game
{
    public class PauseGameManager : MonoBehaviour
    {
        public static PauseGameManager Instance { get; private set; }

        [Header("Events")]
        [SerializeField]
        GameEventVariable PauseEvent;
        [SerializeField]
        GameEventVariable UnpauseEvent;
        [Header("Fields")]
        [SerializeField]
        boolVariable gamePaused;


        float previousTimeScale;
        private void Awake()
        {
            Instance = this;
        }

        public void TogglePauseOnlyForUIButton()
        {
            if (gamePaused.value)
                UnPauseGame();
            else
                PauseGame();
        }
        //anything that causes the game to pause should call this
        public void PauseGame()
        {
            previousTimeScale = Time.timeScale;
            //this should be the duration of the fade
            Time.timeScale = 0.0f;
            gamePaused.SetValue(true);
            //the post processing vfx should respond to this
            PauseEvent?.Raise();
        }
        //anything that causes the game to UNpause should call this
        public void UnPauseGame()
        {
            Time.timeScale = previousTimeScale;
            gamePaused.SetValue(false);
            //the post processing vfx should respond to this
            UnpauseEvent?.Raise();
        }
    }
}
