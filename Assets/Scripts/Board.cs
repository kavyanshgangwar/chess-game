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
    private Image[,] board = new Image[8,8];
    private Text[] numbers = new Text[8];
    private Text[] alphabets = new Text[8];
    private Color whiteCellColor = new Color(238,238,210);
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
