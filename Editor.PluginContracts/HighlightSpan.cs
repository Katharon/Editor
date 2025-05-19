namespace Editor.PluginContracts
{
    using Editor.Domain;
    using System;

    public class HighlightSpan : ObservableObject
    {
        required public int StartIndex
        {
            get => field;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(StartIndex), "Start index cannot be smaller than 0.");
                }

                this.SetProperty(ref field, value);
            }
        }

        required public int Length
        {
            get => field;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Length), "Length cannot be shorter than 0.");
                }

                this.SetProperty(ref field, value);
            }
        }

        required public string HighlightType
        {
            get => field;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(HighlightType), "Highlight type cannot be null.");
                }

                this.SetProperty(ref field, value);
            }
        }
    }
}