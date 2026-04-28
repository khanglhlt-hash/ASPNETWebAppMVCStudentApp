CREATE TABLE tblUser (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100)
);

INSERT INTO tblUser (Username, Password, Email) 
VALUES ('admin', '123', 'admin@tdtu.edu.vn');
