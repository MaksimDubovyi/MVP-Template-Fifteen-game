

namespace Пятнашки
{
    internal interface IfifteenView
    {

        public int Min { get; set; }
        public int Sec { get; set; }
        public string GetButtons(int i);
        public void SetButtons(int i, string str);
        public bool GetButtonsEnabled(int i);
        public void SetButtonsEnabled(int i, bool en);
        public bool GetButtonsVisible(int i);
        public void SetButtonsVisible(int i, bool vi);
        public int GetButtonsTabIndex(int i);
        public int SetButtonsTabIndex(int i, int inq);
        public int ProgressBarValue { get; set; }
        public int MinimumProgressBar { get; set; }
        public int MaximumProgressBar { get; set; }
        public int Curentbutton { get ;set;}
        public bool StartButtonEnabled { get; set; }
        public bool ReStartButtonEnabled { get; set; }
        public bool FinishVisible { get; set; }
        public void Time_Stop();
        public string Label { get; set; }
        event EventHandler<EventArgs> Game;
        event EventHandler<EventArgs> Tick;
        event EventHandler<EventArgs> Start;
        event EventHandler<EventArgs> RE_Start;
        event EventHandler<EventArgs> Save;
        event EventHandler<EventArgs> Savetart;
        public bool ProceedVisible { get; set; }


    }
}
