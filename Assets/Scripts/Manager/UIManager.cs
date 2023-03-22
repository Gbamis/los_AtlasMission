using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AtlastMision
{
    public class UIManager : MonoBehaviour
    {
        public Text scoreUI;
        public Text gameOverUI;
        public Image healthUI;
        public GameObject menu;
        public GameObject replayBtn;

        private void Awake()
        {
            menu.SetActive(true);
        }
        private void Start()
        {
            GameProcessor.Instance.OnGameEnd += End;
        }

        public void Update()
        {
            scoreUI.text = GameProcessor.Instance.gameData.count.ToString();
            healthUI.fillAmount = (GameProcessor.Instance.gameData.playerCurrentHealth / GameProcessor.Instance.gameData.playerTotalHealth) * 1;
        }
        public void Play(int index)
        {
            menu.SetActive(false);
            replayBtn.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            if (index == 0)
            {
                GameProcessor.Instance.StartGame();
            }
            else
            {
                GameProcessor.Instance.PlayGame();
            }

            healthUI.transform.parent.gameObject.SetActive(true);
        }
        private void End()
        {
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.text = "Game Over Score : " + GameProcessor.Instance.gameData.count.ToString();
            replayBtn.SetActive(true);
        }
    }
}
