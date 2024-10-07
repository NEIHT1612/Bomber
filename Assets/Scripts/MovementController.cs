using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    private float speed = 5f;

    public KeyCode inputUp = KeyCode.UpArrow;
    public KeyCode inputDown = KeyCode.DownArrow;
    public KeyCode inputLeft = KeyCode.LeftArrow;
    public KeyCode inputRight = KeyCode.RightArrow;

    public AnimatedSprite spriteUp;
    public AnimatedSprite spriteDown;
    public AnimatedSprite spriteLeft;
    public AnimatedSprite spriteRight;
    private AnimatedSprite defaultSprite;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        defaultSprite = spriteDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRight);
        }
        else
        {
            SetDirection(Vector2.zero, defaultSprite);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    void SetDirection(Vector2 newDirection, AnimatedSprite selectedSprite)
    {
        direction = newDirection;

        spriteUp.enabled = (selectedSprite == spriteUp);
        spriteDown.enabled = (selectedSprite == spriteDown);
        spriteLeft.enabled = (selectedSprite == spriteLeft);
        spriteRight.enabled = (selectedSprite == spriteRight);

        defaultSprite = selectedSprite;
        defaultSprite.idle = direction == Vector2.zero;
    }
}
