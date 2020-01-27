using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private Text _scoreText;
    private int _score = -1;
private void Awake() {
    _scoreText = GameObject.Find("Score_Text").GetComponent<Text>();
   MakeInstance() ;
}
void MakeInstance(){
if(instance == null){
    instance = this;
}
}
public void IncrementScore(){
    _score++;
    _scoreText.text = "" + _score;
}
public int GetScore(){
    return this._score;
}
}
