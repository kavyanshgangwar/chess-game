using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public Image cellPrefab;
    public Text textPrefabAlphabets;
    public Text textPrefabDigits;
    public Sprite whitePawnSprite;
    public Sprite whiteBishopSprite;
    public Sprite whiteKnightSprite;
    public Sprite whiteRookSprite;
    public Sprite whiteQueenSprite;
    public Sprite whiteKingSprite;
    public Sprite blackPawnSprite;
    public Sprite blackBishopSprite;
    public Sprite blackKnightSprite;
    public Sprite blackRookSprite;
    public Sprite blackQueenSprite;
    public Sprite blackKingSprite;
    private Image[,] board = new Image[8,8];
    private Text[] numbers = new Text[8];
    private Text[] alphabets = new Text[8];
    private Color whiteCellColor = new Color(238,238,210);
    private Piece[,] pieceBoard = new Piece[8,8];
    private Image[,] pieceImages = new Image[8,8];
    private PieceUtils pieceUtils = new PieceUtils();
    void Start()
    {
        MakeBoard();
        PutPieces();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeBoard(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                board[i,j] = Instantiate(cellPrefab);
                board[i,j].transform.position = new Vector3(100*j+50,-100*i-50,0);
                board[i,j].transform.SetParent(transform,false);
                if((i+j)%2 == 0){
                    board[i,j].color = whiteCellColor;
                }
            }
        }
        for(int i=0;i<8;i++){
            numbers[i] = Instantiate(textPrefabDigits);
            numbers[i].transform.position = new Vector3(15,-5,0);
            numbers[i].transform.SetParent(board[i,0].transform,false);
            numbers[i].text = (i+1).ToString();
            if(i%2==1){
                numbers[i].color = whiteCellColor;
            }
        }
        char a = 'a';
        for(int i=0;i<8;i++){
            alphabets[i] = Instantiate(textPrefabAlphabets);
            alphabets[i].transform.position = new Vector3(-15,30,0);
            alphabets[i].transform.SetParent(board[7,i].transform,false);
            alphabets[i].text = a.ToString();
            a++;
            if(i%2==0){
                alphabets[i].color = whiteCellColor;
            }
        }
    }

    void PutPieces(){
        // on (0,0) black rook
        MakePieceUtil(0,blackRookSprite,pieceUtils.rook,new Vector3(50,-50,0),0,0);
        // on (0,1) we have black knight
        MakePieceUtil(0,blackKnightSprite,pieceUtils.knight,new Vector3(150,-50,0),0,1);
        // on (0,2) we have black bishop
        MakePieceUtil(0,blackBishopSprite,pieceUtils.bishop,new Vector3(250,-50,0),0,2);
        // on (0,3)  we have black queen
        MakePieceUtil(0,blackQueenSprite,pieceUtils.queen,new Vector3(350,-50,0),0,3);
        // on (0,4) we have black King
        MakePieceUtil(0,blackKingSprite,pieceUtils.king,new Vector3(450,-50,0),0,4);
        // on (0,5 ) we have black bishop
        MakePieceUtil(0,blackBishopSprite,pieceUtils.bishop,new Vector3(550,-50,0),0,5);
        // on (0,6) we have black knight
        MakePieceUtil(0,blackKnightSprite,pieceUtils.knight,new Vector3(650,-50,0),0,6);
        // on (0,7) we have black rook
        MakePieceUtil(0,blackRookSprite,pieceUtils.rook,new Vector3(750,-50,0),0,7);
        // on (1,i) we have black pawns
        for(int i=0;i<8;i++){
            MakePieceUtil(0,blackPawnSprite,pieceUtils.pawn,new Vector3(50+(i*100),-150,0),1,i);
        }

        // on (6,i) we have white pawns
        for(int i=0;i<8;i++){
            MakePieceUtil(1,whitePawnSprite,pieceUtils.pawn,new Vector3(50+(i*100),-650,0),6,i);
        }
        // on (7,0) we have white rook
        MakePieceUtil(1,whiteRookSprite,pieceUtils.rook,new Vector3(50,-750,0),7,0);
        // on (7,1) we have white knight
        MakePieceUtil(1,whiteKnightSprite,pieceUtils.knight,new Vector3(150,-750,0),7,1);
        // on (7,2) we have white bishop
        MakePieceUtil(1,whiteBishopSprite,pieceUtils.bishop,new Vector3(250,-750,0),7,2);
        // on (7,3) we have white queen
        MakePieceUtil(1,whiteQueenSprite,pieceUtils.queen,new Vector3(350,-750,0),7,3);
        // on (7,4) we have white king
        MakePieceUtil(1,whiteKingSprite,pieceUtils.rook,new Vector3(450,-750,0),7,4);
        // on (7,5) we have white bishop
        MakePieceUtil(1,whiteBishopSprite,pieceUtils.bishop,new Vector3(550,-750,0),7,5);
        MakePieceUtil(1,whiteKnightSprite,pieceUtils.knight,new Vector3(650,-750,0),7,6);
        MakePieceUtil(1,whiteRookSprite,pieceUtils.rook,new Vector3(750,-750,0),7,7);

    }

    void MakePieceUtil(int color, Sprite sprite, int type, Vector3 position,int i,int j){
        pieceImages[i,j] = Instantiate(cellPrefab);
        pieceImages[i,j].transform.position = position;
        pieceImages[i,j].color = Color.white;
        pieceImages[i,j].transform.SetParent(transform,false);
        pieceImages[i,j].transform.localScale = new  Vector3(0.8f,0.8f,1);
        pieceImages[i,j].sprite = sprite;
        pieceBoard[i,j] = new Piece(type,color);
    }
}
