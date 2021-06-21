using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        //Renamed variables
        private int player1Score = 0;
        private int player2Score = 0;
      
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            //Filling the Dictionary Terms
            FillScoreDictionary();
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }
        Dictionary<string, string> ScoreDictionary = new Dictionary<string, string>();

        public void FillScoreDictionary()
        {
            //Basic Lingo for Scoring
            ScoreDictionary.Add("0", "Love");
            ScoreDictionary.Add("1", "Fifteen");
            ScoreDictionary.Add("2", "Thirty");
            ScoreDictionary.Add("3", "Forty");          
        }


        public string GetScore()
        {
            string score = "";
            int leadValue, highestValue = 0;
            //Getting absolute lead value doesn't matter which player
            leadValue = Math.Abs(player1Score - player2Score);
            //using the highest value from both players
            highestValue = Math.Max(player1Score, player2Score);
            //Removed extra methods changed rules for advantage to both players need at least 3
            try
            {
                //Tied Game Less Than 3  
                if (player1Score == player2Score && player1Score < 3 )
                {                                   
                    score = ScoreDictionary[player1Score.ToString()] + "-All";
                }
                //Deuce for games greater 3 points or greater
                else if (player1Score == player2Score && player1Score >= 3)
                {
                    score = "Deuce";
                }
                //Rules say BOTH players need at least 3 points not 4 for advantages
                else if (player1Score >= 3 && player2Score >= 3)
                {
                   
                    if(leadValue > 1)
                    {
                        score = "Win for ";
                    }
                    else { score = "Advantage "; }
                    

                    //Append player name with higher score
                    if (player1Score > player2Score)                   
                    { score += player1Name; }
                    else { score += player2Name; }
                }
                else if(highestValue >=4 && leadValue >= 2)
                {
                    //Low Scoring Games for one player
                    score = "Win for ";
                    if(player1Score > player2Score) { score += player1Name; }
                    else { score += player2Name; }
                }
                else
                {
                    score = ScoreDictionary[player1Score.ToString()] + "-" + ScoreDictionary[player2Score.ToString()];
                }
               
            }
            catch (Exception ex)
            {
                //Some minor error handling
                Trace.WriteLine("An Error Occurred: " + ex.Message);
               
            }       
            return score;
        }

       
    }
}

