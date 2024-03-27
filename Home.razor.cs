using CourtSystem.Data;
using CourtSystem.Helpers;
using CourtSystem.Models;
using CourtSystem.Models.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;

namespace CourtSystem;

public partial class Home {
    public ElementReference? LoadNewCourtListDialog { get; set; }
    public ElementReference? LoadPreviousCourtListDialog { get; set; }
    public string CaseFileNumbers { get; set; } = string.Empty;
    private string? _error;
    private async Task OpenNewCourtListDialog() {
        if (LoadNewCourtListDialog is not null) { 
            _error = null;
            await JSRuntime.InvokeVoidAsync("openDialog", LoadNewCourtListDialog);
        }
    }

    private async Task OpenPreviousCourtListDialog() {
        if (LoadNewCourtListDialog is not null) {
            _error = null;
            await JSRuntime.InvokeVoidAsync("openDialog", LoadPreviousCourtListDialog);
        }
    }

    private async Task FetchCourtList() {
        var client = new HttpClient();
        var caseFileNumbers = CaseFileNumbers.Split("\n").Where(e => !string.IsNullOrWhiteSpace(e));
        var response = await client.PostAsJsonAsync($"{AppConstants.ApiBaseUrl}/generate-case-files", caseFileNumbers);

        if (!response.IsSuccessStatusCode) {
            await JSRuntime.InvokeVoidAsync("alert", "Failed to fetch court list.");
            return;
        }

        var caseFiles = await response.Content.ReadFromJsonAsync<List<CaseFile>>();
        if (caseFiles is null) {
            _error = "Failed to fetch court list.";
            return;
        }

        var defendants = caseFiles.Select(e => e.Defendant).Distinct().ToList();
        foreach (var defendant in defendants) {
            defendant.CaseFiles = caseFiles.Where(e => e.Defendant.Id == defendant.Id).ToList();
        }

        var courtList = new CourtList {
            Date = DateTime.Now,
            Defendants = defendants
        };

        var dbContext = new ApplicationDbContext();

        dbContext.CourtLists.Add(courtList);
        dbContext.SaveChanges();

        NavManager.NavigateTo("/court-list", true);
    }

    private async Task CloseLoadNewCourtListDialog() {
        if (LoadNewCourtListDialog is not null) { 
            await JSRuntime.InvokeVoidAsync("closeDialog", LoadNewCourtListDialog);
        }
    }
    private async Task CloseLoadPreviousCourtListDialog() {
        if (LoadNewCourtListDialog is not null) { 
            await JSRuntime.InvokeVoidAsync("closeDialog", LoadPreviousCourtListDialog);
        }
    }
}