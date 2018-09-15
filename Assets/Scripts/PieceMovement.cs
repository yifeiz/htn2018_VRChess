using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    class Pawn
    {
        int positionAlpha;
        int positionNum;
        int targetPositionAlpha;
        int targetPositionNum;
        int moves = 0;

        public void MovePawn()
        {
            bool checkAlpha = false;
            bool checkNum = false;
            if (moves == 0)
            {
                if (targetPositionNum == positionNum + 1 || targetPositionNum == positionNum + 2)){
                    checkNum = true;
                }

            }
        }
    }

    class Rook
    {
        int positionAlpha;
        int positionNum;
    }

    class Bishop
    {
        int positionAlpha;
        int positionNum;
    }

    class Knight
    {
        int positionAlpha;
        int positionNum;
    }

    class Queen
    {
        int positionAlpha;
        int positionNum;
    }

    class King
    {
        int positionAlpha;
        int positionNum;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
