using L.Heritage.Admin.Desktop.App.Routing.Commands;
using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Shared.Model;
using Mapster;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class RoomsVM : ViewModelBase
{
    private readonly GetRoomsCommand _getRoomsCommand;
    public NavigateEditRoomCommand _navigateEditRoomCommand;

    public PaginationVM<RoomCardVM> RoomsPaginationVM { get; private set; }

    public NavigateCreateRoomCommand NavigateCreateRoomCommand { get; private set; }

    public RoomsVM(GetRoomsCommand getRoomsCommand, 
        NavigateCreateRoomCommand navigateCreateRoomCommand,
        NavigateEditRoomCommand navigateEditRoomCommand)
    {
        RoomsPaginationVM = new PaginationVM<RoomCardVM>(1, 3)
        {
            NextPageCommand = new RelayCommand(NextPage),
            PrevPageCommand = new RelayCommand(PrevPage),
        };
        NavigateCreateRoomCommand = navigateCreateRoomCommand;
        _navigateEditRoomCommand = navigateEditRoomCommand;
        _getRoomsCommand = getRoomsCommand;
        _getRoomsCommand.Executed += OnGetRoomsExecuted;
        _getRoomsCommand.Execute(new GetRoomsParameters
        {
            Page = RoomsPaginationVM.Page,
            PageSize = RoomsPaginationVM.PageSize,
        });
    }

    private void NextPage(object? _)
    {
        _getRoomsCommand.Execute(new GetRoomsParameters
        {
            Page = ++RoomsPaginationVM.Page,
            PageSize = RoomsPaginationVM.PageSize,
        });
    }

    private void PrevPage(object? _)
    {
        _getRoomsCommand.Execute(new GetRoomsParameters
        {
            Page = --RoomsPaginationVM.Page,
            PageSize = RoomsPaginationVM.PageSize,
        });
    }

    private void OnGetRoomsExecuted(object? _, MetadataList<Room> rooms)
    {
        List<RoomCardVM> roomVms = rooms.Adapt<List<RoomCardVM>>();
        roomVms.ForEach(vm => vm.NavigateEditRoomCommand = _navigateEditRoomCommand);
        RoomsPaginationVM.Values = roomVms;
        RoomsPaginationVM.HasNext = rooms.MetaData.HasNext;
    }

    public override void Dispose()
    {
        _getRoomsCommand.Executed -= OnGetRoomsExecuted;
    }
}
