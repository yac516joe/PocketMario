using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;

namespace imagecombine{
    public partial class MainWindow : Window
    {
        public DispatcherTimer complete, broken, circle_bomb, digger, long_bomb, monster, spring, leave;//new


        int[] id = new int[]{80,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,
                            3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,
                            4,4,4,4,4,4,4,4,4,4,4,4,4,
                            6,6,6,6,6,6,6,6,
                            7,7,7,7,7,7,7,
                            8,8,8,8,8,8,
                            9,9,9,
                            10,10,
                            12,12,
                            13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,
                            17,17
                            };
        int cat_status;
        public Point point;//new
        public int coordinate_x, coordinate_y;//new
        int digger_count = 1;//new
        int circle_bomb_count = 1;//new
        int long_bomb_count = 1;//new
        int monster_count = 1;//new
        int spring_count = 1;//new
        int leave_count = 1;//new
        Random rd = new Random();//new
        int slide = 1;//dead if slide
        int deadtool = 0;
        int down_or_up=0;
        int turn_a = 0;

        DispatcherTimer down, isgameover, time,win_bg;
        Image[,] ay = new Image[6, 2048];
        int time_int=0;
        int[,] color = new int[6, 2048];
        int[,] path = new int[192, 2];
        int pathlengh = 0;
        int top_j = 0;
        Point position = new Point { X = 50, Y = 50 };
        int current = 0;
        int block = 0;
        int main_i = 2;
        int main_j = 0;
        int[,] maze = new int[6, 24];
        int[,] originmaz = new int[6, 24];
        Button begin;
        int create = 0;
        int underplay = 1;
        int hoe = 50;
        int first_click = 1;
        int is_win = 0;
        Image hoeimg,hundredimg,tenimg, oneimg,background;
        Image s_hun, s_ten, s_one, s_bg;
        int speed1 = 1,speed2 = 3,speed=3;
        int b_speed1 = 60, b_speed2 = 20,b_speed=20;
        MediaPlayer bgm,end,win;
        MediaPlayer mine, openbox, grow, digg, heal, bomb, jump;
        int winscore = 50;
        int hold = 118;
        int no_gravity = 0;

        public MainWindow()
        {
            bgm = new MediaPlayer();
            end = new MediaPlayer();
            win = new MediaPlayer();
            bgm.Open(new Uri("bgn.wmv", UriKind.Relative));
            end.Open(new Uri("normal_end.wmv", UriKind.Relative));
            win.Open(new Uri("good_end.wmv", UriKind.Relative));
            
            complete = new DispatcherTimer();//new
            broken = new DispatcherTimer();//new
            circle_bomb = new DispatcherTimer();//new
            long_bomb = new DispatcherTimer();//new
            digger = new DispatcherTimer();//new
            monster = new DispatcherTimer();//new
            spring = new DispatcherTimer();//new
            leave = new DispatcherTimer();//new

            complete.Interval = TimeSpan.FromMilliseconds(50);//new
            broken.Interval = TimeSpan.FromMilliseconds(50);//new
            circle_bomb.Interval = TimeSpan.FromMilliseconds(100);//new
            digger.Interval = TimeSpan.FromMilliseconds(50);//new
            long_bomb.Interval = TimeSpan.FromMilliseconds(50);//new
            monster.Interval = TimeSpan.FromMilliseconds(50);//new
            spring.Interval = TimeSpan.FromMilliseconds(50);//new
            leave.Interval = TimeSpan.FromMilliseconds(100);//new

            complete.Tick += complete_tick;//new
            broken.Tick += broken_tick;//new
            circle_bomb.Tick += circle_bomb_tick;//new
            long_bomb.Tick += long_bomb_tick;//new
            digger.Tick += digger_tick;//new
            monster.Tick += monster_tick;//new
            spring.Tick += spring_tick;//new
            leave.Tick += leave_tick;//new


            InitializeComponent();
          
            mine= new MediaPlayer();
            openbox = new MediaPlayer();
            grow = new MediaPlayer();
            digg =new MediaPlayer();
            heal =new MediaPlayer();
            bomb =new MediaPlayer();
            jump =new MediaPlayer();
            mine.Open(new Uri("mine.wmv", UriKind.Relative));
            openbox.Open(new Uri("open.wmv", UriKind.Relative));
            grow.Open(new Uri("grow.wmv", UriKind.Relative));
            digg.Open(new Uri("digg.wmv", UriKind.Relative));
            heal.Open(new Uri("heal.wmv", UriKind.Relative));
            bomb.Open(new Uri("bomb.wmv", UriKind.Relative));
            jump.Open(new Uri("jump.wmv", UriKind.Relative)); 

            down = new DispatcherTimer();
            isgameover = new DispatcherTimer();
            time = new DispatcherTimer();
            win_bg = new DispatcherTimer();
            begin = new Button();
            begin.Content = "開始遊戲";
            begin.Width = 60;
            begin.Height = 60;
            begin.Margin = new Thickness(150, 360, 0, 0);
            begin.Click += begin_click;
            time.Interval = TimeSpan.FromSeconds(1);
            isgameover.Interval = TimeSpan.FromSeconds(0.01);
            down.Interval = TimeSpan.FromSeconds(0.01);
            isgameover.Tick += check_position;
            time.Tick += timecount;
            down.Tick += move;
            win_bg.Interval = TimeSpan.FromSeconds(0.1);
            win_bg.Tick += winbg_change;
            win_bg.Start();
            down.Start();
            begin.Opacity = 0;
            background = new Image
            {
                Width = 360,
                Height = 12150,
                Margin = new Thickness(0, 0, 0, 0),
                Source = new BitmapImage(new Uri("star.png", UriKind.Relative))
            };
            cv.Children.Add(background);
            cv.Children.Add(begin);
            f_score.Opacity = 0;
            f_time.Opacity = 0;
            cv2.Margin = new Thickness(0, -50, 0, 0);
            cv3.Margin = new Thickness(-75, 0, 0, 0);
            cat_status = 0;
        }

        private void winbg_change(object sender, EventArgs e)
        {
            if (is_win > 0)
            {
                switch (is_win)
                {
                    case 2:
                        background.Source = new BitmapImage(new Uri("win-2.png", UriKind.Relative));
                        break;
                    case 15:
                        background.Source = new BitmapImage(new Uri("win-3.png", UriKind.Relative));
                        break;
                    case 30:
                        background.Source = new BitmapImage(new Uri("win-4.png", UriKind.Relative));
                        break;
                    case 35:
                        background.Source = new BitmapImage(new Uri("win-5.png", UriKind.Relative));
                        break;
                    case 40:
                        background.Source = new BitmapImage(new Uri("win-6.png", UriKind.Relative));
                        break;
                    case 45:
                        background.Source = new BitmapImage(new Uri("win-7.png", UriKind.Relative));
                        break;
                    case 50:
                        background.Source = new BitmapImage(new Uri("win-8.png", UriKind.Relative));
                        break;
                    case 55:
                        background.Source = new BitmapImage(new Uri("win-9.png", UriKind.Relative));
                        break;
                }
                is_win++;
            }
        }

        private void timecount(object sender, EventArgs e)
        {
            time_int++;
        }

        private void begin_click(object sender, EventArgs e)
        {
            underplay = 1;
            begin.Content = "開始嚕~";
            f_score.Opacity = 0;
            f_time.Opacity = 0;
//            bgm.Play();
            end.Stop();
            win.Stop();
            background.Source = new BitmapImage(new Uri("star.png", UriKind.Relative));
            background.Height = 12150;
        }

        private void check_position(object sender, EventArgs e)
        {
            detect();
            if (hoe <= 0)
                cat_status = 1;
            cat_change(main_i,main_j);
            double top = ay[main_i, main_j].Margin.Top;
            if ((top < 0||is_win>0 || slide == 0 || deadtool == 1 ||turn_a ==1) && underplay == 1){
                background.Height = 720;

                if (is_win<=0) {
                    background.Margin = new Thickness(0, 0, 0, 0);
                    f_score.Opacity = 100;
                    f_time.Opacity = 100;
                    background.Source = new BitmapImage(new Uri("over.png", UriKind.Relative));
                    end.Play();
                }
                else
                {
                    background.Margin = new Thickness(0, 0, 0, 0);
                    background.Source = new BitmapImage(new Uri("win-1.png", UriKind.Relative));
                    is_win++;
                    cv.Children.Remove(begin);
                    win.Play();
                }
                gameover();
            }
        }

        private void gameover()
        {
            turn_a = 0;
            underplay = 0;
            no_gravity = 0;
            winscore = 50;
            bgm.Stop();
            cat_status = 0;
            begin.Content = "重新開始";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < current; j++)
                {
                    cv.Children.Remove(ay[i, j]);
                }
            }
            time.Stop();
            down_or_up = 0;
            time_int = 0;
            cv2.Children.Remove(hoeimg);
            cv2.Children.Remove(hundredimg);
            cv2.Children.Remove(tenimg);
            cv2.Children.Remove(oneimg);
            cv3.Children.Remove(s_bg);
            cv3.Children.Remove(s_hun);
            cv3.Children.Remove(s_ten);
            cv3.Children.Remove(s_one);
            create = 0;
            pathlengh = 0;
            top_j = 0;
            current = 0;
            block = 0;
            main_i = 2;
            main_j = 0;
            hoe = 50;
            b_speed = b_speed2;
            speed = speed2;
            first_click = 1;
            ay[2, 0].Margin = new Thickness(0, 0, 0, 0);
            cv2.Margin = new Thickness(0, -50, 0, 0);
            cv3.Margin = new Thickness(-75, 0, 0, 0);
            spring_count = 1;
            deadtool = 0;
        }

        private void cat_change(int i,int j){
            switch(cat_status){
                case 0:
                    ay[i, j].Source = new BitmapImage(new Uri("cat.png", UriKind.Relative));
                    break;
                case 1:
                    ay[i, j].Source = new BitmapImage(new Uri("cat2.png", UriKind.Relative));
                    break;
                case 2:
                    ay[i, j].Source = new BitmapImage(new Uri("strong_cat.png", UriKind.Relative));
                    break;
            }
        }

        private void move(object sender, EventArgs e)
        {
            int i,j;
            if (underplay == 1&&first_click ==1)
            {
                if (create == hold)
                    first_click = 0;
                fall();
                if (create % b_speed == 0)
                {
                    produce();
                }
                else
                {
                    for (j = 0; j < 6; j++)
                    {
                        for (i = block; i < current; i++)
                        {
                            double left = ay[j, i].Margin.Left;
                            double top = ay[j, i].Margin.Top;
                            ay[j, i].Margin = new Thickness(left, top -= speed, 0, 0);
                            if (top < 60 && i > top_j)
                                top_j = i;
                        }
                    }
                    double c_top = cv2.Margin.Top;
                    double s_left = cv3.Margin.Left;
                    if (create < 50)
                    {
                        cv2.Margin = new Thickness(0, c_top+=1, 0, 0);
                        cv3.Margin = new Thickness(s_left+=1.5,0, 0, 0);
                    }
                    double b_left = background.Margin.Left;
                    double b_top = background.Margin.Top;
                    if (create > hold)
                    {
                        background.Margin = new Thickness(b_left, b_top -= 1, 0, 0);
                        speed = speed1;
                        b_speed = b_speed1;
                    }
                    hoeimg.Source = new BitmapImage(new Uri("tool.png", UriKind.Relative));
                    change((hoe / 100) % 10, hundredimg,1);
                    change((hoe / 10) % 10, tenimg,1);
                    change(hoe % 10, oneimg,1);
                    s_bg.Source = new BitmapImage(new Uri("score.png", UriKind.Relative));
                    if (current < 6)
                    {
                        change(0, s_hun, 0);
                        change(0, s_ten, 1);
                        change(0, s_one, 1);
                    }
                    else
                    {
                        change(((current - 6) / 100) % 10, s_hun, 0);
                        change(((current - 6) / 10) % 10, s_ten, 1);
                        change((current - 6) % 10, s_one, 1);
                    }
                }
                create++;
                f_score.Content = (current - 6).ToString();
                f_time.Content = time_int.ToString();
            }
        }
        private void change(int num, Image img , int locate)
        {
            switch(num){
                case 0:
                    if(locate ==0)
                        img.Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    else
                        img.Source = new BitmapImage(new Uri("0.png", UriKind.Relative));
                    break;
                case 1:
                    img.Source = new BitmapImage(new Uri("1.png", UriKind.Relative));
                    break;
                case 2:
                    img.Source = new BitmapImage(new Uri("2.png", UriKind.Relative));
                    break;
                case 3:
                    img.Source = new BitmapImage(new Uri("3.png", UriKind.Relative));
                    break;
                case 4:
                    img.Source = new BitmapImage(new Uri("4.png", UriKind.Relative));
                    break;
                case 5:
                    img.Source = new BitmapImage(new Uri("5.png", UriKind.Relative));
                    break;
                case 6:
                    img.Source = new BitmapImage(new Uri("6.png", UriKind.Relative));
                    break;
                case 7:
                    img.Source = new BitmapImage(new Uri("7.png", UriKind.Relative));
                    break;
                case 8:
                    img.Source = new BitmapImage(new Uri("8.png", UriKind.Relative));
                    break;
                case 9:
                    img.Source = new BitmapImage(new Uri("9.png", UriKind.Relative));
                    break;
            }
        }

        private void produce()
        {
            isgameover.Start();
            int i;
            for (i = 0; i < 6; i++)
            {
                if (current == 0)
                {
                    bgm.Play();

                    if (i == 2) 
                    {
                        ay[i, current] = new Image
                        {
                            Width = 60,
                            Height = 60,
                            Margin = new Thickness(i * 60, 780, 0, 0),
                            Source = new BitmapImage(new Uri("cat.png", UriKind.Relative))
                        };
                    }
                    else
                    {
                        ay[i, current] = new Image
                        {
                            Width = 60,
                            Height = 60,
                            Margin = new Thickness(i * 60, 780, 0, 0),
                            Source = new BitmapImage(new Uri("empty.png", UriKind.Relative))
                        };
                    }
                    color[i, current] = 0;

                    /*
                      below is the tool image
                     
                     */
                    hoeimg = new Image
                    {
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(-45, -20, 0, 0),
                    };
                    cv2.Children.Add(hoeimg);
                    hundredimg = new Image
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(45, 10, 0, 0),
                    };
                    cv2.Children.Add(hundredimg);
                    tenimg = new Image
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(85, 10, 0, 0),
                    };
                    cv2.Children.Add(tenimg);
                    oneimg = new Image
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(125, 10, 0, 0),
                    };
                    cv2.Children.Add(oneimg);
                    /*
                      below is the score image
                     
                     */
                    s_bg = new Image
                    {
                        Width = 400,
                        Height = 100,
                        Margin = new Thickness(-130, 0, 0, 0),
                    };
                    cv3.Children.Add(s_bg);
                    s_hun = new Image
                    {
                        Width = 30,
                        Height = 30,
                        Margin = new Thickness(-15, 30, 0, 0),
                    };
                    cv3.Children.Add(s_hun);
                    s_ten = new Image
                    {
                        Width = 30,
                        Height = 30,
                        Margin = new Thickness(7, 30, 0, 0),
                    };
                    cv3.Children.Add(s_ten);
                    s_one = new Image
                    {
                        Width = 30,
                        Height = 30,
                        Margin = new Thickness(29, 30, 0, 0),
                    };
                    cv3.Children.Add(s_one);


                }
                else if (current > winscore && current < winscore+5)
                {
                    if (current == winscore+4&&i == 3)
                    {
                        ay[i, current] = new Image
                        {
                            Width = 60,
                            Height = 60,
                            Margin = new Thickness(i * 60, 780, 0, 0),
                            Source = new BitmapImage(new Uri("priencess.png", UriKind.Relative))
                        };
                        color[i, current] = 999;
                    }
                    else
                    {
                        ay[i, current] = new Image
                        {
                            Width = 60,
                            Height = 60,
                            Margin = new Thickness(i * 60, 780, 0, 0),
                            Source = new BitmapImage(new Uri("empty.png", UriKind.Relative))
                        };
                        color[i, current] = 0;
                    }
                }
                else
                {
                    int random = rd.Next(0,213);
                    ay[i, current] = new Image
                    {
                        Width = 60,
                        Height = 60,
                        Margin = new Thickness(i * 60, 780, 0, 0),
                        Source = new BitmapImage(new Uri("black.png", UriKind.Relative))
                    };
                    color[i, current] = id[random];
                    if (color[i, current] == -1)
                    {
                        ay[i, current].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    }
                    if (current == 1)
                    {
                        showimage(color[i, current], i, current);
                    }
                   // showimage(color[i, current], i, current);
                }
                cv.Children.Add(ay[i, current]);
            }
            current++;
            if (current % 24 == 0 && current > 24)
                block += 24;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(cv);
            int i, j;
            if (underplay == 1&& create>hold - 1 && down_or_up == 0)
            {
                first_click = 1;
                time.Start();
                for (i = 0; i < 6; i++)
                {
                    for (j = top_j; j < current; j++)
                    {
                        double left = ay[i, j].Margin.Left;
                        double top = ay[i, j].Margin.Top;
                        if (point.X > left && point.X < (left + 60) && point.Y > top && point.Y < (top + 60))
                        {
                            coordinate_x = i;
                            coordinate_y = j;
                            if (color[i, j] == 999)
                            {
                                is_win = 1;
                            }
                            else if (color[i, j] != 0 && air(i, j) && hoe > 0)
                            {
                                hoe--;
                             // ay[i, j].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                                int temid = color[i, j];
                                color[i, j] = 0;
                                movetofront(i, j);
                                color[i, j] = temid;
                                playsound(color[i, j]);
                                dig(color[i, j],i,j);

                            }
                            else
                            {
                                moveto(i, j);
                            }
                            fall();
                            detect();
                        }
                    }
                }
               
            }

        }

        private void fall()
        {
            if ((current-main_j) > 1 && no_gravity == 0)
            {
                if (color[main_i, main_j + 1] == 999)
                {
                    is_win = 1;
                }
                while (color[main_i, main_j + 1] == 0 || color[main_i, main_j + 1] == -1)
                {
                    ay[main_i, main_j].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    cat_change(main_i, main_j + 1);
                    color[main_i, main_j + 1] = 0; 
                    main_j++;
                    if (main_j + 1 >= current)
                        break;
                }
            }
        }

        private void movetofront(int ti, int tj)
        {
            for (int i = 0; i < 192; i++)
            {
                path[i, 0] = 0;
                path[i, 1] = 0;
            }
            pathlengh = 0;
            if (main_i != ti || main_j != tj)
            {
                copymaze();
                if (findpath(main_i, main_j - top_j, ti, tj - top_j))
                {
                    for (int i = pathlengh - 1; i >= 0; i--)
                    {
                        if (path[i + 1, 1] > path[i, 1])
                            ay[path[i, 0], path[i, 1]].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                        else
                            ay[path[i, 0], path[i, 1]].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    }
                    main_i = path[1, 0];
                    main_j = path[1, 1];
                    color[main_i, main_j] = 0;
                    cat_change(main_i,main_j);
                }
            }
        }

        private void moveto(int ti, int tj)
        {
            for (int i = 0; i < 192; i++)
            {
                path[i, 0] = 0;
                path[i, 1] = 0;
            }
            pathlengh = 0;
            if (main_i != ti || main_j != tj)
            {
                copymaze();
                if (findpath(main_i, main_j - top_j, ti, tj - top_j))
                {
                    for (int i = pathlengh - 1; i >= 0; i--)
                    {
                        if (path[i + 1, 1] > path[i, 1])
                            ay[path[i, 0], path[i, 1]].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                        else
                            ay[path[i, 0], path[i, 1]].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    }
                    color[ti, tj] = 0;
                    main_i = ti;
                    main_j = tj;
                    cat_change(ti, tj);
                   
                }
            }
        }

        private void copymaze()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < current-top_j; j++)
                {
                    maze[i, j] = color[i,j+top_j];
                    originmaz[i, j] = color[i,j+top_j];
                }
            }
        }

        private Boolean findpath(int oi, int oj, int target_i, int target_j)
        {
            maze[oi, oj] = 1;
            if (oi == target_i && oj == target_j)
            {
                path[pathlengh, 0] = oi;
                path[pathlengh, 1] = oj + top_j;
                pathlengh++;
                return true;
            }
            else if (oj + 1 < (current-top_j) && maze[oi, oj + 1] == 0 && findpath(oi, oj + 1, target_i, target_j))
            {
                path[pathlengh, 0] = oi;
                path[pathlengh, 1] = oj + top_j;
                pathlengh++;
                return true;
            }
            else if (oi - 1 >= 0 && maze[oi - 1, oj] == 0 && findpath(oi - 1, oj, target_i, target_j))
            {
                path[pathlengh, 0] = oi;
                path[pathlengh, 1] = oj + top_j;
                pathlengh++;
                return true;
            }
            else if (oi + 1 < 6 && maze[oi + 1, oj] == 0 && findpath(oi + 1, oj, target_i, target_j))
            {
                path[pathlengh, 0] = oi;
                path[pathlengh, 1] = oj + top_j;
                pathlengh++;
                return true;
            }
            else if (oj - 1 >= 0 && maze[oi, oj - 1] == 0 && findpath(oi, oj - 1, target_i, target_j))
            {
                path[pathlengh, 0] = oi;
                path[pathlengh, 1] = oj + top_j;
                pathlengh++;
                return true;
            }
            else
            {
                maze[oi, oj] = originmaz[oi, oj];
                return false;
            }
        }
        private void showimage(int id, int px, int py)
        {
            switch (id)
            {
                case 2:
                    ay[px, py].Source = new BitmapImage(new Uri("mud.png", UriKind.Relative));
                    break;
                case 3:
                    ay[px, py].Source = new BitmapImage(new Uri("stone.png", UriKind.Relative));
                    break;
                case 4:
                    ay[px, py].Source = new BitmapImage(new Uri("coal.png", UriKind.Relative));
                    break;
                case 6:
                    ay[px, py].Source = new BitmapImage(new Uri("silver.png", UriKind.Relative));
                    break;
                case 7:
                    ay[px, py].Source = new BitmapImage(new Uri("gold.png", UriKind.Relative));
                    break;
                case 8:
                    ay[px, py].Source = new BitmapImage(new Uri("diamond.png", UriKind.Relative));
                    break;
                case 9:
                    ay[px, py].Source = new BitmapImage(new Uri("mushroom.png", UriKind.Relative));
                    break;
                case 10:
                    ay[px, py].Source = new BitmapImage(new Uri("digger.png", UriKind.Relative));
                    break;
                case 11:
                    ay[px, py].Source = new BitmapImage(new Uri("long_bomb.png", UriKind.Relative));
                    break;
                case 12:
                    ay[px, py].Source = new BitmapImage(new Uri("heal.png", UriKind.Relative));
                    break;
                case 13:
                    ay[px, py].Source = new BitmapImage(new Uri("bomb.png", UriKind.Relative));
                    break;
                case 14:
                    ay[px, py].Source = new BitmapImage(new Uri("monster.png", UriKind.Relative));
                    break;
                case 17:
                    ay[px, py].Source = new BitmapImage(new Uri("spring.png", UriKind.Relative));
                    break;
                case 18:
                    ay[px, py].Source = new BitmapImage(new Uri("leave.png", UriKind.Relative));
                    break;
                case 80:
                    ay[px, py].Source = new BitmapImage(new Uri("turn_A.png", UriKind.Relative));
                    break;

            }
        }

        private Boolean air(int i, int j)
        {
            if (i == 0 && j == top_j)
            {
                if (color[i + 1, j] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
            else if (i == 5 && j == top_j)
            {
                if (color[i-1, j] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
            else if (j == top_j)
            {
                if (color[i + 1, j]==0 ||color[i - 1, j] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
            else if (i == 0)
            {
                if (color[i + 1, j] == 0 || color[i, j-1] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
            else if (i == 5)
            {
                if (color[i - 1, j] == 0 || color[i, j - 1] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (color[i - 1, j] == 0 || color[i + 1, j] == 0 || color[i, j - 1] == 0 || color[i, j + 1] == 0)
                    return true;
                else
                    return false;
            }
        }
        public void complete_tick(object sender, EventArgs e)//new
        {
            complete.Stop();
            color[coordinate_x, coordinate_y] = 0;
           ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
        }
        private void broken_tick(object sender, EventArgs e)//new
        {
            broken.Stop();
            color[coordinate_x, coordinate_y] = 0;
           ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
        }
        private void circle_bomb_tick(object sender, EventArgs e)//new
        {
            if (circle_bomb_count == 1)
            {
                color[coordinate_x, coordinate_y] = 0;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("smoke_center.png", UriKind.Relative));
                circle_bomb_count++;

            }
            else if (circle_bomb_count == 2)
            {
                if (coordinate_x - 1 >= 0)
                {

                    ay[coordinate_x - 1, coordinate_y - 1].Source = new BitmapImage(new Uri("smoke1.png", UriKind.Relative));
                    ay[coordinate_x - 1, coordinate_y].Source = new BitmapImage(new Uri("smoke4.png", UriKind.Relative));
                    ay[coordinate_x - 1, coordinate_y + 1].Source = new BitmapImage(new Uri("smoke7.png", UriKind.Relative));

                    color[coordinate_x - 1, coordinate_y - 1] = 0;
                    color[coordinate_x - 1, coordinate_y] = 0;
                    color[coordinate_x - 1, coordinate_y + 1] = 0;

                }
                ay[coordinate_x, coordinate_y - 1].Source = new BitmapImage(new Uri("smoke2.png", UriKind.Relative));
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("smoke5.png", UriKind.Relative));
                ay[coordinate_x, coordinate_y + 1].Source = new BitmapImage(new Uri("smoke8.png", UriKind.Relative));

                color[coordinate_x, coordinate_y + 1] = 0;
                color[coordinate_x, coordinate_y - 1] = 0;

                if (coordinate_x + 1 <= 5)
                {
                    ay[coordinate_x + 1, coordinate_y - 1].Source = new BitmapImage(new Uri("smoke3.png", UriKind.Relative));
                    ay[coordinate_x + 1, coordinate_y].Source = new BitmapImage(new Uri("smoke6.png", UriKind.Relative));
                    ay[coordinate_x + 1, coordinate_y + 1].Source = new BitmapImage(new Uri("smoke9.png", UriKind.Relative));

                    color[coordinate_x + 1, coordinate_y - 1] = 0;
                    color[coordinate_x + 1, coordinate_y] = 0;
                    color[coordinate_x + 1, coordinate_y + 1] = 0;



                }
                circle_bomb_count++;


            }
            else if (circle_bomb_count == 3)
            {
                if (coordinate_x - 1 >= 0)
                {
                    ay[coordinate_x - 1, coordinate_y - 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    ay[coordinate_x - 1, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    ay[coordinate_x - 1, coordinate_y + 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));

                }


                ay[coordinate_x, coordinate_y - 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                ay[coordinate_x, coordinate_y + 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));

                if (coordinate_x + 1 <= 5)
                {
                    ay[coordinate_x + 1, coordinate_y - 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    ay[coordinate_x + 1, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    ay[coordinate_x + 1, coordinate_y + 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));

                }


                circle_bomb.Stop();
                circle_bomb_count = 1;

            }
        }
        private void digger_tick(object sender, EventArgs e)//new
        {
            if (digger_count < 5)
            {
                if (coordinate_y + 2 > current)
                {
                    for (int j = digger_count; j < 5; j++)
                        color[coordinate_x, j] = -1;
                }
                else
                {
                    color[coordinate_x, coordinate_y] = 0;
                    ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    ay[coordinate_x, coordinate_y + 1].Source = new BitmapImage(new Uri("digging.png", UriKind.Relative));
                    coordinate_y++;
                    detect();
                    digger_count++;
                }
            }
            else
            {
                detect();
                digger.Stop();
                digger_count = 1;
            }

        }
        private void long_bomb_tick(object sender, EventArgs e)//new
        {
            if (long_bomb_count == 1)
            {
                color[coordinate_x, coordinate_y] = 0;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                long_bomb_count++;
                detect();

            }
            else if (long_bomb_count == 2)
            {
                if (coordinate_x + 1 < 6)
                {
                    color[coordinate_x + 1, coordinate_y] = 0;
                    ay[coordinate_x + 1, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                if (coordinate_x - 1 >= 0)
                {
                    color[coordinate_x - 1, coordinate_y] = 0;
                    ay[coordinate_x - 1, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                long_bomb_count++;
                detect();

            }
            else if (long_bomb_count == 3)
            {
                if (coordinate_x + 2 <= 5)
                {
                    color[coordinate_x + 2, coordinate_y] = 0;
                    ay[coordinate_x + 2, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                if (coordinate_x - 2 >= 0)
                {
                    color[coordinate_x - 2, coordinate_y] = 0;
                    ay[coordinate_x - 2, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                long_bomb_count++;
                detect();

            }
            else if (long_bomb_count == 4)
            {
                if (coordinate_x + 3 <= 5)
                {
                    color[coordinate_x + 3, coordinate_y] = 0;
                    ay[coordinate_x + 3, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                if (coordinate_x - 3 >= 0)
                {
                    color[coordinate_x - 3, coordinate_y] = 0;
                    ay[coordinate_x - 3, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                }
                detect();
                digger.Stop();
                long_bomb_count = 1;
            }
        }
        private void monster_tick(object sender, EventArgs e)//new
        {
            switch (monster_count)
            {
                case 1:
                    //主角變成沒有十字搞
                    //十字搞在[+1,-1]
                    monster_count++;
                    color[coordinate_x, coordinate_y] = 0;
                    ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    break;
                case 2:
                    //十字搞在[+2,-1]
                    monster_count++;
                    color[coordinate_x, coordinate_y] = 0;
                    ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    break;
                case 3:
                    //十字搞在[+3,0]
                    monster_count = 1;
                    color[coordinate_x, coordinate_y] = 0;
                    ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    monster.Stop();
                    break;

            }
        }
        private void spring_tick(object sender, EventArgs e)//new
        {
            down_or_up = 1;
            no_gravity = 1;
            if (main_j > top_j)
            {
                color[main_i, main_j] = 0;
                ay[main_i, main_j].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                main_j--;
                cat_change(main_i, main_j);
                spring_count++;
            }
            else
            {
                deadtool = 1;
                spring.Stop();
            }
            
        }
        private void leave_tick(object sender, EventArgs e)//new
        {
            down_or_up = 1;
            if (main_j < current - 1)
            {
                if(leave_count == 1){
                    cat_status = 2;
                    cat_change(main_i, main_j);
                }
                else{
                    color[main_i, main_j + 1] = 0;
                    ay[main_i, main_j + 1].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                    fall();
                }
                leave_count++;
            }
            else {
                deadtool = 1;
                leave.Stop();
            }
            
        }
        private void playsound(int id){
            if (id == 3 || id == 4 || id == 6 || id == 56 || id == 7 || id == 8 || id == 58)
            {
                soundstop();
                mine.Play();
            }
            else if (id == 9)
            {
                soundstop();
                openbox.Play();
            }
            else if (id == 59)
            {
                soundstop();
                grow.Play();
            }
            else if (id == 10)
            {
                soundstop();
                digg.Play();
            }
            else if (id == 12)
            {
                soundstop();
                heal.Play();
            }
            else if (id == 13)
            {
                soundstop();
                bomb.Play();
            }
            else if (id == 17)
            {
                soundstop();
                jump.Play();
            }
        }

        private void soundstop()
        {
            mine.Stop();
            openbox.Stop();
            grow.Stop();
            digg.Stop();
            heal.Stop();
            bomb.Stop();
            jump.Stop();
        }


        private void detect()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = top_j; j < current - 1 ; j++)
                {
                    if (air(i, j))
                    {
                        showimage(color[i, j], i, j);
                    }
                }
            }
        }
        public bool dig(int id ,int ti, int tj)/*參數為該磚塊的id*///new
        {

            if (id == 2)/*如果是泥土*/
            {
                complete.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                return true;
            }
            else if (id == 3)/*如果是岩石*/
            {
                color[coordinate_x, coordinate_y] = 53;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("broken_stone.png", UriKind.Relative));
                return true;
            }
            else if (id == 53)/*如果是破裂的岩石*/
            {
                broken.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("fragment.png", UriKind.Relative));
                return true;
            }
            else if (id == 4)/*如果是煤礦*/
            {
                complete.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("fragment.png", UriKind.Relative));
                return true;
            }
            else if (id == 5)/*如果是鐵礦*/
            {
                color[coordinate_x, coordinate_y] = 55;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("broken_iron.png", UriKind.Relative));
                return true;
            }
            else if (id == 55)/*如果是破裂的鐵礦*/
            {
                broken.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("fragment.png", UriKind.Relative));
                return true;
            }
            else if (id == 6)/*如果是銀礦*/
            {
                color[coordinate_x, coordinate_y] = 56;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("broken_silver.png", UriKind.Relative));
                return true;
            }
            else if (id == 56)/*如果是破裂的銀礦*/
            {
                broken.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("piece_silver.png", UriKind.Relative));
                return true;
            }
            else if (id == 7)/*如果是金礦*/
            {
                complete.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("piece_gold.png", UriKind.Relative));
                return true;
            }
            else if (id == 8)/*如果是鑽石礦*/
            {
                color[coordinate_x, coordinate_y] = 58;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("broken_diamond.png", UriKind.Relative));
                return true;
            }
            else if (id == 58)/*如果是破裂的鑽石礦*/
            {
                broken.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("piece_diamond.png", UriKind.Relative));
                return true;
            }
            else if (id == 9)/*如果是蘑菇礦*/
            {
                color[coordinate_x, coordinate_y] = 59;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("broken_mushroom.png", UriKind.Relative));
                return true;
            }
            else if (id == 59)/*如果是破裂的蘑菇礦*/
            {
                cat_status = 2;
                cat_change(main_i, main_j);
                ay[main_i, main_j].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                color[main_i, main_j] = 0;
                main_i = ti;
                main_j = tj;
               
                leave.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("fragment.png", UriKind.Relative));
                return false;
            }
            else if (id == 10)/*如果是鑽頭*/
            {
                digger.Start();
                return true;
            }
            else if (id == 80)/*如果是turnA*/
            {
                turn_a = 1;
                return true;
            }
            //else if (id == 11)/*如果是長型炸彈*/
         /* {
                long_bomb.Start();
                return true;
            }*/
            else if (id == 12)/*如果是醫藥箱*/
            {
                hoe += 3;
                color[coordinate_x, coordinate_y] = 0;
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                return true;
            }
            else if (id == 13)/*如果是圓形炸彈*/
            {
                circle_bomb.Start();
                return true;
            }
            else if (id == 63)/*如果是圓形炸彈*/
            {
                circle_bomb.Start();
                return false;
            }
            else if (id == 14)/*如果是搶十字搞的怪物*/
            {
                monster.Start();
                ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("monster.png", UriKind.Relative));
                return false;
            }
            //            else if (id == 15)/*如果是任意門*/
            /*           {
                            complete.Start();
                            clicked_block = "stone.png";
                            ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("white.png", UriKind.Relative));
                        }
            *///            else if (id == 16)/*如果是方向炸彈 */
            /*            {
                            complete.Start();
                            clicked_block = "direc_bomb.png";
                            ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("white.png", UriKind.Relative));
                        }*/ 
            else if (id == 17)/*如果是飛向天堂的彈簧*/
            {
                cat_change(ti, tj);
                ay[main_i, main_j].Source = new BitmapImage(new Uri("empty.png", UriKind.Relative));
                color[main_i, main_j] = 0;
                main_i = ti;
                main_j = tj;
                spring.Start();
                return false;
            }
            else if (id == 18)/*如果是滑出場外的通道*/
            {
                complete.Start();
                return false;
            }
            //            else if (id == 19)/*如果是反重力磚塊*/
            /*            {
                            complete.Start();
                            clicked_block = "anti_no_gravity.png";
                            ay[coordinate_x, coordinate_y].Source = new BitmapImage(new Uri("white.png", UriKind.Relative));
                            return false;
                        }*/
            else
            {
                return true;
            }
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (winscore > current + 5)
                winscore -= 5;
            else
                hoe += 5;
        }

    }
}
