using System.Threading;
using UnityEngine;

public class DoorCloseScript : MonoBehaviour
{
    public GameObject Door;
    public float timer = 0 ;
    public float delay = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //closes the door after a set delay
        if (Door.activeSelf == false)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                Door.SetActive(true);
                timer = 0;
            }
        }
    }
}
