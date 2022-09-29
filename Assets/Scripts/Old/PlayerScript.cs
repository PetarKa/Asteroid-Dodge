using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI highScore;

    public Rigidbody rb;
     [SerializeField]
    private int Speed;
    public int movementSpeed = 10;
    bool onGround;
    public Animator anim;
    int trenutniRezultat=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
        anim = gameObject.GetComponent<Animator>();
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Highscore");
        if (PlayerPrefs.HasKey("Highscore") == false)
        {
            PlayerPrefs.SetInt("HighScore", 0);

        }
        StartCoroutine(ScoreTime());

    }

    IEnumerator ScoreTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            trenutniRezultat++;
            resultText.text = "REZULTAT: " + trenutniRezultat;

            if (trenutniRezultat > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", trenutniRezultat);
                highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");


            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= -3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0), Space.Self);

        if (Input.GetKey(KeyCode.A))
        {
        transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime), Space.Self);

        }

        if (Input.GetKey(KeyCode.D))
        {
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime), Space.Self);
            //anim.Play("RightDrift");
        }

        if (Input.GetKeyDown(KeyCode.Space)&&onGround)
        {
            rb.AddForce(0, 7, 0, ForceMode.Impulse);
            onGround = false;
            //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 120f);

        }
    }
}
