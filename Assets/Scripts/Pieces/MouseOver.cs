using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseOver : MonoBehaviour {
    private static Color32 copper = new Color32(223, 141, 56, 255);

    public GameObject player;
    private Renderer rend;
    private Material originalMaterial;
    private bool mouseDown;
    

    void OnMouseOver() {
        if (gameObject.name.Contains("White")) {
            rend.material.color = Color.green;
        }
        else if (gameObject.name.Contains("Black")) {
            rend.material.color = Color.red;
        } 
    }

    void OnMouseDown() {
        mouseDown = true;
    }

    void OnMouseUp() {
        if (mouseDown) {
            player.GetComponent<Game>().SetSelectedPiece(gameObject);
        }
    }

    void OnMouseExit() {
        mouseDown = false;
        if (player.GetComponent<Game>().GetSelectedPiece() != gameObject) {
            rend.material = originalMaterial;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // player is initialized manually
        rend = GetComponent<Renderer>();
        originalMaterial = new Material(rend.material);
        mouseDown = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}

 


