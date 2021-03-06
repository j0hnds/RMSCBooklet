// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox1;
    
    private Gtk.HBox hbox1;
    
    private Gtk.Label lblShows;
    
    private Gtk.ComboBox cbShows;
    
    private Gtk.HButtonBox hbuttonbox1;
    
    private Gtk.Button btnGenerate;
    
    private Gtk.Button btnExit;
    
    private Gtk.ProgressBar pbProgress;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("RMSC Booklet Generator");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        this.AllowShrink = true;
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        this.vbox1.BorderWidth = ((uint)(6));
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbox1 = new Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Spacing = 6;
        // Container child hbox1.Gtk.Box+BoxChild
        this.lblShows = new Gtk.Label();
        this.lblShows.Name = "lblShows";
        this.lblShows.LabelProp = Mono.Unix.Catalog.GetString("Select Show:");
        this.hbox1.Add(this.lblShows);
        Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.lblShows]));
        w1.Position = 0;
        w1.Expand = false;
        w1.Fill = false;
        // Container child hbox1.Gtk.Box+BoxChild
        this.cbShows = Gtk.ComboBox.NewText();
        this.cbShows.Name = "cbShows";
        this.hbox1.Add(this.cbShows);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.cbShows]));
        w2.Position = 1;
        this.vbox1.Add(this.hbox1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
        w3.Position = 0;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox1 = new Gtk.HButtonBox();
        this.hbuttonbox1.Name = "hbuttonbox1";
        // Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnGenerate = new Gtk.Button();
        this.btnGenerate.Sensitive = false;
        this.btnGenerate.CanFocus = true;
        this.btnGenerate.Name = "btnGenerate";
        this.btnGenerate.UseStock = true;
        this.btnGenerate.UseUnderline = true;
        this.btnGenerate.Label = "gtk-save";
        this.hbuttonbox1.Add(this.btnGenerate);
        Gtk.ButtonBox.ButtonBoxChild w4 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox1[this.btnGenerate]));
        w4.Expand = false;
        w4.Fill = false;
        // Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnExit = new Gtk.Button();
        this.btnExit.CanFocus = true;
        this.btnExit.Name = "btnExit";
        this.btnExit.UseStock = true;
        this.btnExit.UseUnderline = true;
        this.btnExit.Label = "gtk-quit";
        this.hbuttonbox1.Add(this.btnExit);
        Gtk.ButtonBox.ButtonBoxChild w5 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox1[this.btnExit]));
        w5.Position = 1;
        w5.Expand = false;
        w5.Fill = false;
        this.vbox1.Add(this.hbuttonbox1);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
        w6.Position = 1;
        w6.Expand = false;
        w6.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.pbProgress = new Gtk.ProgressBar();
        this.pbProgress.Name = "pbProgress";
        this.pbProgress.Text = Mono.Unix.Catalog.GetString("Creating PDF...");
        this.vbox1.Add(this.pbProgress);
        Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.pbProgress]));
        w7.Position = 2;
        w7.Expand = false;
        w7.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 390;
        this.DefaultHeight = 115;
        this.pbProgress.Hide();
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.cbShows.Changed += new System.EventHandler(this.ShowCursorChanged);
        this.btnGenerate.Clicked += new System.EventHandler(this.SaveButtonClicked);
        this.btnExit.Clicked += new System.EventHandler(this.ExitButtonClicked);
    }
}
