using System;
using System.Collections.Generic;
using Gtk;
using NumerianMF;

public partial class MainWindow: Gtk.Window
{	
	private readonly int checkDC = 25;
	private int nmfRoll;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		RollResults ();

		nmfDescLabel.SetSizeRequest (400, -1);
		ericDescLabel.SetSizeRequest (400, -1);
		stanDescLabel.SetSizeRequest (400, -1);
		nmfDescLabel.Wrap = true;
		ericDescLabel.Wrap = true;
		stanDescLabel.Wrap = true;
	}

	private void RollResults()
	{
		this.nmfRoll = RNG.RollDie (100);
		int ericResult = 0;
		int stanResult = 0;
		nmfRollLabel.Text = this.nmfRoll.ToString ();
        nmfDescLabel.Markup = "<span font_desc=\"Ariel 9\"><i>" + MysteryFluid.GetEffectString(this.nmfRoll) + "</i></span>";

		// Roll Eric
		if (ericCheck.Active)
		{
			ericResult = RollCheck (ericRollLabel, ericResultLabel, (int)ericSpin.Value);
            ericDescLabel.Markup = (this.nmfRoll == ericResult) ? "" : "<span font_desc=\"Ariel 9\"><i>" + MysteryFluid.GetEffectString(ericResult) + "</i></span>";
		}
		else
			ericRollLabel.Text = ericResultLabel.Text = "-";

		// Roll Stan
		if (stanCheck.Active)
		{
			stanResult = RollCheck (stanRollLabel, stanResultLabel, (int)stanSpin.Value);
			stanDescLabel.Markup = (this.nmfRoll == stanResult) ? "" : "<span font_desc=\"Ariel 9\"><i>" + MysteryFluid.GetEffectString (stanResult) + "</i></span>";
		}
		else
			stanRollLabel.Text = stanResultLabel.Text = "-";

		// Set Label Colors
		if (MysteryFluid.IsSameResult(ericResult, stanResult) && MysteryFluid.IsSameResult(ericResult, this.nmfRoll))
		{
            ericResultLabel.Markup = "<span foreground=\"green\" font_desc=\"Ariel 9\"><b>" + ericResultLabel.Text + "</b></span>";
            stanResultLabel.Markup = "<span foreground=\"green\" font_desc=\"Ariel 9\"><b>" + stanResultLabel.Text + "</b></span>";
		}
		else if (MysteryFluid.IsSameResult(ericResult, stanResult))
		{
            ericResultLabel.Markup = "<span foreground=\"orange\" font_desc=\"Ariel 9\"><b>" + ericResultLabel.Text + "</b></span>";
            stanResultLabel.Markup = "<span foreground=\"orange\" font_desc=\"Ariel 9\"><b>" + stanResultLabel.Text + "</b></span>";
		}
		else
		{
            ericResultLabel.Markup = "<span foreground=\"red\" font_desc=\"Ariel 9\"><b>" + ericResultLabel.Text + "</b></span>";
            stanResultLabel.Markup = "<span foreground=\"red\" font_desc=\"Ariel 9\"><b>" + stanResultLabel.Text + "</b></span>";
		}
	}

	private int RollCheck(Label rollLabel, Label resultLabel, int bonus)
	{
		int skillRoll = RNG.RollDie (20) + bonus;
		int tableRoll = RNG.RollDie (100);
        rollLabel.Markup = string.Format("<span font_desc=\"Ariel 9\"><b>{0} ({1})</b></span>", (skillRoll - bonus), skillRoll);

		if (skillRoll < this.checkDC || RNG.RollDie (100) > 75)
		{
			if (skillRoll < this.checkDC)
                resultLabel.Text = string.Format("(Failed DC) {0}", tableRoll);
			else
                resultLabel.Text = string.Format("(Failed 75%) {0}", tableRoll);

			return tableRoll;
		}
        resultLabel.Text = "Success";

		return this.nmfRoll;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnRollButtonClicked (object sender, EventArgs e)
	{
		RollResults ();
	}
}
