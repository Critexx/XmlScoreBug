using System.Xml;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace XmlScoreBug
{
    class XmlHandler
    {
        private string _filename;
        public Match match;
        private string _lastScoreAction;

        public XmlHandler()
        {
            match = new Match();
        }

        public string NewXml()
        {
            match = new Match();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                _filename = saveFileDialog.FileName;           
                WriteXml();
            }
            return _filename;
        }

        public string OpenXmlFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                _filename = openFileDialog.FileName;
                XmlReader reader = XmlReader.Create(_filename);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "NameT1":
                                match.NameTeam1 = reader.ReadString();
                                break;
                            case "NameT2":
                                match.NameTeam2 = reader.ReadString();
                                break;
                            case "ScoreT1":
                                match.ScoreTeam1 = reader.ReadElementContentAsInt();
                                break;
                            case "ScoreT2":
                                match.ScoreTeam2 = reader.ReadElementContentAsInt();
                                break;
                            case "FoulT1":
                                match.FoulTeam1 = reader.ReadElementContentAsInt();
                                break;
                            case "FoulT2":
                                match.FoulTeam2 = reader.ReadElementContentAsInt();
                                break;
                        }
                    }
                }
                reader.Close();               
            }
            return _filename;
        }

        public void SaveXml()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                _filename = saveFileDialog.FileName;
                WriteXml();
            }
        }

        public void ScoreChange(object sender)
        {
            var btn = (Button)sender;
            switch (btn.Name)
            {
                case "BtnTeam1Plus1":
                    match.ScoreTeam1++;
                    break;
                case "BtnTeam1Plus2":
                    match.ScoreTeam1 += 2;
                    break;
                case "BtnTeam1Plus3":
                    match.ScoreTeam1 += 3;
                    break;
                case "BtnTeam2Plus1":
                    match.ScoreTeam2++;
                    break;
                case "BtnTeam2Plus2":
                    match.ScoreTeam2 += 2;
                    break;
                case "BtnTeam2Plus3":
                    match.ScoreTeam2 += 3;
                    break;
            }
            _lastScoreAction = btn.Name;
        }

        public void ClearScore()
        {
            match.ScoreTeam1 = 0;
            match.ScoreTeam2 = 0;
        }

        public void UndoScore()
        {
            switch (_lastScoreAction)
            {
                case "BtnTeam1Plus1":
                    match.ScoreTeam1--;
                    break;
                case "BtnTeam1Plus2":
                    match.ScoreTeam1 -= 2;
                    break;
                case "BtnTeam1Plus3":
                    match.ScoreTeam1 -= 3;
                    break;
                case "BtnTeam2Plus1":
                    match.ScoreTeam2--;
                    break;
                case "BtnTeam2Plus2":
                    match.ScoreTeam2 -= 2;
                    break;
                case "BtnTeam2Plus3":
                    match.ScoreTeam2 -= 3;
                    break;
            }
        }

        public void FoulChange(object sender)
        {
            var btn = (RepeatButton)sender;
            switch (btn.Name)
            {
                case "BtnTeam1Up":
                    match.FoulTeam1++;
                    break;
                case "BtnTeam1Down":
                    if (match.FoulTeam1 > 0)
                        match.FoulTeam1--;
                    break;
                case "BtnTeam2Up":
                    match.FoulTeam2++;
                    break;
                case "BtnTeam2Down":
                    if (match.FoulTeam2 > 0)
                        match.FoulTeam2--;
                    break;
            }
        }

        public void ClearFoul()
        {
            match.FoulTeam1 = 0;
            match.FoulTeam2 = 0;
        }

        public void WriteXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";

            XmlWriter writer = XmlWriter.Create(_filename, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Scorebug");
            writer.WriteComment("Created with " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            writer.WriteElementString("NameT1", match.NameTeam1);
            writer.WriteElementString("NameT2", match.NameTeam2);
            writer.WriteElementString("ScoreT1", match.ScoreTeam1.ToString());
            writer.WriteElementString("ScoreT2", match.ScoreTeam2.ToString());
            writer.WriteElementString("FoulT1", match.FoulTeam1.ToString());
            writer.WriteElementString("FoulT2", match.FoulTeam2.ToString());
            writer.WriteElementString("Time", match.Time.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
