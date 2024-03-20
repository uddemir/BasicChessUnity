using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessMan
{
        public override bool [,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessMan c;
        int i, j;

        // Top Sideü
        i = currentX - 1;
        j = CurrentY + 1; 

        if (CurrentY !=7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i>= 0 || i<8)
                {
                    c = BoardManager.Instance.Chesmans[i, j];
                    if (c == null)
                    {
                        r[i, j] = true;

                    }
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j] = true;
                    }                 
                }
                i++;
            }
        }

        // Top Sideü
        i = currentX - 1;
        j = CurrentY - 1;

        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {
                    c = BoardManager.Instance.Chesmans[i, j];
                    if (c == null)
                    {
                        r[i, j] = true;

                    }
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j] = true;
                    }
                }
                i++;
            }
        }

        // Middle Left
        if (currentX !=0)
        {
            c = BoardManager.Instance.Chesmans[currentX - 1, CurrentY];
                 if (c==null)
            {
                r[currentX - 1, CurrentY] = true; ;
            }

            else if (isWhite != c.isWhite)
            {
                r[currentX - 1, CurrentY] = true; ;
            }
        }

        // Middle Right
        if (currentX != 7)
        {
            c = BoardManager.Instance.Chesmans[currentX - 1, CurrentY];
            if (c == null)
            {
                r[currentX + 1, CurrentY] = true; ;
            }

            else if (isWhite != c.isWhite)
            {
                r[currentX + 1, CurrentY] = true; ;
            }
        }
        return r;

    }
	
    
   
}
