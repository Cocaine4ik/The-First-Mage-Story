using UnityEngine;

public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer) {

        return mask == (mask | (1 << layer));

    }

    public static float[] BubleSort(this float[] array) {

        for (int i = 0; i < array.Length; i++) {

            for (int j = 0; j < array.Length - 1; j++) {

                if (array[j] > array[j + 1]) {

                    float z = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = z;
                }
            }
        }
        return array;
    }
}
