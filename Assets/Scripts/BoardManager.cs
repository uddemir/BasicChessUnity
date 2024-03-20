using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // SATRANÇ YAPIYOK //

    public static BoardManager Instance { set; get; }
    public bool[,]  allowedMoves { set; get; }

    public ChessMan [,] Chesmans { set;  get;  }
    public ChessMan selectedChessman;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX;
    private int SelectionY;


    public  List< GameObject > chessManPrefabs;
    private List< GameObject >  activeChessMan;

    private Quaternion orientation = Quaternion.Euler(0, 180, 0);

    public bool isWhiteTurn=true;

    private void Awake()
    {

        Instance = this;
    }

    private void Start()
    {
     SpawnAllChessMans();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
        DrawChessboard();



        if (Input.GetMouseButton(0))
        {
            if (selectionX >= 0 && SelectionY >= 0)	
            {
                if (selectedChessman == null)
                {
                    // Selected the chessman
                    SelectChessman(selectionX, SelectionY);
                }
                else
                {
                    MoveChessman(selectionX, SelectionY);
                    // MOve the Chessman
                }
            }

        }
    }
    private void SelectChessman(int x, int y)
    {
        if (Chesmans[x,y]==null)
        {
            return; 
        }
    
        if (Chesmans [x,y].isWhite != isWhiteTurn)
        {
            return;

           
        }
        bool hasAtleastOneMove = false;
        allowedMoves = Chesmans[x, y].PossibleMove();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedMoves[i, j] )
                {
                    hasAtleastOneMove = true;
                }
            }
        }
        if (!hasAtleastOneMove)
        {
            return;
        }

        selectedChessman = Chesmans[x, y];
        BoardHighLights.Instance.HighlightAlloweMove(allowedMoves);
       

    }


    private void MoveChessman(int x, int y)
    {
     
        if (allowedMoves[x,y])
        {
            ChessMan c = Chesmans[x, y];
            if (c !=null && c.isWhite != isWhiteTurn)
            {
                if (c.GetType()==typeof(King))
                {
                    // end Game
                    EndGame();
                    return;
                }
                activeChessMan.Remove(c.gameObject);
                Destroy(c.gameObject);
            }
            Debug.Log("MoveChesmann İçi");
            Chesmans[selectedChessman.currentX, selectedChessman.CurrentY] = null;
            selectedChessman.transform.position = GetTileCenter(x, y);
            selectedChessman.SetPosition(x,y);
            Chesmans[x, y] = selectedChessman;
            isWhiteTurn = !isWhiteTurn;    // 
        }

        Debug.Log("MoveChesmann Dışkı");
        BoardHighLights.Instance.HideHighLights();
        selectedChessman = null;

       
    }



    private void UpdateSelection()
    {
        if (!Camera.main)
        {
            Debug.Log("burada");
            return;
        }
        RaycastHit hit;

        if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
    
                                
            selectionX = (int)hit.point.x;
            SelectionY = (int)hit.point.z;
         
        }
        else
        {
            selectionX = -1;
            SelectionY = -1;
        }

    }


    private void SpawnChessman(int index, int x, int y )
    {
        GameObject go = Instantiate(chessManPrefabs [index], GetTileCenter(x,y) ,  orientation) as GameObject;     //Instantiate 
        go.transform.SetParent(transform);
        Chesmans [x, y] = go.GetComponent<ChessMan>();
        Chesmans[x, y].SetPosition(x, y);
        activeChessMan.Add(go);

    }


    private void    SpawnAllChessMans()
    {
			activeChessMan = new List<GameObject>();
			Chesmans = new ChessMan[8, 8];

			// Spawn the white team

			// King
			SpawnChessman(0, 3, 0);

			// Queen
			 SpawnChessman(1, 4, 0);

			// Rooks
			SpawnChessman(2,0, 0);
			SpawnChessman(2, 7, 0);

			// Bishops
			SpawnChessman(3, 2, 0);
			SpawnChessman(3, 5, 0);

			// Knights
			SpawnChessman(4, 1, 0);
			SpawnChessman(4, 6, 0);

			//Pawns

			for (int i = 0; i < 8; i++)
			{
				SpawnChessman(5, i, 1);
			}

			// Spawn the Blact team

			// King
			SpawnChessman(6, 4, 7);

			// Queen
			SpawnChessman(7, 3, 7);

			// Rooks
			SpawnChessman(8, 0, 7);
			SpawnChessman(8, 7, 7);

			// Bishops
			SpawnChessman(9, 2, 7);
			SpawnChessman(9, 5, 7);

			// Knights
			SpawnChessman(10, 1, 7);
			SpawnChessman(10, 6, 7);

			//Pawns

			for (int i = 0; i < 8; i++)
			{
				SpawnChessman(11, i, 6);
			}
			
		}
   

    private Vector3     GetTileCenter(int x, int z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * z) + TILE_OFFSET;

        return origin;
    }


    private void DrawChessboard()   // Draw board
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heigthLine = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);

            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heigthLine);
            }

        }

        // Draw the Selection   
      if (selectionX  >=0 || SelectionY  >=0)
      {
                         Debug.DrawLine(
                           Vector3.forward * SelectionY + Vector3.right * selectionX,
                           Vector3.forward * (SelectionY + 1) + Vector3.right * (selectionX + 1));

          Debug.DrawLine(  Vector3.forward * (SelectionY + 1) + Vector3.right * selectionX,
                           Vector3.forward * SelectionY + Vector3.right * (selectionX + 1));

      }
    }

    private void EndGame()
    {
        if (isWhiteTurn)
        {
            Debug.Log("Beyaz Kazandı");
        }
        else
        {
            Debug.Log("Siyah Kazandı");
        }

        foreach ( GameObject go in activeChessMan)
        {
            Destroy(go);
        }

        isWhiteTurn = true;
        BoardHighLights.Instance.HideHighLights();
        SpawnAllChessMans();
    }


}
