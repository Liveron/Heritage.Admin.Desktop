using L.Heritage.Admin.Desktop.Features.Orders.Model;
using SharpVectors.Converters;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace L.Heritage.Admin.Desktop.Views.Orders.UI;

public partial class OrdersTable : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(OrdersTable), new PropertyMetadata(ItemsSourceChanged));

    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public OrdersTable()
    {
        InitializeComponent();
    }

    private static void ItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is OrdersTable ordersTable)
            ordersTable.OnItemsSourceChanged(e);
    }

    protected void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue != null) ClearItems();
        if (e.NewValue != null) BindItems((IEnumerable)e.NewValue);
    }

    private void ClearItems()
    {
        Container?.RowDefinitions.RemoveRange(
            1, Container.RowDefinitions.Count - 1);
    }

    private void BindItems(IEnumerable items)
    {
        if (Container == null) return;

        int row = 1;
        foreach (OrderRowVM item in items)
        {
            Container.RowDefinitions.Add(new RowDefinition());
            CreateOrderRow(row++, Container, item);
        }
    }

    private static void CreateOrderRow(int row, Grid grid, OrderRowVM orderRowVM)
    {
        CreateIdTextBox(row, grid, orderRowVM);
        CreateStartDatePicker(row, grid, orderRowVM);
        CreateEndDatePicker(row, grid, orderRowVM);
        CreateRoomTextBox(row, grid, orderRowVM);
        CreateUserNameTextBox(row, grid, orderRowVM);
        CreateButtons(row, grid, orderRowVM);
    }

    private static void CreateIdTextBox(int row, Grid grid, OrderRowVM orderRowVM)
    {
        var identifier = new TextBox { DataContext = orderRowVM, IsReadOnly = true };

        var idBinding = new Binding { Path = new PropertyPath(nameof(orderRowVM.Id)) };

        identifier.SetBinding(TextBox.TextProperty, idBinding);
        Grid.SetColumn(identifier, 0);
        Grid.SetRow(identifier, row);
        grid.Children.Add(identifier);
    }

    private static void CreateStartDatePicker(int row, Grid grid, OrderRowVM orderRowVM)
    {
        var startDate = new DatePicker { DataContext = orderRowVM };

        var startDateBinding = new Binding 
        { Path = new PropertyPath(nameof(orderRowVM.Start)) };

        startDate.SetBinding(DatePicker.SelectedDateProperty, startDateBinding);
        Grid.SetColumn(startDate, 1);
        Grid.SetRow(startDate, row);
        grid.Children.Add(startDate);
    }

    private static void CreateEndDatePicker(int row, Grid grid, OrderRowVM orderRowVM)
    {
        var endDate = new DatePicker { DataContext = orderRowVM };

        var endDateBinding = new Binding { Path = new PropertyPath(nameof(orderRowVM.End)) };

        endDate.SetBinding(DatePicker.SelectedDateProperty, endDateBinding);
        Grid.SetColumn(endDate, 2);
        Grid.SetRow(endDate, row);
        grid.Children.Add(endDate);
    }

    private static void CreateRoomTextBox(int row, Grid grid, OrderRowVM orderRowVM)
    {
        var room = new TextBox { DataContext = orderRowVM };

        var roomBinding = new Binding 
        { Path = new PropertyPath(nameof(orderRowVM.RoomId)) };

        room.SetBinding(TextBox.TextProperty, roomBinding);
        Grid.SetColumn(room, 3);
        Grid.SetRow(room, row);
        grid.Children.Add(room);
    }

    private static void CreateUserNameTextBox(int row, Grid grid, OrderRowVM orderRowVM)
    {
        var userName = new TextBox { DataContext = orderRowVM };

        var userNameBinding = new Binding 
        { Path = new PropertyPath(nameof(orderRowVM.UserName)) };

        userName.SetBinding(TextBox.TextProperty, userNameBinding);
        Grid.SetColumn(userName, 4);
        Grid.SetRow(userName, row);
        grid.Children.Add(userName);
    }

    private static void CreateButtons(int row, Grid grid, OrderRowVM orderRowVM)
    {
        Button saveButton = CreateSaveButton(orderRowVM);
        Button deleteButton = CreateDeleteButton();
        var stackPanel = new StackPanel();
        stackPanel.Children.Add(saveButton);
        stackPanel.Children.Add(deleteButton);
        var border = new Border 
        { Child = stackPanel, BorderThickness = new Thickness(3, 0, 3, 3) };
        Grid.SetColumn(border, 5);
        Grid.SetRow(border, row);
        grid.Children.Add(border);
    }

    private static Button CreateSaveButton(OrderRowVM orderRowVM)
    {
        var saveIcon = new SvgIcon
        { UriSource = new Uri("/Shared/UI/Icons/save.svg", UriKind.RelativeOrAbsolute) };
        var button = new Button { Content = saveIcon, DataContext = orderRowVM };
        var buttonBinding = new Binding
        { Path = new PropertyPath(nameof(orderRowVM.IsChanged)), 
            Converter = new BooleanToVisibilityConverter() };
        button.SetBinding(VisibilityProperty, buttonBinding);
        return button;
    }

    private static Button CreateDeleteButton()
    {
        var deleteIcon = new SvgIcon
        { UriSource = new Uri("/Shared/UI/Icons/bin.svg", UriKind.RelativeOrAbsolute) };
        return new Button { Content = deleteIcon };
    }
}
