using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    public GameObject EndText;
    public GameObject B;
    public float time2 = 10f;
    public float timer = 0f;
    public bool TimerStart = false;
    void Start()
    {
    }
    void Update()
    {
        if (TimerStart)
        {
            //Debug.Log("timer Start");
            if (timer >= time2)
            {
                //Debug.Log("at endgame");
                GameManager.Instance.EndGame();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triger Start");
        GameObject objectCollided = collision.gameObject;
        if (objectCollided.CompareTag("Player"))
        {
            //Debug.Log("if Start");
            GameManager.Instance.inputs = false;
            EndText.SetActive(true);
            B.SetActive(true);    
            TimerStart = true;
        }
    }

}
