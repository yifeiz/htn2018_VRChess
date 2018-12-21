using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseOver : MonoBehaviour
{
    public GameObject player;
    private Renderer rend;
    private Material original;
    private Color32 copper = new Color32(223, 141, 56, 255);


    // Called on frames where mouse hovers over target
    void OnMouseOver()
    {
        if (gameObject.name.Contains("White"))
        {
            rend.material.color = Color.green;
        }
        else if (gameObject.name.Contains("Black"))
        {
            rend.material.color = Color.red;
        }
        player.GetComponent<Testing>().SetHighlightPieceViaMouse(gameObject);

    }


    // Called on frame where mouse exits target
    void OnMouseExit()
    {
        if (gameObject.name.Contains("White"))
        {
            rend.material.color = copper;
        }
        else if (gameObject.name.Contains("Black"))
        {
            rend.material.color = Color.black;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {

    }
}

 


