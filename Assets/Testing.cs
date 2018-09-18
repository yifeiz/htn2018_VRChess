using ChessDotNet; 
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Testing : MonoBehaviour {

    public static ChessGame game;
    public static Dictionary<string, int[]> boardCoords = new Dictionary<string, int[]>()
    {
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

    /* public Dictionary<Dictionary<char, Piece>, GameObject> translateBoard = new Dictionary<char, Piece>()
    {
        { FenMappings['K'], "wKing" },
        { FenMappings['k'], "bKing" },
        { FenMappings['Q'], "wQueen" },
        { FenMappings['q'], "bQueen" },
        { FenMappings['R'], "wRook" },
        { FenMappings['r'], "bRook" },
        { FenMappings['N'], "wKnight" },
        { FenMappings['n'], "bKnight" },
        { FenMappings['B'], "wBishop" },
        { FenMappings['b'], "bBishop" },
        { FenMappings['P'], "wPawn" },
        { FenMappings['p'], "bPawn" },
    }; */


    public GameObject violetDetector;
    public Boolean black = false;
    public int modifier = 1;

    public void movePiece(string current, string target)
    {
        Move move = new Move(current, target, game.WhoseTurn);
        bool isValid = game.IsValidMove(move);


        if (isValid == true)
        {
            MoveType type = game.ApplyMove(move, true);
            violetDetector = GameObject.Find(current);
            Collider[] hitColliders = Physics.OverlapSphere(violetDetector.transform.position, 1);
            GameObject sumireko = hitColliders[0].gameObject;
            sumireko.transform.Translate(Vector3.up * (boardCoords[target][2] - sumireko.transform.position.z) * modifier);
            sumireko.transform.Translate(Vector3.right * (boardCoords[target][0] - sumireko.transform.position.x) * modifier);
        }

        /*if (black == false)
        {
            black = true;
            modifier = -1;
        }
        else
        {
            black = false;
            modifier = 1;
        }*/

        Piece[][] currentBoard = game.GetBoard();
        int i = 0;
        int j = 0;

        if (game.IsInCheck(game.WhoseTurn) == true)
        {}

        bool gameOver = false;
        if (game.IsCheckmated(game.WhoseTurn) == true)
        {
            gameOver = true;
        }

        if (game.IsDraw() == true)
        {
            gameOver = true;
        }

        if (gameOver == true)
        {}
    }

	// Use this for initialization
	void Start () {
        game = new ChessGame();

        this.movePiece("E2", "E4");
        this.movePiece("G8", "H6");
        this.movePiece("F1", "A6");
        this.movePiece("C7", "C5");
     

     /*   Piece pieceAtA1 = game.GetPieceAt(new Position("A1")); 
        Console.WriteLine("What piece is there at A1? {0}", pieceAtA1.GetFenCharacter());
        
        Move e2e4 = new Move("E2", "E4", Player.White);
        bool isValid = game.IsValidMove(e2e4);

        
        MoveType type = game.ApplyMove(e2e4, true);
       
        Debug.Log(game.GetPieceAt(File.E, 4));
        moveWPawn5.MoveYoAss();
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
