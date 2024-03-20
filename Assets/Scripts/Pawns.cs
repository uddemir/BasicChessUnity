using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawns : ChessMan
{


    public override bool [,] PossibleMove()
    {

        bool[,] r = new bool[8, 8];
        ChessMan c, c2;

        if (isWhite)
        {


            // Diagonal Left
            if (currentX != 0 && CurrentY !=7)
            {
                c = BoardManager.Instance.Chesmans[currentX - 1, CurrentY +1];   // C nin içi dolu artık
                if (c != null && !c.isWhite)
                {
                    r[currentX - 1, CurrentY + 1] = true;  //   sol çapraz gitme
                }
            }

            // Diagonal Right
            if (currentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.Chesmans[currentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                {
                    r[currentX + 1, CurrentY + 1] = true;
                }

            }

            // Middle

            if (CurrentY != 7)
            {
                c = BoardManager.Instance.Chesmans[currentX, CurrentY + 1];  // 

                if (c==null)
                {
                    r[currentX, CurrentY+1] = true;
                }
            }

            // Middle On First Move 

            if (CurrentY ==1 )
            {
                c = BoardManager.Instance.Chesmans[currentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chesmans[currentX, CurrentY + 2];

                if (c==null & c2 == null)
                {
                    r[currentX, CurrentY + 2] = true;
                }
            }

        }

        else     // Beyaz olmadıgında çalışacak kısım
        {
            // Diagonal Left
            if (currentX != 0 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chesmans[currentX - 1, CurrentY - 1];  
                if (c != null && c.isWhite)
                {
                    r[currentX - 1, CurrentY - 1] = true;
                }

            }

            // Diagonal Right
            if (currentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chesmans[currentX + 1, CurrentY - 1];

                if (c != null && c.isWhite)
                {
                    r[currentX + 1, CurrentY - 1] = true;
                }
            }

            // Middle

            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chesmans[currentX, CurrentY - 1];

                if (c == null)
                {
                    r[currentX, CurrentY - 1] = true;
                }
            }

            // Middle On First Move 

            if (CurrentY == 6)
            {
                c = BoardManager.Instance.Chesmans[currentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chesmans[currentX, CurrentY - 2];
                 
                if (c == null & c2 == null)
                {
                    r[currentX, CurrentY - 2] = true;
                }
            }
        }


        return r;
    }



}
