﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMYVector
{
    internal class MYVector<T>
    {
        private T[]? elementData; // ? // массив для хранения элементов вектора
        private int elementCount; // количество элементов в массиве

        private int capacityIncrement; // значение, на кот увеличивается емкость вектора при необходимости

        public MYVector(int initialCapacity, int capacityIncrement)
        {
            this.elementCount = initialCapacity; this.capacityIncrement = capacityIncrement;
        }





    }
}
