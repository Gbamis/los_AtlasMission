using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace AtlastMision
{
    public class GameProcessor : MonoBehaviour
    {
        private static GameProcessor m_instance;
        public static GameProcessor Instance{
            set{
                m_instance = value;
            }
            get{
                return m_instance;
            }
        }
        public delegate void Game();
        public event Game OnGameEnd;
        public event Game OnPowerUpUsed;

        public GameData gameData;
        public Transform player;
        public Transform nuzzle;
        public PlayableDirector cutscene;

        public bool isGameRunning;

        private void Awake(){
            Instance = this;
            gameData.ResetValues();
        }

        public void PlayGame(){
            cutscene.Stop();
            isGameRunning = true;
            gameData.ResetValues();
            Time.timeScale = 1;
        }
        public void StartGame(){
            cutscene.Play();
        }
        public void GameOver(){
            OnGameEnd();
            Time.timeScale = 0;
        }

        public void PowerUpUsed(){
            OnPowerUpUsed();
        }
    }
}
