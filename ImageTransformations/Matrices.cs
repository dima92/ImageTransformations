using System;

namespace ImageTransformations
{
    class Matrices
    {
        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            // кэшируем размеры матриц для лучшей производительности 
            var matrix1Rows = matrix1.GetLength(0);
            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            // проверяем, совместимы ли матрицы
            if (matrix1Cols != matrix2Rows)
                throw new InvalidOperationException
                    ("Матрицы не совместимы. Число столбцов первой матрицы должно быть равно числу строк второй матрицы");

            // создаем пустую результирующую матрицу нужного размера
            double[,] product = new double[matrix1Rows, matrix2Cols];

            // заполняем результирующую матрицу
            // цикл по каждому ряду первой матрицы
            for (int matrix1Row = 0; matrix1Row < matrix1Rows; matrix1Row++)
            {
                // цикл по каждому столбцу второй матрицы  
                for (int matrix2Col = 0; matrix2Col < matrix2Cols; matrix2Col++)
                {
                    // вычисляем скалярное произведение двух векторов  
                    for (int matrix1Col = 0; matrix1Col < matrix1Cols; matrix1Col++)
                    {
                        product[matrix1Row, matrix2Col] +=
                            matrix1[matrix1Row, matrix1Col] *
                            matrix2[matrix1Col, matrix2Col];
                    }
                }
            }

            return product;
        }

        public static double[,] CreateIdentityMatrix(int length)
        {
            double[,] matrix = new double[length, length];

            for (int i = 0, j = 0; i < length; i++, j++)
                matrix[i, j] = 1;

            return matrix;
        }
    }
}