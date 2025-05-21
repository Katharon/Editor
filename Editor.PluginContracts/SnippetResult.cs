namespace Editor.PluginContracts
{
    using System;

    public class Snippet : ObservableObject
    {
        required public int ReplaceStart
        {
            get => field;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(ReplaceStart), "Replace start-index cannot be smaller than 0.");
                }

                this.SetProperty(ref field, value);
            }
        }

        required public int ReplaceLength
        {
            get => field;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(ReplaceLength), "Replace length cannot be smaller than 0.");
                }

                this.SetProperty(ref field, value);
            }
        }

        required public string ReplacementText
        {
            get => field;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(ReplacementText), "Replacement text cannot be null.");
                }

                this.SetProperty(ref field, value);
            }
        }
    }
}