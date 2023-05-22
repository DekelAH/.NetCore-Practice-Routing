using CountriesAppRoutingPractice.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/countries", async context =>
    {
        foreach (var country in CountriesData.GetCountriesData)
        {
            await context.Response.WriteAsync($"{country.Key}. {country.Value}\n");
        }
    });

    endpoints.Map("/countries/{id:int:min(1)}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (CountriesData.GetCountriesData.ContainsKey(id))
        {
            string countryName = CountriesData.GetCountriesData[id];
            await context.Response.WriteAsync($"{countryName}");
        }
        else
        {
            if (context.Response.StatusCode == 200)
            {
                context.Response.StatusCode = 404;

                if (id > 100)
                {
                    await context.Response.WriteAsync("The CountryID should be between 1 and 100");
                }
                else
                {

                    await context.Response.WriteAsync("[No Country]");
                }
            }
        }
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});

app.Run();
