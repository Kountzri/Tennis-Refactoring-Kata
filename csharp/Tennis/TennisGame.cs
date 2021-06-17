using System;
using System.Diagnostics;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            //Simplifying Code so each part returns the most reduced code minimizing errors also added try catches
            try
            {
                if (m_score1 == m_score2)
                {
                    //Game is Tied Return Tied Text
                    score = TiedGame();
                }
                else if (m_score1 >= 4 || m_score2 >= 4)
                {
                    //Game is Advantage to a player return Advantage Text
                    score = GameAdvantage();
                }
                else
                {
                    //Score is neither tied nor are we at advantage
                    score = MidGameScoreText();
                }
            }
            catch (Exception ex)
            {
                //Some minor error handling
                Trace.WriteLine("An Error Occurred: " + ex.Message);
               
            }       
            return score;
        }
        public string MidGameScoreText()
        {
            string midGameScoreText = "";
            try
            {
              
                var tempScore = 0;
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1)
                    { tempScore = m_score1; }
                    else
                    { midGameScoreText += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            midGameScoreText += "Love";
                            break;
                        case 1:
                            midGameScoreText += "Fifteen";
                            break;
                        case 2:
                            midGameScoreText += "Thirty";
                            break;
                        case 3:
                            midGameScoreText += "Forty";
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                //Error Handling
                Trace.WriteLine("An Error Occurred:" + ex.Message);
               
            }
          
            return midGameScoreText;
        
        }
        public string TiedGame()
        {
            string gameTied = "";
            try
            {
                switch (m_score1)
                {
                    case 0:
                        gameTied = "Love-All";
                        break;
                    case 1:
                        gameTied = "Fifteen-All";
                        break;
                    case 2:
                        gameTied = "Thirty-All";
                        break;
                    default:
                        gameTied = "Deuce";
                        break;
                }
            }
            catch (Exception ex)
            {

                Trace.WriteLine("An Error Occurred" + ex.Message);
            }
           
            return gameTied;
        }
        public string ShutoutGame()
        {
            //Someone had a bad game

            string shutoutText = "";

            try
            {
                if (m_score1 > 2)
                {
                    shutoutText = "Win for player1";
                }
                else
                { shutoutText = "Win for player2"; }
            }
            catch (Exception ex)
            {

                Trace.WriteLine("An error occurred" + ex.Message);
              
            }
           
            return shutoutText;
        }
        public string GameAdvantage()
        {         
            string advantageText = "";
            try
            {
                //Didn't really need to change name just thought the readability improved over minusResult
                var advantageDifference = m_score1 - m_score2;

                if (advantageDifference > 2 || advantageDifference < -2)
                {
                    //Game will be ending
                    advantageText = ShutoutGame();
                }
                else
                {
                    switch (advantageDifference)
                    {
                        case 1:
                            advantageText = "Advantage player1";
                            break;
                        case -1:
                            advantageText = "Advantage player2";
                            break;
                        case 2:
                            advantageText = "Win for player1";
                            break;
                        default:
                            advantageText = "Win for player2";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error Handling
                Trace.WriteLine("An Error Occurred:" + ex.Message);
            }
          
            return advantageText;
        }
    }
}

