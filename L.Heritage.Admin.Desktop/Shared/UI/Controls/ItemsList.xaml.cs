using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace L.Heritage.Admin.Desktop.Shared.UI.Controls;

public partial class ItemsList : UserControl
{
    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ItemsList), new PropertyMetadata(null));

    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ItemsList), new PropertyMetadata(ItemsSourceChanged));

    public ItemsList()
    {
        InitializeComponent();
    }

    private static void ItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is ItemsList itemsList)
            itemsList.OnItemsSourceChanged(e);
    }

    protected void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue != null) ClearItems();
        if (e.NewValue != null) BindItems((IEnumerable)e.NewValue);
    }

    private void ClearItems()
    {
        Container?.Children.Clear();
    }

    private void BindItems(IEnumerable items)
    {
        if (Container is null) return;

        int counter = 1;
        foreach (var item in items)
        {
            if (counter > 5) return;

            if (ItemTemplate.LoadContent() is not FrameworkElement obj)
                return;

            obj.DataContext = item;
            Grid.SetColumn(obj, counter);
            Grid.SetRow(obj, 1);
            Container.Children.Add(obj);
            counter += 2;
        }
    }
}
