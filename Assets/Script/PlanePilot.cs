using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanePilot : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float rotSpeed1;
    public float rotSpeed2;
    public TextMeshProUGUI score;
    public TextMeshProUGUI youwin;
    public Button button;
    public int scorePoint;
    public int MaxScore = 4;
    void Start()
    {
        scorePoint = 0;
    }

    void SetScoreText()
    {
        score.text = "Points= " + scorePoint.ToString() + "/4";
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

      

        if (Input.GetKey(KeyCode.W))
        {
           if(speed < maxSpeed)
            {
                speed++;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speed > minSpeed)
            {
                speed--;
            }
        }

        speed -= transform.forward.y * Time.deltaTime * 50;

     

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotSpeed1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotSpeed1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * rotSpeed1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * rotSpeed1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotSpeed1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * rotSpeed1 * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            scorePoint++;
            if (scorePoint == 4)
            {
                NextScene();
            }
            SetScoreText();
        }
    }


    public void NextScene()
    {
        youwin.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }

   
}
