using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Start of game");

        int square1X = 300;
        int square1Y = 300;
        int square2X = 300;
        int square2Y = 300;

        int player1HP = 100;
        int player2HP = 100;

        bool startScreen = true;
        bool endScreen = false;

        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            if (startScreen)
            {
                // Start Screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawText("Press Enter to Start", 250, 250, 30, Color.WHITE);

                Raylib.EndDrawing();

                // Check for Enter key to start the game
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    startScreen = false;

                continue; // Skip the game loop until the player starts the game
            }

            if (endScreen)
            {
                // End Screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RED);

                Raylib.DrawText("Game Over!", 300, 250, 30, Color.WHITE);

                Raylib.EndDrawing();

                continue; // Skip the game loop if the game has ended
            }


            // MOVEMENT ****************************************************************************************
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) square1X += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) square1X -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) square1Y -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) square1Y += 5;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) square2X += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) square2X -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) square2Y -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) square2Y += 5;
            // MOVEMENT ****************************************************************************************


            //**********************************************
            player1HP = 100;

            if (player1HP < 1)
            {
                endScreen = true;
                continue;
            }
            player2HP = 100;

            if (player2HP < 1)
            {
                endScreen = true;
                continue;
            }
            //**********************************************
            
            //DRAWING********************************************************************
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLUE);

            Raylib.DrawRectangle(square1X, square1Y, 50, 50, Color.RAYWHITE);
            Raylib.DrawRectangle(square2X, square2Y, 50, 50, Color.RAYWHITE);

            Raylib.EndDrawing();
            //DRAWING********************************************************************
        }

        Raylib.CloseWindow();
    }
}