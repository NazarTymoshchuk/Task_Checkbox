enum ICONS
{
	CHECKED = (char)84,
	UNCHECKED = (char)70,
	INDETERMINATE = (char)73
}

class Checkbox
{
	public bool IsEnable { get; set; }
	public bool? IsChecked { get; private set; }

	public bool IsIndeterminate { get; private set; }
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
		if (IsEnable)
		{
			if (IsIndeterminate)
				IsChecked = null;
			else
				IsChecked = isChecked;

			Console.WriteLine(Print());
		}
	}

	public string Print()
	{
		if (IsChecked == true)
			return ((char)ICONS.CHECKED) + " : " + Title;

		if (IsChecked == false)
            return ((char)ICONS.UNCHECKED) + " : " + Title;

		if (IsChecked == null)
            return ((char)ICONS.INDETERMINATE) + " : " + Title;

		return string.Empty;
	}

    public override string ToString()
    {
		return Print();
    }

    public static implicit operator Checkbox(bool value) => new Checkbox() { IsChecked = value };
}