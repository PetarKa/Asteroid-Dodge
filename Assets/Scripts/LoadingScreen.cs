using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    public Slider mySlider;
    public TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingSlider());
        mySlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mySlider.value >= 100)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator LoadingSlider()
    {
        while (true)
        {
            mySlider.value++;
            resultText.text = mySlider.value.ToString("0") + "%";
            yield return new WaitForSeconds(0.03f);
        }
    }
}
