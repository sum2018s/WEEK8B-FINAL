using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace OperationsHub;

// MainWindow is a class. Put fields and methods inside these outer braces.
public partial class MainWindow : Window
{
    // Application state
    private readonly ObservableCollection<string> items = new ObservableCollection<string>();
    private readonly DispatcherTimer timer = new DispatcherTimer();
    private int remainingSeconds = 25 * 60;

    public MainWindow()
    {
        InitializeComponent();
        lstItems.ItemsSource = items;
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;
        Closed += (_, _) => timer.Stop();
        UpdateTimer();
    }

    private void Timer_Click(object sender, RoutedEventArgs e)
    {
        if (timer.IsEnabled)
        {
            timer.Stop();
            txtStatus.Text = "Timer paused.";
        }
        else if (remainingSeconds > 0)
        {
            timer.Start();
            txtStatus.Text = "Focus timer running.";
        }
        else { txtStatus.Text = "Reset the completed timer first."; }
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        remainingSeconds--;
        UpdateTimer();
        if (remainingSeconds <= 0)
        {
            timer.Stop();
            txtStatus.Text = "Focus interval complete.";
        }
    }

    private void UpdateTimer()
    {
        txtTimer.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
    }

    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        timer.Stop();
        remainingSeconds = 25 * 60;
        UpdateTimer();
        txtStatus.Text = "Timer reset to 25 minutes.";
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var text = txtEntry.Text?.Trim();
        if (string.IsNullOrEmpty(text))
        {
            txtStatus.Text = "Enter a non-empty task before adding.";
            return;
        }
        items.Add(text);
        txtEntry.Clear();
        txtStatus.Text = "Item added.";
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        if (lstItems.SelectedItem is string sel)
        {
            items.Remove(sel);
            txtStatus.Text = "Selected item removed.";
        }
        else
        {
            txtStatus.Text = "Select an item to remove.";
        }
    }

    private string BuildReport()
    {
        // The return value travels back to the method that called us.
        string report = "TEAM CONTRACT / WORK REPORT\n\n" + txtDocument.Text;
        report += "\n\nTASKS / ITEMS\n";
        foreach (string item in items)
        {
            report += "- " + item + "\n";
        }
        return report;
    }

    private void Save_Click(object sender, RoutedEventArgs e) => SaveText(BuildReport());

    private void SaveText(string text)
    {
        var dialog = new SaveFileDialog { Filter = "Text files|*.txt", FileName = "operations-record.txt" };
        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Save canceled. Your text stays here.";
            return;
        }
        try
        {
            File.WriteAllText(dialog.FileName, text);
            txtStatus.Text = "Saved: " + Path.GetFileName(dialog.FileName);
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not save. Choose a writable folder: " + ex.Message;
        }
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Text files|*.txt" };
        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Open canceled. Your current text stays here.";
            return;
        }
        try
        {
            txtDocument.Text = File.ReadAllText(dialog.FileName);
            txtStatus.Text = "Text reopened. Review it before editing.";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not read the file: " + ex.Message;
        }
    }

    private void Image_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.jpeg" };
        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Image choice canceled. Your work stays here.";
            return;
        }
        try
        {
            // Load the image fully so its original file is not left locked.
            var bitmap = new System.Windows.Media.Imaging.BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(dialog.FileName);
            bitmap.EndInit();
            imgArtwork.Source = bitmap;
            imgButton.Source = bitmap;
            txtStatus.Text = "Artwork loaded. Check labels and contrast.";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Choose a valid PNG or JPG: " + ex.Message;
        }
    }
}
