class Checkbox
{
    public bool IsChecked { get; set; }
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


}
