using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMiroProgram.Maze;
using WPFMiroProgram;

namespace WPFMiroProgram.ViewModel
{
    class CreateMiroViewModel : ViewModelBase
    {
        MiroList mirolist = new MiroList();
        public Command CreateCommand { get; set; }
        public Command SaveCommand { get; set; }
        private string msg;
        public string Msg
        {
            get { return msg; }
            set
            {
                msg = value;
                OnPropertyChanged("Msg");
            }
        }
        private string filename;

        public string Filename
        {
            get { return filename; }
            set
            {
                filename = value;
                OnPropertyChanged("Filename");
            }
        }
        private int row;

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                OnPropertyChanged("Row");
            }
        }
        private int col;

        public int Col
        {
            get { return col; }
            set
            {
                col = value;
                OnPropertyChanged("Col");
            }
        }
        private string mazefile;
        public string Mazefile
        {
            get { return mazefile; }
            set
            {
                mazefile = value;
                OnPropertyChanged("Mazefile");
            }
        }

        public CreateMiroViewModel()
        {
            CreateCommand = new Command(CreateMethod);
            SaveCommand = new Command(SaveMethod);
            Msg = "";
        }

        private void SaveMethod(object obj)
        {
            mirolist.Addlist(Mazefile, Filename);
            Msg = Filename+" 저장완료";
        }

        private void CreateMethod(object obj)
        {
            Mazefile = "1111\r\n0011\r\n1000\r\n1111";
            Msg = "생성완료";
        }
    }
}
