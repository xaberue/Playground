using System.Net.Http.Json;
using Xelit3.Playground.Users.Shared.Models;

namespace Xelit3.Playground.Users.WebUI.Services;


public interface IUserService
{
    Task<UserDto[]> GetAllAsync();
    Task<UserDto?> GetAsync(Int32 userId);
    Task CreateAsync(CreateUserDto createUserDto);
    Task UpdateAsync(UpdateUserDto updateUserDto);
    Task DeleteAsync(Int32 userId);
}


public sealed class UserService : IUserService
{

    private readonly HttpClient _apiClient;


    public UserService(HttpClient apiClient)
    {
        _apiClient = apiClient;
    }


    public async Task<UserDto[]> GetAllAsync()
    {
        return await _apiClient.GetFromJsonAsync<UserDto[]>("users") ?? [];
    }

    public async Task<UserDto?> GetAsync(int userId)
    {
        return await _apiClient.GetFromJsonAsync<UserDto>($"users/{userId}");
    }

    public async Task CreateAsync(CreateUserDto createUserDto)
    {
        await _apiClient.PostAsJsonAsync<CreateUserDto>("users", createUserDto);
    }

    public async Task UpdateAsync(UpdateUserDto updateUserDto)
    {
        await _apiClient.PutAsJsonAsync<UpdateUserDto>("users", updateUserDto);
    }

    public async Task DeleteAsync(int userId)
    {
        await _apiClient.DeleteAsync($"users/{userId}");
    }

}
