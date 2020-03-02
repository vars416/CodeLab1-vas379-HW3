using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("You Won");
            Destroy(gameObject);
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Additive);
            GameManager.instance.TimerText.enabled = false;
        }
    }
}
