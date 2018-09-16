using ChessDotNet; 
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Testing : MonoBehaviour {

    public MoveWPawn5 moveWPawn5;

	// Use this for initialization
	void Start () {

        ChessGame game = new ChessGame();

        
        Piece pieceAtA1 = game.GetPieceAt(new Position("A1")); 
        Console.WriteLine("What piece is there at A1? {0}", pieceAtA1.GetFenCharacter());
        
        Move e2e4 = new Move("E2", "E4", Player.White);
        bool isValid = game.IsValidMove(e2e4);

        
        MoveType type = game.ApplyMove(e2e4, true);
       
        Debug.Log(game.GetPieceAt(File.E, 4));
        moveWPawn5.MoveYoAss();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
