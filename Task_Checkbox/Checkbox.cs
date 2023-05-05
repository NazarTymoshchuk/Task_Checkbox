using System.ComponentModel;
using System.Runtime.CompilerServices;

enum ICONS
{
    CHECKED = (char)84,
    UNCHECKED = (char)70,
    INDETERMINATE = (char)73
}

class Checkbox : INotifyPropertyChanged
{
	public bool? IsChecked { get; private set; }

	private bool isEnable;
	private bool canBeIndeterminate;
	private string title;

	public bool IsEnable
    {
		get { return isEnable; }
		set 
		{ 
			isEnable = value;
			OnPropertyChanged("IsEnable");
		}
	}

    public bool CanBeIndeterminate
    {
        get { return canBeIndeterminate; }
        set
        {
            canBeIndeterminate = value;
            OnPropertyChanged("CanBeIndeterminate");
        }
    }


	public string Title
	{
		get { return title; }
		set 
		{ 
			title = value;
			OnPropertyChanged("Title");
		}
	}


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

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    public void Click()
	{
		if (IsEnable)
		{
			if (IsChecked == true)
				IsChecked = false;

			else if (IsChecked == false && CanBeIndeterminate)
				IsChecked = null;

			else if (IsChecked == null)
				IsChecked = true;

			else if (IsChecked == false)
				IsChecked = true;

			OnPropertyChanged("IsChecked");
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
