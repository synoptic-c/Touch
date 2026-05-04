using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Touch.Modules
{
    class TileDefinition
    {
        [JsonPropertyName("name")]
        public string? name { get; set; }
        [JsonPropertyName("solid")]
        public byte solid { get; set; }
    }

    class Map
    {
        public List<TileDefinition>? tiles { get; set; }
        [JsonPropertyName("map")]
        public List<List<int>>? map { get; set; }

        public Map(string? tilesPath, string? mapPath, ref bool isRunning, Player player)
        {
            try
            {
                if (tilesPath == null)
                {
                    isRunning = false;
                    Console.WriteLine("Tiles path is null");
                    return;
                }
                if (mapPath == null)
                {
                    isRunning = false;
                    Console.WriteLine("Map path is null");
                    return;
                }

                tiles = JsonSerializer.Deserialize<List<TileDefinition>>(File.ReadAllText(tilesPath));
                JsonNode? jsonNode = JsonNode.Parse(File.ReadAllText("Maps/" + mapPath + ".json"));

                if (jsonNode == null)
                {
                    isRunning = false;
                    Console.WriteLine("Failed to parse map json");
                    Console.ReadKey(intercept: true);
                    return;
                }
                if (jsonNode["map"] == null)
                {
                    isRunning = false;
                    Console.WriteLine("The map is empty");
                    Console.ReadKey(intercept: true);
                    return;
                }
                map = jsonNode["map"].Deserialize<List<List<int>>>();

                if (jsonNode["playerPosition"] != null)
                {
                    player.x = (int)(jsonNode["playerPosition"]?["x"] ?? 1);
                    player.y = (int)(jsonNode["playerPosition"]?["y"] ?? 1);
                }
                
            }
            catch (Exception exception)
            {
                isRunning = false;
                Console.WriteLine(exception.Message);
                Console.ReadKey(intercept: true);
            }
        }
    }
}
