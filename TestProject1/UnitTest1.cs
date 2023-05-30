using DAL;
using DTO;
using NUnit.Framework;
using System.Data;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TinhThanhTien_CorrectCalculation_ReturnsTrue0()
        {
            // Khi nhập đơn giá là 1 số âm thì nó sẽ báo lỗi 
            // Khi nhập đơn giá là 1 số dương thì sẽ không báo lỗi 
            decimal donGia = 10;
            int soLuong = 5;
            decimal expected = 50;

            // Act
            decimal actual = TinhTongTien(donGia, soLuong);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // Thay thế điều này bằng chức năng tính toán thực tế của bạn
        private decimal TinhTongTien(decimal donGia, int soLuong)
        {
            // Thực hiện logic tính toán của bạn ở đây
            if (donGia < 0)
            {
                throw new ArgumentException("Đơn giá không thể là số âm.");
            }

            decimal tongTien = donGia * soLuong;
            return tongTien;
        }
        public class LoginTests
        {
            [Test]
            public void DangNhap_ValidCredentials_ReturnsTrue()
            {

                string username = "admin";
                string password = "password";
                bool expected = true;


                bool actual = YourLoginFunction(username, password);


                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DangNhap_InvalidCredentials_ReturnsFalse()
            {

                string username = "invalid";
                string password = "wrongpassword";
                bool expected = false;


                bool actual = YourLoginFunction(username, password);


                Assert.AreEqual(expected, actual);
            }

            // Thay thế điều này bằng chức năng đăng nhập thực tế của bạn
            private bool YourLoginFunction(string username, string password)
            {
                // Triển khai logic đăng nhập của bạn tại đây
                // Trả về true nếu thông tin xác thực hợp lệ, ngược lại là false

                if (username == "admin" && password == "password")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}