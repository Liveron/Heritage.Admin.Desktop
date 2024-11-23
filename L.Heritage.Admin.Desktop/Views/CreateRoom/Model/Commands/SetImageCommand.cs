using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;

public class SetImageCommand : CommandBase<BitmapImage>
{
    public override event EventHandler? CanExecuteChanged;
    public override event EventHandler<BitmapImage>? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
        var dialog = new OpenFileDialog { Filter = "Image files (*.jpg;*.jpeg)|*.jpg;*.jpeg" };

        BitmapImage? image = null;
        if (dialog.ShowDialog() == true)
        {
            image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(dialog.FileName);
            image.EndInit();
        }

        if (image != null) 
            OnExecuted(image);
    }

    private void OnExecuted(BitmapImage image) => Executed?.Invoke(this, image);
}
