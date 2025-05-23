 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;     // We need this line for uGUI to work.

 public class HighScore : MonoBehaviour {
     static private Text      _UI_TEXT;                                   
     static private int       _SCORE = 0;                              

     private Text txtCom;  // txtCom is a reference to this GO’s Text component

     void Awake () {                                                      
         _UI_TEXT = this.GetComponent<Text>();                            
        
         // If the PlayerPrefs HighScore already exists, read it
         if (PlayerPrefs.HasKey("HighScore")) {                                        
             SCORE = PlayerPrefs.GetInt("HighScore");
         }
         // Assign the high score to HighScore
         PlayerPrefs.SetInt("HighScore", SCORE);                                       
     }

     static public int SCORE {
         get { return _SCORE; }
         private set {
             _SCORE = value;
             PlayerPrefs.SetInt("HighScore", value);                                   
            if ( _UI_TEXT != null ) {
                 _UI_TEXT.text = "High Score: " + value.ToString( "#,0" );
             }
         }
     }

     static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {           
         if ( scoreToTry <= SCORE ) return; // If scoreToTry is too low, return
         SCORE = scoreToTry;
     }

     // The following code allows you to easily reset the PlayerPrefs HighScore
     [Tooltip( "Check this box to reset the HighScore in PlayerPrefs" )]
     public bool resetHighScoreNow = false;                                           
 
     void OnDrawGizmos() {                                                            
         if ( resetHighScoreNow ) {
             resetHighScoreNow = false;
             PlayerPrefs.SetInt( "HighScore", 0 );
             Debug.LogWarning( "PlayerPrefs HighScore reset to 1,000." );
         }        
     }
 }
 
