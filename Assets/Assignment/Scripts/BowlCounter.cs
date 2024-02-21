using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCounter : MonoBehaviour
{
    public Player player;
    public float horFacing, verFacing;

    protected bool isArrivedCounter = false;

    BowlCounter bowl;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[4];
    public Sprite[] highlightSprites = new Sprite[4];

    public int juiceType;

    // Start is called before the first frame update
    void Start()
    {
        bowl = GetComponent<BowlCounter>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && isArrivedCounter)
        {
            //Debug.Log("Active");
            player.juicing(bowl);
        }
    }

    public void changeJuice(int type)
    {
        juiceType = type;
        spriteRenderer.sprite = sprites[juiceType];
    }

    private void OnMouseDown()
    {
        player.setDestination((Vector2)transform.position, new Vector2(horFacing, verFacing));
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = highlightSprites[juiceType];
    }
    private void OnMouseExit()
    {
        spriteRenderer.sprite = sprites[juiceType];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isArrivedCounter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isArrivedCounter = false;
    }
}
