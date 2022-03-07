using Microsoft.Playwright;
using NUnit.Framework;
using TestAssignment.Pages;

namespace TestAssignment.Steps;

[Binding]
public class LoginStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly LoginPage _loginPage;

    public LoginStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _loginPage = new LoginPage(scenarioContext.Get<IPage>("page"));
    }

    [Given("user visits the login page")]
    public async Task GivenUserVisitsTheLoginPage()
    {
        await _loginPage.Goto();
    }

    [When("user logs in with credentials")]
    public async Task WhenUserLogsInWithCredentials(Table table)
    {
        await _loginPage.SetUserName(table.Rows[0][0]);
        await _loginPage.SetPassword(table.Rows[0][1]);
        await _loginPage.Submit();
    }

    [Then("the login error (.*) is displayed")]
    public async Task ThenTheLoginErrorIsDisplayed(string error)
    {
        Assert.AreEqual(error, await _loginPage.GetLoginError());
    }
    
    [Then("user is logged in successfully")]
    public void ThenUserIsLoggedInSuccessfully()
    {
        Assert.AreEqual("https://parabank.parasoft.com/parabank/overview.htm", 
            _loginPage.GetLandingPageUrl());
    }
}