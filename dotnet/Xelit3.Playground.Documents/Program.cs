using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using Xelit3.Playground.Documents;

//Sample following Nick Chapsas's video: https://youtu.be/BMnjwz-u-9Y?si=VeW3NVSJ6uQ9LVPr

//Microsoft.Playwright.Program.Main(["install"]);
//return;


var invoice = InvoiceHelper.GetFakeInvoice();

var services = new ServiceCollection();
services.AddLogging();

var serviceProvider = services.BuildServiceProvider();

var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var paramenters = new Dictionary<string, object?>()
    {
        { "Invoice", invoice }
    };

    var parameters = ParameterView.FromDictionary(paramenters);
    var output = await htmlRenderer.RenderComponentAsync<InvoiceReportView>(parameters);

    return output.ToHtmlString();
});

using var playwrigght = await Playwright.CreateAsync();
var browser = await playwrigght.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = true,
});

var page = await browser.NewPageAsync();
await page.SetContentAsync(html);

await page.PdfAsync(new PagePdfOptions
{
    Format = "A4",
    Path = "./invoice-sample.pdf"
});

await page.CloseAsync();

Console.ReadLine();
