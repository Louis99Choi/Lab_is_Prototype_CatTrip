using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameManager V;
    public GameObject Vs;
    public static Item instancee;
    // Start is called before the first frame update
/*    private void Awake()
    {
        if (instancee == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instancee = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/
    void Start()
    {
        float Rx = UnityEngine.Random.Range(-100.0f, 100.0f);
        float Ry = UnityEngine.Random.Range(-100.0f, 100.0f);
        Vector3 vec = new Vector3(Rx, Ry, 0);
        transform.position = vec;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0.0f)
        {
            if (Vs.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.playergold += 100;
                    this.gameObject.SetActive(false);
                 }
            }
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vs.SetActive(true);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vs.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
