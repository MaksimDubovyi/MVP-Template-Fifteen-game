using System.Runtime.Serialization.Json;

namespace Пятнашки
{
    internal class FifeenPresenter
    {
        private  IModel _model;
        private readonly IfifteenView _fifteen;
        int r = 0;
        public FifeenPresenter(IModel model, IfifteenView fifteen)
        {
            _model = model;
            _fifteen = fifteen;
            _fifteen.Game += new EventHandler<EventArgs>(OnGame);
            _fifteen.Start += new EventHandler<EventArgs>(Start);
            _fifteen.RE_Start += new EventHandler<EventArgs>(ReStart);
            _fifteen.Tick += new EventHandler<EventArgs>(Tick_Tick);
            _fifteen.Save += new EventHandler<EventArgs>(Save_);
            _fifteen.Savetart += new EventHandler<EventArgs>(Savetart_);
        }
        void Save()
        {
            FileStream stream = null;
            DataContractJsonSerializer json = null;

            stream = new FileStream("Json.json", FileMode.Create);
            json = new DataContractJsonSerializer(typeof(Model));
            json.WriteObject(stream, _model);
            stream.Close();
        }
        void Load()
        {
            try
            {
                FileStream stream = null;
                DataContractJsonSerializer json = null;

                stream = new FileStream("Json.json", FileMode.Open);
                json = new DataContractJsonSerializer(typeof(Model));
                _model=((Model)json.ReadObject(stream));
                stream.Close();
            }
            catch (Exception ex) { };
        }
        void Sstarts()
        {
            Load();

            for (int i = 0; i < 16; i++)
            {
                if (_model[i] == 16)
                {
                    r = i;
                    _fifteen.SetButtonsEnabled(i, true);
                }
                else
                    _fifteen.SetButtonsEnabled(i, true);
            }
                

            _fifteen.StartButtonEnabled = false;
            _fifteen.ReStartButtonEnabled = true;
            _fifteen.FinishVisible = false;
            _fifteen.MinimumProgressBar = 0;
            _fifteen.ProgressBarValue=_model.ProgressBarValue;
            _fifteen.MaximumProgressBar = 15;

            for (int i = 0; i < 16; i++)
                _fifteen.SetButtons(i, _model[i].ToString());

            _fifteen.SetButtons(r, "0");
            _fifteen.SetButtonsVisible(r, false);
        }
        void mix()
        {
            Random rand = new Random();
            for (int t = 0; t < 15; t++)
            {
                int j = rand.Next(1, 15);
                for (int i = 0; i < j; i++)
                {
                    int tmp = _model[i];
                    _model[i] = _model[i + 1];
                    _model[i + 1] = tmp;
                }
            }
        }
        void Init()
        {
            mix();
            for (int i = 0; i < 16; i++)
                _fifteen.SetButtons(i, _model[i].ToString());
        }
        void Starts()
        {
            for (int i = 0; i < 16; i++)
             _fifteen.SetButtonsEnabled(i, true);
            _fifteen.ProceedVisible = false;
            _fifteen.StartButtonEnabled = false;
            _fifteen.ReStartButtonEnabled = true;
            _fifteen.FinishVisible = false;
            _fifteen.MinimumProgressBar = 0;
            _fifteen.MaximumProgressBar = 15;
            _fifteen.ProgressBarValue = 0;
            Init();
            _model.Min = 0;
            _model.Sec = 0;
            _fifteen.SetButtons(15, "0");
            _fifteen.SetButtonsVisible(15, false);
        }
        void Time()
        {

            _model.Sec++;
            if (_model.Sec == 60)
            {
                _model.Min++;
                _model.Sec = 0;
            }
            _fifteen.Label = string.Format("{0:D2}:{1:D2}", _model.Min, _model.Sec);
        }
        private void Tick_Tick(object sender, EventArgs e)
        {
            Time();
            if (_fifteen.ProgressBarValue == _fifteen.MaximumProgressBar)
            {
                _fifteen.Time_Stop();
                for (int i = 0; i < 15; i++)
                    _fifteen.SetButtonsEnabled(i, false);

                _fifteen.ReStartButtonEnabled = true;
                _fifteen.FinishVisible = true;
            }
        }
        private void Start(object sender, EventArgs e)
        {
            Starts();
        }

        private void Savetart_(object sender, EventArgs e)
        {
            Sstarts();
        }
        private void ReStart(object sender, EventArgs e)
        {
            for(int i = 0; i < 16; i++)
            {
                if(_model[i]==16)
                {
                    int temp = _model[i];
                    _model[i] = _model[15];
                    _model[15] = temp;
                }
            }
            Starts();
            for (int i = 0; i < 15; i++)
                _fifteen.SetButtonsVisible(i, true);
        }
        void Left(int t, int x)
        {
            int txt = Convert.ToInt32(_fifteen.GetButtons(x));
            if (txt == _fifteen.GetButtonsTabIndex(x) + 1 && t != 0)
            {
                _fifteen.ProgressBarValue = --t;
                _model.ProgressBarValue = --t;
            }
            if (txt == (_fifteen.GetButtonsTabIndex(x + 1) + 1))
            {
                _fifteen.ProgressBarValue = ++t;
                _model.ProgressBarValue = ++t;
            }

            string str = _fifteen.GetButtons(x + 1);
            _fifteen.SetButtons(x + 1, _fifteen.GetButtons(x));
            _fifteen.SetButtons(x, str);

            int temp = _model[x + 1];
            _model[x + 1] = _model[x];
            _model[x] = temp;

            _fifteen.SetButtonsVisible(x, false);
            _fifteen.SetButtonsVisible(x + 1, true);
        }
        void Right(int t, int x)
        {
            int txt = Convert.ToInt32(_fifteen.GetButtons(x - 1));
            if (txt == _fifteen.GetButtonsTabIndex(x) + 1 && t != 0)
            {
                _fifteen.ProgressBarValue = --t;
                _model.ProgressBarValue = --t;
            }

            if (txt == (_fifteen.GetButtonsTabIndex(x - 1) + 1))
            {
                _fifteen.ProgressBarValue = ++t;
                _model.ProgressBarValue = ++t;
            }

            string str = _fifteen.GetButtons(x - 1);
            _fifteen.SetButtons(x - 1, _fifteen.GetButtons(x));
            _fifteen.SetButtons(x, str);

            int temp = _model[x - 1];
            _model[x - 1] = _model[x];
            _model[x] = temp;

            _fifteen.SetButtonsVisible(x, false);
            _fifteen.SetButtonsVisible(x - 1, true);
        }
        void Top(int t,int x)
        {
            int txt = Convert.ToInt32(_fifteen.GetButtons(x));
            if (txt == _fifteen.GetButtonsTabIndex(x) + 1 && t != 0)
            {
                _fifteen.ProgressBarValue = --t;
                _model.ProgressBarValue = --t;
            }

            if (txt == (_fifteen.GetButtonsTabIndex(x + 4) + 1))
            {
                _fifteen.ProgressBarValue = ++t;
                _model.ProgressBarValue = ++t;
            }

            string str = _fifteen.GetButtons(x + 4);
            _fifteen.SetButtons(x + 4, _fifteen.GetButtons(x));
            _fifteen.SetButtons(x, str);

            int temp = _model[x + 4];
            _model[x + 4] = _model[x];
            _model[x] = temp;

            _fifteen.SetButtonsVisible(x, false);
            _fifteen.SetButtonsVisible(x + 4, true);
        }
        void Bottom(int t, int x)
        {
            int txt = Convert.ToInt32(_fifteen.GetButtons(x));
            if (txt == _fifteen.GetButtonsTabIndex(x) + 1 && t != 0)
            {
                _fifteen.ProgressBarValue = --t;
                _model.ProgressBarValue = --t;
            }

            if (txt == (_fifteen.GetButtonsTabIndex(x - 4) + 1))
            {
                _fifteen.ProgressBarValue = ++t;
                _model.ProgressBarValue = ++t;
            }

            string str = _fifteen.GetButtons(x - 4);
            _fifteen.SetButtons(x - 4, _fifteen.GetButtons(x));
            _fifteen.SetButtons(x, str);

            int temp = _model[x - 4];
            _model[x - 4] = _model[x];
            _model[x] = temp;

            _fifteen.SetButtonsVisible(x, false);
            _fifteen.SetButtonsVisible(x - 4, true);
        }
        private void OnGame(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(_fifteen.Curentbutton);
                int t = _fifteen.ProgressBarValue;

                if (x != 0 && x != 4 && x != 8 && x != 12 && _model[x - 1] == 16)
                    Right(t, x);
                else if (x != 0 && x != 1 && x != 2 && x != 3 && _model[x - 4] == 16)
                    Bottom(t, x);
                else if (x != 12 && x != 13 && x != 14 && x != 15 && _model[x + 4] == 16)
                    Top(t, x);
                else if (x != 3 && x != 7 && x != 11 && x != 15 && _model[x + 1] == 16)
                    Left(t, x);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void Save_(object sender, EventArgs e)
        {
            Save();
        }
    }
}
