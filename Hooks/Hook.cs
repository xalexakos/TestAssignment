using System;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace TestAssignment.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Before]
        public async Task PageSetupAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync();
            _scenarioContext.Add("page", await browser.NewPageAsync());
        }
    }
}