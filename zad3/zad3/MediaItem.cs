using System;
using System.ComponentModel;

namespace MediaLibrary
{
    public class MediaItem
    {
        private string _tytuł;

        public string Tytuł
        {
            get { return _tytuł; }
            set
            {
                if (_tytuł != value)
                {
                    _tytuł = value;
                    OnPropertyChanged(nameof(Tytuł));
                }
            }
        }

        public string ReżyserAutor { get; set; }
        public string WydawcaStudio { get; set; }
        public string Nośnik { get; set; }
        public TimeSpan Długość { get; set; }
        public DateTime DataWydania { get; set; }

        // Add other properties such as ReżyserAutor, WydawcaStudio, Nośnik, etc.

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

