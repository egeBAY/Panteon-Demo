using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private Button btnRestart;
    [SerializeField] private GameObject paintWall;
    [SerializeField] private RenderTexture paintTexture;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI paintedText;
    public Texture2D texture;

    [SerializeField] private GameObject[] opponents;
    [SerializeField] private GameObject player;

    public bool isGameFinished = false;

    private float[] characterPositions = new float [11];
    private float playerPos;
    private int currentPos;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        gameOverPopup.SetActive(false);
        paintedText.gameObject.SetActive(false);

        InvokeRepeating("CalculatePaintedArea", 1f, 3f); 
    }

    private void Update()
    {
        if (isGameFinished)
            return;
        PositionCalculate();
    }

    public void FinishGame()
    {
        isGameFinished = true;
        paintWall.SetActive(true);

        for (int i = 0; i < opponents.Length; i++)
        {
            opponents[i].SetActive(false);
        }
    }

    private void PositionCalculate()
    {
        characterPositions[0] = player.transform.position.z;

        for (int i = 0; i < opponents.Length; i++)
        {
            characterPositions[i + 1] = opponents[i].transform.position.z;
        }

        playerPos = player.transform.position.z;

        Array.Sort(characterPositions);
        Array.Reverse(characterPositions);
             
        int x = Array.IndexOf(characterPositions, playerPos);

        currentPos = x + 1;

        Debug.Log(currentPos);

        UpdatePosText(currentPos, opponents.Length + 1);
    }

    private void UpdatePosText(int pos, int playerCount)
    {
        rankText.text = pos + " / " + playerCount;
    }

    private void CalculatePaintedArea()
    {
        texture = new Texture2D(1024, 1024, TextureFormat.RGB24, false);

        Rect rectReadPicture = new Rect(0, 0, 1024, 1024);
        RenderTexture.active = paintTexture;

        texture.ReadPixels(rectReadPicture, 0, 0);
        texture.Apply();

        RenderTexture.active = null;

        int resolution = 50;
        int total = 0;
        int painted = 0;

        if (isGameFinished)
        {
            for (int i = 0; i < paintTexture.width; i += resolution)
            {
                for (int j = 0; j < paintTexture.height; j += resolution)
                {
                    total++;
                    if (IsPainted(texture, i, j))
                        painted++;
                }
            }
            UpdatePaintedText(painted * 100 / total);
        }
    }

    private void UpdatePaintedText(int percentage)
    {
        paintedText.gameObject.SetActive(true);
        paintedText.text = "% " + percentage;
    }

    private bool IsPainted(Texture2D texture, int x, int y)
    {
        if (texture.GetPixel(x, y).g != 1 && texture.GetPixel(x,y).b != 1 && texture.GetPixel(x,y).r == 1)
            return true;
        return false;
    }

    public void GameOver()
    {
        gameOverPopup.SetActive(true);
        isGameFinished = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        isGameFinished = false;
        Time.timeScale = 1f;
    }

}
