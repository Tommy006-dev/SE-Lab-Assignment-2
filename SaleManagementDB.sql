CREATE DATABASE SaleManagementDB
USE SaleManagementDB
-- Bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    Password NVARCHAR(100) NOT NULL,
    Lock BIT DEFAULT 0
);

-- Bảng Item
CREATE TABLE Item (
    ItemID INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100) NOT NULL,
    Size NVARCHAR(20),
    Price DECIMAL(18,2),
    Description NVARCHAR(200)
);

-- Bảng Agent
CREATE TABLE Agent (
    AgentID INT PRIMARY KEY IDENTITY(1,1),
    AgentName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200)
);

-- Bảng Order
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATE NOT NULL,
    AgentID INT FOREIGN KEY REFERENCES Agent(AgentID)
);

-- Bảng OrderDetail
CREATE TABLE OrderDetail (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES [Order](OrderID),
    ItemID INT FOREIGN KEY REFERENCES Item(ItemID),
    Quantity INT,
    UnitAmount DECIMAL(18,2)
);

select * from Users
select * from OrderDetail
select * from [Order]

select * from Items

-- Insert Users
INSERT INTO Users (UserName, Email, Password, Lock) VALUES
('admin', 'admin@gmail.com', '123456', 0),
('user1', 'user1@gmail.com', '123456', 0),
('user2', 'user2@gmail.com', '123456', 0),
('user3', 'user3@gmail.com', '111111', 0),
('user4', 'user4@gmail.com', '222222', 1),
('manager', 'manager@gmail.com', 'manager123', 0),
('staff1', 'staff1@gmail.com', 'staff111', 0),
('staff2', 'staff2@gmail.com', 'staff222', 0),
('staff3', 'staff3@gmail.com', 'staff333', 1),
('guest', 'guest@gmail.com', 'guest123', 0),
('john', 'john@gmail.com', 'john123', 0),
('mary', 'mary@gmail.com', 'mary123', 0),
('peter', 'peter@gmail.com', 'peter123', 0),
('lisa', 'lisa@gmail.com', 'lisa123', 0),
('david', 'david@gmail.com', 'david123', 0);

-- Insert Item
INSERT INTO Item(ItemName, Size, Price, Description) VALUES
(N'Áo thun', 'M', 150000, N'Áo thun cotton'),
(N'Áo thun', 'L', 160000, N'Áo thun cotton'),
(N'Quần jean', '30', 350000, N'Quần jean nam'),
(N'Quần jean', '32', 360000, N'Quần jean nam'),
(N'Áo sơ mi', 'M', 250000, N'Áo sơ mi trắng'),
(N'Áo sơ mi', 'L', 260000, N'Áo sơ mi trắng'),
(N'Váy công sở', 'S', 300000, N'Váy nữ'),
(N'Áo khoác', 'XL', 500000, N'Áo khoác gió'),
(N'Giày thể thao', '40', 700000, N'Giày sneaker'),
(N'Giày thể thao', '41', 720000, N'Giày sneaker'),
(N'Túi xách', 'Free', 450000, N'Túi da'),
(N'Mũ lưỡi trai', 'Free', 120000, N'Mũ thể thao'),
(N'Tất vớ', 'Free', 30000, N'Tất cotton'),
(N'Dây lưng', 'Free', 180000, N'Dây da'),
(N'Kính mát', 'Free', 250000, N'Kính UV400');

-- Insert Agent
INSERT INTO Agent (AgentName, Address) VALUES
(N'Đại lý Miền Nam', N'123 Lê Lợi, TP.HCM'),
(N'Đại lý Miền Bắc', N'456 Hoàn Kiếm, Hà Nội'),
(N'Đại lý Miền Trung', N'789 Nguyễn Huệ, Đà Nẵng'),
(N'Cửa hàng ABC', N'321 Trần Hưng Đạo, TP.HCM'),
(N'Cửa hàng XYZ', N'654 Hai Bà Trưng, TP.HCM'),
(N'Shop thời trang A', N'111 Điện Biên Phủ, TP.HCM'),
(N'Shop thời trang B', N'222 Võ Văn Tần, TP.HCM'),
(N'Siêu thị thời trang', N'333 Cách Mạng Tháng 8, TP.HCM'),
(N'Đại lý Đông Nam Bộ', N'444 Lý Thường Kiệt, TP.HCM'),
(N'Đại lý Tây Nam Bộ', N'555 Nam Kỳ Khởi Nghĩa, Cần Thơ'),
(N'Outlet Store', N'666 Phan Xích Long, TP.HCM'),
(N'Fashion House', N'777 Nguyễn Trãi, TP.HCM'),
(N'Boutique Sài Gòn', N'888 Bùi Viện, TP.HCM'),
(N'Trendy Shop', N'999 Lê Văn Sỹ, TP.HCM'),
(N'Style Zone', N'101 Đồng Khởi, TP.HCM');

-- Insert Order
INSERT INTO [Order] (OrderDate, AgentID) VALUES
('2025-01-05', 1), ('2025-01-10', 2), ('2025-01-15', 3),
('2025-02-01', 4), ('2025-02-10', 5), ('2025-02-20', 1),
('2025-03-01', 6), ('2025-03-10', 7), ('2025-03-15', 2),
('2025-04-01', 8), ('2025-04-05', 9), ('2025-04-10', 3),
('2025-04-15', 10), ('2025-04-20', 11), ('2025-05-01', 12);

-- Insert OrderDetail
INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount) VALUES
(1,1,10,150000),(1,2,5,160000),(1,5,8,250000),
(2,3,20,350000),(2,6,15,260000),
(3,7,12,300000),(3,9,10,700000),
(4,4,25,360000),(4,10,18,720000),
(5,8,7,500000),(5,11,9,450000),
(6,12,30,120000),(6,13,50,30000),
(7,14,20,180000),(7,15,15,250000),
(8,1,25,150000),(8,3,10,350000),
(9,5,20,250000),(9,7,8,300000),
(10,2,15,160000),(10,9,12,700000),
(11,6,10,260000),(11,11,5,450000),
(12,8,6,500000),(12,12,20,120000),
(13,4,30,360000),(13,13,40,30000),
(14,10,22,720000),(14,14,18,180000),
(15,1,35,150000),(15,15,10,250000);