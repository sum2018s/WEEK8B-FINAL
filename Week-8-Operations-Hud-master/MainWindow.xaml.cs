using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace OperationsHub;

// MainWindow is a class. Put fields and methods inside these outer braces.
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // TODO: connect your collection in the Data chapter.
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        // TODO (List chapter): Implement Add in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Add_Click: behavior still to build.";
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        // TODO (List chapter): Implement Remove in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Remove_Click: behavior still to build.";
    }

    private void Timer_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Timer chapter): Implement Timer in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Timer_Click: behavior still to build.";
    }

    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Timer chapter): Implement Reset in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Reset_Click: behavior still to build.";
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Text files chapter): Implement Save in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Save_Click: behavior still to build.";
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Text files chapter): Implement Open in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Open_Click: behavior still to build.";
    }

    private void Image_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Artwork chapter): Implement Image in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Image_Click: behavior still to build.";
    }
}
