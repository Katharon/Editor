namespace Editor.PluginContracts.Extensions
{
    using Editor.Domain;
    using Editor.PluginContracts;
    using System;
    using System.Collections.Generic;

    public class CSyntaxHighlighter : ObservableObject, ISyntaxHighlighter
    {
        required public string Name
        {
            get => field;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Value cannot be null.");
                }

                this.SetProperty(ref field, value);
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HighlightSpan> GetHighlights(Document document)
        {
            throw new NotImplementedException();
        }
    }
}