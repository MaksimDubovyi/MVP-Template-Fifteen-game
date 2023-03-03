namespace Пятнашки
{
    public partial class Form1 : Form, IfifteenView
    {
        List<Button> buttons = new List<Button>();
        int min = 0;
        int sec = 0;
        Button curentbutton = null;

        public int Min { get { return min; } set { min = value; } }
        public int Sec { get { return sec; } set { sec = value; } }
        public string GetButtons (int i)
        {
            return buttons[i].Text;
        }
        public void SetButtons(int i,string str)
        {
             buttons[i].Text=str;
        }
        public bool GetButtonsEnabled(int i)
        {
            return buttons[i].Enabled;
        }
        public void SetButtonsEnabled(int i, bool en)
        {
            buttons[i].Enabled = en;
        }
        public bool GetButtonsVisible(int i)
        {
            return buttons[i].Visible;
        }
        public void SetButtonsVisible(int i, bool vi)
        {
            buttons[i].Visible = vi;
        }
        public int GetButtonsTabIndex(int i)
        {
            return buttons[i].TabIndex;
        }
        public int SetButtonsTabIndex(int i,int inq)
        {
            return buttons[i].TabIndex=inq;
        }
        public int ProgressBarValue { get { return progressBar1.Value; } set { progressBar1.Value = value; } }
        public int MinimumProgressBar { get { return progressBar1.Minimum; } set { progressBar1.Minimum = value; } }
        public int MaximumProgressBar { get { return progressBar1.Maximum; } set { progressBar1.Maximum = value; } }
        public string Label
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public bool StartButtonEnabled { get { return button17.Enabled; } set { button17.Enabled = value; } }
        public bool ReStartButtonEnabled { get { return button18.Enabled; } set { button18.Enabled = value; } }
        public bool FinishVisible { get { return button19.Visible; } set { button19.Visible = value; } }
        public int Curentbutton { get { return curentbutton.TabIndex; } set { curentbutton.TabIndex = value; } }

        public bool ProceedVisible
        {
            get {return proceedToolStripMenuItem.Visible; }
            set { proceedToolStripMenuItem.Visible = value; }
        }
        
        public void Time_Stop()
        {
            timer1.Stop();
        }
        public event EventHandler<EventArgs> Game;
        public event EventHandler<EventArgs> Tick;
        public event EventHandler<EventArgs> Start;
        public event EventHandler<EventArgs> RE_Start;
        public event EventHandler<EventArgs> Save;
        public event EventHandler<EventArgs> Savetart;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Step = 1;
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            for (int i = 0; i < 16; i++)
                buttons[i].Enabled = false;
            button18.Enabled = false;
            button19.Visible = false;
            Text = "Game";
        }
      
       
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Tick?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) { }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            curentbutton = button;
            try
            {
                Game?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) { }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                Start?.Invoke(this, EventArgs.Empty);
                timer1.Start();
            }
            catch (Exception ex) { }
        }
        private void RE_Start_Click(object sender, EventArgs e)
        {
            try
            {
                RE_Start?.Invoke(this, EventArgs.Empty); ;
                timer1.Start();
            }
            catch (Exception ex) { }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Save?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) { }
        }

        private void S(object sender, EventArgs e)
        {
            try
            {
                Save?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex) { }
        }

        private void Proceed(object sender, EventArgs e)
        {
            try
            {
                Savetart?.Invoke(this, EventArgs.Empty);
                timer1.Start();
            }
            catch (Exception ex) { }
        }
    }
}