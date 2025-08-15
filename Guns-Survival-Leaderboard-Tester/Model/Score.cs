using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guns_Survival_Leaderboard_Tester.Model
{
    // API 요청에 사용하는 데이터
    public class ScoreCreate
    {
        public int Score { get; set; }
        public int SurvivalTime { get; set; }
        public string Nickname { get; set; }

        public ScoreCreate(int score, int survivalTime, string nickname)
        {
            Score = score;
            SurvivalTime = survivalTime;
            Nickname = nickname;
        }
    }

    // API 응답에 사용하는 데이터
    public class ScoreEntry
    {
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Score { get; set; }
        public int SurvivalTime { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return $"{Nickname} - Score: {Score}, Survival Time: {SurvivalTime}, Registered: {RegistrationDate}";
        }
    }
}
