namespace PrintPicture
{
    internal class OpenFileDialogDialog
    {
        public OpenFileDialogDialog()
        {
        }

        public string Filters { get; set; }
        public bool ValidateNames { get; set; }
        public string Filter { get; internal set; }
    }
}