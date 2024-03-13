﻿using Raylib_cs;

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
        bool endScreen1 = false;
        bool endScreen2 = false;
        bool drawScreen = false;

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

        int hpLossPerFrame = 1;

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

            if (endScreen1 || endScreen2 || drawScreen)
            {
                // Game Over Screens
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RED);

                if (endScreen1)
                    Raylib.DrawText("Game Over! Superman Won!", 715, 250, 45, Color.WHITE);

                else if (endScreen2)
                    Raylib.DrawText("Game Over! Batman Won!", 715, 250, 45, Color.WHITE);

                else if (drawScreen)
                    Raylib.DrawText("Game Over! It's a draw!", 715, 250, 45, Color.WHITE);

                Raylib.DrawText("Press R to Restart", 800, 550, 30, Color.WHITE);

                Raylib.EndDrawing();


                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {

                    endScreen1 = false;
                    endScreen2 = false;
                    drawScreen = false;
                    player1HP = 320;
                    player2HP = 320;
                }

                continue;
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
            player1HP -= hpLossPerFrame;
            player2HP -= hpLossPerFrame;          

            if (player1HP < 1 && player2HP >= 1)
            {
                endScreen1 = true;
                continue;
            }
            else if (player2HP < 1 && player1HP >= 1)
            {
                endScreen2 = true;
                continue;
            }
            else if (player1HP < 1 && player2HP < 1)
            {
                drawScreen = true;
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
            Raylib.DrawText($"Health: {player1HP}", 100, 110, 30, Color.WHITE);
            Raylib.DrawText($"Health: {player2HP}", 1650, 110, 30, Color.WHITE);


            Raylib.EndDrawing();
            // DRAWING ********************************************************************
        }
        Raylib.CloseWindow();
    }
}