namespace Editor.PluginContracts.Extensions
{
    using Editor.PluginContracts;
    using System;

    public class CSharpSnippets : ObservableObject, ISnippetProvider
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

        public bool IsActive
        {
            get => field;
            set => this.SetProperty(ref field, value);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Snippet? TryExpandSnippet(Document document, CursorPosition cursor)
        {
            throw new NotImplementedException();
        }
    }
}