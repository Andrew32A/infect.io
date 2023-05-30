using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public float speed;
    
    public float decrease;
    public float scaleSpeed = 5f;
    private float currentScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Input.mousePosition;
        Vector3 worldInput = cam.ScreenToWorldPoint(input);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, worldInput, speed * Time.deltaTime);
        newPosition.z = transform.position.z;

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * scaleSpeed);

        transform.position = newPosition;

        if (Input.GetMouseButtonDown(0)) {
            transform.localScale += new Vector3(decrease, decrease, decrease);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        currentScale += 1f;

        if (other.gameObject.tag == "Food") {
            Destroy(other.gameObject);
        }
    }
}
