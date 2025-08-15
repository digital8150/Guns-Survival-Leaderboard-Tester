using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Guns_Survival_Leaderboard_Tester.Model;


namespace Guns_Survival_Leaderboard_Tester.Services
{
    public class LeaderboardService
    {
        private readonly HttpClient _httpClient;

        public LeaderboardService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // Top 10 랭킹 가져오기
        public async Task<List<ScoreEntry>> GetTop10Async()
        {
            var response = await _httpClient.GetAsync("/leaderboard/top10");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ScoreEntry>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // 점수 등록
        public async Task<ScoreEntry> AddScoreAsync(ScoreCreate score)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(score),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/leaderboard", jsonContent);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ScoreEntry>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // 특정 ID 주변 랭킹 가져오기
        public async Task<List<ScoreEntry>> GetAroundIdAsync(string scoreId)
        {
            var response = await _httpClient.GetAsync($"/leaderboard/{scoreId}/around");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ScoreEntry>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // 특정 점수 삭제
        public async Task DeleteScoreAsync(string scoreId)
        {
            var response = await _httpClient.DeleteAsync($"/leaderboard/{scoreId}");
            response.EnsureSuccessStatusCode();
        }

        // 리더보드 초기화
        public async Task ResetLeaderboardAsync()
        {
            var response = await _httpClient.DeleteAsync("/leaderboard");
            response.EnsureSuccessStatusCode();
        }
    }
}
