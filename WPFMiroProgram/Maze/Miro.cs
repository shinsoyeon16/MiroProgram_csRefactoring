using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMiroProgram.Resource;

namespace WPFMiroProgram.Maze
{
    public class Miro
    {
        #region Field
        private int rowSize = 0;
        private int colSize = 0;
        private string filename;
        public char[][] miro;
        public string mazeFile { get; set; }
        public bool isFindEntry = false;

        public int RowSize
        {
            get { return rowSize; }
            set { rowSize = value; }
        }
        public int ColSize
        {
            get { return colSize; }
            set { colSize = value; }
        }
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        private Node entry;

        internal Node Entry
        {
            get { return entry; }
            set { entry = value; }
        }
        #endregion


        public Miro(string filename)
        {
            Filename = filename;
            Load(Filename);
            entry = new Node();
            FindEntry();
            Print();
        }


        public void Load(string filename)
        {
            //파일의 모든 문자열을 읽어오기
            mazeFile = File.ReadAllText("../../Miro/" + filename + ".txt");

            //미로의 행, 열 정보 알아내기
            foreach (char a in mazeFile)
            {
                if (a == '\n') break;
                ColSize++;
            }
            mazeFile.Trim();
            RowSize = mazeFile.Length / ColSize;

            //이차원 배열 선언 및 미로 저장하기
            miro = new char[RowSize][];
            for (int x = 0; x < RowSize; x++)
            {
                miro[x] = new char[ColSize];
            }
            int i = 0, j = 0;
            foreach (char a in mazeFile)
            {
                if (j == ColSize) { i++; j = 0; }
                else
                {
                    miro[i][j] = a;
                    j++;
                }
            }
        }

        public string Print()
        {
            mazeFile = "";

            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    if (miro[i][j] == '0') //이동 가능한 곳
                    {
                        mazeFile = mazeFile + "□";
                    }
                    else if (miro[i][j] == '1') //벽
                    {
                        mazeFile = mazeFile + "▒";
                    }
                    else if (miro[i][j] == '.') //이동한 자리
                    {
                        mazeFile = mazeFile + "▣";
                    }
                    else if (miro[i][j] == 'c') //이동할 자리 (다음분기에 추가한 칸 표시)
                    {
                        mazeFile = mazeFile + "▩";
                    }
                    else if (miro[i][j] == 'e') //입구
                    {
                        mazeFile = mazeFile + "▶";
                    }
                    else if (miro[i][j] == 'x') //출구
                    {
                        mazeFile = mazeFile + "★";
                    }
                    else if (miro[i][j] == 'q') //미로 탐색 종료시 출구 표시
                    {
                        mazeFile = mazeFile + "■";
                    }
                }
                mazeFile = mazeFile + "\r\n";
            }
            return mazeFile;
        }

        public void FindEntry()
        {
             Node exit = new Node();

            if (!isFindEntry)
            {
                for (int i = 0; i < RowSize; i++)
                {
                    for (int j = 0; j < ColSize; j++)
                    {
                        if (miro[0][j] == '0') { entry.row = 0; entry.col = j; }
                        else if (miro[i][0] == '0') { entry.row = i; entry.col = 0; }
                        if (miro[RowSize - 1][j] == '0') { exit.row = RowSize - 1; exit.col = j; }
                        else if (miro[i][ColSize - 1] == '0') { exit.row = i; exit.col = ColSize - 1; }
                    }
                    isFindEntry = true;
                }
            }

            miro[entry.row][entry.col] = 'e'; //미로의 입구를 e로 표시(출력시 가독성을 위해)
            miro[exit.row][exit.col] = 'x'; //미로의 출구를 x로 표시
        }
    }
}
