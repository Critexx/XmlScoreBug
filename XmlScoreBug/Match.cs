using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace XmlScoreBug
{
    class Match : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string _nameTeam1;
        private string _nameTeam2;
        private int _scoreTeam1;
        private int _scoreTeam2;
        private int _foulTeam1;
        private int _foulTeam2;
        private TimeSpan _time;
        TimeSpan StartTime;
        DateTime StartCalcTime;
        private DispatcherTimer _timer;

        public Match()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += dispatcherTimer_Tick;
        }

        public string NameTeam1
        {
            get { return _nameTeam1; }
            set
            {
                _nameTeam1 = value; 
                OnPropertyChanged(new PropertyChangedEventArgs("NameTeam1"));
            }
        }

        public string NameTeam2
        {
            get { return _nameTeam2; }
            set
            {
                _nameTeam2 = value; 
                OnPropertyChanged(new PropertyChangedEventArgs("NameTeam2"));
            }
        }

        public int ScoreTeam1
        {
            get { return _scoreTeam1; }
            set
            {
                _scoreTeam1 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ScoreTeam1"));
            }
        }

        public int ScoreTeam2
        {
            get { return _scoreTeam2; }
            set
            {
                _scoreTeam2 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ScoreTeam2"));
            }
        }

        public int FoulTeam1
        {
            get { return _foulTeam1; }
            set
            {
                _foulTeam1 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FoulTeam1"));
            }
        }

        public int FoulTeam2
        {
            get { return _foulTeam2; }
            set
            {
                _foulTeam2 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FoulTeam2"));
            }
        }

        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeFormatted"));
            }
        }

        public string TimeFormatted
        {
            get
            {
                string strformatSek;
                if (Time.Seconds < 10)
                    strformatSek = "0" + Time.Seconds.ToString();
                else
                    strformatSek = Time.Seconds.ToString();
                return Time.Minutes.ToString() + ":" + strformatSek;
            }
            set  { }
        }

        public void Play()
        {
            int interval = 200;
            _timer.Interval = TimeSpan.FromMilliseconds(interval);
            StartCalcTime = DateTime.Now;
            StartTime = Time;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Time = StartTime + StartCalcTime.Subtract(DateTime.Now);
            
        }
    }
}
