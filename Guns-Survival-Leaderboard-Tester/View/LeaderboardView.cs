using System;
using System.Collections.Generic;
using Guns_Survival_Leaderboard_Tester.Model;

namespace Guns_Survival_Leaderboard_Tester.View
{
    public class LeaderboardView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n=== Leaderboard Menu ===");
            Console.WriteLine("1. Get Top 10");
            Console.WriteLine("2. Add Score");
            Console.WriteLine("3. Get Around ID");
            Console.WriteLine("4. Delete Score");
            Console.WriteLine("5. Reset Leaderboard");
            Console.WriteLine("6. Add Random Score 50 (stress test!)");
            Console.WriteLine("0. Exit");
            Console.Write("Select option: ");
        }

        public void ShowTop10(List<ScoreEntry> entries)
        {
            Console.WriteLine("\n=== Top 10 Leaderboard ===");
            foreach (var entry in entries)
            {
                Console.WriteLine($"{entry.nickname} - Score: {entry.score}, SurvivalTime: {entry.survival_time}, Date: {entry.registration_date}, ID : {entry.id}");
            }
        }

        public void ShowAroundId(List<ScoreEntry> entries)
        {
            Console.WriteLine("\n=== Around ID ===");
            foreach (var entry in entries)
            {
                Console.WriteLine($"{entry.nickname} - Score: {entry.score}, Survival: {entry.survival_time}, Date: {entry.registration_date}");
            }
        }

        public ScoreCreate PromptForNewScore()
        {
            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("Score: ");
            int score = int.Parse(Console.ReadLine());
            Console.Write("Survival Time: ");
            int survivalTime = int.Parse(Console.ReadLine());

            return new ScoreCreate(score, survivalTime, nickname);
        }

        public string PromptForScoreId(string action)
        {
            Console.Write($"Enter Score ID to {action}: ");
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
