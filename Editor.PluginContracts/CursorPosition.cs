namespace Editor.PluginContracts
{
    using System;
    using System.ComponentModel;

    public struct CursorPosition : INotifyPropertyChanged
    {
        required public int X
        {
            readonly get => field;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                field = value;
                RaiseOnPropertyChanged(nameof(X));
            }
        }

        required public int Y
        {
            readonly get => field;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                field = value;
                RaiseOnPropertyChanged(nameof(Y));
            }
        }

        required public int Index
        {
            readonly get => field;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                field = value;
                RaiseOnPropertyChanged(nameof(Index));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}