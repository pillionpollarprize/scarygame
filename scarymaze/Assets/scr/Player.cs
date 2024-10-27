using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5.0f;
    public string sceneName;
    Vector2 startPos = new();
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * speed * Time.deltaTime;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("hello");
        if (collision.CompareTag("Ground"))
        {
            transform.position = startPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exit"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
