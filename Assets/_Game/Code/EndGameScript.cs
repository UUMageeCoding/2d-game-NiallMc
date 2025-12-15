using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    public GameObject EndText;
    public GameObject White;
    public Image white;
    float alpha = 255f;
    float time = 3f;
    void Start()
    {
        white = White.GetComponent<Image>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollided = collision.gameObject;
        if (objectCollided.CompareTag("Player"))
        {
            GameManager.Instance.inputs = false;
            EndText.SetActive(true);
            White.SetActive(true);
            white.CrossFadeAlpha(alpha, time, false);
        }
    }
}
