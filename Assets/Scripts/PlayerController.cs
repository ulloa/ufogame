using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // must import for text and ui elements

public class PlayerController : MonoBehaviour {

    public float speed; // will show up in Unity inspector

    public Text countText;

    public Text winText;

    private Rigidbody2D rb2d; //Giving rb2d the Rigidbody2D definition

    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void FixedUpdate() //Updates on physics frames
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other) /// in this game we want to deactive the entered game object upon player entry
    {
        if (other.gameObject.CompareTag ("PickUp")) /// this is important because you don't want to deactivate the walls
            /// the tag is not the same as the label of gameobjects  
        {
            other.gameObject.SetActive(false); /// effectively deactivates the other object
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // count must be attached to the player controller in the Unity IDE
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
