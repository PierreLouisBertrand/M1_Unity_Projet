using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite closedDoorSprite;
    public Sprite openedDoorSprite;

    private SpriteRenderer _doorSpriteRenderer;
    private BoxCollider2D _boxCollider2D;

    void Start()
    {
        _doorSpriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        Open(); // par défaut, la porte est ouverte
    }

    public void Open()
    {
        _boxCollider2D.enabled = false;
        _doorSpriteRenderer.sprite = openedDoorSprite;
    }

    public void Close()
    {
        _boxCollider2D.enabled = true;
        _doorSpriteRenderer.sprite = closedDoorSprite;
    } 
}
