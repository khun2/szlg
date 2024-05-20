#include "raylib.h"

int main(void) {
    const int sWidth = 1600;
    const int sHeight = 1200;

    InitWindow(sWidth, sHeight, "is this just the name");

    while (!WindowShouldClose()) {

        
        BeginDrawing();

            ClearBackground(RAYWHITE);

            DrawText("Congrats! You created your first window!", 190, 200, 20, LIGHTGRAY);

        EndDrawing();
    }
    CloseWindow();
    return 0;
}
