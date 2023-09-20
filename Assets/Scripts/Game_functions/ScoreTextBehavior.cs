using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreTextBehavior : MonoBehaviour
    {
        // Start is called before the first frame update
        public void SetScoreText(int score)
        {
            GetComponent<TMP_Text>().text="Coins collected:"+score;
        }

}
