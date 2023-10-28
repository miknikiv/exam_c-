using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace MediaLibrary
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MediaItem> mediaItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            mediaItems = new ObservableCollection<MediaItem>();
            DataContext = this; // Set DataContext to the current instance
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Open the Add/Edit window for adding a new media item
            var addEditWindow = new AddEditWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                mediaItems.Add(addEditWindow.EditedMediaItem);
            }
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected
            if (mediaListView.SelectedIndex != -1)
            {
                // Open the Add/Edit window for editing the selected media item
                var selectedMediaItem = mediaListView.SelectedItem as MediaItem;
                var addEditWindow = new AddEditWindow(selectedMediaItem);
                if (addEditWindow.ShowDialog() == true)
                {
                    // Update the media item
                    int selectedIndex = mediaListView.SelectedIndex;
                    mediaItems[selectedIndex] = addEditWindow.EditedMediaItem;
                }
            }
        }

        private void Usuń_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected
            if (mediaListView.SelectedIndex != -1)
            {
                // Remove the selected media item
                int selectedIndex = mediaListView.SelectedIndex;
                mediaItems.RemoveAt(selectedIndex);
            }
        }

        private void Importuj_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to import media items from a file
            // For example, using a file dialog and deserialization
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Library Files|*.mlib";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(ObservableCollection<MediaItem>));
                        mediaItems.Clear();
                        mediaItems = (ObservableCollection<MediaItem>)serializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while importing: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Eksportuj_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to export media items to a file
            // For example, using a file dialog and serialization
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Media Library Files|*.mlib";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        var serializer = new XmlSerializer(typeof(ObservableCollection<MediaItem>));
                        serializer.Serialize(fs, mediaItems);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while exporting: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
