using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knights : ChessMan

{
    public override bool [,] PossibleMove()
    {

        bool[,] r = new bool[8, 8];
        // Up Left

        KnightMove(currentX - 1, CurrentY + 2, ref r);

        // UpRight
        KnightMove(currentX + 1, CurrentY + 2, ref r);

        //RightUp
        KnightMove(currentX + 2, CurrentY + 1, ref r);

        // RightDown
        KnightMove(currentX +2, CurrentY - 1, ref r);

        // DonLeft
        KnightMove(currentX - 1, CurrentY -2, ref r);

        // DownRight
        KnightMove(currentX + 1, CurrentY - 2, ref r);

        //Leftup
        KnightMove(currentX - 2, CurrentY + 1, ref r);

        // LeftDown
        KnightMove(currentX - 2, CurrentY - 1, ref r);


        return r;
    }
	
    public void KnightMove(int x, int y , ref bool [,] r)  // At Hareket
    {
        ChessMan c;

        if (x>=0 && x<8 && y>=0 && y<8)
        {
            c = BoardManager.Instance.Chesmans[x, y];
            if (c==null)
            {
                r[x, y] = true;
            }
            else if (isWhite !=c.isWhite)
            {
                r[x, y] = true;
            }
        }

    }
}
