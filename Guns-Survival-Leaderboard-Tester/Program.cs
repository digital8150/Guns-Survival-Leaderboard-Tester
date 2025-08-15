using System.Threading.Tasks;
using Guns_Survival_Leaderboard_Tester.Services;
using Guns_Survival_Leaderboard_Tester.View;
using Guns_Survival_Leaderboard_Tester.Controller;
using System.Globalization;

namespace Guns_Survival_Leaderboard_Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://oci.codingbot.kr";

            var service = new LeaderboardService(baseUrl);
            var view = new LeaderboardView();
            var controller = new LeaderboardController(service, view);

            await controller.RunAsync();
        }
    }
}