using Raylib_cs;

class Program
{
    static void Main()
    {
        bool fullscreen = false;

        Raylib.InitWindow(1920, 1080, "Start of game");

        int batmanX = 200;
        int batmanY = 700;

        int supermanX = 1200;
        int supermanY = 550;

        int player1HP = 320;
        int player2HP = 320;

        bool startScreen = true;
        bool endScreen = false;

        Raylib.SetTargetFPS(60);

        Texture2D background = Raylib.LoadTexture("gotham.png");
        Texture2D batman = Raylib.LoadTexture("batman.png");
        Texture2D superman = Raylib.LoadTexture("supermanfin.png");
        Texture2D healthbar = Raylib.LoadTexture("healthbar.png");
        Texture2D healthbarV = Raylib.LoadTexture("healthbarV.png");      

        batman.Width = 200;
        batman.Height = 200;

        superman.Width = 200;
        superman.Height = 200;



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

                continue;
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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) supermanX += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) supermanX -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) supermanY -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) supermanY += 5;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) batmanX += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) batmanX -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) batmanY -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) batmanY += 5;

            // MOVEMENT ****************************************************************************************


            //**********************************************
            player1HP = 320;

            if (player1HP < 1)
            {
                endScreen = true;
                continue;
            }
            player2HP = 320;

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
            Raylib.DrawRectangle(90, 70, player1HP, 32, Color.LIME);
            Raylib.DrawRectangle(1514, 70, player2HP, 32, Color.LIME);
            Raylib.DrawTexture(healthbar, 0, 0, Color.WHITE);
            Raylib.DrawTexture(healthbarV, 1470, 0, Color.WHITE);
        
            
            Raylib.EndDrawing();
            // DRAWING ********************************************************************
        }
        Raylib.CloseWindow();
    }
}