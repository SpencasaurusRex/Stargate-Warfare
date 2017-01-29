namespace SpencerHaney
{
    using UnityEngine;
    using System.Collections.Generic;

    public static class Util
    {
        public static T PickRandomFrom<T>(T[] array)
        {
            int index = Random.Range(0, array.Length);
            return array[index];
        }
    }
}
