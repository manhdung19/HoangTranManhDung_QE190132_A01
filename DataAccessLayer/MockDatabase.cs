using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public static class MockDatabase
    {
        public static List<RoomType> RoomTypes { get; } = new List<RoomType>
        {
            new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Standard Room" },
            new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Deluxe Room" },
            new RoomType { RoomTypeID = 3, RoomTypeName = "Family", TypeDescription = "Family Room" },
            new RoomType { RoomTypeID = 4, RoomTypeName = "Suite", TypeDescription = "Suite Room" },
            new RoomType { RoomTypeID = 5, RoomTypeName = "Studio", TypeDescription = "Studio Room" }
        };

        public static List<RoomInformation> Rooms { get; } = new List<RoomInformation>
        {
            new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room, 1 bed", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 100, RoomTypeID = 1 },
            new RoomInformation { RoomID = 2, RoomNumber = "102", RoomDescription = "Standard room, 2 beds", RoomMaxCapacity = 3, RoomStatus = 1, RoomPricePerDate = 120, RoomTypeID = 1 },
            new RoomInformation { RoomID = 3, RoomNumber = "201", RoomDescription = "Deluxe room, king bed", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 200, RoomTypeID = 2 },
            new RoomInformation { RoomID = 4, RoomNumber = "202", RoomDescription = "Deluxe room, queen bed", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 220, RoomTypeID = 2 },
            new RoomInformation { RoomID = 5, RoomNumber = "301", RoomDescription = "Family room, 3 beds", RoomMaxCapacity = 5, RoomStatus = 1, RoomPricePerDate = 500, RoomTypeID = 3 },
            new RoomInformation { RoomID = 6, RoomNumber = "302", RoomDescription = "Family room, 4 beds", RoomMaxCapacity = 6, RoomStatus = 1, RoomPricePerDate = 550, RoomTypeID = 3 },
            new RoomInformation { RoomID = 7, RoomNumber = "401", RoomDescription = "Suite room, king bed, living area", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 800, RoomTypeID = 4 },
            new RoomInformation { RoomID = 8, RoomNumber = "402", RoomDescription = "Suite room, queen bed, living area", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 850, RoomTypeID = 4 },
            new RoomInformation { RoomID = 9, RoomNumber = "501", RoomDescription = "Studio room, open layout", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 300, RoomTypeID = 5 },
            new RoomInformation { RoomID = 10, RoomNumber = "502", RoomDescription = "Studio room, city view", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 320, RoomTypeID = 5 }
        };

        public static List<Customer> Customers { get; } = new List<Customer>
        {
            new Customer { CustomerID = 1, CustomerFullName = "Nguyen Van A", Telephone = "0981234567", EmailAddress = "anguyenvan111@example.com", CustomerBirthday = new DateTime(2005, 1, 1), CustomerStatus = 1, Password = "123" },
            new Customer { CustomerID = 2, CustomerFullName = "Tran Thi B", Telephone = "0907654321", EmailAddress = "btranthi222@example.com", CustomerBirthday = new DateTime(2004, 5, 10), CustomerStatus = 1, Password = "456" },
            new Customer { CustomerID = 3, CustomerFullName = "Le Van C", Telephone = "0912345678", EmailAddress = "abc@gmail.com", CustomerBirthday = new DateTime(2003, 3, 15), CustomerStatus = 1, Password = "789" },
            new Customer { CustomerID = 4, CustomerFullName = "Nguyen Xuan Dang Khoa", Telephone = "0923456789", EmailAddress = "khoa@gmail.com", CustomerBirthday = new DateTime(2002, 7, 20), CustomerStatus = 1, Password = "khoa123" }
        };

        public static List<BookingReservation> BookingReservations { get; } = new List<BookingReservation>
        {
            new BookingReservation { BookingReservationID = 1001, BookingDate = new DateTime(2025, 10, 1), TotalPrice = 240, CustomerID = 1, BookingStatus = 1 },
            new BookingReservation { BookingReservationID = 1002, BookingDate = new DateTime(2025, 10, 5), TotalPrice = 400, CustomerID = 2, BookingStatus = 1 },
            new BookingReservation { BookingReservationID = 1003, BookingDate = new DateTime(2025, 10, 10), TotalPrice = 500, CustomerID = 4, BookingStatus = 1 },
            new BookingReservation { BookingReservationID = 1004, BookingDate = new DateTime(2025, 10, 12), TotalPrice = 800, CustomerID = 3, BookingStatus = 1 }
        };

        public static List<BookingDetail> BookingDetails { get; } = new List<BookingDetail>
        {
            new BookingDetail { BookingReservationID = 1001, RoomID = 2, StartDate = new DateTime(2025, 10, 15), EndDate = new DateTime(2025, 10, 17), ActualPrice = 120 },
            new BookingDetail { BookingReservationID = 1002, RoomID = 3, StartDate = new DateTime(2025, 10, 20), EndDate = new DateTime(2025, 10, 22), ActualPrice = 200 },
            new BookingDetail { BookingReservationID = 1003, RoomID = 5, StartDate = new DateTime(2025, 11, 1), EndDate = new DateTime(2025, 11, 2), ActualPrice = 500 },
            new BookingDetail { BookingReservationID = 1004, RoomID = 7, StartDate = new DateTime(2025, 11, 5), EndDate = new DateTime(2025, 11, 8), ActualPrice = 800 }
        };
    }
}
