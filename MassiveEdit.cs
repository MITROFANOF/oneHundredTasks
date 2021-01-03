namespace oneHundredTasks
{
    public static class MassiveEdit
    {
        private static int[] _array = {1, 2, 3, 4, 5, -1, -2, -3, 55, 0, 16, -12, 43};

        public static void Block1(int valueToAdd)
        {
            var largerArray = new int[_array.Length + 1];
            for (var i = 0; i < _array.Length; i++) largerArray[i] = _array[i];

            largerArray[_array.Length] = valueToAdd;
            _array = largerArray;
        }

        public static void Block2(int valueToAdd)
        {
            var largerArray = new int[_array.Length + 1];
            for (var i = 1; i < largerArray.Length; i++) largerArray[i] = _array[i];

            largerArray[0] = valueToAdd;
            _array = largerArray;
        }

        public static void Block3(int valueToAdd, int index)
        {
            var largerArray = new int[_array.Length + 1];
            for (var i = 0; i < index; i++) largerArray[i] = _array[i];
            largerArray[index] = valueToAdd;
            for (var i = index; i < _array.Length; i++) largerArray[i + 1] = _array[i];
            _array = largerArray;
        }

        public static void Block4()
        {
            var smallerArray = new int[_array.Length - 1];
            for (var i = 0; i < smallerArray.Length - 1; i++) smallerArray[i] = _array[i];
            _array = smallerArray;
        }

        public static void Block5()
        {
            var smallerArray = new int[_array.Length - 1];
            for (var i = 0; i < smallerArray.Length - 1; i++) smallerArray[i] = _array[i + 1];
            _array = smallerArray;
        }

        public static void Block6(int index)
        {
            var smallerArray = new int[_array.Length - 1];
            for (var i = 0; i < index; i++) smallerArray[i] = _array[i];
            for (var i = index; i < smallerArray.Length - 1; i++) smallerArray[i] = _array[i + 1];
            _array = smallerArray;
        }

        public static int[] Block7(int[] arr1, int[] arr2)
        {
            var largerArray = new int[arr1.Length + arr2.Length];
            for (var i = 0; i < arr1.Length; i++) largerArray[i] = arr1[i];
            for (var i = 0; i < arr2.Length; i++) largerArray[i + arr1.Length] = arr2[i];
            return largerArray;
        }
    }
}