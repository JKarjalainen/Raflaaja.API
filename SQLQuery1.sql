CREATE TABLE Product
(
  ProductId INT NOT NULL IDENTITY(1,1),
  [Name] VARCHAR(MAX) NOT NULL,
  Price FLOAT NOT NULL,
  Description VARCHAR(MAX) NOT NULL,
  PRIMARY KEY (ProductId)
);

CREATE TABLE [User]
(
  UserId INT NOT NULL IDENTITY(1,1),
  FirstName VARCHAR(MAX) NOT NULL,
  LastName VARCHAR(MAX) NOT NULL,
  AccessLevel INT NOT NULL,
  PRIMARY KEY (UserId)
);

CREATE TABLE Reservation
(
  ReservationId INT NOT NULL IDENTITY(1,1),
  StartTime DATETIME NOT NULL,
  EndTime DATETIME NOT NULL,
  NumberOfPeople INT NOT NULL,
  UserId INT NOT NULL,
  PRIMARY KEY (ReservationId),
  FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

CREATE TABLE [Table]
(
  TableNumber INT NOT NULL IDENTITY(1,1),
  Size INT NOT NULL,
  PRIMARY KEY (TableNumber)
);

CREATE TABLE Reserved
(
  ReservedId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  ReservationId INT NOT NULL,
  TableNumber INT NOT NULL,
  FOREIGN KEY (ReservationId) REFERENCES Reservation(ReservationId),
  FOREIGN KEY (TableNumber) REFERENCES [Table](TableNumber)
);

CREATE TABLE [Order]
(
  OrderId INT NOT NULL IDENTITY(1,1),
  TimeOrdered DATETIME NOT NULL,
  Delivered INT NOT NULL,
  UserId INT NOT NULL,
  PRIMARY KEY (OrderId),
  FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

CREATE TABLE OrderIncludes
(
  Amount INT NOT NULL,
  OrderId INT NOT NULL,
  ProductId INT NOT NULL,
  PRIMARY KEY (OrderId, ProductId),
  FOREIGN KEY (OrderId) REFERENCES [Order](OrderId),
  FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);
