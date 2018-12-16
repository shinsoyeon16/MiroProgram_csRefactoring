using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WPFMiroProgram.Maze;
using System.Windows;
using WPFMiroProgram.Resource;
using System.Windows.Threading;
using System.Threading;

namespace WPFMiroProgram.ViewModel
{
    class EscapeMiroViewModel : ViewModelBase
    {
        #region Field

        public Command EscapeCommand { get; set; }
        public Command StopCommand { get; set; }
        public Command RestartCommand { get; set; }
        public Command ResetCommand { get; set; }
        public int index = 0;
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
        private char[][] miro;

        public char[][] Miro
        {
            get { return miro; }
            set
            {
                miro = value;
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
                col = value - 1;
                OnPropertyChanged("Col");
            }
        }
        static Thread thread;
        MiroList mirolist;

        #endregion

        public EscapeMiroViewModel()
        {
            EscapeCommand = new Command(EscapeMethod);
            ResetCommand = new Command(ResetMethod);
            StopCommand = new Command(StopMethod);
            RestartCommand = new Command(RestartMethod);
            mirolist = new MiroList();
            Msg = "";
        }
        private void EscapeMethod(object parameter)
        {
            if (parameter.ToString() == "0")
            {
                thread = new Thread(EscapeMaze_BFS);
            }
            else
            {
                thread = new Thread(EscapeMaze_DFS);
            }
            thread.Start();
        }
        private void ResetMethod(object parameter)
        {
            mirolist._mirolist[index] = new Maze.Miro(filename);
            SelectedChange(index);
        }

        private void StopMethod(object parameter)
        {
            thread.Suspend();
        }
        private void RestartMethod(object parameter)
        {
            thread.Resume();
        }
        
        public void SelectedChange(int idx)
        {
            index = idx;
            Miro m = mirolist._mirolist[index];
            Filename = m.Filename;
            Row = m.RowSize;
            Col = m.ColSize;
            miro = m.miro;
            Mazefile = m.mazeFile;
            Msg = "";
        }

        public bool isValidLoc(int r, int c)
        {
            //유효하지 않은 미로 좌표일경우 false반환
            if (r < 0 || c < 0 || r >= mirolist._mirolist[index].RowSize || c >= mirolist._mirolist[index].ColSize)
                return false;
            // 탐색할 수 있는 미로인지 검사 후 반환
            else
                return miro[r][c] == '0' || miro[r][c] == 'c' || miro[r][c] == 'x';
        }

        public bool isValidLocOnly(int r, int c)
        {
            int a = 0;
            if (r < 0 || c < 0 || r >= mirolist._mirolist[index].RowSize || c >= mirolist._mirolist[index].ColSize)
                return false; // 유효하지 않은 길이면 false 반환
            else
            { //다른 분기점을 만나면 false, 현재 분기점이 이어지고있다면 true 반환
                if (isValidLoc(r - 1, c)) a++;
                if (isValidLoc(r + 1, c)) a++;
                if (isValidLoc(r, c - 1)) a++;
                if (isValidLoc(r, c + 1)) a++;
                return a == 1;
            }
        }

        public void EscapeMaze_BFS()
        {
            // field 선언부
            LinkedQueue list = new LinkedQueue(); // 다음 분기점의 정보를 저장하는 큐
            LinkedStack stack = new LinkedStack(); //현재 분기점 정보를 담는 스택

            list.enqueue(mirolist._mirolist[index].Entry); //미로의 입구를 찾기위한 함수 호출

            while (list.isEmpty() == false) //탐색할 다음분기가 없을 때까지 반복하는 반복문
            {
                Node next = list.dequeue();
                stack.push(next);
                while (!stack.isEmpty())
                {
                    Mazefile = mirolist._mirolist[index].Print();
                    Thread.Sleep(90);
                    Node here = stack.pop(); //좌표  이동
                    int row = here.row;
                    int col = here.col;

                    // 미로의 출구를 탐색했다면 함수 탈출
                    if (miro[row][col] == 'x')
                    {
                        miro[row][col] = 'q';
                        Mazefile = mirolist._mirolist[index].Print();
                        Msg = "성공!!!!!";
                        return;
                    }

                    //현재위치가 출구가 아니라면 다음좌표 탐색
                    else
                    {
                        if (miro[row][col] != 'e') miro[row][col] = '.'; //지나온 자리를 표시한다
                        Thread.Sleep(1);

                        //탐색할 수 있는 여러갈래가 없고 한 분기만 있다면 스택에 추가하여 탐색
                        if (isValidLocOnly(row, col))
                        {
                            if (isValidLoc(row - 1, col)) stack.push(new Node(row - 1, col));//상
                            else if (isValidLoc(row, col + 1)) stack.push(new Node(row, col + 1));//우
                            else if (isValidLoc(row + 1, col)) stack.push(new Node(row + 1, col));//하
                            else if (isValidLoc(row, col - 1)) stack.push(new Node(row, col - 1));//좌
                        }

                        //여러개의 분기를 만나면 큐에 추가하여 탐색
                        else
                        {
                            if (isValidLoc(row - 1, col)) { list.enqueue(new Node(row - 1, col)); if (miro[row - 1][col] != 'x') miro[row - 1][col] = 'c'; }//상 부터 시계방향으로 탐색
                            if (isValidLoc(row, col + 1)) { list.enqueue(new Node(row, col + 1)); if (miro[row][col + 1] != 'x') miro[row][col + 1] = 'c'; }//우
                            if (isValidLoc(row + 1, col)) { list.enqueue(new Node(row + 1, col)); if (miro[row + 1][col] != 'x') miro[row + 1][col] = 'c'; }//하
                            if (isValidLoc(row, col - 1)) { list.enqueue(new Node(row, col - 1)); if (miro[row][col - 1] != 'x') miro[row][col - 1] = 'c'; }//좌
                        }
                    }
                }
            }
            thread.Abort();
            Msg="미로 탐색 실패";
        }
        public void EscapeMaze_DFS()
        {
            // field 선언부
            LinkedStack list = new LinkedStack(); // 다음 분기점의 정보를 저장하는 스택
            LinkedStack stack = new LinkedStack(); //현재 분기점 정보를 담는 스택 

            stack.push(mirolist._mirolist[index].Entry); //미로의 입구를 찾기위한 함수 호출

            while (stack.isEmpty() == false) //탐색할 다음분기가 없을 때까지 반복하는 반복문
            {
                Mazefile = mirolist._mirolist[index].Print();
               Thread.Sleep(90);
                Node here = stack.pop(); //좌표  이동
                int row = here.row;
                int col = here.col;

                // 미로의 출구를 탐색했다면 함수 탈출
                if (miro[row][col] == 'x')
                {
                    miro[row][col] = 'q';
                    Mazefile = mirolist._mirolist[index].Print();
                    Msg = "성공!!!!!";
                    return;
                }

                //현재위치가 출구가 아니라면 다음좌표 탐색
                else
                {
                    if (miro[row][col] != 'e') miro[row][col] = '.'; //지나온 자리를 표시한다
                    Thread.Sleep(1);

                    //탐색할 수 있는 여러갈래가 없고 한 분기만 있다면 스택에 추가하여 탐색
                    if (isValidLocOnly(row, col))
                    {
                        if (isValidLoc(row - 1, col)) stack.push(new Node(row - 1, col));//상
                        else if (isValidLoc(row, col + 1)) stack.push(new Node(row, col + 1));//우
                        else if (isValidLoc(row + 1, col)) stack.push(new Node(row + 1, col));//하
                        else if (isValidLoc(row, col - 1)) stack.push(new Node(row, col - 1));//좌
                    }

                    //여러개의 분기를 만나면 스택에 추가하여 탐색
                    else
                    {
                        if (isValidLoc(row - 1, col)) { stack.push(new Node(row - 1, col)); if (miro[row - 1][col] != 'x') miro[row - 1][col] = 'c'; }//상 부터 시계방향으로 탐색
                        if (isValidLoc(row, col + 1)) { stack.push(new Node(row, col + 1)); if (miro[row][col + 1] != 'x') miro[row][col + 1] = 'c'; }//우
                        if (isValidLoc(row + 1, col)) { stack.push(new Node(row + 1, col)); if (miro[row + 1][col] != 'x') miro[row + 1][col] = 'c'; }//하
                        if (isValidLoc(row, col - 1)) { stack.push(new Node(row, col - 1)); if (miro[row][col - 1] != 'x') miro[row][col - 1] = 'c'; }//좌
                    }
                }
            }
            thread.Abort();
            Msg = "미로 탐색 실패";
        }
    }
}

