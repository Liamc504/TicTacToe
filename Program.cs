using System;

namespace TictactoeArrays{ //NAMESPACE 

    internal class Program { //CLASS


        //FUNCTION INPUTNUMBERS. WRITES INPUTTED STRING, AND THEN ASKS USER TO INPUT A NUMBER. WILL KEEP ASKING UNTIL USER ENTERS AN INTEGER
        static int InputNumber(string prompt) {

            string userinput = "";
            bool goodinput = false;

            //DO-WHILE1 LOOP1
            do {
                Console.Write(prompt);
                userinput = Console.ReadLine(); //RECORDS USER INPUT

                if (userinput == "0" | userinput == "1" | userinput == "2") //CHECKS IF USERINPUT CAN IS 0,1, or 2
                {
                    goodinput = true;
                } else {
                    Console.WriteLine("Invalid input. Try again:");
                }


            }//END "DO" OF DO-WHILE1
            while (goodinput != true); //WILL LOOP AS LONG AS "USERINPUT" FAILS TO PARSE. User must input an integer to end loop
            //END DO-WHILE1 LOOP1

            return int.Parse(userinput); //RETURNS PARSED INT 0, 1, or 2

        }
        //END FUNCTION INPUTNUMBERS

        //VOID DRAWBOARD FUNCTION
        static void drawBoard(string[,] board) {

            int counter = 0; //FOR STYLE REASONS, KEEPS TRACK OF HOW MANY TIMES A COORDINATE IS DRAWN IN A SPOT
            Console.Clear(); //CLEARS CONSOLE BEFORE BOARD IS DRAWN 

            //FOR LOOP 1
            for (int y = 0; y < board.GetLength(0); ++y) {
                for (int x = 0; x < board.GetLength(1); ++x) {//NESTED FOR LOOP 2. WORKS WITH LOOP 1 TO RUN THROUGH EVERY X, Y COORDINATE IN ARRAY

                    //IF CHECKS FOR WINNING VALUES, HIGHLIGHTING WINNING COORDS
                    if (board[x, y] == "X!" || board[x, y] == "0!") { //ONLY WINNNIG COORDS HAVE "!" AFTER THEM
                        Console.ForegroundColor = ConsoleColor.Black; //CHANGES CONSOLE COLORS AKA HIGHLIGHTS
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("   " + board[x, y]);         //DRAWS WINNING COORDS
                        Console.ResetColor();                       //TURNS HIGHLIGHTING OFF
                    } //END IF

                    else //DRAWS EVERY NON-WINNING COORDINATE X Y
                    {
                        Console.Write("    " + board[x, y]); //MARKS THE VALUE FOR EVERY COORDINATE X,Y
                    }

                    if (board[x, y] == "*") //ONLY WRITES COORDS IN PARENTHESIS IF SPOT IS "*" AKA EMPTY
                        {
                        Console.Write("(" + x + "," + y + ")");
                    } else {
                        Console.Write("     "); //BLANK SPACE TO REPLACE COORDS IF SPOT IS NOT "*"
                    }

                    counter++;  // ADDS TO COUNTER, TRACKING EVERY TIME BOARD IS MARKED, FOR STYLE FORMATTING PURPOSES

                    if (counter % 3 != 0)  //EXCLUDES WRITING AFTER MARKS #3, #6, #9, etc.
                      {
                        Console.Write("|"); //VISUAL STYLE LINES, SKIPS END COLUMNS @MARKS #3, #6, #9, etc
                    }

                    if (counter % 3 == 0)  //EVERY 3 MARKS, STARTS NEW LINE SO BOARD IS 3x3
                     {
                        Console.WriteLine("\n__________|__________|_________");
                    }//END IF
                }//END FOR NESTED FOR LOOP 2
            }//END FOR LOOP 1


        }//END VOID DRAWBOARD
         //

        //VOID ASKXCOORDS METHOD 1
        static int AskXCoords(int Player) { //PLAYER = 1 OR 2
            Console.WriteLine("Player " + Player + ", input an x and y coordinate to place your marker");

            int X_Coord = InputNumber("Input the X coordinate integer:");//ASKS FOR INPUT AND SAVES TO X COORD
            return X_Coord;
        }//END VOID ASKXCOORDS METHOD 1

        //VOID ASKYCOORDS METHOD 2
        static int AskYCoords(int Player) {
            int Y_Coord = InputNumber("Input the Y coordinate integer:");
            return Y_Coord;
        } //END VOID ASKCOORDS METHOD


        //VOID PLACEMARKER
        static void placeMarker(string[,] board, string marker, int x_coord, int y_coord) { //MARKER = PLAYERTURN = X or 0, DEPENDING ON PLAYERTURN 

            board[x_coord, y_coord] = marker; //TURNS COORDINATES VALUE FROM "*" INTO AN "X" or "O"
        }
        //END VOID PLACEMARKER

        //BOOL CHECKWINNER
        static bool checkWinner(string[,] board, string player) { //CHECKS PLAYER 1 OR 2 FOR WIN

            // check rows
            //IF BOARD == ALL SAME SYMBOL (X or 0)
            if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) {
                board[0, 0] = board[0, 1] = board[0, 2] = player + "!"; //ADDS AN "!" TO THE WINNING SPOTS, TO BE HIGHLIGHTED IN DRAWBOARD
                return true;                                            //RETURN TRUE AKA THERE IS A WINNER
            }//END IF 

            //IF BOARD == ALL SAME SYMBOL (X or 0)
            if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) {
                board[1, 0] = board[1, 1] = board[1, 2] = player + "!"; //ADDS AN "!", making (X! or 0!)
                return true;                                            //RETURN TRUE AKA THERE IS A WINNER
            }//END IF    
            if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) {
                board[2, 0] = board[2, 1] = board[2, 2] = player + "!";  //ADDS AN "!", making (X! or 0!)
                return true;                                              //RETURN TRUE AKA THERE IS A WINNER
            }

            // check columns
            if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) {
                board[0, 0] = board[1, 0] = board[2, 0] = player + "!";
                return true;
            }
            if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) {
                board[0, 1] = board[1, 1] = board[2, 1] = player + "!";
                return true;
            }
            if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) {
                board[0, 2] = board[1, 2] = board[2, 2] = player + "!";
                return true;
            }

            // check diags
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) {
                board[0, 0] = board[1, 1] = board[2, 2] = player + "!";
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) {
                board[0, 2] = board[1, 1] = board[2, 0] = player + "!";
                return true;
            }
            //ELSE, AFTER FAILING ALL IFS
            return false; //NO WINNER
        }
        //END BOOL CHECKWINNER

        //VOID DECLARWINNER
        static void declareWinner(int Player){ //ANOUNCES WHO THE WINNER IS.
            
            if (Player == 3)  // 3 = TIE
                {
                Console.WriteLine("Tie! No Winner. \n Press enter to play again.");
                }//END IF
            else            //PLAYER 1 or 2 WINS
                {
                Console.WriteLine("Player " + Player + " wins! \n Press enter to play again.");              
                }//END ELSE
        }
        //END VOID DECLARE WINNER


        //VOID START GAME. TO BE LOOPED IN MAIN IN ORDER TO RESET ALL VARS, e.g. ARRAY, COUNTER, PLAYER1 TURN
        //
        static void StartGame(){
        
                //VARS
                string[,] boardarray = new string[3, 3];
                string playerturn;    //KEEPS TRACK OF WHICH PLAYERS TURN. STARTS OFF WITH PLAYER1 aka X
                int Player;           //MAKES AN INT SO THAT EACH PLAYER HAS A STRING AND INT VAR, 1 AND X, OR 2 AND O
                int MainCounter = 0;  //KEEPS TRACK OF HOW MANY TURNS HAVE PASSED.

                //FOR LOOP 1, INITIALIZES ARRAY VALUES AS "*"
                for (int x = 0; x < boardarray.GetLength(0); ++x) 
                {
                    //NESTED FOR LOOP 2
                    for (int y = 0; y < boardarray.GetLength(1); ++y) //WILL LOOP THROUGH ALL Y values in X0, Then Ys in X1, Then Ys in X2, ETC.) 
                    {
                        boardarray[x, y] = "*";
                    }//END FOR LOOP 1
                }//END NESTED FOR LOOP 2


                //DRAWBOARD 1x
                drawBoard(boardarray);

            //WHILE BOOL, RUNS THE GAME FUNCTIONS
            bool ContinuePlaying = true;

                while (ContinuePlaying == true) //GAME PLAYS UNTIL FALSE
                    {
                        //IF, SWITCHES BETWEEN PLAYERS EVERY TURN.
                    if (MainCounter % 2 == 0) //PLAYER 1 MOVES ON EVEN TURNS. STARTS FROM TURN #ZERO     .                         
                        {                     
                        playerturn = "X";    //EVEN TURNS. X
                        Player = 1;
                        } //END IF
                    else                    
                        {   
                        playerturn = "O";    //ODD turns for PLAYER 2, starting at turn #ONE                         
                        Player = 2;
                        } //END ELSE

                    
                    placeMarker(boardarray, playerturn, AskXCoords(Player), AskYCoords(Player)); //INPUT. MARKS PLAYERS INPUT
                    drawBoard(boardarray);                                                       //OUTPUT
                    MainCounter++;                                                             //TRACKS TURN, ADDING +1

                        //CHECK FOR TIE
                    if (MainCounter >= 9) //IF 9 TURNS HAVE PASSED 
                        {
                        declareWinner(3);
                        ContinuePlaying = false;             
                        } //END IF

                        //CHECK FOR WINNER
                    if (MainCounter >= 4) //DOESNT CHECK UNTIL AFTER 4th TURN 
                        {   //if 1
                        if (checkWinner(boardarray, playerturn) == true) 
                            {//if 2
                            drawBoard(boardarray); //DRAWS WINNING BOARD
                            declareWinner(Player); //ANNOUNCES WINNER
                            ContinuePlaying = false; //END CURRENT GAME  
                            }//end if 2
                        }   //end if 1
                    }//END WHILE BOOL
            }
        //END VOID STARTGAME

        //MAIN
        static void Main(string[] args){
            int ContinueGame = 1;    //1= GAME IS ON. 
            while (ContinueGame == 1) //GAME WILL STAY ON, UNTIL GAME=0. 
                {                    //THE MAIN IS A WHILE-LOOP AROUND A FUNCTION SO THAT VARS RESET AFTER EVERY GAME ENDS
                StartGame();        //CALLS GAME METHOD CODE
                Console.WriteLine("Input '1' to continue"); //ASKS PLAYER TO CONTINUE AFTER A GAME ENDS
                if (Console.ReadLine() != "1") 
                    {
                    ContinueGame = 0;       //GAME = TURNS OFF IF USER DID NOT INPUT TO CONTINUE 
                    }
                }//END WHILE 
            }//END MAIN
        }//END CLASS
}   //END NAMESPACE