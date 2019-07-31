using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game
{
    public class EnemyWaveManager
    {
        static EnemyWave Current;
        static EnemyWave[] enemies;
        static int index;
        public static void LoadWaves(EnemyWave[] waves)
        {
            enemies = waves;
        }
        public static bool NextWave()
        {
            if (index >= enemies.Length)
            {
                Current.Dispose();
                Current = null;
                return false;
            }
            Current.Dispose();
            Current = enemies[index];
            Current.Create();
            index++;
            return true;
        }
        public static void Clear()
        {
            if (Current != null)
                Current.Dispose();
        }
        public static void Update(float time)
        {
            Current.Update(time);
        }
    }
}
