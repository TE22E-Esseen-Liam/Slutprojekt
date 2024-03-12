using Raylib_cs;

class Program
{
    static void Main()
    {
        bool fullscreen = false;

        Raylib.InitWindow(1920, 1080, "Start of game");

        int batmanX = 300;
        int batmanY = 600;

        int supermanX = 600;
        int supermanY = 300;

        int player1HP = 100;
        int player2HP = 100;

        bool startScreen = true;
        bool endScreen = false;

        Raylib.SetTargetFPS(60);

        Texture2D background = Raylib.LoadTexture("gotham.png");
        Texture2D batman = Raylib.LoadTexture("batman.png");
        Texture2D superman = Raylib.LoadTexture("supermanfin.png");

        while (!Raylib.WindowShouldClose())
        {
            if (startScreen)
            {
                // Start Screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawText("Press Enter to Start", 670, 400, 50, Color.WHITE);

                Raylib.EndDrawing();

                // Check for Enter key to start the game and toggle full-screen
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    startScreen = false;
                    fullscreen = !fullscreen;
                    Raylib.ToggleFullscreen();
                }

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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) batmanX += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) batmanX -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) batmanY -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) batmanY += 5;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) supermanX += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) supermanX -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) supermanY -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) supermanY += 5;

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
            
            // DRAWING ********************************************************************
            Raylib.BeginDrawing();
            
            // Draw background image
            Raylib.DrawTexture(background, 0, 0, Color.WHITE);
            Raylib.DrawTexture(batman, batmanX, batmanY, Color.WHITE);
            Raylib.DrawTexture(superman, supermanX, supermanY, Color.WHITE);           
        
            
            Raylib.EndDrawing();
            // DRAWING ********************************************************************
        }
        Raylib.CloseWindow();
    }
}