// See https://aka.ms/new-console-template for more information
using Lesson6;

Console.WriteLine("Hello, World!");


var width = 10;
var height = 10;
var map = new Map();
map.Tiles = new Tile[width, height];
var rnd = new Random();
var terrains = Enum.GetValues(typeof(Terrain)).Cast<Terrain>().ToArray();
var landscapes = Enum.GetValues(typeof(Landscape)).Cast<Landscape>().ToArray();

for (var i = 0; i < width; i++)
{
    for (var j = 0; j < height; j++)
    {
        var terrainsIndex = rnd.Next(terrains.Length);
        var landscapesIndex = rnd.Next(landscapes.Length);
        map.Tiles[i, j] = new Tile
        {
            Terrain = terrains[terrainsIndex],
            Landscape = landscapes[landscapesIndex]
        };
    }
}

for (var i = 0; i < width; i++)
{
    for (var j = 0; j < height; j++)
    {
        if(map.Tiles[i,j].Terrain == Terrain.Tundra)
        {
            if (map.Tiles[i, j].Landscape == Landscape.Hill)
            {
                Console.Write("♦");
            }
            else
            {
                Console.Write("☻");
            }
        }
        if (map.Tiles[i, j].Terrain == Terrain.Ice)
        {
            Console.Write(" ");
        }
        if (map.Tiles[i, j].Terrain == Terrain.Desert)
        {
            Console.Write(".");
        }
    }
    Console.WriteLine();
}

