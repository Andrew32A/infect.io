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

    // Update is called once per frame
    void Update()
    {
        // move player towards mouse
        Vector2 input = Input.mousePosition;
        Vector3 worldInput = cam.ScreenToWorldPoint(input);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, worldInput, speed * Time.deltaTime);
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        // update size slowly
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * scaleSpeed);

        // split player
        if (Input.GetMouseButtonDown(0)) {
            transform.localScale += new Vector3(decrease, decrease, decrease);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // check if player ate food
        if (other.gameObject.tag == "Food") {
            currentScale += 1f;
            Destroy(other.gameObject);
        }

        if (other.transform.localScale.magnitude > transform.localScale.magnitude) {
            Destroy(gameObject);
        }
    }
}
