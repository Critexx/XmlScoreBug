using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private TimeSpan _matchTimeLength;

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
                OnPropertyChanged(new PropertyChangedEventArgs("Time"));
            }
        }

        public TimeSpan MatchTimeLength
        {
            get { return _matchTimeLength; }
            set { _matchTimeLength = value; }
        }

        public void ResetScore()
        {
            
        }
    }
}
