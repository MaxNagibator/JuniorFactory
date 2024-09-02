using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Map
    {
        public Tile[,] Tiles { get; set; }
    }

    public class Tile
    {
        public Terrain Terrain { get; set; }
        public Landscape Landscape { get; set; }
    }

    /// <summary>
    /// Тип местности.
    /// </summary>
    public enum Terrain
    {
        /// <summary>
        /// Тундра.
        /// </summary>
        Tundra,

        /// <summary>
        /// Пустыня.
        /// </summary>
        Desert,

        /// <summary>
        /// Лёд.
        /// </summary>
        Ice,
    }

    /// <summary>
    /// Ландшафт.
    /// </summary>
    public enum Landscape
    {
        /// <summary>
        /// Холм.
        /// </summary>
        Hill,

        /// <summary>
        /// Равнина.
        /// </summary>
        Plain,
    }
}
