enum ICONS
{
	CHECKED = (char)251,
	UNCHECKED = (char)233,
	INDETERMINATE = (char)254
}

class Checkbox
{
    public bool? IsChecked { get; set; }
	public bool IsEnable { get; set; }
	public bool IsIndeterminate { get; set; }
	public string Title { get; set; }

	public Checkbox()
	{
		IsChecked = false;
		IsEnable = true;
		IsIndeterminate = false;
		Title = string.Empty;
	}

	public Checkbox(string title) : this()
	{
		Title = title;
	}

	public void Checked(bool? isChecked)
	{
		if(IsEnable)
		{
			if(IsIndeterminate)
				IsChecked = null;
			else
				IsChecked = isChecked;

			Print(isChecked);
		}
	}

	private void Print(bool? isChecked) 
	{
		if(isChecked == true)
			Console.WriteLine(ICONS.CHECKED + " : " + Title);

        if (isChecked == false)
            Console.WriteLine(ICONS.UNCHECKED + " : " + Title);

        if (isChecked == null)
            Console.WriteLine(ICONS.INDETERMINATE + " : " + Title);
    }
}