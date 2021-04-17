using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Piece
{
    private int piece;
    private bool hasMoved=false;
    private bool hasCastlingRightsLeft=false;
    private bool hasCastlingRightsRight=false;
    private PieceUtils pieceUtils = new PieceUtils();
    public Piece(int type,int color){
        
        piece = type;
        piece |= (color<<6);
        if((piece&pieceUtils.pieceMask) == pieceUtils.king){
            hasCastlingRightsLeft = true;
            hasCastlingRightsRight = true;
        }
    }
}
