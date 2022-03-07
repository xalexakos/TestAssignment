using Microsoft.Playwright;
using NUnit.Framework;
using TestAssignment.Pages;

namespace TestAssignment.Steps;

[Binding]
public class RegistrationStepDefinition
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RegistrationPage _registrationPage;

    public RegistrationStepDefinition(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _registrationPage = new RegistrationPage(scenarioContext.Get<IPage>("page"));
    }
    
    [Given("user visits the registration page")]
    public async Task GivenUserVisitsTheRegistrationPage()
    {
        await _registrationPage.Goto();
    }
    
    [When("a user is registered with the following details")]
    public async Task WhenAUserIsRegisteredWithTheFollowingDetails(Table table)
    {
        _scenarioContext.Set( table.Rows[0][8], "username");
        await _registrationPage.SetFirstName(table.Rows[0][0]);
        await _registrationPage.SetLastName(table.Rows[0][1]);
        await _registrationPage.SetAddress(table.Rows[0][2]);
        await _registrationPage.SetCity(table.Rows[0][3]);
        await _registrationPage.SetState(table.Rows[0][4]);
        await _registrationPage.SetZipCode(table.Rows[0][5]);
        await _registrationPage.SetPhoneNumber(table.Rows[0][6]);
        await _registrationPage.SetSsn(table.Rows[0][7]);
        await _registrationPage.SetUserName(table.Rows[0][8]);
        await _registrationPage.SetPassword(table.Rows[0][9]);
        await _registrationPage.SetPasswordConfirmation(table.Rows[0][10]);
        await _registrationPage.Register();
    }

    [Then("the registration error (.*) is displayed")]
    public async Task ThenTheRegistrationErrorIsDisplayed(string error)
    {
        var errors = await _registrationPage.GetRegistrationErrors();
        Assert.AreEqual(errors.Count(err => err == error), 1);
    }
    
    [Then("the registration is not completed")]
    public async Task ThenTheRegistrationIsNotCompleted()
    {
        StringAssert.Contains("Signing up is easy!", await _registrationPage.GetRegistrationPageTitle());
    }
    
    [Then("the registration is completed")]
    public async Task ThenTheRegistrationIsCompleted()
    {
        StringAssert.Contains($"Welcome {_scenarioContext["username"]}", await _registrationPage.GetRegistrationPageTitle());
    }

    [Given("a user with username (.*)")]
    public async Task GivenAUserWithUsername(string username)
    {
        await _registrationPage.Goto();
        await _registrationPage.SetFirstName("Test First Name");
        await _registrationPage.SetLastName("Test Last Name");
        await _registrationPage.SetAddress("Test Addr");
        await _registrationPage.SetCity("Test City");
        await _registrationPage.SetState("Test State");
        await _registrationPage.SetZipCode("123456");
        await _registrationPage.SetPhoneNumber("123456");
        await _registrationPage.SetSsn("12345");
        await _registrationPage.SetUserName(username);
        await _registrationPage.SetPassword("123456");
        await _registrationPage.SetPasswordConfirmation("123456");
        await _registrationPage.Register();
    }
}