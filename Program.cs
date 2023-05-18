using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using StudentManagmentApp.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor(); //UI components library for creating Blazor WebAssembly and Server applications

var app = builder.Build();

//License key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1mQ1BCaV1CX2BZfFl3TWlad04QCV5EYF5SRHNeRVxnS31RcU1iXXk=;Mgo+DSMBPh8sVXJ1S0R+X1pCaV5EQmFJfFBmR2lYd1RzfEUmHVdTRHRcQlhiTn9XdEZhXndceHI=;ORg4AjUWIQA/Gnt2VFhiQlJPcEBDW3xLflF1VWFTflZ6d11WACFaRnZdQV1mSHlSckdgW3hWc31T;MjA5NDE2MUAzMjMxMmUzMjJlMzNSTGYyaUszck5UdmE5MVdSNVUxN0VaK1NlcERkbzlkWU9XaUJUR2NvWS93PQ==;MjA5NDE2MkAzMjMxMmUzMjJlMzNIM1Z3eGY1U1RGZE11SzkrSDB0b1g1MFFtbGg0dko3a2xsWEp4eUF0UXRBPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVldXGVWfFN0RnNbdV94flZOcDwsT3RfQF5jTH9Ud0FhWn1ZeH1UQA==;MjA5NDE2NEAzMjMxMmUzMjJlMzNSWE04MUM3VDUwVENueFA5bXNVTnRBNGI4ZGlPYTV4d09zaUZhQTBNTzFNPQ==;MjA5NDE2NUAzMjMxMmUzMjJlMzNPa1l6enVlZFkxUlRKWG1KdW5lZzArWE9LaWtWQURTbFMyeGN6RDBLOHlNPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPcEBDW3xLflF1VWFTflZ6d11WACFaRnZdQV1mSHlSckdgW3hXdHBT;MjA5NDE2N0AzMjMxMmUzMjJlMzNYWG1RUnJxbFBBdDVIcmVxTFNQSzJXelVLbkozTkhsVjJNR2NhY1ZjTUdrPQ==;MjA5NDE2OEAzMjMxMmUzMjJlMzNQZm5MUWZTeW9ScHd3STZiWFJKangvN3hpemVPc0lERmhyTFR5QWdackQ0PQ==;MjA5NDE2OUAzMjMxMmUzMjJlMzNSWE04MUM3VDUwVENueFA5bXNVTnRBNGI4ZGlPYTV4d09zaUZhQTBNTzFNPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
