using System;
using Raylib_cs;

class Start
{
    static void ResetGame(ref int player1HP, ref int player2HP, ref int[] batmanPosition, ref int[] supermanPosition, ref int score1, ref int score2)
    {
        player1HP = 320;
        player2HP = 320;
        batmanPosition[0] = 500;
        batmanPosition[1] = 1000;
        supermanPosition[0] = 1200;
        supermanPosition[1] = 1000;
        score1 = 0;
        score2 = 0;
    }

    static void Main()
    {
        bool fullscreen = false;

        Raylib.InitWindow(1920, 1080, "Start of game");

        int[] batmanPosition = { 500, 1000 };
        int[] supermanPosition = { 1200, 1000 };

        int player1HP = 320;
        int player2HP = 320;

        int score1 = 0;
        int score2 = 0;

        bool startScreen = true;
        bool endScreen1 = false;
        bool endScreen2 = false;
        bool drawScreen = false;
        bool batmanPunching = false;
        bool batmanRunning = false;
        bool supermanPunching = false;

        Raylib.SetTargetFPS(60);

        Texture2D background = Raylib.LoadTexture("gothamfinal.png");
        Texture2D batman = Raylib.LoadTexture("batmanstand.png");
        Texture2D startscreen2 = Raylib.LoadTexture("batmanVSsuperman1.png");
        Texture2D batmanPunch = Raylib.LoadTexture("batmanpunch1.png");
        Texture2D batmanRun = Raylib.LoadTexture("batmanrun.png");
        Texture2D superman = Raylib.LoadTexture("supermanfin.png");
        Texture2D supermanPunch = Raylib.LoadTexture("supermanPunch1.png");
        Texture2D healthbar = Raylib.LoadTexture("healthbar.png");
        Texture2D healthbarV = Raylib.LoadTexture("healthbarV.png");
        Texture2D BatmanRunLeftTexture = Raylib.LoadTexture("BatmanRunLeft.png");

        batman.Width = 200;
        batman.Height = 200;

        batmanRun.Width = 195;
        batmanRun.Height = 195;

        batmanPunch.Width = 190;
        batmanPunch.Height = 190;

        superman.Width = 200;
        superman.Height = 200;

        supermanPunch.Width = 200;
        supermanPunch.Height = 200;

        Random random = new Random();

        while (!Raylib.WindowShouldClose())
        {
            if (startScreen)
            {
                // Start Screen
                Raylib.BeginDrawing();
                Raylib.DrawTexture(startscreen2, 0, 0, Color.WHITE);
                Raylib.DrawText("Press Enter to Start", 670, 400, 50, Color.WHITE);
                Raylib.DrawText("Batman use A and D to move and Superman use arrow left and right to move", 520, 700, 20, Color.BLUE);
                Raylib.DrawText("PSST! use F for Batman and right control for Superman for double damage", 560, 750, 20, Color.DARKBLUE);
                Raylib.EndDrawing();

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
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RED);

                if (endScreen1)
                {
                    Raylib.DrawText("Superman Won!", 760, 250, 45, Color.WHITE);
                    Raylib.DrawText($"{score1} - {score2}", 880, 350, 45, Color.WHITE);
                }
                else if (endScreen2)
                {
                    Raylib.DrawText("Batman Won!", 810, 250, 45, Color.WHITE);
                    Raylib.DrawText($"{score1} - {score2}", 880, 350, 45, Color.WHITE);
                }
                else if (drawScreen)
                {
                    Raylib.DrawText("It's a draw!", 810, 250, 45, Color.WHITE);
                    Raylib.DrawText($"{score1} - {score2}", 790, 350, 45, Color.WHITE);
                }

                Raylib.DrawText("Press R to Start next Round", 720, 550, 30, Color.WHITE);

                Raylib.EndDrawing();

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {
                    if (endScreen1)
                        score2 = score2 + 1;
                    else if (endScreen2)
                        score1 = score1 + 1;

                    endScreen1 = false;
                    endScreen2 = false;
                    drawScreen = false;
                    ResetGame(ref player1HP, ref player2HP, ref batmanPosition, ref supermanPosition, ref score1, ref score2);
                }
            }

            // MOVEMENT ****************************************************************************************
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) supermanPosition[0] += 5;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) supermanPosition[0] -= 5;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                batmanPosition[0] += 5;
                batmanRunning = true;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                batmanPosition[0] -= 5;
                batmanRunning = true;
            }
            else
            {
                batmanRunning = false;
            }

            //*************************************************************** ground level 
            if (supermanPosition[1] + superman.Height > 970)
                supermanPosition[1] = 970 - superman.Height;

            if (batmanPosition[1] + batman.Height > 985)
                batmanPosition[1] = 985 - batman.Height;
            //*************************************************************** ground level
            

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                batmanPunching = true;
            }
            else
            {
                batmanPunching = false;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
            {
                int damage = random.Next(10, 50);
                player2HP -= damage;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                int damage = random.Next(40, 100);
                player2HP -= damage;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT))
            {
                supermanPunching = true;
            }
            else
            {
                supermanPunching = false;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT_SHIFT))
            {
                int damage = random.Next(10, 50);
                player1HP -= damage;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT_CONTROL))
            {
                int damage = random.Next(40, 100);
                player1HP -= damage;
            }
            // MOVEMENT ****************************************************************************************



            //**********************************************         
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

            if (supermanPunching)
                Raylib.DrawTexture(supermanPunch, supermanPosition[0], supermanPosition[1], Color.WHITE);

            else
                Raylib.DrawTexture(superman, supermanPosition[0], supermanPosition[1], Color.WHITE);

            if (batmanPunching)
                Raylib.DrawTexture(batmanPunch, batmanPosition[0], batmanPosition[1], Color.WHITE);
                
            else if (batmanRunning)
                Raylib.DrawTexture(batmanRun, batmanPosition[0], batmanPosition[1], Color.WHITE);

            else
                Raylib.DrawTexture(batman, batmanPosition[0], batmanPosition[1], Color.WHITE);

            Raylib.DrawTexture(BatmanRunLeftTexture, batmanPosition[0], batmanPosition[1], Color.WHITE);
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