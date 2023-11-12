using Blazored.FluentValidation;
using Forces.Application.Features.Forces.Queries.GetAll;
using Forces.Application.Features.Inventory.Queries.GetAll;
using Forces.Application.Features.InventoryInventoryItem.Commands.AddEdit;
using Forces.Application.Features.MeasureUnits.Queries.GetAll;
using Forces.Application.Responses.VoteCodes;
using Forces.Client.Extensions;
using Forces.Client.Infrastructure.Managers.BasicInformation.Forces;
using Forces.Client.Infrastructure.Managers.Inventory;
using Forces.Client.Infrastructure.Managers.InventoryItem;
using Forces.Client.Infrastructure.Managers.Items.MeasureUnits;
using Forces.Client.Infrastructure.Managers.VoteCodes;
using Forces.Shared.Constants.Application;
using Forces.Shared.Constants.Permission;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.Security.Claims;

namespace Forces.Client.Pages.InventoryItem
{
    public partial class InventorySerials
    {
        [Inject] private IInventoryItemManager InventoryItemManager { get; set; }
        [Inject] private IInventoryManager InventoryManager { get; set; }
        private List<GetAllInventoriesResponse> _InventoryList = new();
        private List<string> _SerialsList = new();

        [Parameter] public int count { get; set; }

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [Inject] IDialogService DialogService { get; set; }


        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        public void Cancel()
        {
            MudDialog.Cancel();
        }
        
        private async Task SaveAsync()
        {
            /*var response = await InventoryItemManager.SaveAsync(AddEditInventoryItemModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], MudBlazor.Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, MudBlazor.Severity.Error);
                }
            }*/
            await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
        }
        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();

            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }
       
        private int? converterForInventories(string ss)
        {
            return _InventoryList.FirstOrDefault(s => s.Name == ss).Id;
        }


        private async Task LoadDataAsync()
        {
           
            await Task.CompletedTask;
        }
    }
}
