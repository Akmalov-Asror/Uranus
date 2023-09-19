using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MimeKit.Text;

namespace Urnaus.Client.Services;

public class LocalStorageService
{
    private readonly NavigationManager _navigationManager;
    private readonly IJSRuntime _jsruntime;

    public LocalStorageService(NavigationManager navigationManager, IJSRuntime jsruntime)
    {
        _navigationManager = navigationManager;
        _jsruntime = jsruntime;
    }

    public async Task ClearLocalStorage()
    {
        await _jsruntime.InvokeVoidAsync("clearLocalStorage");
    }

    public async void LogOut()
    {
        await ClearLocalStorage();
    }

    public async Task<string> GetEmailFromLocalStorage()
    {
        var email = await _jsruntime.InvokeAsync<string>("localStorage.getItem", "email");

        return email;
    }
    

}