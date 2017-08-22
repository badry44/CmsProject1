using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shura.SimpleCMS.Logic
{
    public static class Structs
    {
        public struct ThreeDoubleStruct
        {
            public double A;
            public double B;
            public double C;

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return A + "," + B + "," + C;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            public void SetA(double a)
            {
                A = a;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="b"></param>
            public void SetB(double b)
            {
                B = b;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            public void SetC(double c)
            {
                C = c;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public ThreeDoubleStruct CloneWithNewAddedC(double c)
            {
                return new ThreeDoubleStruct { A = A, B = B, C = C + c };
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="points"></param>
            /// <returns></returns>
            public static ThreeDoubleStruct GetCenter(params ThreeDoubleStruct?[] points)
            {
                double totalX = 0, totalY = 0, totalZ = 0;
                foreach (var p in points)
                {
                    totalX += p.Value.A;
                    totalY += p.Value.B;
                    totalZ += p.Value.C;
                }

                return new ThreeDoubleStruct { A = totalX / points.Length, B = totalY / points.Length, C = totalZ / points.Length };
            }
        }

        public struct TwoDoubleStruct
        {
            public double A;
            public double B;

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return A + "," + B;
            }
        }

        public struct ThreeIntStruct
        {
            public int A;
            public int B;
            public int C;

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return A + "," + B + "," + C;
            }
        }
    }
}
