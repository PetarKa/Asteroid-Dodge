using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    int speed;
    bool onGround;
    public GameObject gameManager;
    GameManager gmScript;
    public TextMeshProUGUI coinText;
    public AudioSource audioSource;
    public GameObject gameOver;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + PlayerPrefs.GetInt("Coin");
        if (PlayerPrefs.HasKey("Coin") == false)
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        gmScript = gameManager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        onGround = true;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }

        if (collision.gameObject.tag == "Coin")
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin")+1);
            gmScript.trenutniRezultat = gmScript.trenutniRezultat + 5;
            coinText.text = "Coins: " + PlayerPrefs.GetInt("Coin");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            gmScript.setHighScore();
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.World);
            anim.SetBool("isWalking", true);
        }
        
        else if (Input.GetKey(KeyCode.D))
        {

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(0, 7, 0, ForceMode.Impulse);
            onGround = false;
        }
    }
}
