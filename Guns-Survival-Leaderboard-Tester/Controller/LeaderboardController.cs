using System;
using System.Threading.Tasks;
using Guns_Survival_Leaderboard_Tester.Model;
using Guns_Survival_Leaderboard_Tester.Services;
using Guns_Survival_Leaderboard_Tester.View;

namespace Guns_Survival_Leaderboard_Tester.Controller
{
    public class LeaderboardController
    {
        private readonly LeaderboardService _service;
        private readonly LeaderboardView _view;

        public LeaderboardController(LeaderboardService service, LeaderboardView view)
        {
            _service = service;
            _view = view;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                _view.ShowMenu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var top10 = await _service.GetTop10Async();
                            _view.ShowTop10(top10);
                            break;
                        case "2":
                            var newScore = _view.PromptForNewScore();
                            var created = await _service.AddScoreAsync(newScore);
                            _view.ShowMessage($"Added: {created.nickname} ({created.score}) ID={created.id}");
                            break;
                        case "3":
                            var aroundId = _view.PromptForScoreId("view around");
                            var aroundList = await _service.GetAroundIdAsync(aroundId);
                            _view.ShowAroundId(aroundList);
                            break;
                        case "4":
                            var delId = _view.PromptForScoreId("delete");
                            await _service.DeleteScoreAsync(delId);
                            _view.ShowMessage("Score deleted successfully.");
                            break;
                        case "5":
                            await _service.ResetLeaderboardAsync();
                            _view.ShowMessage("Leaderboard reset successfully.");
                            break;
                        case "6":
                            Random random = new Random();
                            for(int  i =0; i< 50; i++)
                            {
                                ScoreCreate entry = new ScoreCreate(random.Next(1000), random.Next(500), $"사용자{random.Next(1000)}");
                                created = await _service.AddScoreAsync(entry);
                                _view.ShowMessage($"Added: {created.nickname} ({created.score}) ID={created.id}");
                            }
                            break;
                        case "0":
                            return;
                        default:
                            _view.ShowMessage("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _view.ShowMessage($"[Error] {ex.Message}");
                }
            }
        }
    }
}
