using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    
    private void Awake() {
        scoreText = GetComponent<Text>();
    }
    public void setPoint(int point) {
        scoreText.text = point.ToString();
    }

    public void setHighestPoint(int highestPoint) {
        scoreText.text = "Highest point: " + highestPoint.ToString();
    }
}
