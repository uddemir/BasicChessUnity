using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour
{


    public int currentX { set; get; }
    public int CurrentY { set; get; }

    public bool isWhite;

   public void SetPosition(int x, int y)
    {
        currentX = x;
        CurrentY = y;

    }
    public virtual bool[,] PossibleMove()
    {
        return new bool [8,8];
    }

}
