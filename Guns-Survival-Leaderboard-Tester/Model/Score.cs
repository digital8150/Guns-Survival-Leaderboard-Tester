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
        public int score { get; set; }
        public int survival_time { get; set; }
        public string nickname { get; set; }

        public ScoreCreate(int score, int survivalTime, string nickname)
        {
            this.score = score;
            this.survival_time = survivalTime;
            this.nickname = nickname;
        }
    }

    // API 응답에 사용하는 데이터
    public class ScoreEntry
    {
        public string id { get; set; }
        public DateTime registration_date { get; set; }
        public int score { get; set; }
        public int survival_time { get; set; }
        public string nickname { get; set; }

        public override string ToString()
        {
            return $"{nickname} - Score: {score}, Survival Time: {survival_time}, Registered: {registration_date}";
        }
    }
}
