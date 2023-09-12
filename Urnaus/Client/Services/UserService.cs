using System.Net.Http.Json;
using Urnaus.Server.Dto_s;
using Urnaus.Shared;

namespace Urnaus.Client.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<User> Register(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user/register", loginDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }
}