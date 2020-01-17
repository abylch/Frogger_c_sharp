using System;
using System.Windows.Forms;

namespace Frogger
{
    class Program
    {
        //members for screen
        private static int widthScreen;
        private static int heightScreen;
        private static int miliSecPerFrame;
        private static int[] framePosX;
        private static int[] framePosY;
        private static int nextLevelY;
        private static int[] nextLevelX;

        // object that has info wich key is pressed
        private static ConsoleKeyInfo cki;
        private static char money='$';
        //members for apple(as digit)
        private static int moneyLocX;
        private static int moneyLocY;
        //counter
        private static int level = 1;
        private static int counter = 0;
        private static int score = 0;
        private static Random rnd;

        //difference in last location frog
        private static int dx;
        private static int dy;
        private static bool firstRun;

        //members for frog
        private static char[] frogChars = { '\0', (char)92, '"', '/', '/', '0', (char)92 };
        private static int[] frogLocationX;
        private static int[] frogLocationY;
        private static int life = 3;

        //members for tank
        private static char[] tankChars = { '\0', '#', '-', '<', '>' };
        private static int tx;
        private static int ty;
        private static int[] tankLocationX;
        private static int[] tankLocationY;
        private static int tankSize = 10;
        private static int t4x;
        private static int t4y;
        private static int[] tank2LocationX;
        private static int[] tank2LocationY;
        private static bool firstRunTank2;

        //members for truck
        private static char[] truckChars = { '\0', '-', '[', ']', 'o' };
        private static int t2x;
        private static int t2y;
        private static int[] truckLocationX;
        private static int[] truckLocationY;
        private static int truckSize = 10;
        private static bool firstRunTruck;
        private static int t5x;
        private static int t5y;
        private static int[] truck2LocationX;
        private static int[] truck2LocationY;
        private static bool firstRunTruck2;

        //members for train
        private static char[] trainChars = { '\0', '-', '[', ']', 'o' , '*' };
        private static int t3x;
        private static int t3y;
        private static int[] trainLocationX;
        private static int[] trainLocationY;
        private static int trainSize = 28;
        private static bool firstRunTrain;

        //members for water
        private static char[] waterChars = { '\0', '~' };
        private static int[] waterLocationX;
        private static int[] waterLocationY;

        //members for tree logs
        private static char[] treeLogChars = { '\0', '#',' ' };
        private static int[] treeLocationX;
        private static int[] treeLocationY;
        static bool treefirstRun;
        private static int treeSize = 21;
        private static int t6x;
        private static int t6y;

        //members for tree logs2
        private static int[] tree2LocationX;
        private static int[] tree2LocationY;
        static bool tree2firstRun;
        private static int tree2Size = 21;
        private static int t7x;
        private static int t7y;
        
        //members for tree logs3
        private static int[] tree3LocationX;
        private static int[] tree3LocationY;
        static bool tree3firstRun;
        private static int t8x;
        private static int t8y;
        private static int tree3Size = 21;

        static void InitGame()
        {
            rnd = new Random();
            
            miliSecPerFrame = 75;
            
            frogLocationX = new int[widthScreen * (heightScreen-1)];
            frogLocationY = new int[widthScreen * (heightScreen-1)];
            tankLocationX = new int[widthScreen * (heightScreen/4 - 1)];
            tankLocationY = new int[widthScreen * (heightScreen/4 - 1)];
            truckLocationX = new int[widthScreen * (heightScreen/4 - 1)];
            truckLocationY = new int[widthScreen * (heightScreen/4 - 1)];
            trainLocationX = new int[widthScreen * (heightScreen/4 - 1)];
            trainLocationY = new int[widthScreen * (heightScreen/4 - 1)];
            tank2LocationX = new int[widthScreen * (heightScreen/4 - 1)];
            tank2LocationY = new int[widthScreen * (heightScreen/4 - 1)];
            truck2LocationX = new int[widthScreen * (heightScreen/4 - 1)];
            truck2LocationY = new int[widthScreen * (heightScreen/4 - 1)];
            waterLocationX = new int[(widthScreen) * (heightScreen - 1)];
            waterLocationY = new int[(widthScreen) * (heightScreen - 1)];
            treeLocationX = new int[(widthScreen) * (heightScreen/4 - 1)];
            treeLocationY = new int[(widthScreen) * (heightScreen/4 - 1)];
            tree3LocationX = new int[(widthScreen) * (heightScreen / 4 - 1)];
            tree3LocationY = new int[(widthScreen) * (heightScreen / 4 - 1)];
            tree2LocationX = new int[(widthScreen) * (heightScreen / 4 - 1)];
            tree2LocationY = new int[(widthScreen) * (heightScreen / 4 - 1)];
            firstRun = true;
            firstRunTruck = true;
            firstRunTank2 = true;
            firstRunTruck = true;
            treefirstRun = true;
            
        }

        static void water()
        {
            miliSecPerFrame = 75;

            int x = 0;
            int i;


            //water build
            for (i = 4; i <= heightScreen - 23; i++)
            {
                for (int j = 1; j <= widthScreen-1; j++)
                {
                        Console.SetCursorPosition(j, i);
                        Console.Write("~");
                        waterLocationX[x] = j;
                        waterLocationY[x] = i;
                        x++;
                }

            }
        }

        static void Main(string[] args)
        {
            frame();
            
            InitGame();
            water();
            
            InitFrog();
            InitTank();
            InitTruck();
            InitTrain();
            InitTank2();
            InitTruck2();
            InitTreeLog();
            InitTreeLog3();
            InitTreeLog2();

       
            
            move();
            Console.ReadKey();
            
        }



        static bool isFrog(int locX, int locY)
        {
            int i = 0;
            for (i = 0; i < 6; i++)
            {
                if (frogLocationX[i] == locX && frogLocationY[i] == locY)
                    return true;
            }
            return false;
        }

        static void PlaceMoney()
        {

            do
            {
                    moneyLocX = rnd.Next(1, widthScreen -1);
                    moneyLocY = rnd.Next(heightScreen - 9, heightScreen - 8);
            }
            while (isFrog(moneyLocX, moneyLocY));

            

             Console.SetCursorPosition(moneyLocX, moneyLocY); Console.Write(money);
          
            Console.SetCursorPosition(67-6, 0); Console.Write("SCORE:");
            Console.SetCursorPosition(67, 0); Console.Write(score);

        }
        // after arrow press and blank space, places the new spider
        static void move()
        {
            
            do
            {
                //frame();
                nextLevel();
                MoveTruck();
                MoveTank();
                MoveTrain();
                MoveTank2();
                MoveTank2();
                MoveTruck2();
                MoveTruck2();
                MoveTree();
                MoveTree3();
                //MoveTree3();
                MoveTree2();
                MoveTree2();

                //life
                if (life == 0)
                {
                   
                    DialogResult result = MessageBox.Show("you die, play again", "confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                   
                        life = 3;
                        score = 0;
                        level = 1;

                        Console.SetCursorPosition(70, 0); Console.Write('\0');
                        Console.SetCursorPosition(69, 0); Console.Write('\0');
                        Console.SetCursorPosition(68, 0); Console.Write('\0');
                        Console.SetCursorPosition(67, 0); Console.Write('\0');
                        Console.SetCursorPosition(67, 0); Console.Write(score);
                        Console.SetCursorPosition(6, 0); Console.Write('\0');
                        Console.SetCursorPosition(7, 0); Console.Write('\0');
                        Console.SetCursorPosition(5, 0); Console.Write('\0');
                        Console.SetCursorPosition(5, 0); Console.Write(life);
                    }
                    else
                    { 
                        Console.SetCursorPosition(widthScreen / 2, heightScreen / 2);
                        Console.Write("YOU ARE DEATH!!!!!!");
                        break;
                    }
                }

                //position
                KeyRead();


                //new position 
                //down
                frogLocationX[0] = dx; frogLocationX[1] = dx + 1; frogLocationX[2] = dx + 2;
                frogLocationY[0] = dy; frogLocationY[1] = dy; frogLocationY[2] = dy;
                //up
                frogLocationX[3] = dx; frogLocationX[4] = dx + 1; frogLocationX[5] = dx + 2;
                frogLocationY[3] = dy - 1; frogLocationY[4] = dy - 1; frogLocationY[5] = dy - 1;


                //placing characters on location
                //down
                Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[4]);
                Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[5]);
                Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[6]);
                //up
                Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[1]);
                Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[2]);
                Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[3]);
                Console.Beep(20000, miliSecPerFrame);

                //move tank
                //MoveTank();

                // check eating function
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (frogLocationX[i] == moneyLocX && frogLocationY[i] == moneyLocY)
                    {
                        score += 15;
                        PlaceMoney();
                    }
                }

                //bug, the cursor always 1 space foward deletes the right column
                if (frogLocationX[5] + 1 == widthScreen)
                    frame();

                // check if frame function
                int j;
                for (j = 0; j < ((widthScreen * 2) + (heightScreen * 2)); j++)
                    for (i = 0; i < 6; i++)
                    {
                        if (frogLocationX[i] == framePosX[j] && frogLocationY[i] == framePosY[j])
                        {
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                            
                            life--;
                            InitFrog();
                            frame();
                            water();
                            
                           //dx = widthScreen / 2;
                           //dy = heightScreen - 1;
                            
                        }
                    }
                
                // check if water and tree log function 
                if (frogLocationY[3] <= (heightScreen - 23) && frogLocationY[3] >= 4)
                {
                    int counter = 0;
                    for (i = 0; i < 6; i++)
                    {
                        for (int t = 0; t < treeSize; t++)
                        {
                            if ((frogLocationX[i] == treeLocationX[t] && frogLocationY[i] == treeLocationY[t]) ||
                                (frogLocationX[i] == tree2LocationX[t] && frogLocationY[i] == tree2LocationY[t]) ||
                                (frogLocationX[i] == tree3LocationX[t] && frogLocationY[i] == tree3LocationY[t]))
                            {
                                counter++;
                                if (counter == 6)
                                {
                                    i = 7; t = treeSize;
                                    break;
                                }
                            }
                            // if ((frogLocationX[i] == treeLocationX[t] && frogLocationY[i] == treeLocationY[t]) ||
                            //     (frogLocationX[i] == tree2LocationX[t] && frogLocationY[i] == tree2LocationY[t]))
                            // {
                            //      counter++;
                            //     if (counter >= 6)
                            //       {
                            //            i = 7; t = treeSize;
                            //             break;
                            //         }
                            //     }
                        }

                        if (counter != 6 && i == 5)
                        {
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);

                            life--;
                            InitFrog();
                            frame();
                            water();
                            break;
                        }

                    }
                    if (counter >= 6)
                    {
                        if (frogLocationY[0] <= tree2LocationY[0] && frogLocationY[3] >= tree2LocationY[tree2Size-1])
                        {
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                            dx = dx - 3;
                            //new position 
                            //down
                            frogLocationX[0] = dx; frogLocationX[1] = dx + 1; frogLocationX[2] = dx + 2;
                            frogLocationY[0] = dy; frogLocationY[1] = dy; frogLocationY[2] = dy;
                            //up
                            frogLocationX[3] = dx; frogLocationX[4] = dx + 1; frogLocationX[5] = dx + 2;
                            frogLocationY[3] = dy - 1; frogLocationY[4] = dy - 1; frogLocationY[5] = dy - 1;


                            //placing characters on location
                            //down
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[4]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[5]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[6]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[1]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[2]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[3]);

                            counter = 0;
                        }
                        if (frogLocationY[0] <= tree3LocationY[0] && frogLocationY[3] >= tree3LocationY[tree3Size-1])
                        {
                           //blank space after move
                           Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                           Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                           Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                           //up
                           Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                           Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                           Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                           dx = dx + 1;
                           //new position 
                           //down
                           frogLocationX[0] = dx; frogLocationX[1] = dx + 1; frogLocationX[2] = dx + 2;
                           frogLocationY[0] = dy; frogLocationY[1] = dy; frogLocationY[2] = dy;
                           //up
                           frogLocationX[3] = dx; frogLocationX[4] = dx + 1; frogLocationX[5] = dx + 2;
                           frogLocationY[3] = dy - 1; frogLocationY[4] = dy - 1; frogLocationY[5] = dy - 1;


                           //placing characters on location
                           //down
                           Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[4]);
                           Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[5]);
                           Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[6]);
                           //up
                           Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[1]);
                           Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[2]);
                           Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[3]);

                           counter = 0;
                       }
                        else
                        {
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                            dx++;
                            //new position 
                            //down
                            frogLocationX[0] = dx; frogLocationX[1] = dx + 1; frogLocationX[2] = dx + 2;
                            frogLocationY[0] = dy; frogLocationY[1] = dy; frogLocationY[2] = dy;
                            //up
                            frogLocationX[3] = dx; frogLocationX[4] = dx + 1; frogLocationX[5] = dx + 2;
                            frogLocationY[3] = dy - 1; frogLocationY[4] = dy - 1; frogLocationY[5] = dy - 1;


                            //placing characters on location
                            //down
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[4]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[5]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[6]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[1]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[2]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[3]);

                            counter = 0;
                        }
                    }
                }

               
                // check if train function 
                for (j = 0; j < trainSize; j++)
                    for (i = 0; i < 6; i++)
                    {
                        if (frogLocationX[i] == trainLocationX[j] && frogLocationY[i] == trainLocationY[j])
                        {
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);

                            life--;
                            InitFrog();
                            frame();

                            //dx = widthScreen / 2;
                            //dy = heightScreen - 1;

                        }
                    }

                // check if tank or truck function    
                for (j = 0; j < tankSize; j++)
                {
                    for (i = 0; i < 6; i++)
                    {
                        if ((frogLocationX[i] == tankLocationX[j] && frogLocationY[i] == tankLocationY[j]) || (frogLocationX[i] == tank2LocationX[j] && frogLocationY[i] == tank2LocationY[j])
                            || (frogLocationX[i] == truckLocationX[j] && frogLocationY[i] == truckLocationY[j]) || (frogLocationX[i] == truck2LocationX[j] && frogLocationY[i] == truck2LocationY[j]))
                        {
                            life--;
                            //blank space after move
                            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                            //up
                            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);

                            InitFrog();
                            frame();

                            //dx = widthScreen / 2;
                            //dy = heightScreen - 1;

                        }
                    }
                }

                //frame();
                Console.Beep(20000, miliSecPerFrame);
                
            } while (true);
        }
            

        static void frame()
        {
            
            widthScreen = 70;
            heightScreen = 35;
            miliSecPerFrame = 75;
            Console.SetCursorPosition(widthScreen / 2 - 7, 0); Console.Write("FROGGER LEVEL:");
            Console.SetCursorPosition(widthScreen / 2 - 7 + 14, 0); Console.Write(level);
            Console.SetCursorPosition(0, 0); Console.Write("LIFE:");
            Console.SetCursorPosition(5, 0); Console.Write(life);
            int x=0;
            int i;
            framePosX = new int[widthScreen * 2 + heightScreen * 2];
            framePosY = new int[widthScreen * 2 + heightScreen * 2];
            nextLevelX = new int[widthScreen + 10];
            //frame build
            for (i = 1; i < widthScreen; i++)
            {
                Console.SetCursorPosition(i, 3);
                Console.Write("*");
                Console.SetCursorPosition(i, 2);
                Console.Write("$");
            }

                for (i = 2; i <= heightScreen; i++)
                {
                    for (int j = 0; j <= widthScreen; j++)
                    {
                        if (i == 1 || i == heightScreen)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write("*");
                            framePosX[x] = j;
                            framePosY[x] = i;
                            x++;
                        }
                        else if (j == 0 || j == widthScreen)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write("*");
                            framePosX[x] = j;
                            framePosY[x] = i;
                            x++;
                        }
                    }
                }
            
            nextLevelY = 1;
            for( i = 0; i <= widthScreen; i++)
            {
                Console.SetCursorPosition(i, nextLevelY);
                Console.Write("*");
                nextLevelX[i] = i;
            }

            for (i = 0; i <= widthScreen; i++)
            {
                Console.SetCursorPosition(i, heightScreen - 19);
                Console.Write("*");
                Console.SetCursorPosition(i, heightScreen - 22);
                Console.Write("*");
               
            }
        }

        static void InitFrog()
        {
            PlaceMoney();
            //position
            dx = widthScreen / 2; dy = heightScreen - 1;

            //down
            frogLocationX[0] = dx; frogLocationX[1] = dx + 1; frogLocationX[2] = dx + 2;
            frogLocationY[0] = dy; frogLocationY[1] = dy; frogLocationY[2] = dy;
            //up
            frogLocationX[3] = dx; frogLocationX[4] = dx + 1; frogLocationX[5] = dx + 2;
            frogLocationY[3] = dy-1; frogLocationY[4] = dy - 1; frogLocationY[5] = dy - 1;

            

            //down
            Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[4]);
            Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[5]);
            Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[6]);
            //up
            Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[1]);
            Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[2]);
            Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[3]);

            
        }
        //arrow and blank space no move yet
        static void KeyRead()
        {
            if (Console.KeyAvailable == true)
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow:
                        //blank space after move
                        Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                        //up
                        Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                        dx++;
                       // dy = 0;
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                        //up
                        Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                        dx--;
                       // dy = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        
                        //down
                        Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                        //up
                        Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                     //   dx = 0;
                            dy--;
                        break;

                    case ConsoleKey.Spacebar:

                        //down
                        Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                        //up
                        Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                        //   dx = 0;
                            dy = dy - 2;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(frogLocationX[0], frogLocationY[0]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[1], frogLocationY[1]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[2], frogLocationY[2]); Console.Write(frogChars[0]);
                        //up
                        Console.SetCursorPosition(frogLocationX[3], frogLocationY[3]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[4], frogLocationY[4]); Console.Write(frogChars[0]);
                        Console.SetCursorPosition(frogLocationX[5], frogLocationY[5]); Console.Write(frogChars[0]);
                       // dx = 0;
                        dy++;
                        break;
                }
            }
        }

        //tank on screen 
        static void InitTank()
        {

            
            //position
            tx = 2; ty = heightScreen - 3;

            //down
            tankLocationX[0] = tx; tankLocationX[1] = tx + 1; tankLocationX[2] = tx + 2; tankLocationX[3] = tx + 3; tankLocationX[4] = tx + 4;
            tankLocationY[0] = ty; tankLocationY[1] = ty; tankLocationY[2] = ty; tankLocationY[3] = ty; tankLocationY[4] = ty;

            //up
            tankLocationX[5] = tx+1; tankLocationX[6] = tx + 2; tankLocationX[7] = tx + 3; tankLocationX[8] = tx + 4; tankLocationX[9] = tx + 5;
            tankLocationY[5] = ty - 1; tankLocationY[6] = ty - 1; tankLocationY[7] = ty - 1; tankLocationY[8] = ty - 1; tankLocationY[9] = ty - 1;



            //down
            Console.SetCursorPosition(tankLocationX[0], tankLocationY[0]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[1], tankLocationY[1]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[2], tankLocationY[2]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[3], tankLocationY[3]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[4], tankLocationY[4]); Console.Write(tankChars[1]);
            //up
            Console.SetCursorPosition(tankLocationX[5], tankLocationY[5]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[6], tankLocationY[6]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tankLocationX[7], tankLocationY[7]); Console.Write(tankChars[2]);
            Console.SetCursorPosition(tankLocationX[8], tankLocationY[8]); Console.Write(tankChars[3]);
            Console.SetCursorPosition(tankLocationX[9], tankLocationY[9]); Console.Write(tankChars[3]);

        }

        //tank movement
        static void MoveTank()
        {
            
                //down
                Console.SetCursorPosition(tankLocationX[0], tankLocationY[0]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[1], tankLocationY[1]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[2], tankLocationY[2]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[3], tankLocationY[3]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[4], tankLocationY[4]); Console.Write(tankChars[0]);
                //up
                Console.SetCursorPosition(tankLocationX[5], tankLocationY[5]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[6], tankLocationY[6]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[7], tankLocationY[7]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[8], tankLocationY[8]); Console.Write(tankChars[0]);
                Console.SetCursorPosition(tankLocationX[9], tankLocationY[9]); Console.Write(tankChars[0]);

                for (int i = 0; i < tankSize / 2; i++)
                {
                    //down
                    tankLocationX[i] = tankLocationX[i] + 1;
                    tankLocationY[i] = tankLocationY[0];
                    //up
                    tankLocationX[i + 5] = tankLocationX[i + 5] + 1;
                    tankLocationY[i + 5] = tankLocationY[5];
                }
                if (tankLocationX[4] == widthScreen)
                {
                    InitTank();
                    frame();
                }
                //down
                Console.SetCursorPosition(tankLocationX[0], tankLocationY[0]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[1], tankLocationY[1]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[2], tankLocationY[2]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[3], tankLocationY[3]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[4], tankLocationY[4]); Console.Write(tankChars[1]);
                //up
                Console.SetCursorPosition(tankLocationX[5], tankLocationY[5]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[6], tankLocationY[6]); Console.Write(tankChars[1]);
                Console.SetCursorPosition(tankLocationX[7], tankLocationY[7]); Console.Write(tankChars[2]);
                Console.SetCursorPosition(tankLocationX[8], tankLocationY[8]); Console.Write(tankChars[3]);
                Console.SetCursorPosition(tankLocationX[9], tankLocationY[9]); Console.Write(tankChars[3]);
        }

        static void InitTruck()
        {

            if (firstRunTruck == true)
            {
                firstRunTruck = false;
                //position
                t2x = widthScreen / 2; t2y = heightScreen - 10;
            }
            else
                t2x = 2; t2y = heightScreen - 10;

            //down
            truckLocationX[0] = t2x; truckLocationX[1] = t2x + 1; truckLocationX[2] = t2x + 2; truckLocationX[3] = t2x + 3; truckLocationX[4] = t2x + 4;
            truckLocationY[0] = t2y; truckLocationY[1] = t2y; truckLocationY[2] = t2y; truckLocationY[3] = t2y; truckLocationY[4] = t2y;

            //up
            truckLocationX[5] = t2x; truckLocationX[6] = t2x + 1; truckLocationX[7] = t2x + 2; truckLocationX[8] = t2x + 3; truckLocationX[9] = t2x + 4;
            truckLocationY[5] = t2y - 1; truckLocationY[6] = t2y - 1; truckLocationY[7] = t2y - 1; truckLocationY[8] = t2y - 1; truckLocationY[9] = t2y - 1;



            //down
            Console.SetCursorPosition(truckLocationX[0], truckLocationY[0]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[1], truckLocationY[1]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[2], truckLocationY[2]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[3], truckLocationY[3]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[4], truckLocationY[4]); Console.Write(truckChars[4]);
            //up
            Console.SetCursorPosition(truckLocationX[5], truckLocationY[5]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[6], truckLocationY[6]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[7], truckLocationY[7]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[8], truckLocationY[8]); Console.Write(truckChars[2]);
            Console.SetCursorPosition(truckLocationX[9], truckLocationY[9]); Console.Write(truckChars[3]);

        }

        static void MoveTruck()
        {

            //down
            Console.SetCursorPosition(truckLocationX[0], truckLocationY[0]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[1], truckLocationY[1]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[2], truckLocationY[2]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[3], truckLocationY[3]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[4], truckLocationY[4]); Console.Write(truckChars[0]);
            //up
            Console.SetCursorPosition(truckLocationX[5], truckLocationY[5]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[6], truckLocationY[6]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[7], truckLocationY[7]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[8], truckLocationY[8]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truckLocationX[9], truckLocationY[9]); Console.Write(truckChars[0]);

            for (int i = 0; i < tankSize / 2; i++)
            {
                //down
                truckLocationX[i] = truckLocationX[i] + 1;
                truckLocationY[i] = truckLocationY[0];
                //up
                truckLocationX[i + 5] = truckLocationX[i + 5] + 1;
                truckLocationY[i + 5] = truckLocationY[5];
            }
            if (truckLocationX[4] == widthScreen)
            {
                InitTruck();
                frame();
            }
            //down
            Console.SetCursorPosition(truckLocationX[0], truckLocationY[0]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[1], truckLocationY[1]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[2], truckLocationY[2]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[3], truckLocationY[3]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truckLocationX[4], truckLocationY[4]); Console.Write(truckChars[4]);
            //up
            Console.SetCursorPosition(truckLocationX[5], truckLocationY[5]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[6], truckLocationY[6]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[7], truckLocationY[7]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truckLocationX[8], truckLocationY[8]); Console.Write(truckChars[2]);
            Console.SetCursorPosition(truckLocationX[9], truckLocationY[9]); Console.Write(truckChars[3]);
        }

        static void InitTreeLog()
        {

            if (treefirstRun == true)
            {
                treefirstRun = false;
                //position
                t6x = widthScreen / 2; t6y = heightScreen - 25;
            }
            else
                t6x = 1; t6y = heightScreen - 25;

            int x=0,y=0;
            for (int i = 0; i < treeSize; i++)
            {
                treeLocationX[i] = t6x + x;
                treeLocationY[i] = t6y - y;
                if(x==(treeSize / 3)-1||x==((treeSize / 3)*2)-1)
                {
                    x=0;
                    y--;
                }
                else
                { x++; }

            }
            //creates tree log
            for(int i =0; i < treeSize; i++ )
            {
                if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[2]);
                }
                else
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[1]);
                }
            }
        }

        static void MoveTree()
        {
            //last place ~
            for (int i = 0; i < treeSize; i++)
            {
                Console.SetCursorPosition(treeLocationX[i], treeLocationY[i]); Console.Write(waterChars[1]);
               // i += ((treeSize / 3) * 2);
            }
            //new position tree
            for (int i = 0; i < treeSize / 3; i++)
            {
                //down
                treeLocationX[i] = treeLocationX[i] + 1;
                //up
                treeLocationX[i + ((treeSize / 3) * 2)] = treeLocationX[i + (treeSize / 3) * 2] + 1;
                //center
                treeLocationX[i + treeSize / 3] = treeLocationX[i + treeSize / 3] + 1;
            }
            if (treeLocationX[6] == widthScreen)
            {
                for (int i = 0; i < treeSize; i++)
                {
                    Console.SetCursorPosition(treeLocationX[i], treeLocationY[i]); Console.Write(waterChars[0]);
                }
                InitTreeLog();
                water();
                frame();
                
            }

            //creates tree log
            for (int i = 0; i < treeSize; i++)
            {
                //end of frame
                if (treeLocationX[i] == widthScreen)
                {
                    Console.SetCursorPosition(treeLocationX[i], treeLocationY[i]); Console.Write(treeLogChars[0]);
                }
                else
                {
                    if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                    {
                        Console.SetCursorPosition(treeLocationX[i], treeLocationY[i]); Console.Write(treeLogChars[2]);
                    }
                    else
                    {
                        Console.SetCursorPosition(treeLocationX[i], treeLocationY[i]); Console.Write(treeLogChars[1]);
                    }
                }
            }
        }

        static void InitTrain()
        {

            if (firstRunTrain == true)
            {
                firstRunTrain = false;
                //position
                t3x = widthScreen -2; t3y = heightScreen - 6;
            }
            else
                t3x = widthScreen - 2 ; t3y = heightScreen - 6;

            //down
            trainLocationX[0] = t3x; trainLocationX[1] = t3x - 1; trainLocationX[2] = t3x - 2; trainLocationX[3] = t3x - 3; trainLocationX[4] = t3x - 4;
            trainLocationY[0] = t3y; trainLocationY[1] = t3y; trainLocationY[2] = t3y; trainLocationY[3] = t3y; trainLocationY[4] = t3y;
            trainLocationX[5] = t3x-5; trainLocationX[6] = t3x -6; trainLocationX[7] = t3x -7; trainLocationX[8] = t3x -8; trainLocationX[9] = t3x -9;
            trainLocationY[5] = t3y; trainLocationY[6] = t3y; trainLocationY[7] = t3y; trainLocationY[8] = t3y; trainLocationY[9] = t3y;
            trainLocationX[10] = t3x-10; trainLocationX[11] = t3x -11; trainLocationX[12] = t3x -12; trainLocationX[13] = t3x -13; 
            trainLocationY[10] = t3y; trainLocationY[11] = t3y; trainLocationY[12] = t3y; trainLocationY[13] = t3y;
            //up
            trainLocationX[14] = t3x; trainLocationX[15] = t3x - 1; trainLocationX[16] = t3x - 2; trainLocationX[17] = t3x - 3; trainLocationX[18] = t3x - 4;
            trainLocationY[14] = t3y-1; trainLocationY[15] = t3y-1; trainLocationY[16] = t3y-1; trainLocationY[17] = t3y-1; trainLocationY[18] = t3y-1;
            trainLocationX[19] = t3x-5; trainLocationX[20] = t3x -6; trainLocationX[21] = t3x -7; trainLocationX[22] = t3x -8; trainLocationX[23] = t3x -9;
            trainLocationY[19] = t3y-1; trainLocationY[20] = t3y-1; trainLocationY[21] = t3y-1; trainLocationY[22] = t3y-1; trainLocationY[23] = t3y-1;
            trainLocationX[24] = t3x-10; trainLocationX[25] = t3x -11; trainLocationX[26] = t3x -12; trainLocationX[27] = t3x -13;
            trainLocationY[24] = t3y - 1; trainLocationY[25] = t3y - 1; trainLocationY[26] = t3y - 1; trainLocationY[27] = t3y - 1;

            //down
            Console.SetCursorPosition(trainLocationX[0], trainLocationY[0]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[1], trainLocationY[1]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[2], trainLocationY[2]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[3], trainLocationY[3]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[4], trainLocationY[4]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[5], trainLocationY[5]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[6], trainLocationY[6]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[7], trainLocationY[7]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[8], trainLocationY[8]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[9], trainLocationY[9]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[10], trainLocationY[10]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[11], trainLocationY[11]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[12], trainLocationY[12]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[13], trainLocationY[13]); Console.Write(trainChars[4]);
            
            //up
            Console.SetCursorPosition(trainLocationX[14], trainLocationY[14]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[15], trainLocationY[15]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[16], trainLocationY[16]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[17], trainLocationY[17]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[18], trainLocationY[18]); Console.Write(trainChars[2]);
            Console.SetCursorPosition(trainLocationX[19], trainLocationY[19]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[20], trainLocationY[20]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[21], trainLocationY[21]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[22], trainLocationY[22]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[23], trainLocationY[23]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[24], trainLocationY[24]); Console.Write(trainChars[2]);
            Console.SetCursorPosition(trainLocationX[25], trainLocationY[25]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[26], trainLocationY[26]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[27], trainLocationY[27]); Console.Write(trainChars[2]);
        }

        //move train
        static void MoveTrain()
        {

            //down
            Console.SetCursorPosition(trainLocationX[0], trainLocationY[0]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[1], trainLocationY[1]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[2], trainLocationY[2]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[3], trainLocationY[3]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[4], trainLocationY[4]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[5], trainLocationY[5]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[6], trainLocationY[6]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[7], trainLocationY[7]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[8], trainLocationY[8]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[9], trainLocationY[9]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[10], trainLocationY[10]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[11], trainLocationY[11]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[12], trainLocationY[12]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[13], trainLocationY[13]); Console.Write(trainChars[0]);

            //up
            Console.SetCursorPosition(trainLocationX[14], trainLocationY[14]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[15], trainLocationY[15]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[16], trainLocationY[16]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[17], trainLocationY[17]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[18], trainLocationY[18]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[19], trainLocationY[19]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[20], trainLocationY[20]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[21], trainLocationY[21]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[22], trainLocationY[22]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[23], trainLocationY[23]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[24], trainLocationY[24]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[25], trainLocationY[25]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[26], trainLocationY[26]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[27], trainLocationY[27]); Console.Write(trainChars[0]);

            for (int i = trainSize/2 -1; i >= 0; i--)
            {
                //down
                trainLocationX[i] = trainLocationX[i] - 1;
                //trainLocationY[i] = trainLocationY[0];
                //up
                trainLocationX[i + 14] = trainLocationX[i + 14] - 1;
                //trainLocationY[i + 14] = trainLocationY[14];
            }
            if (trainLocationX[27] == 0)
            {
                InitTrain();
                frame();
            }
            //down
            Console.SetCursorPosition(trainLocationX[0], trainLocationY[0]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[1], trainLocationY[1]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[2], trainLocationY[2]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[3], trainLocationY[3]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[4], trainLocationY[4]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[5], trainLocationY[5]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[6], trainLocationY[6]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[7], trainLocationY[7]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[8], trainLocationY[8]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[9], trainLocationY[9]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[10], trainLocationY[10]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[11], trainLocationY[11]); Console.Write(trainChars[1]);
            Console.SetCursorPosition(trainLocationX[12], trainLocationY[12]); Console.Write(trainChars[4]);
            Console.SetCursorPosition(trainLocationX[13], trainLocationY[13]); Console.Write(trainChars[4]);

            //up
            Console.SetCursorPosition(trainLocationX[14], trainLocationY[14]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[15], trainLocationY[15]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[16], trainLocationY[16]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[17], trainLocationY[17]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[18], trainLocationY[18]); Console.Write(trainChars[2]);
            Console.SetCursorPosition(trainLocationX[19], trainLocationY[19]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[20], trainLocationY[20]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[21], trainLocationY[21]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[22], trainLocationY[22]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[23], trainLocationY[23]); Console.Write(trainChars[5]);
            Console.SetCursorPosition(trainLocationX[24], trainLocationY[24]); Console.Write(trainChars[2]);
            Console.SetCursorPosition(trainLocationX[25], trainLocationY[25]); Console.Write(trainChars[0]);
            Console.SetCursorPosition(trainLocationX[26], trainLocationY[26]); Console.Write(trainChars[3]);
            Console.SetCursorPosition(trainLocationX[27], trainLocationY[27]); Console.Write(trainChars[2]);
        }

        static void InitTank2()
        {
            if (firstRunTank2 == true)
            {
                firstRunTank2 = false;
                //position
                t4x = widthScreen - 2; t4y = heightScreen - 13;
            }
            else
                t4x = widthScreen - 2; t4y = heightScreen - 13;

          

            //down
            tank2LocationX[0] = t4x; tank2LocationX[1] = t4x - 1; tank2LocationX[2] = t4x - 2; tank2LocationX[3] = t4x - 3; tank2LocationX[4] = t4x - 4;
            tank2LocationY[0] = t4y; tank2LocationY[1] = t4y; tank2LocationY[2] = t4y; tank2LocationY[3] = t4y; tank2LocationY[4] = t4y;

            //up
            tank2LocationX[5] = t4x - 1; tank2LocationX[6] = t4x - 2; tank2LocationX[7] = t4x - 3; tank2LocationX[8] = t4x - 4; tank2LocationX[9] = t4x - 5;
            tank2LocationY[5] = t4y - 1; tank2LocationY[6] = t4y - 1; tank2LocationY[7] = t4y - 1; tank2LocationY[8] = t4y - 1; tank2LocationY[9] = t4y - 1;



            //down
            Console.SetCursorPosition(tank2LocationX[0], tank2LocationY[0]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[1], tank2LocationY[1]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[2], tank2LocationY[2]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[3], tank2LocationY[3]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[4], tank2LocationY[4]); Console.Write(tankChars[1]);
            //up
            Console.SetCursorPosition(tank2LocationX[5], tank2LocationY[5]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[6], tank2LocationY[6]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[7], tank2LocationY[7]); Console.Write(tankChars[2]);
            Console.SetCursorPosition(tank2LocationX[8], tank2LocationY[8]); Console.Write(tankChars[4]);
            Console.SetCursorPosition(tank2LocationX[9], tank2LocationY[9]); Console.Write(tankChars[4]);

        }

        //tank movement
        static void MoveTank2()
        {

            //down
            Console.SetCursorPosition(tank2LocationX[0], tank2LocationY[0]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[1], tank2LocationY[1]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[2], tank2LocationY[2]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[3], tank2LocationY[3]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[4], tank2LocationY[4]); Console.Write(tankChars[0]);
            //up
            Console.SetCursorPosition(tank2LocationX[5], tank2LocationY[5]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[6], tank2LocationY[6]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[7], tank2LocationY[7]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[8], tank2LocationY[8]); Console.Write(tankChars[0]);
            Console.SetCursorPosition(tank2LocationX[9], tank2LocationY[9]); Console.Write(tankChars[0]);

            for (int i = tankSize / 2 -1; i >= 0; i--)
            {
                //down
                tank2LocationX[i] = tank2LocationX[i] - 1;
                tank2LocationY[i] = tank2LocationY[0];
                //up
                tank2LocationX[i + 5] = tank2LocationX[i + 5] - 1;
                tank2LocationY[i + 5] = tank2LocationY[5];
            }
            if (tank2LocationX[4] == 0)
            {
                InitTank2();
                frame();
            }
            //down
            Console.SetCursorPosition(tank2LocationX[0], tank2LocationY[0]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[1], tank2LocationY[1]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[2], tank2LocationY[2]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[3], tank2LocationY[3]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[4], tank2LocationY[4]); Console.Write(tankChars[1]);
            //up
            Console.SetCursorPosition(tank2LocationX[5], tank2LocationY[5]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[6], tank2LocationY[6]); Console.Write(tankChars[1]);
            Console.SetCursorPosition(tank2LocationX[7], tank2LocationY[7]); Console.Write(tankChars[2]);
            Console.SetCursorPosition(tank2LocationX[8], tank2LocationY[8]); Console.Write(tankChars[4]);
            Console.SetCursorPosition(tank2LocationX[9], tank2LocationY[9]); Console.Write(tankChars[4]);
        }

        static void InitTruck2()
        {

            if (firstRunTruck2 == true)
            {
                firstRunTruck2 = false;
                //position
                t5x = widthScreen / 2 + 10; t5y = heightScreen - 16;
            }
            else
                t5x = 2; t5y = heightScreen - 16;

            //down
            truck2LocationX[0] = t5x; truck2LocationX[1] = t5x + 1; truck2LocationX[2] = t5x + 2; truck2LocationX[3] = t5x + 3; truck2LocationX[4] = t5x + 4;
            truck2LocationY[0] = t5y; truck2LocationY[1] = t5y; truck2LocationY[2] = t5y; truck2LocationY[3] = t5y; truck2LocationY[4] = t5y;

            //up
            truck2LocationX[5] = t5x; truck2LocationX[6] = t5x + 1; truck2LocationX[7] = t5x + 2; truck2LocationX[8] = t5x + 3; truck2LocationX[9] = t5x + 4;
            truck2LocationY[5] = t5y - 1; truck2LocationY[6] = t5y - 1; truck2LocationY[7] = t5y - 1; truck2LocationY[8] = t5y - 1; truck2LocationY[9] = t5y - 1;



            //down
            Console.SetCursorPosition(truck2LocationX[0], truck2LocationY[0]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[1], truck2LocationY[1]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[2], truck2LocationY[2]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[3], truck2LocationY[3]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[4], truck2LocationY[4]); Console.Write(truckChars[4]);
            //up
            Console.SetCursorPosition(truck2LocationX[5], truck2LocationY[5]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[6], truck2LocationY[6]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[7], truck2LocationY[7]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[8], truck2LocationY[8]); Console.Write(truckChars[2]);
            Console.SetCursorPosition(truck2LocationX[9], truck2LocationY[9]); Console.Write(truckChars[3]);

        }

        static void MoveTruck2()
        {

            //down
            Console.SetCursorPosition(truck2LocationX[0], truck2LocationY[0]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[1], truck2LocationY[1]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[2], truck2LocationY[2]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[3], truck2LocationY[3]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[4], truck2LocationY[4]); Console.Write(truckChars[0]);
            //up
            Console.SetCursorPosition(truck2LocationX[5], truck2LocationY[5]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[6], truck2LocationY[6]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[7], truck2LocationY[7]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[8], truck2LocationY[8]); Console.Write(truckChars[0]);
            Console.SetCursorPosition(truck2LocationX[9], truck2LocationY[9]); Console.Write(truckChars[0]);

            for (int i = 0; i < tankSize / 2; i++)
            {
                //down
                truck2LocationX[i] = truck2LocationX[i] + 1;
                truck2LocationY[i] = truck2LocationY[0];
                //up
                truck2LocationX[i + 5] = truck2LocationX[i + 5] + 1;
                truck2LocationY[i + 5] = truck2LocationY[5];
            }
            if (truck2LocationX[4] == widthScreen)
            {
                InitTruck2();
                frame();
            }
            //down
            Console.SetCursorPosition(truck2LocationX[0], truck2LocationY[0]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[1], truck2LocationY[1]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[2], truck2LocationY[2]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[3], truck2LocationY[3]); Console.Write(truckChars[4]);
            Console.SetCursorPosition(truck2LocationX[4], truck2LocationY[4]); Console.Write(truckChars[4]);
            //up
            Console.SetCursorPosition(truck2LocationX[5], truck2LocationY[5]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[6], truck2LocationY[6]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[7], truck2LocationY[7]); Console.Write(truckChars[1]);
            Console.SetCursorPosition(truck2LocationX[8], truck2LocationY[8]); Console.Write(truckChars[2]);
            Console.SetCursorPosition(truck2LocationX[9], truck2LocationY[9]); Console.Write(truckChars[3]);
        }

        static void InitTreeLog3()
        {

            if (tree3firstRun == true)
            {
                tree3firstRun = false;
                //position
                t8x = 1; t8y = heightScreen - 31;
            }
            else
                t8x = 1; t8y = heightScreen - 31;

            int x = 0, y = 0;
            for (int i = 0; i < treeSize; i++)
            {
                tree3LocationX[i] = t8x + x;
                tree3LocationY[i] = t8y - y;
                if (x == (treeSize / 3) - 1 || x == ((treeSize / 3) * 2) - 1)
                {
                    x = 0;
                    y--;
                }
                else
                { x++; }

            }
            //creates tree log
            for (int i = 0; i < treeSize; i++)
            {
                Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(treeLogChars[1]);
                if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                    Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(treeLogChars[2]);
            }
        }

        static void MoveTree3()
        {
            //last place ~
            for (int i = 0; i < treeSize; i++)
            {
                Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(waterChars[1]);
                // i += ((treeSize / 3) * 2);
            }
            //new position tree
            for (int i = 0; i < treeSize / 3; i++)
            {
                //down
                tree3LocationX[i] = tree3LocationX[i] + 1;
                //up
                tree3LocationX[i + ((treeSize / 3) * 2)] = tree3LocationX[i + (treeSize / 3) * 2] + 1;
                //center
                tree3LocationX[i + treeSize / 3] = tree3LocationX[i + treeSize / 3] + 1;
            }
            if (tree3LocationX[6] == widthScreen -1)
            {
                for (int i = 0; i < treeSize; i++)
                {
                    Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(waterChars[0]);
                }
                InitTreeLog3();
                water();
                frame();

            }

            //creates tree log
            for (int i = 0; i < treeSize; i++)
            {
                //end of frame
                if (tree3LocationX[i] == widthScreen)
                {
                    Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(treeLogChars[0]);
                }
                else
                {
                    if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                    {
                        Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(treeLogChars[2]);
                    }
                    else
                    {
                        Console.SetCursorPosition(tree3LocationX[i], tree3LocationY[i]); Console.Write(treeLogChars[1]);
                    }
                }
            }
        }

        static void InitTreeLog2()
        {

            if (tree2firstRun == true)
            {
                tree2firstRun = false;
                //position
                t7x = widthScreen - 1; t7y = heightScreen - 26;
            }
            else
                t7x = widthScreen - 1; t7y = heightScreen - 26;

            int x = 0, y = 0;
            for (int i = 0; i < treeSize; i++)
            {
                tree2LocationX[i] = t7x - x;
                tree2LocationY[i] = t7y + y;
                if (x == (treeSize / 3) - 1 || x == ((treeSize / 3) * 2) - 1)
                {
                    x = 0;
                    y--;
                }
                else
                { x++; }

            }
            //creates tree log
            for (int i = 0; i < treeSize; i++)
            {

                if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[2]);
                }
                else
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[1]);
                }
            }
        }

        static void MoveTree2()
        {
            //last place ~
            for (int i = 0; i < treeSize; i++)
            {
                Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(waterChars[1]);
                // i += ((treeSize / 3) * 2);
            }
            //new position tree
            for (int i = 0; i < treeSize / 3; i++)
            {
                //down
                tree2LocationX[i] = tree2LocationX[i] - 1;
                //up
                tree2LocationX[i + ((treeSize / 3) * 2)] = tree2LocationX[i + (treeSize / 3) * 2] - 1;
                //center
                tree2LocationX[i + treeSize / 3] = tree2LocationX[i + treeSize / 3] - 1;
            }
            if (tree2LocationX[6] == 1)
            {
                for (int i = 0; i < treeSize; i++)
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(waterChars[0]);
                }
                InitTreeLog2();
                water();
                frame();

            }

            //creates tree log
            for (int i = 0; i < treeSize; i++)
            {
                //end of frame
                if (tree2LocationX[i] == 1)
                {
                    Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[0]);
                }
                else
                {
                    if (i > (treeSize / 3) && i < ((treeSize / 3) * 2) - 1)
                    {
                        Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[2]);
                    }
                    else
                    {
                        Console.SetCursorPosition(tree2LocationX[i], tree2LocationY[i]); Console.Write(treeLogChars[1]);
                    }
                }
            }
        }

        //next level
        static void nextLevel()
        {
            if (frogLocationY[3]<=2)
            {
                level++;
                score = score + 25;
                InitFrog();
            }
            if (level == 2)
                MoveTank();
            if (level == 3)
            {
                MoveTruck();
                MoveTank();
            }
            if (level == 4)
            {
                MoveTruck();
                MoveTank();
                MoveTank2();
            }
        }
    }
}
