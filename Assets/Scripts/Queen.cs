using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessMan
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessMan c;
        int i,j;

        // ------------------Right ----------------// 

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

        // ----------- Left -----------------------// 

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
        // ------------  Up -----------------------//
        i = CurrentY;
        while (true)
        {
            i++;

            if (i >= 8)
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
        // ------------ Down ----------------------//
        i = CurrentY;
        while (true)
        {
            i--;

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

        i = currentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j++;

            if (i < 0 || j >= 8)
            {
                break;
            }

            c = BoardManager.Instance.Chesmans[i, j];
            if (c == null)
            {
                r[i, j] = true;

            }
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j] = true;

                }
                break;

            }

        }
        // ----------Top Right -------------------// 
        i = currentX;
        j = CurrentY;

        while (true)
        {
            i++;
            j++;

            if (i >= 8 || j >= 8)
            {
                break;
            }

            c = BoardManager.Instance.Chesmans[i, j];
            if (c == null)
            {
                r[i, j] = true;

            }
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j] = true;

                }
                break;

            }

        }

        // ---------  Down Left ------------------//   
        i = currentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j--;

            if (i < 0 || j < 0)
            {
                break;
            }

            c = BoardManager.Instance.Chesmans[i, j];
            if (c == null)
            {
                r[i, j] = true;

            }
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j] = true;

                }
                break;

            }

        }
        // ----------- Down Right ----------------// 
        i = currentX;
        j = CurrentY;

        while (true)

        return r;
    }


}
