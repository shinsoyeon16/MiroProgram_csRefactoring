using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMiroProgram.ViewModel;

namespace WPFMiroProgram.Maze
{
    public class MiroList : ViewModelBase
    {
        private List<Miro> _Mirolist;

        public List<Miro> _mirolist
        {
            get { return _Mirolist; }
            set { _Mirolist = value;
                OnPropertyChanged("_mirolist");
            }
        }
        public  string[] filenames { get; set; }

        public MiroList()
        {
            FillMiroList();
        }
        public  void FillMiroList()
        {
            _mirolist = new List<Miro>();
            filenames = File.ReadAllLines(@"../../Miro/Mirolist.txt");
            foreach (string filename in filenames)
            {
                _mirolist.Add(new Miro(filename));
            }
        }
        public  void Addlist(string mazefile, string filename)
        {
            string s = File.ReadAllText(@"../../Miro/Mirolist.txt");
            StreamWriter sw = new StreamWriter(@"../../Miro/Mirolist.txt");
            sw.Write(s + "\r\n" + filename);
            sw.Close();
            StreamWriter stream = new StreamWriter(@"../../Miro/"+filename+".txt");
            stream.Write(mazefile);
            stream.Close();
        }
    }
}