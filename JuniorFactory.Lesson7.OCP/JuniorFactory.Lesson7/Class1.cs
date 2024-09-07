using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public abstract class BlaBlaTile
    {
        public abstract int GetProduct();
        public abstract int GetFood();
    }

    public class PlainTile : BlaBlaTile
    {
        public override int GetFood()
        {
            return 1;
        }

        public override int GetProduct()
        {
            return 3;
        }
    }

    public class HillTile : BlaBlaTile
    {

        public override int GetFood()
        {
            return 2;
        }

        public override int GetProduct()
        {
            return 2;
        }
    }

    public class HillWithMineralsTile : BlaBlaTile
    {
        public override int GetFood()
        {
            return 1;
        }

        public override int GetProduct()
        {
            return 5;
        }
    }

    public class MarshTile : BlaBlaTile
    {
        public override int GetFood()
        {
            return 2;
        }

        public override int GetProduct()
        {
            return 1;
        }
    }

    public class City
    {
        public BlaBlaTile[] Tiles { get; set; }
    }

    public class ProductManager
    {
        public int GetProduct(BlaBlaTile[] tiles)
        {
            var value = 0;
            foreach (var tile in tiles)
            {
                value += tile.GetProduct();
            }
            return value;
        }

        public int GetFood(BlaBlaTile[] tiles)
        {
            var value = 0;
            foreach (var tile in tiles)
            {
                value += tile.GetFood();
            }
            return value;
        }
    }
}
