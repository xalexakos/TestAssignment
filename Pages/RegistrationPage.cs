using Microsoft.Playwright;

namespace TestAssignment.Pages;

public class RegistrationPage
{
    private readonly IPage _page;

    public RegistrationPage(IPage page)
    {
        _page = page;
    }
    
    public async Task Goto()
    {
        await _page.GotoAsync("https://parabank.parasoft.com/parabank/register.htm");
    }
    
    public async Task SetFirstName(string? value)
    {
        await _page.FillAsync("[id*=firstName]", value!);
    }
    
    public async Task SetLastName(string? value)
    {
        await _page.FillAsync("[id*=lastName]", value!);
    }
    
    public async Task SetAddress(string? value)
    {
        await _page.FillAsync("[id*=address]", value!);
    }
    
    public async Task SetCity(string? value)
    {
        await _page.FillAsync("[id*=city]", value!);
    }
    
    public async Task SetState(string? value)
    {
        await _page.FillAsync("[id*=state]", value!);
    }
    
    public async Task SetZipCode(string? value)
    {
        await _page.FillAsync("[id*=zipCode]", value!);
    }
    
    public async Task SetPhoneNumber(string? value)
    {
        await _page.FillAsync("[id*=phoneNumber]", value!);
    }
    
    public async Task SetSsn(string? value)
    {
        await _page.FillAsync("[id*=ssn]", value!);
    }
    
    public async Task SetUserName(string? value)
    {
        await _page.FillAsync("[id*=username]", value!);
    }

    public async Task SetPassword(string? value)
    {
        await _page.FillAsync("[id*=password]", value!);
    }
    
    public async Task SetPasswordConfirmation(string? value)
    {
        await _page.FillAsync("[id=repeatedPassword]", value!);
    }
    
    public async Task Register()
    {
        await _page.ClickAsync("[value=Register]");
    }

    public async Task<IReadOnlyList<string>> GetRegistrationErrors()
    {
        await _page.WaitForSelectorAsync("tr [id*=errors]");
        var errors = _page.Locator("tr [id*=errors]");
        return await errors.AllTextContentsAsync();
    }

    public async Task<string?> GetRegistrationPageTitle()
    {
        return await _page.Locator("[class=title]").TextContentAsync();
    }
}