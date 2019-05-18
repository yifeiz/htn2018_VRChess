using ChessDotNet; 
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    private Color32 copper = new Color32(223, 141, 56, 255);
    private static Dictionary<string, int[]> boardCoords = new Dictionary<string, int[]>() { // Remove this BS
        { "A1", new[]{-14, 0, -14} },
        { "B1", new[]{-10, 0, -14} },
        { "C1", new[]{-6, 0, -14} },
        { "D1", new[]{-2, 0, -14} },
        { "E1", new[]{2, 0, -14} },
        { "F1", new[]{6, 0, -14} },
        { "G1", new[]{10, 0, -14} },
        { "H1", new[]{14, 0, -14} },
        { "A2", new[]{-14, 0, -10} },
        { "B2", new[]{-10, 0, -10} },
        { "C2", new[]{-6, 0, -10} },
        { "D2", new[]{-2, 0, -10} },
        { "E2", new[]{2, 0, -10} },
        { "F2", new[]{6, 0, -10} },
        { "G2", new[]{10, 0, -10} },
        { "H2", new[]{14, 0, -10} },
        { "A3", new[]{-14, 0, -6} },
        { "B3", new[]{-10, 0, -6} },
        { "C3", new[]{-6, 0, -6} },
        { "D3", new[]{-2, 0, -6} },
        { "E3", new[]{2, 0, -6} },
        { "F3", new[]{6, 0, -6} },
        { "G3", new[]{10, 0, -6} },
        { "H3", new[]{14, 0, -6} },
        { "A4", new[]{-14, 0, -2} },
        { "B4", new[]{-10, 0, -2} },
        { "C4", new[]{-6, 0, -2} },
        { "D4", new[]{-2, 0, -2} },
        { "E4", new[]{2, 0, -2} },
        { "F4", new[]{6, 0, -2} },
        { "G4", new[]{10, 0, -2} },
        { "H4", new[]{14, 0, -2} },
        { "A5", new[]{-14, 0, 2} },
        { "B5", new[]{-10, 0, 2} },
        { "C5", new[]{-6, 0, 2} },
        { "D5", new[]{-2, 0, 2} },
        { "E5", new[]{2, 0, 2} },
        { "F5", new[]{6, 0, 2} },
        { "G5", new[]{10, 0, 2} },
        { "H5", new[]{14, 0, 2} },
        { "A6", new[]{-14, 0, 6} },
        { "B6", new[]{-10, 0, 6} },
        { "C6", new[]{-6, 0, 6} },
        { "D6", new[]{-2, 0, 6} },
        { "E6", new[]{2, 0, 6} },
        { "F6", new[]{6, 0, 6} },
        { "G6", new[]{10, 0, 6} },
        { "H6", new[]{14, 0, 6} },
        { "A7", new[]{-14, 0, 10} },
        { "B7", new[]{-10, 0, 10} },
        { "C7", new[]{-6, 0, 10} },
        { "D7", new[]{-2, 0, 10} },
        { "E7", new[]{2, 0, 10} },
        { "F7", new[]{6, 0, 10} },
        { "G7", new[]{10, 0, 10} },
        { "H7", new[]{14, 0, 10} },
        { "A8", new[]{-14, 0, 14} },
        { "B8", new[]{-10, 0, 14} },
        { "C8", new[]{-6, 0, 14} },
        { "D8", new[]{-2, 0, 14} },
        { "E8", new[]{2, 0, 14} },
        { "F8", new[]{6, 0, 14} },
        { "G8", new[]{10, 0, 14} },
        { "H8", new[]{14, 0, 14} },
    };

    private ChessGame game;
    private GameObject selectedPiece;
    private string selectedSquare;
    private string inputCommand;

    public bool MovePiece(string origin, string dest) {
        Move move = new Move(origin, dest, game.WhoseTurn);

        if (game.IsValidMove(move)) {
            Debug.Log(game.WhoseTurn + " from " + origin + " to " + dest + " successful.");
            MoveType type = game.ApplyMove(move, true);
            GameObject violetDetector = GameObject.Find(origin); // Sets detector as current space

            Collider[] hitColliders = Physics.OverlapSphere(violetDetector.transform.position, 1);
            GameObject sumireko = null;
            for (int i = 0; i < hitColliders.Length; ++i) {
                Debug.Log(hitColliders[i].gameObject.transform.parent.name);
                if ((hitColliders[i].gameObject.transform.parent.name == "WhitePieces") || (hitColliders[i].gameObject.transform.parent.name == "BlackPieces")) {
                    sumireko = hitColliders[i].gameObject;
                }
            }

            sumireko.transform.Translate(Vector3.up * (boardCoords[dest][2] - sumireko.transform.position.z));
            sumireko.transform.Translate(Vector3.right * (boardCoords[dest][0] - sumireko.transform.position.x));
            return true;
        }
        Debug.Log(game.WhoseTurn + " from " + origin + " to " + dest + " failed.");
        return false;
    }

    public GameObject GetPieceAt(string square) {
        GameObject violetDetector = GameObject.Find(square);
        Collider[] hitColliders = Physics.OverlapSphere(violetDetector.transform.position, 1);

        for (int i = 0; i < hitColliders.Count(); i++) {
            if ((hitColliders[i].gameObject.transform.parent.name == "WhitePieces") || (hitColliders[i].gameObject.transform.parent.name == "BlackPieces")) {
                return hitColliders[i].gameObject;
            }
        }
        return null; 
    }

    public void SetSelectedPiece(GameObject piece) {
        // Deselect previous selected piece
        if ((selectedPiece) && (selectedPiece != piece)) { 
            Renderer rend = selectedPiece.GetComponent<Renderer>();
            if (selectedPiece.name.Contains("White")) {
                rend.material.color = copper;
            }
            else if (selectedPiece.name.Contains("Black")) {
                rend.material.color = Color.black;
            }
        }
        selectedPiece = piece;

        if (piece) { // This is a bootleg solution that needs to be fixed.
            Collider[] sumirekoCollider = Physics.OverlapSphere(piece.transform.position, 1);
            for (int i = 0; i < sumirekoCollider.Count(); i++) {
                if (Regex.IsMatch(sumirekoCollider[i].gameObject.name, @"^[A-H][1-8]$")) {
                    selectedSquare = sumirekoCollider[i].gameObject.name;
                    break;
                }
            }
        }
        else {
            selectedSquare = "";
        }
    }

    public GameObject GetSelectedPiece() {
        return selectedPiece;
    }


	// Game Init. Put any pre-loading stuff in here.
	void Start () {
        game = new ChessGame();
        selectedPiece = null;
        selectedSquare = "";
        inputCommand = "";

        MovePiece("E2", "E4");
        MovePiece("G8", "H6");
        MovePiece("F1", "A6");
        MovePiece("C7", "C5");
    }
	
	// Update is called once per frame
	void Update () {
		if (selectedPiece && Input.GetMouseButtonDown(0)) {
            SetSelectedPiece(null);
        }

        if (selectedSquare != "") {
            if (Input.anyKeyDown) {
                inputCommand += Input.inputString;
                inputCommand = inputCommand.ToUpper();
                Debug.Log("Currently Selected: " + selectedSquare + "\nTarget: " + inputCommand);
            }
            
            if (inputCommand.Length >= 2) {
                if (Regex.IsMatch(inputCommand, @"^[A-H][1-8]$")) {
                    bool moveResult = MovePiece(selectedSquare, inputCommand);
                }
                SetSelectedPiece(null);
                inputCommand = "";
            }
        }
	}
}
