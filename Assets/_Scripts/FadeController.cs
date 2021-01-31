using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    public static FadeController Instance;
    public float fadeOutSpeed, fadeBackInSpeed;

    Image image;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("You have too many fade controllers!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeBackIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeOut()
    {
        Debug.Log("Fading to black.");
        StopAllCoroutines();
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        while (image.color.a < 1)
        {
            image.color = new Color (0,0,0, image.color.a + fadeOutSpeed/100);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 1);

    }

    public void StopFadeOut()
    {
        Debug.Log("Fading back in.");
        StopAllCoroutines();
        StartCoroutine(FadeBackIn());
    }

    IEnumerator FadeBackIn()
    {
        while (image.color.a > 0)
        {
            image.color = new Color(0, 0, 0, image.color.a - fadeOutSpeed / 100);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 0);
    }
}
