namespace ivy.Models
{
    public class Item : BaseDataObject
    {

        string funid = string.Empty;
        public string Funid
        {
            get { return funid; }
            set { SetProperty(ref funid, value); }
        }

        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
