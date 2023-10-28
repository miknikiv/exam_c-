using System.Windows;

namespace MediaLibrary
{
    public partial class AddEditWindow : Window
    {
        public MediaItem MediaItem { get; private set; }

        public AddEditWindow()
        {
            InitializeComponent();
            MediaItem = new MediaItem();
            DataContext = MediaItem;
        }

        public AddEditWindow(MediaItem mediaItem)
        {
            InitializeComponent();
            MediaItem = mediaItem;
            DataContext = MediaItem;
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
