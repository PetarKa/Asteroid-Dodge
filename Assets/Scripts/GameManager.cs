using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject dropPods;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    GameObject pauseMenu;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI highScore;
    public int trenutniRezultat = 0;

    float dificulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        if (PlayerPrefs.HasKey("HighScore") == false)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        StartCoroutine(SpawnTimer());
        StartCoroutine(SpawnTimer2());
        StartCoroutine(ScoreTime());
        StartCoroutine(CoinDrop());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            float[] array = Spawner();
            yield return new WaitForSeconds(array[0]-dificulty);
            dificulty = dificulty + 0.01f;
            Instantiate(dropPods, new Vector3(0, 9, array[1]), Quaternion.identity);
        }
    }
    private float[] Spawner()
    {
        float range = player.transform.position.z;
        float timer = Random.Range(1f, 1.5f);
        float zPosition = Random.Range(range - 4, range + 4);
        float[] arr = { timer, zPosition };

        return arr;
    }

    IEnumerator SpawnTimer2()
    {
        while (true)
        {
            float[] array = Spawner();

            yield return new WaitForSeconds(array[0]+0.3f);
            Instantiate(dropPods, new Vector3(0, 9, array[1]), Quaternion.identity);
        }
    }

    IEnumerator ScoreTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            trenutniRezultat++;
            resultText.text = "Score: " + trenutniRezultat;
        }
    }

    IEnumerator CoinDrop()
    {
        while (true)
        {
            float timer = Random.Range(8f, 10f);
            int zPosition = Random.Range(-8, 8);
            yield return new WaitForSeconds(timer);

            Instantiate(coin, new Vector3(0, 7, zPosition), Quaternion.identity);
        }
    }

    public void setHighScore()
    {
        if (trenutniRezultat > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", trenutniRezultat);
            highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
