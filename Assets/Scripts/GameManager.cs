using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool IsGameEnded { get; private set; } = false;

	[SerializeField]
	private GameObject _gameOverPanel;

	private void Start()
	{
		_gameOverPanel.SetActive(false);
	}
	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void GameOver()
	{
		IsGameEnded = true;
		_gameOverPanel.SetActive(true);
	}
}
