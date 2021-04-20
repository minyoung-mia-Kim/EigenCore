﻿using EigenCore.Core.Dense;
using EigenCore.Core.Dense.LinearAlgebra;
using Xunit;

namespace EigenCore.Test.Dense.Core
{
    public class MatrixXDTest
    {
        public const int DoublePrecision = 12;

        [Fact]
        public void ConstructorJagged_ShouldSucceed()
        {
            var A = new MatrixXD(new double[][] { new double[] { 1, 3, 2 } , new double[] { 0, 2, 1 } });
            Assert.Equal(2, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.Equal(new double[] { 1, 0, 3, 2, 2, 1 }, A.GetValues().ToArray());
        }

        [Fact]
        public void ConstructorMutyDim_ShouldSucceed()
        {
            var A = new MatrixXD(new double[,] { { 1, 3, 2 }, { 0, 2, 1 } });
            Assert.Equal(2, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.Equal(new double[] { 1, 0, 3, 2, 2, 1 }, A.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void Minus_ShouldSucceed()
        {

            MatrixXD A = new MatrixXD("2 4; 3 5");
            MatrixXD B = new MatrixXD("1 3; 3 2");

            var result = A.Minus(B);
            Assert.Equal(new MatrixXD("1 1; 0 3"), result);
        }

        [Fact]
        public void Mult_ShouldSucceed()
        {

            MatrixXD A = new MatrixXD("1 2; 3 5");
            MatrixXD B = new MatrixXD("1 2; 3 2");

            var result = A.Mult(B);
            Assert.Equal(new double[] { 7, 18, 6, 16 }, result.GetValues().ToArray());

            A = new MatrixXD("0 -1 2; 4 11 2");
            B = new MatrixXD("3, -1; 1 2; 6 1");

            result = A.Mult(B);

            Assert.Equal(new double[] { 11, 35, 0, 20 }, result.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void Transpose_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2 4; 3 5 7");
            MatrixXD B = A.Transpose();
            Assert.Equal(new double[] { 1, 2, 4, 3, 5, 7 }, B.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void MultT_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2 1; 2 5 2");
            MatrixXD B = new MatrixXD("1 0 1; 1 1 0");
            MatrixXD C = A.MultT(B);
            Assert.Equal(new double[] { 2, 4, 3, 7 }, C.GetValues().ToArray());
        }

        [Fact]
        public void Random_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Random(10, 10, 1, 100);
            Assert.Equal(10, A.Rows);
            Assert.Equal(10, A.Cols);
            Assert.True(A.Min() >= 1);
            Assert.True(A.Max() <= 100);
        }

        [Fact]
        public void Identity_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Identity(3);
            Assert.Equal(3, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.True(A.Min() == 0.0);
            Assert.True(A.Max() == 1.0);
            Assert.Equal(
                new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 },
                A.GetValues().ToArray());
        }

        [Fact]
        public void Equals_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Random(10, 10);
            Assert.Equal(10, A.Rows);
            Assert.Equal(10, A.Cols);
            Assert.True(A.Equals(A.Clone()));
        }

        [Fact]
        public void Clone_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Random(10, 10);
            Assert.Equal(10, A.Rows);
            Assert.Equal(10, A.Cols);
            Assert.True(A.Min() >= 0.0);
            Assert.True(A.Max() <= 1.0);
        }

        [Fact]
        public void Zeros_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Zeros(2, 3);
            Assert.Equal(2, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.Equal(0.0, A.Min());
            Assert.Equal(0.0, A.Max());

            Assert.Equal(new double[] { 0, 0, 0, 0, 0, 0 }, A.GetValues().ToArray());
        }

        [Fact]
        public void Ones_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Ones(2, 3);
            Assert.Equal(2, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.Equal(1.0, A.Min());
            Assert.Equal(1.0, A.Max());

            Assert.Equal(new double[] { 1, 1, 1, 1, 1, 1 }, A.GetValues().ToArray());
        }

        [Fact]
        public void Diag_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Diag(new[] { 3.5, 2, 4.5 });
            Assert.Equal(3, A.Rows);
            Assert.Equal(3, A.Cols);
            Assert.Equal(0.0, A.Min());
            Assert.Equal(4.5, A.Max());

            Assert.Equal(new double[] { 3.5, 0, 0, 0, 2, 0, 0, 0, 4.5 }, A.GetValues().ToArray());
        }

        [Fact]
        public void Min_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 3 4");
            Assert.Equal(1, A.Min());
        }

        [Fact]
        public void Max_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 3 4");
            Assert.Equal(4, A.Max());
        }

        [Fact]
        public void Sum_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 3 4");
            Assert.Equal(10, A.Sum());
        }

        [Fact]
        public void Prod_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 3 4");
            Assert.Equal(24, A.Prod());
        }

        [Fact]
        public void Mean_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 3 4");
            Assert.Equal(2.5, A.Mean());
        }

        [Fact]
        public void Scale__ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Ones(3,2);
            A.Scale(0.4);

            for(int i = 0; i< A.Rows; i++)
            {
                for (int j = 0; j< A.Cols; j++)
                {
                    Assert.Equal(0.4, A.Get(i, j));
                }
            }
        }

        [Fact]
        public void Row_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 4 5; 7 8");
            var v1 = A.Row(0);
            var v2 = A.Row(1);
            var v3 = A.Row(2);

            Assert.Equal(new VectorXD("1 2"), v1);
            Assert.Equal(new VectorXD("4 5"), v2);
            Assert.Equal(new VectorXD("7 8"), v3);
        }

        [Fact]
        public void Col_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2; 4 5; 7 8");
            var v1 = A.Col(0);
            var v2 = A.Col(1);

            Assert.Equal(new VectorXD("1 4 7"), v1);
            Assert.Equal(new VectorXD("2 5 8"), v2);
        }

        [Fact]
        public void Slice_ArrayInput_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2 3; 4 5 5; 7 8 2");
            var result = A.Slice(new[] { 1, 2 }, new[] { 0, 1 });

            Assert.Equal(new MatrixXD("4 5; 7 8"), result);
        }

        [Fact]
        public void Slice_StartEnd_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("1 2 3; 4 5 6; 7 8 2");
            var result = A.Slice(0, 1, 1 , 2);

            Assert.Equal(new MatrixXD("2 3; 5 6"), result);

            result = A.Slice(0, 1, 0, 2);

            Assert.Equal(new MatrixXD("1 2 3; 4 5 6"), result);
        }

        [InlineData("1 2 3; 4 5 6; 7 8 2", new double[] { 1, 2, 3 }, "1 2 3 1 0 0;4 5 6 0 2 0;7 8 2 0 0 3")]
        [InlineData("1 2; 4 5; 7 8", new double[] { 1, 2, 3 }, "1 2 1 0 0;4 5 0 2 0;7 8 0 0 3")]
        [InlineData("1 2; 4 5", new double[] { 1, 2 }, "1 2 1 0;4 5 0 2")]
        [Theory]
        public void ConcatHorizontal_ShouldSucceed(string matrixString, double[] diag, string expected)
        {
            MatrixXD A = new MatrixXD(matrixString);
            MatrixXD B = MatrixXD.Diag(diag);
            var C = A.Concat(B, ConcatType.Horizontal);
            Assert.Equal(new MatrixXD(expected), C);
        }

        [InlineData("1 2 3; 4 5 6; 7 8 2", new double[] { 1, 2, 3 }, "1 2 3;4 5 6;7 8 2;1 0 0; 0 2 0; 0 0 3")]
        [InlineData("1 2; 4 5; 7 8", new double[] { 1, 2 }, "1 2 ;4 5 ;7 8; 1 0; 0 2")]
        [InlineData("1 2; 4 5", new double[] { 1, 2 }, "1 2;4 5;1 0; 0 2")]
        [Theory]
        public void ConcatVertical_ShouldSucceed(string matrixString, double[] diag, string expected)
        {
            MatrixXD A = new MatrixXD(matrixString);
            MatrixXD B = MatrixXD.Diag(diag);
            var C = A.Concat(B, ConcatType.Vertical);
            Assert.Equal(new MatrixXD(expected), C);
        }


        [Fact(Skip = "need to update .so")]
        public void MultV_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Diag(new[] { 3.5, 2, 4.5 });
            VectorXD v = new VectorXD(new[] { 2.0, 2.0, 2.0 });
            var result = A.Mult(v);
            Assert.Equal(new double[] { 7, 4, 9 }, result.GetValues().ToArray());


            A = new MatrixXD("1 2 1; 2 5 2; 2 5 5");
            v = new VectorXD(new[] { 1.5, 4.5, 2.0 });
            result = A.Mult(v);
            Assert.Equal(new double[] { 12.5, 29.5, 35.5 }, result.GetValues().ToArray());

            A = new MatrixXD("1 -2 ; 2 5 ; 4 -2");
            v = new VectorXD(new[] { 3.0, -7.0 });
            result = A.Mult(v);
            Assert.Equal(new double[] { 17.0, -29.0, 26.0 }, result.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void Trace_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Diag(new[] { 3.5, 2, 4.5 });
            var result = A.Trace();
            Assert.Equal(10.0, result);
        }

        [Fact(Skip = "need to update .so")]
        public void Eigen_ShouldSucceed()
        {
            MatrixXD A = MatrixXD.Diag(new[] { 3.5, 2, 4.5 });
            var result = A.Eigen();

            var v1 = result.Eigenvalues.Real();
            var v2 = result.Eigenvectors.Real();

            Assert.Equal(new[] { 3.5, 2, 4.5 }, v1.GetValues().ToArray());
            Assert.Equal(new[] { 1.0, 0.0, 0.0,
                                 0.0, 1.0, 0.0,
                                 0.0, 0.0, 1.0 }, v2.GetValues().ToArray());

            MatrixXD B = new MatrixXD("0 1; -2 -3");
            result = B.Eigen();
            v1 = result.Eigenvalues.Real();
            v2 = result.Eigenvectors.Real();

            Assert.Equal(new[] { -1.0, -2.0 }, v1.GetValues().ToArray());
            Assert.Equal(new[] { 0.7071067811865476, -0.7071067811865475,
                                -0.447213595499958, 0.8944271909999157 }, v2.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void PlusT_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("2 2; 1 1");
            var result = A.PlusT();
            Assert.Equal(new double[] { 4, 3, 3 , 2 }, result.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void MultT_WithSelf_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("2 2; 1 1");
            var result = A.MultT();
            Assert.Equal(new MatrixXD("8 4 ; 4 2"), result);

            MatrixXD B = new MatrixXD("2 2; 1 1; 3 3");
            result = B.MultT();
            Assert.Equal(new MatrixXD("8 4 12; 4 2 6; 12 6 18"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void TMult_WithSelf_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("2 2; 1 1");
            var result = A.TMult();
            Assert.Equal(new MatrixXD("5 5 ; 5 5"), result);

            MatrixXD B = new MatrixXD("2 2; 1 1; 3 3");
            result = B.TMult();
            Assert.Equal(new MatrixXD("14 14; 14 14"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void SymmetricEigen_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("4 3; 3 2");
            SAEigenSolverResult eigen = A.SymmetricEigen();
            Assert.Equal(new[] { -0.16227766016837947, 6.162277660168379 }, eigen.Eigenvalues.GetValues().ToArray());
            Assert.Equal(new[] { -0.584710284663765, 0.8112421851755608,
                                  0.8112421851755608, 0.584710284663765 }, eigen.Eigenvectors.GetValues().ToArray());

            MatrixXD B = new MatrixXD("2 1; 1 2");
            eigen = B.SymmetricEigen();
            Assert.Equal(new[] { 0.9999999999999998, 2.9999999999999996 }, eigen.Eigenvalues.GetValues().ToArray());
            Assert.Equal(new[] { -0.7071067811865475, 0.7071067811865475,
                                  0.7071067811865475, 0.7071067811865475 }, eigen.Eigenvectors.GetValues().ToArray());
        }

        [Fact(Skip = "need to update .so")]
        public void Plus_ShouldSucceed()
        {
            MatrixXD A = new MatrixXD("4 3; 3 2");
            MatrixXD B = MatrixXD.Identity(2);
            var result = A.Plus(B);
            Assert.Equal(new MatrixXD("5 3; 3 3"), result);
        }

        [Theory(Skip = "need to update .so")]
        [InlineData(SVDType.Jacobi)]
        [InlineData(SVDType.BdcSvd)]
        public void SVD_ShouldSucceed(SVDType sdvType)
        {
            var A = new MatrixXD("3 2 2 ; 2 3 -2");
            SVDResult result = A.SVD(sdvType);

            Assert.Equal(new MatrixXD("-0.7071067811865476 0.7071067811865475 ;" +
                " -0.7071067811865475  -0.7071067811865476"), result.U);

            Assert.Equal(new[] { 5.0, 3.0 }, result.S.GetValues().ToArray());

            Assert.Equal(new MatrixXD("-0.7071067811865477  0.23570226039551567; " +
                "-0.7071067811865475 -0.23570226039551567; " +
                "-2.220446049250313E-16 0.94280904158206336"),
                result.V);
        }

        [Theory(Skip = "need to update .so")]
        [InlineData(SVDType.Jacobi)]
        [InlineData(SVDType.BdcSvd)]
        public void LeastSquaresSVD_ShouldSucceed(SVDType sdvType)
        {
            var A = new MatrixXD("-1 -0.0827; -0.737 0.0655; 0.511 -0.562 ");
            var rhs = new VectorXD("-0.906 0.358 0.359");
            VectorXD result = A.LeastSquaresSVD(rhs, sdvType);
            Assert.Equal(new VectorXD("0.46347421844577846 0.04209165616389611"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void LeastSquaresNE_ShouldSucceed()
        {
            var A = new MatrixXD("-1 -0.0827; -0.737 0.0655; 0.511 -0.562 ");
            var rhs = new VectorXD("-0.906 0.358 0.359");
            VectorXD result = A.LeastSquaresNE(rhs);
            Assert.Equal(new VectorXD("0.46347421844577846 0.04209165616389611"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void SolveColPivHouseholderQr_ShouldSucceed()
        {
            var A = new MatrixXD("1 2 3; 4 5 6; 7 8 10");
            var rhs = new VectorXD("3 3 4");
            VectorXD result = A.Solve(rhs, DenseSolverType.ColPivHouseholderQR);
            Assert.Equal(new VectorXD("-2 1 1"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void SolveLLT_ShouldSucceed()
        {
            var A = new MatrixXD("1  2  1; 2  1  0 ; -1  1  2");
            var rhs = new VectorXD("3 3 4");
            VectorXD result = A.Solve(rhs, DenseSolverType.LLT);
            Assert.Equal(new VectorXD("2.3333333333333321 -1.6666666666666643 3.9999999999999978"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void Determinant_ShouldSucceed()
        {
            var A = new MatrixXD("1 2 3; 4 5 6; 7 8 10");
            double result = A.Determinant();
            Assert.Equal(-3, result, DoublePrecision);
        }

        [Fact(Skip = "need to update .so")]
        public void Inverse_ShouldSucceed()
        {
            var A = new MatrixXD("1  2  1; 2  1  0 ; -1  1  2");
            var result = A.Inverse();
            Assert.Equal(new MatrixXD("-0.66666666666666663 1 0.33333333333333331;" +
                                      "1.3333333333333333 -1 -0.66666666666666663;" +
                                      "-1 1 1"), result);
        }

        [Fact(Skip = "need to update .so")]
        public void HouseholderQR_ShouldSucceed()
        {
            var A = new MatrixXD("1 -2 4; 1 -1 1;1 0 0");
            var result = A.QR();
            Assert.Equal(new MatrixXD("-0.5773502691896257 0.7071067811865475 0.4082482904638628;" +
                "-0.5773502691896257 0 -0.816496580927726;" +
                "-0.5773502691896257 -0.7071067811865475 0.40824829046386313"),
                result.Q);

            Assert.Equal(new MatrixXD( "-1.7320508075688772 1.7320508075688776 -2.886751345948128;" +
                "0 -1.4142135623730951 2.82842712474619;" +
                "0 0 0.8164965809277254"), result.R);
        }

        [Fact(Skip = "need to update .so")]
        public void ColPivHouseholderQR_ShouldSucceed()
        {
            var A = new MatrixXD("1 -2 4 -8; 1 -1 1 -1; 1 0 0 0;1 1 1 1; 1 2 4 8");

            var result = A.QR(QRType.ColPivHouseholderQR);

            Assert.Equal(new MatrixXD("-0.7016464154456237 -0.6859943405700355 0.12298800925361816 -0.08770580193070285 0.11952286093343929;" +
                "-0.08770580193070293 -0.17149858514250882 -0.491952037014473 0.7016464154456233 -0.47809144373375745;" +
                "0 0 -0.6969320524371696 -4.709932589600423E-17 0.7171371656006363;" +
                "0.08770580193070293 -0.17149858514250885 -0.4919520370144727 -0.7016464154456235 -0.4780914437337573;" +
                "0.7016464154456235 -0.6859943405700353 0.12298800925361814 0.08770580193070301 0.11952286093343928"),
                result.Q);

            Assert.Equal(new MatrixXD("11.40175425099138 -8.881784197001252E-16 -2.220446049250313E-16 2.9819972656438996;" +
                "0 -5.830951894845301 -1.7149858514250886 3.3306690738754696E-16;" +
                "0 0 -1.4348601079588787 9.419865179200846E-17;" +
                "0 0 0 -1.0524696231684352;" +
                "0 0 0 0"), result.R);

            Assert.Equal(new MatrixXD("0 0 1 0;0 0 0 1;0 1 0 0;1 0 0 0"), result.P);
        }

        [Fact(Skip = "need to update .so")]
        public void FullPivLU()
        {
            var A = new MatrixXD("-1 -0.562 -0.233;-0.737 -0.906 0.0388; 0.511 0.358 0.662; -0.0827 0.359 -0.931;  0.0655   0.869  -0.893");
            var result =  A.FullPivLU();
            
            Assert.Equal(new MatrixXD("1 0 0 0 0;" +
                "0.0827 1 0 0 0;" +
                "-0.0655 0.9961947105225896 1 0 0;" +
                "0.737 -0.23090256127109438 -0.9297746434749113 1 0;" +
                "-0.511 -0.5955013699766016 0.7291932816982963 1.2461174142951108E-306 1"), result.L);
            Assert.Equal(new MatrixXD("-1 -0.233 -0.562;" +
                "0 -0.9117309 0.4054774;" +
                "0 0 0.4282545588835477;" +
                "0 0 0;" +
                "0 0 0"), result.U);
            Assert.Equal(new MatrixXD("1 0 0 0 0;0 0 0 1 0;0 0 0 0 1;0 1 0 0 0;0 0 1 0 0"), result.P);
            Assert.Equal(new MatrixXD("1 0 0;0 0 1;0 1 0"), result.Q);
        }
    }
}
