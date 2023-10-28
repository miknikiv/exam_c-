using System.Windows;

namespace MediaLibrary
{
    public partial class AddEditWindow : Window
    {
        public MediaItem EditedMediaItem { get; set; }

        public AddEditWindow(MediaItem mediaItem)
        {
            InitializeComponent();
            EditedMediaItem = mediaItem;
            DataContext = EditedMediaItem; // Set DataContext to the media item being edited
        }

        public AddEditWindow()
        {
            InitializeComponent();
            EditedMediaItem = new MediaItem();
            DataContext = EditedMediaItem;
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
