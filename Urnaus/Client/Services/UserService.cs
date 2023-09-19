using System.Net.Http.Json;
using Urnaus.Server.Dto_s;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Client.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<Course>> GetCourseList()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Course>>("api/Course");
        return result;
    }

    public async Task<List<Course>?> GetUserCourses(string email)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Course>>("/api/User/course?email=" + email);
        return result;
    }

    public async Task<Urnaus.Shared.Task> GetTask(string taskId)
    {
        return await _httpClient.GetFromJsonAsync<Urnaus.Shared.Task>("/api/Task/one?id=" + taskId);
        
    }

    public async Task<List<Homework>> GetHomeworkList() => await _httpClient.GetFromJsonAsync<List<Urnaus.Shared.Homework>>("api/Homework");

    public async Task<List<Teacher>> GetTeacherList() => await _httpClient.GetFromJsonAsync<List<Teacher>>("api/Teacher");
}