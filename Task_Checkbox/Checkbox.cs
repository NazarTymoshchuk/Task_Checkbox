using System.ComponentModel;

class Checkbox : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

	public bool IsEnable { get; set; }
	public bool? IsChecked { get; private set; }
	public bool CanBeIndeterminate { get; set; }
	public string Title { get; set; }

	public Checkbox()
	{
		IsChecked = false;
		IsEnable = true;
		CanBeIndeterminate = false;
		Title = string.Empty;
	}

	public Checkbox(string title) : this()
	{
		Title = title;
	}

    public void Click()
	{
		if (IsEnable)
		{
			if (IsChecked == true)
				IsChecked = false;

			else if (IsChecked == false && CanBeIndeterminate)
				IsChecked = null;

			else if (IsChecked == false)
				IsChecked = true;
		}
	}

	public char Icon
	{
		get
		{
			if (IsChecked == true)
				return (char)ICONS.CHECKED;
			else if (IsChecked == false)
                return (char)ICONS.UNCHECKED;
			else 
				return (char)ICONS.INDETERMINATE;
        }
	}
	public void Print() => Console.WriteLine(Icon + " : " + Title);

    public override string ToString() => Icon + " : " + Title;

    public static implicit operator Checkbox(bool value) => new Checkbox() { IsChecked = value };

	public static bool operator true(Checkbox checkbox) => checkbox.IsChecked == true ? true : false;

    public static bool operator false(Checkbox checkbox) => checkbox.IsChecked == false ? true : false;
}
