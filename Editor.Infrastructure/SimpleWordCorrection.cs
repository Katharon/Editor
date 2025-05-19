namespace Editor.Infrastructure
{
    using Editor.Domain;
    using Editor.PluginContracts;
    using System;

    public class SimpleWordCorrection : ObservableObject, ITextTransformer
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

        public void Transform(Document document)
        {
            throw new NotImplementedException();
        }
    }
}