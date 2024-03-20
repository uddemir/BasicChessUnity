using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooks : ChessMan
{

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessMan c;
        int i;

        // ------------------Right --------------------// 

        i = currentX;

        while (true)
        {
            i++;

            if (i >= 8)
            {
                break;

            } 

            c = BoardManager.Instance.Chesmans[i, CurrentY];
            if (c == null)
            {
                r[i, CurrentY] = true;
            }

            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
                }
                break;
            }
        }

        // ----------- Left ----------------------// 

        i = currentX;

        while (true)
        {
            i--;

            if (i < 0)
            {
                break;

            }

            c = BoardManager.Instance.Chesmans[i, CurrentY];
            if (c == null)
            {
                r[i, CurrentY] = true;

            }

            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;

                }
                break;
            }
        }
            // Up
        i = CurrentY;
        while (true)
        {
            i++;

            if (i >=8)
            {
                break;
            }

            c = BoardManager.Instance.Chesmans[currentX, i];
            if (c == null) 
            {
                r[currentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[currentX, i] = true;
                }
                break;
            }
        }
        // Down
        i = CurrentY;
        while (true)
        {
            i-- ;

            if (i < 0)
            {
                break;
            }

            c = BoardManager.Instance.Chesmans[currentX, i];
            if (c == null)
            {
                r[currentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[currentX, i] = true;
                }
                break;
            }
        }
        return r;
    }
}
