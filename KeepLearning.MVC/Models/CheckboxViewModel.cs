namespace KeepLearning.MVC.Models
{
    public class CheckboxViewModel
    {
        public int Id { get; set; }
        public string LabelName { get; set; } = default!;
        public bool IsChecked { get; set; } = false;
    }
}
