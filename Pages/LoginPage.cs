using Microsoft.Playwright;

namespace TestAssignment.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }
    
    public async Task Goto()
    {
        await _page.GotoAsync("https://parabank.parasoft.com/parabank/index.htm");
    }

    public async Task<LoginPage> SetUserName(string? value)
    {
        await _page.FillAsync("[name=username]", value!);
        return this;
    }
    
    public async Task SetPassword(string? value)
    {
        await _page.FillAsync("[name=password]", value!);
    }
    
    public async Task Submit()
    {
        await _page.ClickAsync("[type=submit]");
    }

    public async Task<string?> GetLoginError()
    {
        return await _page.Locator("[id=rightPanel] [class=error]").TextContentAsync();
    }

    public string GetLandingPageUrl()
    {
        return _page.Url;
    }
}