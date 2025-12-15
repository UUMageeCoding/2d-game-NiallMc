using UnityEngine;
using UnityEngine.UI;

public class DarrylScript : MonoBehaviour
{
    public GameObject D;
    public Image d;

    float alpha = 0f;
    float time = 2f;
    void Start()
    {
        d = D.GetComponent<Image>();
       
    }
    
    //changes scene
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollided = collision.gameObject;
        if (objectCollided.CompareTag("Player") )
        {
            D.SetActive(true);
          
            d.CrossFadeAlpha(alpha, time, false); 
            
        }
        


    }
}
