using UnityEngine;
using UnityEngine.UI;

public class DarrylScript : MonoBehaviour
{
    [SerializeField] public GameObject D;
    [SerializeField] public GameObject D2;
    public Image d;
    public Image d2;
    float alpha = 0f;
    float time = 2f;
    void Start()
    {
        d = D.GetComponent<Image>();
        d2 = D2.GetComponent<Image>();
    }
    
    //changes scene
    void OnTriggerEnter2D(Collider2D collision)
    {
        D.SetActive(true);
        D2.SetActive(true);
        d.CrossFadeAlpha(alpha, time, false); 
        d2.CrossFadeAlpha(alpha, time, false); 


    }
}
