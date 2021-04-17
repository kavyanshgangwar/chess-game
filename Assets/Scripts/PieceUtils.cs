using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class PieceUtils{
    public int pieceMask = 0b111111;
    public int colorMask = 0b1000000;
    public int king = 0b100000;
    public int queen = 0b010000;
    public int rook = 0b001000;
    public int bishop = 0b000100;
    public int knight = 0b000010;
    public int pawn = 0b000001;
}